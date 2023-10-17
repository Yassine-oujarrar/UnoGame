using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devoir1
{
    internal class Carte
    {
       //Variables
        static int nombre_de_cartes = 0;
        public enum Valeurs { As = 1, Deux, Trois, Quatre, Cinq, Six, Sept, Huit, Neuf, Dix, Valet, Dame, Roi }
        public enum Couleurs { Carreau = 1, Coeur, Pique, Trefle }
        string valeur, couleur;

        //Constructeur
        public Carte(string valeur, string couleur) //fonctionne correctement
        { 
            this.valeur = valeur;
            this.couleur = couleur;
            nombre_de_cartes++;
        }

        //Methodes d'instance
        override public string ToString() //fonctionne correctement
        {
            return valeur + " de " + couleur;
        }

        public string getValeur() {  return valeur; }
        public string getCouleur() {  return couleur; }
        public static string getEnumValeur(int i) { return ((Valeurs)i).ToString(); }
        public static string getEnumCouleur(int i) { return ((Couleurs)i).ToString(); }


        //Methodes statiques
        public static int getNombreCartes() //fonctionne correctement
        {
            return nombre_de_cartes;
        }


    }
}
