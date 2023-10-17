// See https://aka.ms/new-console-template for more information

using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;
using static Carte;
using static PaquetCartes;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class Program {

    // determiner le nombre de joueurs de la partie
    public static int CombienDeJoueurs()
    {
        Console.WriteLine("Entrer le nombre de joueurs pour cette partie: 2 à 4 joueurs :");
        int nombreJoueurs;

        while (true)
        {
            string entree = Console.ReadLine();

            if (int.TryParse(entree, out nombreJoueurs) && nombreJoueurs >= 2 && nombreJoueurs <= 4)
            {
                return nombreJoueurs;
            }
            else
            {
                Console.WriteLine("Veuillez entrer un nombre entre 2 et 4");

            }
        }
    }

    // connaitre l'etat du jeu
    public static void EtatDuJeu(Joueurs joueur1, PileDeDepot pileDeDepot)
    {
        Console.WriteLine("Le joueur " + joueur1.Nom + joueur1.Prenom + "a joué la carte " + pileDeDepot.Cartes);
        Console.WriteLine($"La carte au dessus de la pile de dépot est : {pileDeDepot.Cartes}");
        Console.WriteLine();
    }

    // verifier que la partie est terminé lorsque un des joueurs n'a plus de carte en main
    public static bool FinDePartie(List<Joueurs> joueurs)
    {
        foreach (var joueur in joueurs)
        {
            if (joueur.MainJoueur.CarteEnMainDuJoueur.Count == 0)
            {
                return true;
            }
        }
        return false;
    }

    // fonction FinDePartie en utilisant les lambdas
    public static bool FinDePartie2(List<Joueurs> joueurs)
    {
        return joueurs.Exists(joueur => joueur.MainJoueur.CarteEnMainDuJoueur.Count == 0);
    }

    // determiner le prochain joueur
    public static Joueurs ProchainJoueur(List<Joueurs> joueurs, Joueurs joueur1)
    {
        // trouver l'index du joueur 1
        int indexJoueur1 = joueurs.IndexOf(joueur1);
        // calculer l,index du prochain joueur (joueur 2) en ajoutant 1 à l'index du joueur 1
        //
        int indexProchainJoueur = (indexJoueur1 + 1) % joueurs.Count;
        return joueurs[indexProchainJoueur];
    }

    // renvoie le premier joueur de la liste qui n'a plus de cartes
    public static Joueurs JoueurGagnant(List<Joueurs> joueurs)
    {
        return joueurs.Find(joueur => joueur.MainJoueur.CarteEnMainDuJoueur.Count == 0);

    }


    static void Main(string[] args)
    {
        // creer une liste de joueurs
        int nombreJoueurs = CombienDeJoueurs();

        List<Joueurs> Listjoueurs = new List<Joueurs>();

        for (int i = 0; i < nombreJoueurs; i++)
        {
            Console.WriteLine($"Joueur: {i + 1}");
            Console.WriteLine("Entrez votre prénom : ");
            string nom = Console.ReadLine();

            Console.WriteLine("Entrez votre nom : ");
            string prenom = Console.ReadLine();

            Console.WriteLine();

            Joueurs joueur = new Joueurs(nom, prenom, i+1);
            // ajouter chaque nouveau joueur créer à la liste
            Listjoueurs.Add(joueur);
        }

        // appel du paquet de cartes
        List<Carte> paquetDeCartes = new List<Carte>();
        paquetDeCartes = PaquetCartes.PaquetDeCinquanteDeuxCartes();

        // melanger le paquet de carte

        // Appeler la fonction pour mélanger le paquet de cartes
        MelangerJeuDeCartes(paquetDeCartes);

        // distribuer 8 cartes à chaque joueur
        foreach (var joueur in Listjoueurs)
        {
            joueur.MainJoueur.DistribuerCartes(paquetDeCartes);
        }

        // afficher la main de chaque joueur
        foreach (Joueurs joueur in Listjoueurs)
        {
            Console.WriteLine($"{joueur.Nom} {joueur.Prenom} (Joueurs {joueur.Id}):");
            foreach (var carte in joueur.MainJoueur.CarteEnMainDuJoueur)
            {
                Console.WriteLine(carte);
            }
            Console.WriteLine();
        }

        // veriifier le nombre de cartes restant dans le paquet
        Console.WriteLine("Le nombre de carte restant dans le paquet : " + paquetDeCartes.Count);

        // creer une pile de pioche
        PileDePioche pileDePioche = new PileDePioche(paquetDeCartes);

        Console.WriteLine();
        /*
        Console.WriteLine("La pile de pioche ");  
        foreach (var carte in pileDePioche)
        {
            Console.WriteLine(carte);
        }
        */
        Console.WriteLine("Le nombre de carte dans la pile de pioche : " + pileDePioche.Count);


        // creer une pile de depot avec une premiere carte dessus
        //PileDeDepot pileDepot = new PileDeDepot(paquetDeCartes);
        //List<Carte> pileDeDepot = new List<Carte>();
        //pileDeDepot.Add(pileDePioche.Piocher());
        //PileDeDepot pileDeDepot = new PileDeDepot(new List<Carte>());
        PileDeDepot pileDeDepot = new PileDeDepot(new List<Carte> { pileDePioche.Piocher() });



        Console.WriteLine();
        Console.WriteLine("La pile de depot ");
        foreach (var carte in pileDeDepot.Cartes)
        {
            Console.WriteLine(carte);
        }

        // compter le nombre de carte dans la pile de pioche apres avoir
        // enlevé une carte pour la pile de depot
        Console.WriteLine();
        Console.WriteLine("Le nombre de carte dans la pile de pioche : " + pileDePioche.Count);

        Console.WriteLine();

        // choisir de facon aleatoire le 1er joueur
        Random random = new Random();

        int indexPremierJoueur = random.Next(0, Listjoueurs.Count);
        Joueurs joueur1 = Listjoueurs[indexPremierJoueur];

        // implementer une partie
        while (!FinDePartie(Listjoueurs))
        {
            Console.WriteLine($"{joueur1.Nom} {joueur1.Prenom} (Joueur {joueur1.Id})");

            // Afficher la dernière carte sur la pile de dépôt
            Console.WriteLine("Dernière carte sur la pile de dépôt:");
            if (pileDeDepot.Cartes.Count > 0)
                Console.WriteLine($"-{pileDeDepot.Cartes[pileDeDepot.Cartes.Count - 1]}");
            else
                Console.WriteLine("Aucune carte sur la pile de dépôt.");

            // Le joueur joue une carte
            Carte carteAJouer = joueur1.MainJoueur.CarteEnMainDuJoueur[0];

            //Carte carteJouee = joueur1.MainJoueur.JouerCarte(carteAJouer, pileDeDepot, pileDePioche);
            Carte carteJouee = joueur1.MainJoueur.JouerCarte(pileDeDepot, pileDePioche);
            //AjusterSommet();

            //////////////////////////
            Console.WriteLine("Le nombre de carte dans la pile de pioche : " + pileDePioche.Count);


            // Afficher la carte jouée
            Console.WriteLine($"{joueur1.Prenom} {joueur1.Nom} joue : {carteJouee}");

            // Ajouter la carte à la pile de dépôt
            pileDeDepot.AjouterUneCarte(carteJouee);

            foreach (Joueurs joueur in Listjoueurs)
            {
                foreach (var carte in joueur.MainJoueur.CarteEnMainDuJoueur)
                {
                    Console.WriteLine(carte);
                }
                Console.WriteLine();
            }

            // Passer au prochain joueur
            joueur1 = ProchainJoueur(Listjoueurs, joueur1);

            // Attendre une entrée pour le prochain tour
            //Console.WriteLine("Appuyez sur une touche pour continuer...");
            //Console.ReadKey();
            //Thread.Sleep(1000);
            Console.WriteLine();

        }

        // La partie est terminée, trouver le joueur gagnant
        Joueurs joueurGagnant = JoueurGagnant(Listjoueurs);
        Console.WriteLine($"{joueurGagnant.Prenom} {joueurGagnant.Nom} a gagné la partie!");


    }

    private static void MelangerJeuDeCartes(List<Carte> paquetDeCartes)
    {

        for (int i = 0; i < 52; i++)
        {
            Random random = new Random();
            Carte temp;
            int rand1 = random.Next(paquetDeCartes.Count), rand2 = random.Next(paquetDeCartes.Count);
            temp = paquetDeCartes[rand1];
            paquetDeCartes[rand1] = paquetDeCartes[rand2];
            paquetDeCartes[rand2] = temp;

        }
    }

    /*

    static int AjusterSommet(Carte[] cartes, int sommet)
    {
        //Determination du sommet de la pile de cartes passee en parametre
        for (int i = 0; i < cartes.Length; i++)
        {
            if (cartes[i] != null) sommet = i;
            else break;
        }
        return sommet;
    }

    */
}
