using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brief_Duel_Guerriers
{
    interface ICombattant
    {
        string GetNom();
        int GetPointsDeVie();
       void SetPointsDeVie(int pointsDeVie);
        int Attaquer();
        void SubirDegats(int degats);
        void AfficherInfos();
        
    }
}
