using System;

public class Joueur
{
    public List<Carte> cartes;
    private string fn;
    private string ln;
    private int ID;

    public Joueur(int idJoueur)
    {
        // Demander au joueur d'entrer son prénom (Fn) et son nom de famille (Ln)
        Console.Write("Entrez votre prénom : ");
        this.fn = Console.ReadLine() ?? "";
        Console.Write("Entrez votre nom de famille : ");
        this.ln = Console.ReadLine() ?? "";
        // Affecter un ID au joueur
        this.ID = idJoueur;
        this.cartes = new List<Carte>(8);
    }
    public string getFn() // getteur de prénom du joueur
    {
        return fn;
    }

    public string getLn() //getteur de nom de famille du joueur
    {
        return ln;
    }

    public int getID() // getteur de l'ID du joueur
    {
        return ID;
    }
    public override string ToString() // afficher le nom complet du joueur
    {
        return this.fn + " " + this.ln;
    }

    public Carte initierLeJeu() // méthode pour initier le jeu en choisissant une carte au hasard parmi les cartes du joueur.
    {
        Random random = new Random();
        Carte carte = this.cartes[random.Next(0, 8)];
        this.cartes = this.cartes.Where(c => c != carte).ToList();
        Console.WriteLine("Le Joueur "+ this.ToString() + " a initié le jeu avec cette carte " + carte.ToString());
        return carte;
    }

    public Carte jouer(Carte carte)  // Méthode permettant au joueur de jouer une carte basée sur une carte donnée.
    {   
        int size = this.cartes.Count;
        int i = 0;
        while (i<size && this.cartes[i].getCarteType() != carte.getCarteType() && this.cartes[i].getValeur() != carte.getValeur())
        {
            i++;
        }
        if (i<size)
        {
            Carte cartejoue = this.cartes[i];
            Console.WriteLine("Le Joueur "+ this.ToString() + " a joué cette carte " + cartejoue.ToString());
            this.cartes = this.cartes.Where(c => c != cartejoue).ToList();
            return cartejoue;
        }
        return null;
    }

    public void recevoirCarte(Carte carte) // Méthode permettant au joueur de recevoir une carte.
    {
        Console.WriteLine("Le Joueur " + this.ToString() + " a reçu cette carte "+ carte.ToString());
        this.cartes.Add(carte);
    }

}
