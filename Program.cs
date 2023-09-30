using System;

namespace JeuCarte // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {


                    // Créez un paquet de cartes en utilisant la méthode CreerPaquetDeCartes
        List<Cartes> paquetDeCartes = Cartes.CreerPaquetDeCartes();

        // Affichez les cartes du paquet
        foreach (var carte in paquetDeCartes)
        {
            Console.WriteLine(carte);
        }

        // Vérifiez le nombre de cartes dans le paquet (doit être 52)
        int nombreDeCartes = paquetDeCartes.Count;
        Console.WriteLine("Nombre de cartes dans le paquet : " + nombreDeCartes);
        /*Console.Write("Combien de joueurs veulent jouer ? ");
        if (int.TryParse(Console.ReadLine(), out int nombreDeJoueurs) && nombreDeJoueurs >= 2 && nombreDeJoueurs <= 4)
        {
            Partie maPartie = new Partie(nombreDeJoueurs);
            Joueur[] joueurs = maPartie.getJoueurs(); 
            Console.WriteLine("Informations des joueurs :");
            for (int i = 0; i < joueurs.Length; i++)
            {
                Console.WriteLine($"Joueur {i + 1}:");
                Console.WriteLine("Prénom : " + joueurs[i].GetFn());
                Console.WriteLine("Nom de famille : " + joueurs[i].GetLn());
                Console.WriteLine("ID du joueur : " + joueurs[i].GetID());
                Console.WriteLine();
            }

            Console.WriteLine("Nombre total de joueurs : " + maPartie.nombreDeJoueurs());
        }
        else
        {
            Console.WriteLine("Le nombre de joueurs Maximal c'est 4 et 2 le minimum.");
        }

        Console.ReadLine();
        }*/
    }
}
}
