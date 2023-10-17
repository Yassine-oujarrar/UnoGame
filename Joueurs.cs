using System;

public class Joueurs
{
	private string nom;
    private string prenom;
    private int id;
    private MainJoueur mainjoueur; //  carte que le joueur a en main

    private int nombreDeJoueurs = 0;


    public Joueurs(string _nom, string _prenom, int _id)
	{
        this.nom = _nom;
        this.prenom = _prenom;
        this.id = _id;

        nombreDeJoueurs++;

       
        // un joueur possede une liste de carte au debut de la partie
        this.mainjoueur = new MainJoueur();
    }



    // la methode fonctionne
    // dans le main, tu n'appeles pas ToString mais Console.WriteLine
    public override string ToString()
    {
        return nom + " " + prenom + " " + id;
    }
    
    /* autre facon de faire
    public override string ToString()
    {
        return $"{prenom} {nom} (ID: {id})";
    }
    */

    public string Nom
    {
        get { return nom; }
        private set { nom = value; }
    }

    public string Prenom
    {
        get { return prenom; }
        private set { prenom = value; }
    }

    public int Id
    {
        get { return id; }
        private set { id = value; }
    }

    public MainJoueur MainJoueur 
    { 
        get { return mainjoueur; } 
        private set { mainjoueur = value; } 
    }
    


}
