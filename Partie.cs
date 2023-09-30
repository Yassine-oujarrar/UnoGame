public class Partie
{
    private Joueur[] joueurs;
    private List<Cartes> paquetCartes;

    private Stack<Cartes> pileDePioche;

    public Partie(int nombreDeJoueurs)
    {
        Joueur[] localJoueurs = new Joueur[nombreDeJoueurs];
        for (int i = 0; i < nombreDeJoueurs; i++)
        {
            localJoueurs[i] = new Joueur(i+1);
        }
        this.joueurs = localJoueurs;
        
        this.paquetCartes = Cartes.CreerPaquetDeCartes();
        this.Melanger();
        this.pileDePioche = new Stack<Cartes>(this.paquetCartes);
        this.Distribuer();
    }
    public int nombreDeJoueurs()
    {
        return this.joueurs.Length;
    }
    
    public Joueur[] getJoueurs(){

        return this.joueurs;
    }


    private void Melanger()
    {
        Random random = new Random();

        // Parcourez le paquet de cartes en sens inverse
        for (int i = this.paquetCartes.Count - 1; i > 0; i--)
        {
            // Générez un indice aléatoire entre 0 et i inclus
            int j = random.Next(i + 1);

            // Échangez les cartes à l'indice i et j
            Cartes temp = this.paquetCartes[i];
            this.paquetCartes[i] = this.paquetCartes[j];
            this.paquetCartes[j] = temp;
        }
    }
    public void Distribuer()
    {
        foreach(Joueur j in this.joueurs)
        {
            for(int i=0; i<8;i++)
            {
                j.cartes[i] = this.pileDePioche.Pop();
            }
        }
    }

    public Stack<Cartes> getPileDePioche()
    {
        return this.pileDePioche;
    }


}


