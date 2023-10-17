using System;
using System.Collections;

public class PileDeCartes : IPileDeCartes, IEnumerable<Carte>
{
    public List<Carte> Cartes { get; set; }
    public PileDeCartes(List<Carte> cartes)
    {
        this.Cartes = cartes;
    }

    // melanger la pile de cartes
    public void Melanger()
    {

    }

    // retirer et de retourner la première carte de la pile
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

    

    // implementer IEnumerable
    public IEnumerator<Carte> GetEnumerator()
    {
        return Cartes.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
