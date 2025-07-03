using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brief_Duel_Guerriers.classe
{
    internal class Guerrier
    {
        // attributs partie 1

        private string Nom;
        private int PointsDeVie;
        private int NbDesAttaques;

        // constructeur
        public Guerrier(string nom, int pointsDeVie, int nbDesAttaques)
        {
            Nom = nom;
            PointsDeVie = pointsDeVie;
            NbDesAttaques = nbDesAttaques;
        }
        // méthodes publiques

        public string GetNom() {
            return Nom;
        }
        public int GetPointsDeVie() {
            return PointsDeVie;
        }
        public void SetPointsDeVie(int pointsDeVie) { 
        }
        public int GetNbDesAttaque() {
            return NbDesAttaques;
        }

        //  Méthodes Essentielles
        public void AfficherInfos()
        {
            Console.WriteLine($"Le guerrier s'appelle {Nom} et à {PointsDeVie} PV et le nombre d'attaque est de {NbDesAttaques} ");
        }
        public virtual int Attaquer()
        {
            // création du random pour les attaques
            Random random = new Random();

            int totalDesDegats = 0;
            
            for (int i = 0; i < NbDesAttaques; i++) // lancement d'une boucle qui permet de recuperer le total
            {
                totalDesDegats += random.Next(1, 7); // addition de la somme des lancer de dés entre 1 et 6
            }

            Console.WriteLine($"le total des dégats est {totalDesDegats} ");
            return totalDesDegats;
        }
        public virtual void SubirDegats(int degats)
        {
            PointsDeVie -= degats;
            if (PointsDeVie < 0) // si les points de vie sont inferieur à 0, cela ramène les pv a 0
            {
                PointsDeVie = 0;
            }
            Console.WriteLine($"Le nombre de dégats est de {degats}, il reste maintenant {PointsDeVie} PV ");

        }
    }
};
