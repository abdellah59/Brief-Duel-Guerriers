using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brief_Duel_Guerriers
{
    interface ICombattant
    {
        // Méthode pour les informations du guerrier
        string GetNom();
        int GetPointsDeVie();
        void SetPointsDeVie(int pointsDeVie);
        int GetNbDesAttaque();

        // Methode pour les duels du guerrier
        int Attaquer();
        void SubirDegats(int degats);

        // Methode pour l'affichage des infos du guerrier
        void AfficherInfos();

        // Methode pour la sauvegarde : chaque comabattant à un type 
        string GetTypeCombattant();

        // Méthodes spécifiques pour certains types 
        bool GetArmureLourde(); // Pour les Gobelin
        int GetMana(); // Pour les Sorciers
    }
}
