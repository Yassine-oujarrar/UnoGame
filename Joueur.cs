using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Devoir1
{
    internal class Joueur
    {
        string nom, prenom, id;
        static int nombre_joueurs = 0;
        List<Carte> main_du_joueur = new List<Carte>();

        //COnstructeur
        public Joueur(string nom, string prenom) 
        {
            this.nom = nom;
            this.prenom = prenom;
            nombre_joueurs++;
            id = $"J{nombre_joueurs}";
        }

        //Le joueur prend la carte au sommet de la pile de pioche
        //NB: Il faudra redefinir le sommet de la pile car apres l'appel de la methode, la carte au sommet est NULL et
        //    on ne peut pas utiliser de pointeur pour directement decrementer sa valeur
        public void piocher(Carte[] pile_de_pioche, int sommet_pioche)
        {
            main_du_joueur.Add(pile_de_pioche[sommet_pioche]);
            pile_de_pioche[sommet_pioche] = null;
        }

        //On examine chaque carte dans la main du joueur et il joue la 1ere carte jouable, sinon pioche
        public Carte jouer(Carte[] pile_depot, int sommetD, Carte[] pile_pioche, int sommetP)
        {
            bool doitPiocher = true;

            foreach (Carte carte in main_du_joueur)
            {
                if (carte.getValeur() == pile_depot[sommetD].getValeur() || carte.getCouleur() == pile_depot[sommetD].getCouleur())
                {
                    main_du_joueur.Remove(carte);
                    sommetD++;
                    pile_depot[sommetD] = carte;
                    doitPiocher = false;
                    break;
                }
            }
            if (doitPiocher) 
            {
                piocher(pile_pioche, sommetP);
            }

            return pile_depot[sommetD];
        }

        public void AfficherMainDuJoueur()
        {
            foreach (Carte carte in main_du_joueur)
            {
                Console.WriteLine(carte);
            }
        }

        public List<Carte> getMain()
        {
            return main_du_joueur;
        }

        public void ajouterALaMain(Carte carte)
        {
            main_du_joueur.Add(carte);
        }

        public int getNombreCartes()
        {
            return main_du_joueur.Count;
        }

        override public string ToString()
        {
            return id + ": " + prenom + " " + nom;
        }

    }
}
