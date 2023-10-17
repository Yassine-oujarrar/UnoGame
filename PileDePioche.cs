using System;

public class PileDePioche : PileDeCartes
{
    public PileDePioche(List<Carte> cartes) : base(cartes) { }

    public int Count
    {
        get { return Cartes.Count; }
    }
    /*
    public void Piocher1(List<Carte> cartes, int sommet)
    {
        MainJoueur.CarteEnMainDuJoueur.Add(cartes[sommet]);
        cartes[sommet] = null;
    }
    */

    /*
    public void Piocher(List<Carte> cartes, int sommet, MainJoueur mainDuJoueur)
    {
        mainDuJoueur.CarteEnMainDuJoueur.Add(cartes[sommet]);
        cartes[sommet] = null;
    }
    */

    public Carte Piocher()
    {
        // on verifie que la pile contient qu moins une carte
        if (Cartes.Count > 0)
        {
            // on recupere la premiere carte de la pile qu'on attribue 
            // a cartePiochee
            Carte cartePiochee = Cartes[0];
            // puis on la supprime du paquet à l'index selectionné
            Cartes.RemoveAt(0);
            return cartePiochee;
        }
        else
        {
            throw new InvalidOperationException("Il n' y a plus de cartes dans la pile, impossible de piocher");
        }
    }


}
