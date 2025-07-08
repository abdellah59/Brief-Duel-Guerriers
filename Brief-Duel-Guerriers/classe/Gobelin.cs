using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Brief_Duel_Guerriers.classe
{
    internal class Gobelin : Guerrier  // hérite de Guerrier
    {
        // Attribut specifique :
        // Pour vérifier si le gobelin porte une armure 

        private bool ArmureLourde;

        // constructeur
        public Gobelin(string nom, int pointsDeVie, int nbDesAttaques, bool armureLourde) :  base (nom, pointsDeVie, nbDesAttaques)
        {
            ArmureLourde = armureLourde;

        }

        // Methode publique : Getter pour l'armure lourde
        public bool GetArmureLourde()
        {
            return ArmureLourde;
        }

        // Méthode spécifique  : Redéfinition de la méthode SubirDegats avec l'attribut Armure Lourde  

        public override void SubirDegats(int degats)
        {

            if (ArmureLourde) // Conditon qui determine si il y'a armure lourde alors les dégats sont divisé par 2
            {
                degats = degats / 2;
                Console.WriteLine($"{GetNom()} porte une armure lourde : Dégats sont réduit à {degats}");
            }
           
            // Appel de la methode de la classe mère
            base.SubirDegats(degats);  

        }

        // Definition du type pour la sauvegarde
        public override string GetTypeCombattant()
        {

            return $"Gobelin {(GetArmureLourde() ? "(avec armure lourde)" : "(sans armure lourde)")}"; //On retourne si le gobelin a une armure lourde ou non
        }
    }
}
