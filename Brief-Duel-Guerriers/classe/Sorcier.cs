using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Brief_Duel_Guerriers.classe
{
    internal class Sorcier : Guerrier
    {    // attribut
        private int Mana = 50;
        // création d'une liste de sorts
        private List<string> sorts = new List<string> { "Boule de Feu", "Soin", "Bouclier Magique" };

        // herite de guerrier
        public Sorcier(string nom, int pointsDeVie, int nbDesAttaques, int mana) : base(nom, pointsDeVie, nbDesAttaques)
        {
            Mana = mana;
            mana = Math.Min(mana,100); // maximun 100
        }
        Random random = new Random(); // création d'un random
        public int sortsAleatoire;
        int degats = 0;
        public override int Attaquer()
        {
            if (Mana >= 10) // si mana est supérieur ou égal
            {
               
                sortsAleatoire = random.Next(1, 4); // random de 1 à 3
            }
            if (sortsAleatoire == 1) // si random = 1
            {
                Console.WriteLine($"Le guerrier {GetNom} lance une boule de feu");
                return degats = base.Attaquer() + 10; // dégat + 10
            }
            else if (sortsAleatoire == 2) // si random = 2
            {
                Console.WriteLine($"Le guerrier {GetNom} utilise une potion de soin");
                return GetPointsDeVie() + 5; // + 5 pv
            }
            else if (sortsAleatoire == 3) // si random = 3
            {
                Console.WriteLine($"Le guerrier {GetNom} utilise un bouclier magique");
                return degats = base.Attaquer(); 
            }
            return degats;
            Mana -= 10; // mana - 10
        }
        bool armureLourde;
        public override void SubirDegats(int degats)
        {

            if (armureLourde) // Conditon qui determine si armure lourde alros les dégats sont divisé par 2
            {
                degats = degats / 2;
                Console.WriteLine($"{GetNom()} porte une armure lourde : Dégats sont réduit à {degats}");
            }

            // Appel de la methode de la classe mère
            base.SubirDegats(degats);

        }

        public void RegenererMania(int mania)
        {
            Mana += 5; // mana + 5 
            Console.WriteLine($"le nombre de mana est {Mana}");
        }

        public void AfficherInfo()
        {
            Console.WriteLine($"Le guerrier s'appelle {GetNom} et à {GetPointsDeVie} PV et le nombre d'attaque est de {GetNbDesAttaque} et le nombre de mana est {Mana} ");
        }
    }
}
