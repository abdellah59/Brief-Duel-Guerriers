using Brief_Duel_Guerriers.classe;
using System.Linq;

namespace Brief_Duel_Guerriers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AfficherGuideUtilisateur(); // Appel de la methode pour afficher le guide utilisateur au démarrage de la console

            // Boucle principale du programme:  permet d’afficher le menu principal tant que l’utilisateur ne choisit pas de quitter.

            bool continuerMenu = true;
            while (continuerMenu)
            {
                continuerMenu = AfficherMenuPrincipal();
            }

            Console.WriteLine("Fin de la partie");

          
        }

        // Methode pour Afficher le guide utilisateur : 

        static void AfficherGuideUtilisateur()
        {
            Console.WriteLine("╔═══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                  DUEL  DE  GUERRIERS                          ║");
            Console.WriteLine("║                       ------                                  ║");
            Console.WriteLine("║                   GUIDE UTILISATEUR                           ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════════╝");
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
            Console.WriteLine("╔════════════════════════════════════════╗");
            Console.WriteLine("║           MENU PRINCIPAL               ║");
            Console.WriteLine("╠════════════════════════════════════════╣");
            Console.WriteLine("║  1. Créer un guerrier                  ║");
            Console.WriteLine("║  2. Supprimer un guerrier              ║");
            Console.WriteLine("║  3. Afficher la liste                  ║");
            Console.WriteLine("║  4. Lancer un duel                     ║");
            Console.WriteLine("║  5. Lancer un tournoi                  ║");
            Console.WriteLine("║  6. Afficher l'historique              ║");
            Console.WriteLine("║  7. Afficher le guide utlisateur       ║");
            Console.WriteLine("║  8. Quitter                            ║");
            Console.WriteLine("╚════════════════════════════════════════╝");
            Console.WriteLine($"Guerriers créés : {listeGuerriers.Count}");
            Console.WriteLine();

           
            int choix = LireChoixUtilisateur("Votre choix", 1, 8);

            switch (choix)
            {
                case 1:
                    AjouterGuerrier();
                    break;

                case 2:
                    SupprimerGuerrier();
                    break;

                case 3:
                    AfficherListeGuerriers();
                    break;

                /*case 4:
                    LancerDuel();
                    break;

                case 5:
                    LancerTournoi();
                    break;

                case 6:
                    AfficherHistorique();
                    break;*/

                case 7:
                    AfficherGuideUtilisateur();
                    break; 

                case 8: return false; // retourne false si l’utilisateur choisit de quitter et donc fin de la boucle.

                default:
                    Console.WriteLine("Choix invalide. Veuillez réessayer avec 1,2,3,4,5,6,7 ou 8."); // Affiche une erreur quand l'utlisateur fait un choix qui ne correspond pas aux options proposé
                    break;

            }

            return true;

        }

        // Méthodes pour la validation du choix numerique des options à laquel on applicque un min et un max
        static int LireChoixUtilisateur(string message, int min, int max)
        {
            int choix;

            // Boucle qui itère jusqu'à ce qu'une saisie valide et rentrée 
            while (true)
            {
                Console.Write($"{message} ({min}-{max}) : ");      // Affiche le message avec la plage autorisé "Votre choix (1-8) : "
                string input = Console.ReadLine();

                // Condition qui permet de verifier que la saisie convertie  est valide en fonction de la plage fixée
                if (int.TryParse(input, out choix) && choix >= min && choix <= max)
                {
                    return choix;
                }

                Console.WriteLine($"Veuillez entrer un nombre entre {min} et {max}."); // Si la saisie est invalide => message erreur et redemande de saisir 
            }
        }

        // création d'une liste pour stocker les nouveaux guerrier 
        private static List<Guerrier> listeGuerriers = new List<Guerrier>();

        // méthode pour ajouter un ajouter un guerrier 
        public static void AjouterGuerrier()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════╗");
            Console.WriteLine("║         CRÉER UN GUERRIER              ║");
            Console.WriteLine("╚════════════════════════════════════════╝");
            Console.WriteLine();

            // demande de saisir le nom de guerrier ave la methode LireNomValide
            string nom = LireNomValide();

            // demande de saisie avec la methode LiereEntierValide de saisir les PV du guerrier avec une condition : PV entre 10 et 100 et nbr d'attaque entre 1 et 10
            int pointsDeVie = LireEntierValide("Saisissez les Points de vie entre", 10, 100);
            int nbDesAttaques = LireEntierValide("Saisissez le Nombre de dé d'attaque entre", 1, 10);

            // Choix du tupe de guerrier avec un switch 

            Console.WriteLine();
            Console.WriteLine("TYPES DE GUERRIERS :");
            Console.WriteLine("1. Guerrier classique");
            Console.WriteLine("2  Gobelin:");
            Console.WriteLine("3. Sorcière");
            Console.WriteLine("4. Sorcier");
            Console.WriteLine();


            // Appelle la fonction LireChoixUtilisateur pour demander à l'utilisateur de choisir un type de guerrier entre 1 et 4)
            int typeChoix = LireChoixUtilisateur("Choissez un Type de Guerrier", 1, 4);

            Guerrier nouveauGuerrier = null; //  variable qui contient l'objet du guerrier qu'on va créer

            switch (typeChoix) 
            {
                case 1: 
                    nouveauGuerrier = new Guerrier(nom, pointsDeVie, nbDesAttaques);
                    break;

                // demande à l’utilisateur s’il souhaite équiper le Gobelin d'une armure lourde. Reponse covertie en true si la reponse commence par o
                case 2:
                    Console.WriteLine();
                    Console.Write("Vous voulez équiper le gobelin avec une Armure Lourde ? (o/n): ");
                    bool armureLourde = Console.ReadLine().ToLower().StartsWith("o");
                    nouveauGuerrier = new Gobelin(nom, pointsDeVie, nbDesAttaques, armureLourde);
                    break;

                case 3:
                    nouveauGuerrier = new Sorciere(nom, pointsDeVie, nbDesAttaques);
                    break;

                case 4:
                    int mana = LireEntierValide("Mana", 10, 100); // demande de saisir une valeur de mana entre 10 et 100 avec la methode lireEntierValide
                    nouveauGuerrier = new Sorcier(nom, pointsDeVie, nbDesAttaques, mana);
                    break;

            }

            // Ajout du nouveau guerrier créer dans la liste globale
            listeGuerriers.Add(nouveauGuerrier);

            // Affichage d'un message confirmation et des info du guerrier créer
            Console.WriteLine();
            Console.WriteLine("Guerrié créé avec succès");
            Console.Write("Nouveau Guerrier : ");
            nouveauGuerrier.AfficherInfos();
            Console.WriteLine();
            Console.WriteLine("Appuyez sur une touche pour continuer...");
            Console.ReadKey();
            Console.Clear();

        }

        // Methode pour la valida du nom siaisie (non vide, alphanumérique) du guerrier créé
        static string LireNomValide()
        {
            // Boucle qui itère jusqu'à ce qu'une saisie valide et rentrée 
            while (true)
            {
                Console.Write("Saisissez le nom du Guerrier : ");
                string nom = Console.ReadLine();

                // Condition qui permet de verifier que la saisie  est valide en fonction de la condition 

                if (string.IsNullOrWhiteSpace(nom))
                {
                    Console.WriteLine("Erreur ! le nom sisie ne peut pas etre vide"); // Si la saisie est invalide => message erreur et redemande de saisir 
                    continue;
                }
                return nom;

            }
        }

        // Méthode pour la validation du nombre sisie pour les PV et le nbr d'attaque du guerrier créé
        static int LireEntierValide(string message, int min, int max)
        {
            int nombre = 0; 

            // Boucle qui itère jusqu'à ce qu'une saisie valide et rentrée 
            while (true)
            {
                Console.Write($"{message} ({min}-{max}) : "); // Affiche le message avec la plage autorisé "Votre choix (1-8) : "
                string input = Console.ReadLine();

                // Condition qui permet de verifier que la saisie convertie  est valide en fonction de la plage fixée
                if (int.TryParse(input, out nombre) && nombre >= min && nombre <= max)
                {
                    return nombre;
                }

                Console.WriteLine($"Veuillez entrer un nombre entre {min} et {max}."); // Si la saisie est invalide => message erreur et redemande de saisir 
            }
        }

        // Methode pour suprimmer un Guerrier de la liste 
        static void SupprimerGuerrier()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════╗");
            Console.WriteLine("║        SUPPRIMER UN GUERRIER           ║");
            Console.WriteLine("╚════════════════════════════════════════╝");
            Console.WriteLine();

            // Verificationsi la liste est vide ou pas : avec une condition  

            if (listeGuerriers.Count == 0)
            {
                Console.WriteLine("Aucun guerrier à supprimer !");
                Console.WriteLine("Appuyez sur une touche pour continuer...");
                Console.ReadKey();
                Console.Clear();
                return;
            }

            // Affichage de la liste des giuerriers avec des numéros pour chaque guerrier

            Console.WriteLine("LISTE DES GUERRIERS :");
            for (int i = 0; i < listeGuerriers.Count ; i++) // Boucle for qui parcourt la liste.
            {
                Console.Write($"{i + 1}"); 
                listeGuerriers[i].AfficherInfos();
            }

            // Ajout d'une option pour permettre à l'utlisateur d'annuler la supression
            Console.WriteLine();
            Console.WriteLine("Saisisseez 0 pour annuler la supression");
            Console.WriteLine();

            // Demande à l’utilisateur de choisir un guerrier à supprimer :
            int choix = LireChoixUtilisateur("Guerrier à supprimer", 0, listeGuerriers.Count);

            if (choix == 0) // Si le choix est 0 => annulation de la supression 
            {
                Console.WriteLine("Suppression annulée.");
            }
            else //  Sinon l’utilisateur a choisi un guerrier à supprimer : 
            {
                string nomSupprime = listeGuerriers[choix - 1].GetNom(); // On enlève 1 car la liste commence à 0 et on récupère le nom du guerrier avant suppression.
                listeGuerriers.RemoveAt(choix - 1); // supprime le guerrier de la liste.
                Console.WriteLine($"{nomSupprime} a été supprimé de la liste.");
            }

            Console.WriteLine();
            Console.WriteLine("Appuyez sur une touche pour continuer...");
            Console.ReadKey();
            Console.Clear();
        }     

        // Méthode pour afficher la liste des guerrier

        public static void AfficherListeGuerriers()
        {
            foreach (Guerrier liste in listeGuerriers) // boucle pour parcourir la liste
            {
                liste.AfficherInfos();
            }

        }

    }
}
