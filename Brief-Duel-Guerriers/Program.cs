using Brief_Duel_Guerriers.classe;

namespace Brief_Duel_Guerriers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Guerrier Nico = new Guerrier("Nicolas", 5, 3);
            Guerrier Nicolas = new Guerrier("Nico", 15, 18);

            Nico.AfficherInfos();
            Nico.Attaquer();
            Nico.Attaquer();
            Nico.Attaquer();
            Nico.SubirDegats(10);
            Nico.AfficherInfos();
            Nicolas.AfficherInfos();
        }
    }
};
