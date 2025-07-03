using Brief_Duel_Guerriers.classe;

namespace Brief_Duel_Guerriers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Création des guerriers Gobelin et sorciere avec leur attribus et affichage de leur info au debut 
            Gobelin Nico = new Gobelin("Nicolas", 40, 2, true);
            Sorciere soso = new Sorciere("soso", 25, 5);

            Console.WriteLine("Gbelin vs Sorciere :");
            Nico.AfficherInfos();
            soso.AfficherInfos();
            Console.WriteLine();

            // Boucle du duel: tant que les deux personnages ont des points de vie continuer le duel

            while (Nico.GetPointsDeVie() > 0 && soso.GetPointsDeVie() > 0)
            {
                // Le gobelin attaque, et on récupère les dégâts infligés à la sorciere
                int degatsGobelin = Nico.Attaquer();
                soso.SubirDegats(degatsGobelin);
                soso.AfficherInfos();

                // Condition pour verifier si la sorcière est vaincue on arrete la boucle
                if (soso.GetPointsDeVie() <= 0)
                {
                    Console.WriteLine($"{soso.GetNom()} est vaincu");
                    break;
                }

                // La sorciere attaque a son tour, et on récupère les dégâts infligés au goblin
                int degatsSorciere = soso.Attaquer();
                Nico.SubirDegats(degatsSorciere);
                Nico.AfficherInfos();

                // Condition pour verifier si le gobelin n'a plus de pv alors il est vaincu et fin de la boucle
                if (Nico.GetPointsDeVie() <= 0)
                {
                    Console.WriteLine($"{Nico.GetNom()} est vaincu");
                    break;
                }
            }


        }
    }
};
