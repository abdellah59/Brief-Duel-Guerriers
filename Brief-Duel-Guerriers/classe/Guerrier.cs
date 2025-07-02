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
        // création du random pour les attaques

        public Random random = new Random();

        public int Attaquer()
        {
            int attaqueEnMoins = random.Next(1, 7);
            NbDesAttaques -= attaqueEnMoins;
            return attaqueEnMoins;
           
        }
        public void SubirDegats(int degats)
        {
            PointsDeVie -= degats;
            Console.WriteLine($"Le nombre de dégats est de {degats}, il reste maintenant {PointsDeVie} PV ");
        }
    }
};
