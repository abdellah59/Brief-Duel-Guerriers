using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
            // création du random pour les attaques
            Random random = new Random();

            int totalDesDegats = 0;
            int degatsMin = GetNbDesAttaque();

            for (int i = 0; i < GetNbDesAttaque(); i++) // lancement d'une boucle qui permet de recuperer le total
            {
                totalDesDegats += random.Next(1, 7); // addition de la somme des lancer de dés entre 1 et 6
            }
            if (  degatsMin > totalDesDegats )
            {
                degatsMin = totalDesDegats;
                Console.WriteLine($"la sorcière a infligé un minimum de dégats de : {degatsMin} ");
            }
            Console.WriteLine($"le total des dégats est {totalDesDegats} ");
            return totalDesDegats;
        }
    }
};
