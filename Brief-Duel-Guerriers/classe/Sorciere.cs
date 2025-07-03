using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brief_Duel_Guerriers.classe
{
    internal class Sorciere : Guerrier  // hérite de Guerrier
    {
        public Sorciere(string nom, int pointsDeVie, int nbDesAttaques) : base(nom, pointsDeVie, nbDesAttaques)
        {

        }
        public override int Attaquer()
        {
            int attaqueEnMoins = random.Next(1, 10);
            nbDesAttaques -= attaqueEnMoins;
            return attaqueEnMoins;
        }*/
    }
};
