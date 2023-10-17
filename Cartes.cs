using System;
public class Carte
{
    public enum Valeur
    {
        As, Deux, Trois, Quatre, Cinq, Six, Sept, Huit, Neuf, Dix, Valet, Dame, Roi
    }

    public enum Type
    {
        Trèfle, Carreau, Cœur, Pique
    }

    private readonly Valeur valeur;
    private readonly Type type;


    public Carte(Valeur valeur, Type type)
    {
        this.valeur = valeur;
        this.type = type;
    }

    public Valeur getValeur()
    {
        return this.valeur;
    }

    public Type getCarteType()
    {
        return this.type;
    }

    public override string ToString()
    {
        return this.valeur + " de " + this.type;
    }
    
    public static List<Carte> CreerPaquetDeCartes()
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
