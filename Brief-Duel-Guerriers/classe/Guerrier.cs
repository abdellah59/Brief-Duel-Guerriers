using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brief_Duel_Guerriers.classe
{
    internal class Guerrier : ICombattant // Classe Guerrier qui implémente l'interface ICombattant
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
            PointsDeVie = pointsDeVie;
        }
        public int GetNbDesAttaque() {
            return NbDesAttaques;
        }

        //  Méthodes Essentielles
        public virtual void AfficherInfos()
        {
            Console.WriteLine($"{Nom} à {PointsDeVie} PV et {NbDesAttaques} attaque de dés.");
        }

        // Méthode pour attaquer avec le lancé des dés
        public virtual int Attaquer()
        {
            // création du random pour les attaques
            Random random = new Random();

            int totalDesDegats = 0;

            Console.Write($"{Nom} attaque avec {NbDesAttaques} dés : "); // Affichage du nom du guerrier avec le nb de dés pour son attaque 

            for (int i = 0; i < NbDesAttaques; i++) // lancement d'une boucle qui permet de recuperer le total
            {
                totalDesDegats += random.Next(1, 7); // addition de la somme des lancer de dés entre 1 et 6
            }

            Console.WriteLine($"Le total des dégats est :  {totalDesDegats} ");
            return totalDesDegats;
        }

        // Méthode qui met en place les dégats subits avec une condition sur les dégat lorsque les pv sont à 0 
        public virtual void SubirDegats(int degats)
        {
            PointsDeVie -= degats;
            if (PointsDeVie < 0) // si les points de vie sont inferieur à 0, cela ramène les pv à 0
            {
                PointsDeVie = 0;
            }
            Console.WriteLine($"{Nom} à subit {degats} dégats et il reste maintenant {PointsDeVie} PV ");

        }

        //Methode qui permet de retourner le type de comabatant pour la suavegarde
        public virtual string GetTypeCombattant()
        {
            return "Guerrier";
        }

        // Méthodes pour les types spécialisés (retournent des valeurs par défaut)
        public virtual bool GetArmureLourde() => false;
        public virtual int GetMana() => 0;
    }
};
