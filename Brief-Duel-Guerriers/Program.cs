using Brief_Duel_Guerriers.classe;

namespace Brief_Duel_Guerriers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Gobelin Nico = new Gobelin("Nicolas", 40, 2, true);
            Sorciere soso = new Sorciere("soso", 25, 5);

            Console.WriteLine("Gbelin vs Sorciere :");
            Nico.AfficherInfos();
            soso.AfficherInfos();
            Console.WriteLine();

            while(Nico.GetPointsDeVie() > 0 && soso.GetPointsDeVie() > 0)
            {
                int degatsGobelin = Nico.Attaquer();
                soso.SubirDegats(degatsGobelin);
                soso.AfficherInfos();

                if (soso.GetPointsDeVie() <= 0)
                {
                    Console.WriteLine($"{soso.GetNom()} est vaincu");
                    break;
                }

                int degatsSorciere = soso.Attaquer();
                Nico.SubirDegats(degatsSorciere);
                Nico.AfficherInfos();

                if (Nico.GetPointsDeVie() <= 0)
                {
                    Console.WriteLine($"{Nico.GetNom()} est vaincu");
                    break;
                }
            }


        }
    }
};
