using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brief_Duel_Guerriers
{
    interface ICombattant
    {
        string getNom();
        int getPointsDeVie();
       int SetPointsDeVie(int pointsDeVie);
        int Attaquer();
        int SubirDegats(int degats);
        string AfficherInfos();
        
    }
}
