namespace Devoir1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Declaration des variables
            Carte[] pile_pioche = new Carte[52];
            Carte[] pile_depot = new Carte[52];
            int sommet_pioche = 0;
            int sommet_depot = 0;
            int nombre_joueurs = 0;
            Joueur[] joueurs;
            Random random = new Random();

            Console.WriteLine("***BIENVENUE DANS LE JEU DE LA PIOCHE!***");

            //---------------------------------------------------------------------------
            creationPaquet(pile_pioche);
            melangeCarte(pile_pioche);
            sommet_pioche = ajusterSommet(pile_pioche, sommet_pioche);
            //---------------------------------------------------------------------------

            //---------------------------------------------------------------------------
            Console.Write("Tout d'abord, entrez le nombre de joueurs (entre 2 et 4 joueurs): ");

            do //Recuperation du nombre de joueurs et gestion d'exceptions
            {
                try
                {
                    nombre_joueurs = Convert.ToInt16(Console.ReadLine());
                }
                catch (FormatException) { Console.WriteLine("Vous devez entrer un chiffre!"); }
                catch (OverflowException) { Console.WriteLine("Entrer un chiffre entre 2 et 4!"); }

                if (nombre_joueurs < 2 || nombre_joueurs > 4) Console.Write("Choisissez entre 2 et 4 joueurs: ");
            } while (nombre_joueurs < 2 || nombre_joueurs > 4);

            joueurs = new Joueur[nombre_joueurs]; //Initialisation du tableau avec la taille correcte
            creationJoueurs(joueurs, nombre_joueurs);
            partageCarte(pile_pioche, joueurs, sommet_pioche, nombre_joueurs);
            sommet_pioche = ajusterSommet(pile_pioche, sommet_pioche);
 
            //---------------------------------------------------------------------------
            
            /*
            //Verification (affichage de la main des joueurs crees)
            afficherMainDesJoueurs(joueurs, nombre_joueurs);
            Console.WriteLine("Indice au sommet de la pioche: " + sommet_pioche);
            Console.WriteLine("Carte au sommet de la pioche: " + pile_pioche[sommet_pioche]);
            Console.WriteLine();
            */

            //Debut du jeu---------------------------------
            
            //Placement de la premiere carte sur la pile de depot
            pile_depot[sommet_depot] = pile_pioche[sommet_pioche];
            pile_pioche[sommet_pioche] = null;
            sommet_depot = ajusterSommet(pile_depot, sommet_depot);
            sommet_pioche = ajusterSommet(pile_pioche, sommet_pioche);

            Console.WriteLine("********************************************");
            //Choix du premier joueur et jeu
            int tour = random.Next(joueurs.Length);
            Carte cartePrecedente = pile_depot[sommet_depot];
            Carte carteJouee;
            Console.WriteLine($"Premiere carte: {pile_depot[sommet_depot]}");

            while (true)
            {
                /* Juste pour affichage et verifier que le jeu est bien correct
                Console.WriteLine($"Sommet pioche: {pile_pioche[sommet_pioche]}");
                Console.WriteLine($"Sommet depot: {pile_depot[sommet_depot]}");
                */
                //joueurs[tour].AfficherMainDuJoueur(); 

                
                carteJouee = joueurs[tour].jouer(pile_depot, sommet_depot, pile_pioche, sommet_pioche);
                Console.WriteLine($"Sommet depot: {carteJouee}.");

                if (carteJouee.Equals(cartePrecedente)) Console.WriteLine($"J{tour+1} a pioché\n");
                else Console.WriteLine($"J{tour + 1} a joué {carteJouee}\n");
                cartePrecedente = carteJouee;

                if (joueurs[tour].getNombreCartes() == 0) //Si un joueur n'a plus de cartes, il gagne!
                {
                    Console.WriteLine($"J{tour+1} a gagné!\n");
                    break;
                }

                tour++;
                if (tour == joueurs.Length) tour = 0;

                if (sommet_pioche == 0)
                {
                    Console.WriteLine("La pile de pioche est vide!");
                    transfertDepotAPioche(pile_depot, pile_pioche);
                }
                Console.WriteLine("---------");
                sommet_depot = ajusterSommet(pile_depot, sommet_depot);
                sommet_pioche = ajusterSommet(pile_pioche, sommet_pioche);
                //Thread.Sleep(1000);
            }

            Console.WriteLine("***FIN DE LA PARTIE***");

        } //Fin du main

        

        //-------------------------------------------------------------------------------
        static void creationJoueurs(Joueur[] joueurs, int nombre)
        {
            for (int i = 1; i <= nombre; i++)
            {
                string nom, prenom;
                Console.Write($"Prenom du joueur {i}: ");
                prenom = Console.ReadLine();
                Console.Write($"Nom du joueur {i}: ");
                nom = Console.ReadLine();
                Joueur j = new Joueur(nom, prenom);
                joueurs[i - 1] = j;
                Console.Clear();
            }
        }

        //-------------------------------------------------------------------------------

        static void creationPaquet(Carte[] cartes)
        {
            //Creation du paquet de 52 cartes et insertion dans le paquet de 52 cartes
            int index = 0;
            for (int i = 1; i <= 4; i++)
            {
                for (int j = 1; j <= 13; j++)
                {
                    cartes[index] = new Carte(Carte.getEnumValeur(j), Carte.getEnumCouleur(i));
                    index++;
                }
            }
        }

        //-------------------------------------------------------------------------------

        static void melangeCarte(Carte[] cartes)
        {
            for (int i = 0; i < 52; i++)
            {
                Random random = new Random();
                Carte temp;
                int rand1 = random.Next(cartes.Length), rand2 = random.Next(cartes.Length);
                temp = cartes[rand1];
                cartes[rand1] = cartes[rand2];
                cartes[rand2] = temp;

            }
        }

        //-------------------------------------------------------------------------------

        static void partageCarte(Carte[] cartes, Joueur[] joueurs, int sommet, int nombre_joueurs)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < nombre_joueurs; j++)
                {
                    joueurs[j].ajouterALaMain(cartes[sommet]);
                    cartes[sommet] = null;
                    sommet--;
                }
            }
        }

        //-------------------------------------------------------------------------------

        static void transfertDepotAPioche(Carte[] depot, Carte[] pioche)
        {
            for(int i = 0; i < depot.Length - 1; i++)
            {
                pioche[i] = depot[i];
                depot[i] = null;
            }
            depot[0] = depot[depot.Length - 1];
            depot[depot.Length - 1] = null;
            melangeCarte(pioche);
        }

        //-------------------------------------------------------------------------------

        static int ajusterSommet(Carte[] cartes, int sommet)
        {
            //Determination du sommet de la pile de cartes passee en parametre
            for (int i = 0; i < cartes.Length; i++)
            {
                if (cartes[i] != null) sommet = i;
                else break;
            }
            return sommet;
        }

        //-------------------------------------------------------------------------------
        /*
        static void afficherMainDeTousLesJoueurs(Joueur[] joueurs, int nombre_joueurs) //Juste au cas ou
        {
            for (int i = 0; i < nombre_joueurs; i++)
            {
                Console.WriteLine($"Main de j{i + 1}");
                joueurs[i].AfficherMainDuJoueur();
                Console.WriteLine();
            }
        }
        */
        //-------------------------------------------------------------------------------

    }
}