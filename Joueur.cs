using System;

public class Joueur
{
    public static int NombreDeJoueur = 0;
    public string Fn;
    public string Ln;
    public int ID;

    public Joueur()
    {
        // Demander au joueur d'entrer son prénom (Fn) et son nom de famille (Ln)
        Console.Write("Entrez votre prénom : ");
        this.Fn = Console.ReadLine();
        Console.Write("Entrez votre nom de famille : ");
        this.Ln = Console.ReadLine();

        // Incrémenter le nombre total de joueurs
        NombreDeJoueur++;

        // Affecter un ID au joueur
        this.ID = NombreDeJoueur;
    }

    public static int GetNombreDeJoueur()
    {
        return NombreDeJoueur;
    }

    public string GetFn()
    {
        return Fn;
    }

    public string GetLn()
    {
        return Ln;
    }

    public int GetID()
    {
        return ID;
    }
    public static Joueur[] CreerJoueurs(int nombreDeJoueurs)
{
    Joueur[] joueurs = new Joueur[nombreDeJoueurs];
    for (int i = 0; i < nombreDeJoueurs; i++)
    {
        joueurs[i] = new Joueur();
    }
    return joueurs;
}
}