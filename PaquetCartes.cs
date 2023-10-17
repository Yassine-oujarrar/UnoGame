using System;
using static Carte;

public static class PaquetCartes 
{

    // creer le paquet de cartes
    public static List<Carte> PaquetDeCinquanteDeuxCartes()
    {
        List<Carte> paquet = new List<Carte>();

        foreach(Couleur couleur in Enum.GetValues(typeof(Couleur)))
        {
            foreach (Valeur valeur in Enum.GetValues(typeof(Valeur)))
            {
                paquet.Add(new Carte(valeur, couleur));
            }
        }
        return paquet;
    }

    // penser a melanger le paquet de carte
    static void MelangerJeuDeCartes(List<Carte> paquetDe52Cartes)
    {
        for (int i = 0; i < 52; i++)
        {
            Random random = new Random();
            Carte temp;
            int rand1 = random.Next(paquetDe52Cartes.Count), rand2 = random.Next(paquetDe52Cartes.Count);
            temp = paquetDe52Cartes[rand1];
            paquetDe52Cartes[rand1] = paquetDe52Cartes[rand2];
            paquetDe52Cartes[rand2] = temp;

        }
    }
    // a verifier
    static void MelangerJeuDeCartes2(List<Carte> jeuDeCartes)
    {
        Random random = new Random();

        for (int i = jeuDeCartes.Count - 1; i > 0; i--)
        {
            int j = random.Next(i + 1);
            Carte temp = jeuDeCartes[i];
            jeuDeCartes[i] = jeuDeCartes[j];
            jeuDeCartes[j] = temp;
        }
    }



}

