using System;
public class Cartes
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


    public Cartes(Valeur valeur, Type type)
    {
        this.valeur = valeur;
        this.type = type;
    }

    public Valeur GetValeur()
    {
        return this.valeur;
    }

    public Type GetCarteType()
    {
        return this.type;
    }

    public override string ToString()
    {
        return valeur + " de " + type;
    }
    
    public static List<Cartes> CreerPaquetDeCartes()
    {
        List<Cartes> paquet = new List<Cartes>();
        for(int i=0; i<4; i++)
        {
            Cartes.Type type =(Cartes.Type)i;
            for(int j=0; j<13; j++)
            {
                Cartes.Valeur valeur=(Cartes.Valeur)j;
                paquet.Add(new Cartes(valeur, type));
            }
        }
        return paquet;
    }
}
