using Brief_Duel_Guerriers.classe;

namespace Brief_Duel_Guerriers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("----> DUELS DE GUERRIERS <----");

            // Boucle principale du programme:  permet d’afficher le menu principal tant que l’utilisateur ne choisit pas de quitter.

            bool continuerMenu = true;
            while (continuerMenu)
            {
                continuerMenu = AfficherMenuPrincipal();
            }

            Console.WriteLine("Fin de la partie");

            // Methode pour Afficher le Menu Principal avec un switch pour avoir un menu avec des options 

            static bool AfficherMenuPrincipal()
            {
                Console.WriteLine("\n---> Menu Principal <---");
                Console.WriteLine("1. Ajouter un guerrier");
                Console.WriteLine("2. Afficher la listes des guerriers");
                Console.WriteLine("3. Lancer un tournoi");
                Console.WriteLine("4. Quitter");
                Console.Write("Votre choix : ");

                string choix = Console.ReadLine();

                switch (choix)
                {
                    case "1":
                        AjouterGuerrier();
                        break;

                    case "2":
                        AfficherListeGuerriers();
                        break;

                    case "3":
                        LancerTournoi();
                        break;

                    case "4": return false; // retourne false si l’utilisateur choisit de quitter et donc fin à la boucle.

                    default:
                        Console.WriteLine("Choix invalide. Veuillez réessayer avec 1,2,3 our 4."); // Affiche une erreur quand l'utlisateur fait un choix qui ne correspond pas aux options proposé
                        break;

                }

                return true;

            }

        }

    }
    
}
