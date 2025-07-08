using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Brief_Duel_Guerriers.classe
{
    internal class Sorcier : Guerrier // Hérite de Guerrier
    {    // attribut
        private int Mana;
        private int ManaMax;
        private List<string> sorts;
        private bool Bouclier;

        // Constructeur : herite de guerrier
        public Sorcier(string nom, int pointsDeVie, int nbDesAttaques, int manaMin = 50) : base(nom, pointsDeVie, nbDesAttaques)
        {
            Mana = manaMin;
            ManaMax = 100;
            Bouclier = false;
            
            // création d'une liste de sorts
            sorts = new List<string> { "Boule de Feu", "Soin", "Bouclier Magique" };
        }

        //Methode publique : Getter pour le sorcier

        public int GetMana()
        {
            return Mana;
        }

        public int GetManaMax()
        {
            return ManaMax;
        }
        public bool GetBouclier()
        {
            return Bouclier;
        }


        Random random = new Random(); // création d'un random
        public int sortsAleatoire;
        int degats = 0;

        // Méthode spécifique  : Redéfinition de la méthode Attaquer 
        public override int Attaquer()
        {
            RegenererMana(5); // Régénération de mana au début du tour
                              // Vérifier si le sorcier a assez de mana pour un sort
            if (Mana >= 10)
            {
                return LancerSort();
            }
            else
            {
                // Attaque normale si pas assez de mana
                Console.WriteLine($"{GetNom()} n'a pas assez de mana pour lancer un sort !");
                return base.Attaquer();
            }
        }


        // Méthode pour lancer un sort
        private int LancerSort()
        {
            Random random = new Random();
            string sortChoisi = sorts[random.Next(sorts.Count)];

            Console.WriteLine($"{GetNom()} lance le sort '{sortChoisi}' !");

            int degats = 0;

            switch (sortChoisi)
            {
                case "Boule de Feu":
                    // Attaque normale + 10 dégâts bonus
                    degats = base.Attaquer() + 10;
                    Console.WriteLine($"La boule de feu ajoute 10 dégâts ! Total : {degats}");
                    break;

                case "Soin":
                    // Se soigner de 5 PV
                    int anciensPV = GetPointsDeVie();
                    SetPointsDeVie(GetPointsDeVie() + 5);
                    Console.WriteLine($"{GetNom()} lance un sort de soin + 5 PV ! ({anciensPV} -> {GetPointsDeVie()})");
                    // Attaque normale après le soin
                    degats = base.Attaquer();
                    break;

                case "Bouclier Magique":
                    // Activer le bouclier magique
                    Bouclier = true;
                    Console.WriteLine($"{GetNom()} active un bouclier magique ! (réduit les dégâts de 50%)");
                    // Attaque normale après le bouclier
                    degats = base.Attaquer();
                    break;
            }

            // Consommer le mana
            Mana -= 10;
            Console.WriteLine($"Mana restant : {Mana}/{ManaMax}");

            return degats;
        }
        public override void SubirDegats(int degats)
        {
            if (Bouclier)
            {
                // Réduire les dégâts de 50%
                degats = degats / 2;
                Console.WriteLine($"Le bouclier magique réduit les dégâts à {degats} !");

                // Désactiver le bouclier après utilisation
                Bouclier = false;
                Console.WriteLine("Le bouclier magique se dissipe.");
            }

            // Appel de la méthode de la classe parent
            base.SubirDegats(degats);
        }

        // Méthode pour régénérer le mana
        public void RegenererMana(int montant)
        {
            int ancienMana = Mana;
            Mana += montant;

            if (Mana > ManaMax)
            {
                Mana = ManaMax;
            }

            if (montant > 0 && ancienMana < ManaMax)
            {
                Console.WriteLine($"{GetNom()} régénère {Mana - ancienMana} mana ({ancienMana} -> {Mana})");
            }
        }

        public void AfficherInfo()
        {
            Console.WriteLine($"Le sorcier {GetNom} à {GetPointsDeVie} PV et le nombre d'attaque est de : {GetNbDesAttaque} et le nombre de mana est : {Mana} / {ManaMax}");
        }

        // Definition du type pour la sauvegarde
        public override string GetTypeCombattant()
        {
            return "Sorcier";
        }
    }
}
