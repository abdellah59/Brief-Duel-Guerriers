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

            // Methode pour Afficher le guide utilisateur : 

            static void AfficherGuideUtilisateur()
            {
                Console.WriteLine("╔════════════════════════════════════════════════════════════════╗");
                Console.WriteLine("║                    DUELS DE GUERRIERS                          ║");
                Console.WriteLine("║                       GUIDE UTILISATEUR                        ║");
                Console.WriteLine("╚════════════════════════════════════════════════════════════════╝");
                Console.WriteLine();
                Console.WriteLine("OBJECTIF : Créez des guerriers et organisez des duels et tournois épiques !");
                Console.WriteLine();
                Console.WriteLine("OPTIONS DU MENU :");
                Console.WriteLine("  1. Créer un guerrier - Ajoutez un nouveau combattant à votre armée");
                Console.WriteLine("  2. Supprimer un guerrier - Retirez un guerrier de la liste");
                Console.WriteLine("  3. Afficher la liste - Consultez tous vos guerriers");
                Console.WriteLine("  4. Lancer un duel  - Organisez un combat entre deux combatants");
                Console.WriteLine("  5. Lancer un tournoi - Organisez un combat à élimination");
                Console.WriteLine("  6. Afficher l'historique - Consultez les champions précédents");
                Console.WriteLine("  7. Quitter - Fermez le programme");
                Console.WriteLine();
                Console.WriteLine("TYPES DE GUERRIERS :");
                Console.WriteLine("  - Guerrier : Combattant classique et équilibré");
                Console.WriteLine("  - Gobelin : Peut porter une armure lourde (réduit dégâts de 50%)");
                Console.WriteLine("  - Sorciere : Inflige toujours des dégâts minimums égaux à ses dés");
                Console.WriteLine("  - Sorcier : Utilise des sorts magiques (Boule de Feu, Soin, Bouclier)");
                Console.WriteLine();
                Console.WriteLine("RÈGLES DE SAISIE :");
                Console.WriteLine("  - Points de Vie : 10-100");
                Console.WriteLine("  - Dés d'attaque : 1-10");
                Console.WriteLine("  - Mana (Sorcier) : 10-100");
                Console.WriteLine("  - Nom : Lettres et chiffres uniquement");
                Console.WriteLine();
                Console.WriteLine("CONSEILS :");
                Console.WriteLine("  - Créez au moins 2 guerriers pour un tournoi");
                Console.WriteLine("  - Équilibrez PV et dés d'attaque selon votre stratégie");
                Console.WriteLine("  - Les sorciers régénèrent du mana chaque tour");
                Console.WriteLine();
                Console.WriteLine("Appuyez sur une touche pour commencer...");
                Console.ReadKey();
                Console.Clear();
            }


            // Methode pour Afficher le Menu Principal avec un switch pour avoir un menu avec des options 

            static bool AfficherMenuPrincipal()
            {
                Console.WriteLine("\n---> Menu Principal <---");
                Console.WriteLine("1. Ajouter un guerrier");
                Console.WriteLine("2. Afficher la listes des guerriers");
                Console.WriteLine("3. Lancer un tournoi");
                Console.WriteLine("4. Lancer Duel singulier");
                Console.WriteLine("5. Quitter");
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

                    /*case "3":
                        LancerTournoi();
                        break;*/

                    /*case "4":
                        LancerDuel();
                        break;*/

                    case "5": return false; // retourne false si l’utilisateur choisit de quitter et donc fin à la boucle.

                    default:
                        Console.WriteLine("Choix invalide. Veuillez réessayer avec 1,2,3 our 4."); // Affiche une erreur quand l'utlisateur fait un choix qui ne correspond pas aux options proposé
                        break;

                }

                return true;

            }

        }
        // création d'une liste pour stocker les nouveaux guerrier 
        static List<Guerrier> NouveauGuerrier = new List<Guerrier>();

        // méthode pour ajouter un ajouter un guerrier 
        public static void AjouterGuerrier()
        {
            Console.WriteLine($"Saissisez le nom du nouveau guerrier");
            string nom = Console.ReadLine(); // demande le nom


            Console.WriteLine($"Saissisez les points de vie du nouveau guerrier");
            int pointsDeVie = 0;

            int.TryParse(Console.ReadLine(), out pointsDeVie); // demande les pv
            if (pointsDeVie <= 0) // si le chiffre est inférieur ou égal à 0, l'utilisateur doit en saisir un a nouveau
            {
                Console.WriteLine("Vous ne pouvez pas choisir un chiffre inférieur ou égal à 0");
                Console.WriteLine("resaissisez un chiffre positif");
                int.TryParse(Console.ReadLine(), out pointsDeVie);
            }


            Console.WriteLine($"Saissisez le nombre d'attaque du nouveau guerrier");
            int nbDesAttaques;

            int.TryParse(Console.ReadLine(), out nbDesAttaques); // demande le nombre d'attaque 
            if (nbDesAttaques <= 0) // si le chiffre est inférieur ou égal à 0, l'utilisateur doit en saisir un a nouveau
            {
                Console.WriteLine("Vous ne pouvez pas choisir un chiffre inférieur ou égal à 0");
                Console.WriteLine("resaissisez un chiffre positif");
                int.TryParse(Console.ReadLine(), out nbDesAttaques);
            }
            Guerrier liste = new Guerrier(nom, pointsDeVie, nbDesAttaques);
            NouveauGuerrier.Add(liste);

            Console.WriteLine($"Vous avez crée un nouveau guerrier qui s'appelle {nom} qui à {pointsDeVie} PV et {nbDesAttaques} attaques");

        }

        // Méthode pour afficher la liste des guerrier

        public static void AfficherListeGuerriers()
        {
            foreach (Guerrier liste in NouveauGuerrier) // boucle pour parcourir la liste
            {
                liste.AfficherInfos();
            }

        }

    }
}
