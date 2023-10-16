using System;
public class Carte
{
    public enum Valeur // enumération des valeurs possibles pour la carte
    {
        As, Deux, Trois, Quatre, Cinq, Six, Sept, Huit, Neuf, Dix, Valet, Dame, Roi
    }

    public enum Type // enumération des types possibles pour la carte
    {
        Trèfle, Carreau, Cœur, Pique
    }

    private readonly Valeur valeur;
    private readonly Type type;


    public Carte(Valeur valeur, Type type)   // Constructeur de la classe Carte
    {
        this.valeur = valeur;
        this.type = type;
    }

    public Valeur getValeur() // Getteur de la valeur de la carte
    {
        return this.valeur;
    }

    public Type getCarteType() // Getteur de type de la carte
    {
        return this.type;
    }

    public override string ToString() // Méthode pour afficher la carte
    {
        return this.valeur + " de " + this.type;
    }
    
    public static List<Carte> CreerPaquetDeCartes() // Méthode pour créer un paquet de cartes
    {
        List<Carte> paquet = new List<Carte>();
        for(int i=0; i<4; i++)
        {
            Carte.Type type =(Carte.Type)i;
            for(int j=0; j<13; j++)
            {
                Carte.Valeur valeur=(Carte.Valeur)j;
                paquet.Add(new Carte(valeur, type));
            }
        }
        return paquet;
    }
}
