using System;
public class Carte
{
    private Valeur valeur;
    private Couleur couleur;

    public enum Couleur
    {
        trefle,
        carreau,
        pique,
        coeur
    }

    public enum Valeur
    {
        deux = 2,
        trois = 3,
        quatre = 4,
        cinq = 5,
        six = 6,
        sept = 7,
        huit = 8,
        neuf = 9,
        dix = 10,
        valet = 11,
        dame = 12,
        roi = 13,
        As = 14,
    }

    
    public Carte(Valeur _valeur, Couleur _couleur)
    {
        valeur = _valeur;
        couleur = _couleur;
    }

    public Valeur ValeurCarte
    {
        get { return valeur; }
        set { valeur = value; }
    }

    public Couleur CouleurCarte
    {
        get { return couleur; }
        private set { couleur = value; }
    }

    public override string ToString()
    {
        return valeur + " de " + couleur;
    }
}
