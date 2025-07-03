using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brief_Duel_Guerriers.classe
{
    internal class Gobelin : Guerrier 
    {
        // Attribut specifique :
        // Pour vérifier si le gobelin porte une armure 

        private bool ArmureLourde;

        // constructeur
        public Gobelin(string nom, int pointsDeVie, int nbDesAttaques, bool armureLourde) :  base (nom, pointsDeVie, nbDesAttaques)
        {
            ArmureLourde = armureLourde;

        }

        
    }
}
