using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Brief_Duel_Guerriers.classe
{
    internal class Sorcier : Guerrier
    {
        private int Mana = 50;

        private List<string> sorts = new List<string> { "Boule de Feu", "Soin", "Bouclier Magique" };

        public Sorcier(string nom, int pointsDeVie, int nbDesAttaques, int mana) : base(nom, pointsDeVie, nbDesAttaques)
        {
            Mana = mana;
            mana = Math.Min(mana,100);
        }
        Random random = new Random();
        public int sortsAleatoire;
        int degats = 0;
        public override int Attaquer()
        {
            if (Mana >= 10)
            {
               
                sortsAleatoire = random.Next(1, 4);
            }
            if (sortsAleatoire == 1)
            {
                Console.WriteLine($"Le guerrier {GetNom} lance une boule de feu");
                return degats = base.Attaquer() + 10;
            }
            else if (sortsAleatoire == 2)
            {
                Console.WriteLine($"Le guerrier {GetNom} utilise une potion de soin");
                return GetPointsDeVie() + 5;
            }
            else if (sortsAleatoire == 3)
            {
                Console.WriteLine($"Le guerrier {GetNom} utilise un bouclier magique");
                return degats = base.Attaquer();
            }
            return degats;
        }
    }
}
