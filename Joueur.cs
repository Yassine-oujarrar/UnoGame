using System;

public class Joueur
{
    public Cartes[] cartes;
    private string Fn;
    private string Ln;
    private int ID;

    public Joueur(int idJoueur)
    {
        // Demander au joueur d'entrer son prénom (Fn) et son nom de famille (Ln)
        Console.Write("Entrez votre prénom : ");
        this.Fn = Console.ReadLine() ?? "";
        Console.Write("Entrez votre nom de famille : ");
        this.Ln = Console.ReadLine() ?? "";
        // Affecter un ID au joueur
        this.ID = idJoueur;
        this.cartes = new Cartes[8];
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
}