using System;

namespace JeuCarte // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
        Console.Write("Combien de joueurs veulent jouer ? ");
        if (int.TryParse(Console.ReadLine(), out int nombreDeJoueurs) && nombreDeJoueurs >= 2 && nombreDeJoueurs <= 4)
        {
            Joueur[] joueurs = Joueur.CreerJoueurs(nombreDeJoueurs);

            Console.WriteLine("Informations des joueurs :");
            for (int i = 0; i < joueurs.Length; i++)
            {
                Console.WriteLine($"Joueur {i + 1}:");
                Console.WriteLine("Prénom : " + joueurs[i].GetFn());
                Console.WriteLine("Nom de famille : " + joueurs[i].GetLn());
                Console.WriteLine("ID du joueur : " + joueurs[i].GetID());
                Console.WriteLine();
            }

            Console.WriteLine("Nombre total de joueurs : " + Joueur.GetNombreDeJoueur());
        }
        else
        {
            Console.WriteLine("Le nombre de joueurs Maximal c'est 4 et 2 le minimum.");
        }

        Console.ReadLine();
        }
    }
}

