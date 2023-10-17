public class Partie : Sujet
{
    private Joueur[] joueurs;
    private List<Carte> paquetCartes;
    private Stack<Carte> pileDePioche;
    private Stack<Carte> pileDeDepot;

    private int idJoueurEnCours;

    public Partie(int nombreDeJoueurs)
    {
        Joueur[] localJoueurs = new Joueur[nombreDeJoueurs];
        for (int i = 0; i < nombreDeJoueurs; i++)
        {
            localJoueurs[i] = new Joueur(i + 1);
        }
        this.joueurs = localJoueurs;

        this.paquetCartes = Carte.CreerPaquetDeCartes();
        this.pileDeDepot = new Stack<Carte>();
        this.melanger(this.paquetCartes);
        this.pileDePioche = new Stack<Carte>(this.paquetCartes);
        this.distribuer();
        //Choisir un joueur qui commence le premier tour
        Random random = new Random();
        this.idJoueurEnCours = random.Next(1, nombreDeJoueurs + 1);
        foreach (Joueur joueur in this.joueurs)
            {
                AjouterObservateur(joueur);
            }
    }
    public int nombreDeJoueurs()
    {
        return this.joueurs.Length;
    }

    public Joueur[] getJoueurs()
    {

        return this.joueurs;
    }


    private void melanger(List<Carte> paquetCartes)
    {
        Random random = new Random();

        // Parcourez le paquet de cartes en sens inverse
        for (int i = paquetCartes.Count - 1; i > 0; i--)
        {
            // Générez un indice aléatoire entre 0 et i inclus
            int j = random.Next(i + 1);

            // Échangez les cartes à l'indice i et j
            Carte temp = paquetCartes[i];
            paquetCartes[i] = paquetCartes[j];
            paquetCartes[j] = temp;
        }
    }
    public void distribuer()
    {
        foreach (Joueur j in this.joueurs)
        {
            for (int i = 0; i < 8; i++)
            {
                j.cartes.Insert(i,this.pileDePioche.Pop());
            }
        }
    }

    public Stack<Carte> getPileDePioche()
    {
        return this.pileDePioche;
    }
    public Stack<Carte> getPileDeDepot()
    {
        return this.pileDeDepot;
    }
    private void tourSuivant()
    {
        // Incrementer l'ID du joueur actuel
        idJoueurEnCours++;

        // Si l'ID dépasse le nombre de joueurs, revenir à 1 (retour au premier joueur)
        if (idJoueurEnCours > joueurs.Length)
        {
            idJoueurEnCours = 1;
        }
    }

    private Joueur getJoueurParID(int id)
    {
        foreach (Joueur joueur in this.joueurs)
        {
            if (joueur.getID() == id)
            {
                return joueur;
            }
        }
        return null;
    }
    public int getIDJoueurEnCours()
    {
        return this.idJoueurEnCours;
    }
    public void jouer()
    {
        Joueur j = this.getJoueurParID(this.idJoueurEnCours);
        NotifierObservateurs(j); 
        if (this.pileDeDepot.Count == 0)
        {
            this.pileDeDepot.Push(j.initierLeJeu());
        }
        else
        {
            Carte c = j.jouer(this.pileDeDepot.Peek());
            if (c == null) 
            {
                if (this.pileDeDepot.Count == 0){
                    Carte ctop = this.pileDeDepot.Pop();
                    List<Carte> cartes = this.pileDeDepot.ToList();
                    this.melanger(cartes);
                    this.pileDePioche = new Stack<Carte>(cartes);
                    this.pileDeDepot = new Stack<Carte>();
                    this.pileDeDepot.Push(ctop);
                }
                j.recevoirCarte(this.pileDePioche.Pop());
            }
            else
            {           
                this.pileDeDepot.Push(c);
            }
        }
        if (j.cartes.Count == 0)
        {
            Console.WriteLine("Le joueur " + j.getFn() + " a gagné!");
        }
        else
        {
            Thread.Sleep(2000); // On attend 2 secondes avant de passer au tour suivant.
            Console.WriteLine("Le tour passera au joueur suivant");
            this.tourSuivant();
            this.jouer();
        }
    }
}


