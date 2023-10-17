using System;
using static Carte;

public class MainJoueur
{
    private List<Carte> carteEnMainDuJoueur;

    public MainJoueur()
	{
        // les cartes que le joueur a en main est une liste de carte
        carteEnMainDuJoueur = new List<Carte>();

    }

    public List<Carte> CarteEnMainDuJoueur
    {
        get { return carteEnMainDuJoueur; }
        set { carteEnMainDuJoueur = value; }
    }

    // distribuer des cartes à un joueur pour former une main
    public void DistribuerCartes(List<Carte> paquetDe52Cartes)
    {
        Random random = new Random();

        while (carteEnMainDuJoueur.Count < 8 && paquetDe52Cartes.Count > 0)
        {
            int i = random.Next(paquetDe52Cartes.Count);
            Carte carte = paquetDe52Cartes[i];
            paquetDe52Cartes.RemoveAt(i);
            // carteEnMainDuJoueur.Add(carte); // pensez a utiliser AjouterCarte
            AjouterUneCarte(carte);
        }
    }

    /*
    static void partageCarte(Carte[] cartes, Joueur[] joueurs, int sommet, int nombre_joueurs)
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < nombre_joueurs; j++)
            {
                joueurs[j].setMain(cartes[sommet]);
                cartes[sommet] = null;
                sommet--;
            }
        }
    }
    */

    ///////




    // distribuer des cartes à un joueur pour former une main
    public void DistribuerCartes2(List<Carte> paquetDe52Cartes)
    {
        Console.WriteLine("Combien de cartes souhaitez-vous recevoir? (Maximum 8)");
        int nombreCartesARecevoir;

        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out nombreCartesARecevoir) && nombreCartesARecevoir >= 0 && nombreCartesARecevoir <= 8)
            {
                break;
            }
            else
            {
                Console.WriteLine("Veuillez entrer un nombre valide entre 0 et 8.");
            }
        }

        Random random = new Random();

        while (carteEnMainDuJoueur.Count < 8 && paquetDe52Cartes.Count > 0)
        {
            int i = random.Next(paquetDe52Cartes.Count);
            Carte carte = paquetDe52Cartes[i];
            paquetDe52Cartes.RemoveAt(i);
            AjouterUneCarte(carte);
        }
    }

    // jouer une carte
    public Carte JouerCarte2(Carte carteAJouer, PileDeDepot pileDeDepot)
    {
        if (carteAJouer.ValeurCarte == Valeur.huit || carteAJouer.ValeurCarte == pileDeDepot.Cartes[pileDeDepot.Cartes.Count - 1].ValeurCarte ||
            carteAJouer.CouleurCarte == pileDeDepot.Cartes[pileDeDepot.Cartes.Count - 1].CouleurCarte)
        {
            Carte carteJouee = CarteEnMainDuJoueur.FirstOrDefault(carte => carte.Equals(carteAJouer));

            if (carteJouee != null)
            {
                CarteEnMainDuJoueur.Remove(carteJouee);
                return carteJouee;
            }
            else
            {
                Console.WriteLine("Cette carte n'est pas présente dans la main du joueur.");
                return null;
            }
        }
        else
        {
            Console.WriteLine("Cette carte ne peut pas être jouée.");
            return null;
        }
    }

    public Carte JouerCarte1(Carte carteAJouer, PileDeDepot pileDeDepot, PileDePioche pileDePioche)
    {
        bool doitPiocher = true;
        Carte carteAuSommet = pileDeDepot.Cartes[pileDeDepot.Cartes.Count - 1];

        foreach (Carte carte in CarteEnMainDuJoueur)
        {
            if (carte.ValeurCarte == carteAuSommet.ValeurCarte || carte.CouleurCarte == carteAuSommet.CouleurCarte)
            {
                carteEnMainDuJoueur.Remove(carte);
                pileDeDepot.AjouterUneCarte(carte);
                carteAuSommet = carte;
                doitPiocher = false;
                break;
            }
        }
        if (doitPiocher)
        {
            pileDePioche.Piocher();
        }

        return carteAuSommet;
    }

    public Carte JouerCarte( PileDeDepot pileDeDepot, PileDePioche pileDePioche)
    {
        bool doitPiocher = true;
        Carte carteAuSommet = pileDeDepot.Cartes[pileDeDepot.Cartes.Count - 1];

        foreach (Carte carte in CarteEnMainDuJoueur)
        {
            if (carte.ValeurCarte == carteAuSommet.ValeurCarte || carte.CouleurCarte == carteAuSommet.CouleurCarte)
            {
                carteEnMainDuJoueur.Remove(carte);
                pileDeDepot.AjouterUneCarte(carte);
                carteAuSommet = carte;
                doitPiocher = false;
                break;
            }
        }
        if (doitPiocher)
        {
            pileDePioche.Piocher();
        }

        return carteAuSommet;
    }








    // ajouter une carte à la main du joueur lorqu'il a moins de 8 cartes
    public void AjouterUneCarte(Carte carte)
    {
        if (carteEnMainDuJoueur.Count < 8)
        {
            carteEnMainDuJoueur.Add(carte);
        }
        else
        {
            Console.WriteLine("Vous avez déjà 8 cartes, impossible d'en rajouter");
        }
    }

    // retirer une carte de la main du joueur lorsqu'il joue
    public void RetirerUneCarte(Carte carte)
    {
        carteEnMainDuJoueur.Remove(carte);
    }

    /*
    internal Carte JouerCarte(int v)
    {
        throw new NotImplementedException();
    }
    */
}
