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
        // méthodes

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

    }
}
