using System;

public class Joueur : Sujet, PatronObservateur
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
    public string getFn()
    {
        return fn;
    }

    public string getLn()
    {
        return ln;
    }

    public int getID()
    {
        return ID;
    }
    public override string ToString()
    {
        return this.fn + " " + this.ln;
    }

    public Carte initierLeJeu()
    {
        Random random = new Random();
        Carte carte = this.cartes[random.Next(0, 8)];
        this.cartes = this.cartes.Where(c => c != carte).ToList();
        Console.WriteLine("Le Joueur "+ this.ToString() + " a initié le jeu avec cette carte " + carte.ToString());
        Console.WriteLine();
        return carte;
    }

    public Carte jouer(Carte carte)
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
            Console.WriteLine();
            this.cartes = this.cartes.Where(c => c != cartejoue).ToList();
            return cartejoue;
        }
        return null;
    }

    public void recevoirCarte(Carte carte)
    {
        Console.WriteLine("Le Joueur " + this.ToString() + " a reçu cette carte "+ carte.ToString());
        Console.WriteLine();
        this.cartes.Add(carte);
    }
        public void Notificateur(Joueur joueurActuel)
        {
            if (this == joueurActuel)
            {
             Console.WriteLine("C'est le tour de " + this.ToString() + " de jouer!");
             Console.WriteLine();
        }
        }
}
