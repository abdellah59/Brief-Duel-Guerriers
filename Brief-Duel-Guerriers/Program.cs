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
            Console.WriteLine("║  1. Créer un Combattant                ║");
            Console.WriteLine("║  2. Supprimer un Combattant            ║");
            Console.WriteLine("║  3. Afficher la liste                  ║");
            Console.WriteLine("║  4. Lancer un duel                     ║");
            Console.WriteLine("║  5. Lancer un tournoi                  ║");
            Console.WriteLine("║  6. Afficher l'historique              ║");
            Console.WriteLine("║  7. Afficher le guide utlisateur       ║");
            Console.WriteLine("║  8. Quitter                            ║");
            Console.WriteLine("╚════════════════════════════════════════╝");
            Console.WriteLine($"Guerriers créés : {listeCombattants.Count}");
            Console.WriteLine();


            int choix = LireChoixUtilisateur("Votre choix", 1, 8);

            switch (choix)
            {
                case 1:
                    AjouterCombattant();
                    break;

                case 2:
                    SupprimerCombattant();
                    break;

                case 3:
                    AfficherListeCombattants();
                    break;

                case 4:
                    LancerDuel();
                    break;

                case 5:
                    LancerTournoi();
                    break;

               /* case 6:
                    AfficherHistorique();
                    break;*/

                case 7:
                    AfficherGuideUtilisateur();
                    break;

                case 8: return false; // retourne false si l’utilisateur choisit de quitter et donc fin de la boucle.

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Choix invalide. Veuillez réessayer avec 1,2,3,4,5,6,7 ou 8."); // Affiche une erreur quand l'utlisateur fait un choix qui ne correspond pas aux options proposé
                    Console.ResetColor();
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
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Veuillez entrer un nombre entre {min} et {max}."); // Si la saisie est invalide => message erreur et redemande de saisir 
                Console.ResetColor();
            }
        }

        static List<ICombattant> listeCombattants = new List<ICombattant>();

        // méthode pour ajouter un ajouter un guerrier 
        public static void AjouterCombattant()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════╗");
            Console.WriteLine("║         CRÉER UN COMBATTANT            ║");
            Console.WriteLine("╚════════════════════════════════════════╝");
            Console.WriteLine();

            // demande de saisir le nom de guerrier ave la methode LireNomValide
            string nom = LireNomValide();

            // demande de saisie avec la methode LiereEntierValide de saisir les PV du guerrier avec une condition : PV entre 10 et 100 et nbr d'attaque entre 1 et 10
            int pointsDeVie = LireEntierValide("Saisissez les Points de vie entre", 10, 100);
            int nbDesAttaques = LireEntierValide("Saisissez le Nombre de dé d'attaque entre", 1, 10);

            // Choix du tupe de guerrier avec un switch 

            Console.WriteLine();
            Console.WriteLine("TYPES DE Combatant :");
            Console.WriteLine("1. Guerrier classique");
            Console.WriteLine("2  Gobelin");
            Console.WriteLine("3. Sorcière");
            Console.WriteLine("4. Sorcier");
            Console.WriteLine();


            // Appelle la fonction LireChoixUtilisateur pour demander à l'utilisateur de choisir un type de guerrier entre 1 et 4)
            int typeChoix = LireChoixUtilisateur("Choissez un Type de Combattant", 1, 4);

            ICombattant nouveauCombattant = null; //  variable qui contient l'objet du guerrier qu'on va créer

            switch (typeChoix)
            {
                case 1:
                    nouveauCombattant = new Guerrier(nom, pointsDeVie, nbDesAttaques);
                    break;

                // demande à l’utilisateur s’il souhaite équiper le Gobelin d'une armure lourde. Reponse covertie en true si la reponse commence par o
                case 2:
                    Console.WriteLine();
                    Console.Write("Vous voulez équiper le gobelin avec une Armure Lourde ? (o/n): ");
                    bool armureLourde = Console.ReadLine().ToLower().StartsWith("o");
                    nouveauCombattant = new Gobelin(nom, pointsDeVie, nbDesAttaques, armureLourde);
                    break;

                case 3:
                    nouveauCombattant = new Sorciere(nom, pointsDeVie, nbDesAttaques);
                    break;

                case 4:
                    int mana = LireEntierValide("Mana", 10, 100); // demande de saisir une valeur de mana entre 10 et 100 avec la methode lireEntierValide
                    nouveauCombattant = new Sorcier(nom, pointsDeVie, nbDesAttaques, mana);
                    break;

            }

            // Ajout du nouveau guerrier créer dans la liste globale
            listeCombattants.Add(nouveauCombattant);

            // Affichage d'un message confirmation et des info du guerrier créer
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Combattant créé avec succès");
            Console.ResetColor();
            Console.Write("Nouveau Combattant : ");
            nouveauCombattant.AfficherInfos();
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
                Console.Write("Saisissez le nom du Combattant : ");
                string nom = Console.ReadLine();

                // Condition qui permet de verifier que la saisie  est valide en fonction de la condition 

                if (string.IsNullOrWhiteSpace(nom))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Erreur ! le nom sisie ne peut pas etre vide"); // Si la saisie est invalide => message erreur et redemande de saisir 
                    Console.ResetColor();
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
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Veuillez entrer un nombre entre {min} et {max}."); // Si la saisie est invalide => message erreur et redemande de saisir 
                Console.ResetColor();
            }
        }

        // Methode pour suprimmer un Guerrier de la liste 
        static void SupprimerCombattant()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════╗");
            Console.WriteLine("║        SUPPRIMER UN COMBATTANT         ║");
            Console.WriteLine("╚════════════════════════════════════════╝");
            Console.WriteLine();

            // Verification si la liste est vide ou pas : avec une condition  

            if (listeCombattants.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Aucun combattant à supprimer !");
                Console.ResetColor();
                Console.WriteLine("Appuyez sur une touche pour continuer...");
                Console.ReadKey();
                Console.Clear();
                return;
            }

            // Affichage de la liste des guerriers avec des numéros pour chaque guerrier

            Console.WriteLine("LISTE DES COMBATTANTS :");
            for (int i = 0; i < listeCombattants.Count; i++) // Boucle for qui parcourt la liste.
            {
                Console.Write($"{i + 1} : ");
                listeCombattants[i].AfficherInfos();
            }

            // Ajout d'une option pour permettre à l'utlisateur d'annuler la supression
            Console.WriteLine();
            Console.WriteLine("Saisisseez 0 pour annuler la supression");
            Console.WriteLine();

            // Demande à l’utilisateur de choisir un guerrier à supprimer :
            int choix = LireChoixUtilisateur("Combattant à supprimer", 0, listeCombattants.Count);

            if (choix == 0) // Si le choix est 0 => annulation de la supression 
            {
                Console.WriteLine("Suppression annulée.");
            }
            else //  Sinon l’utilisateur a choisi un guerrier à supprimer : 
            {
                string nomSupprime = listeCombattants[choix - 1].GetNom(); // On enlève 1 car la liste commence à 0 et on récupère le nom du guerrier avant suppression.
                listeCombattants.RemoveAt(choix - 1); // supprime le guerrier de la liste.
                Console.WriteLine($"{nomSupprime} a été supprimé de la liste.");
            }

            Console.WriteLine();
            Console.WriteLine("Appuyez sur une touche pour continuer...");
            Console.ReadKey();
            Console.Clear();
        }

        // Méthode pour afficher la liste des guerrier
        public static void AfficherListeCombattants()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════╗");
            Console.WriteLine("║         LISTE DES COMBATTANT           ║");
            Console.WriteLine("╚════════════════════════════════════════╝");
            Console.WriteLine();

            // Condition pour verifier si la liste est vide, afficher un message d'information
            if (listeCombattants.Count == 0)
            {
                Console.WriteLine("Aucun combattant créé !!.");
                Console.WriteLine("Utilisez l'option 1 pour créer votre premier combattant !");
            }
            else // Sinon on affiche le nombre total de guerriers dans la liste 
            {
                Console.WriteLine($"Total : {listeCombattants.Count} combattant(s)");
                Console.WriteLine();

                for (int i = 0; i < listeCombattants.Count; i++) // On Parcourt la liste des Combattants et affiche leurs informations
                {
                    Console.Write($"  {i + 1}. ");
                    listeCombattants[i].AfficherInfos();
                    Console.WriteLine($"  Type: {listeCombattants[i].GetTypeCombattant()}\n"); // On affiche le type de guerrier en parcourant la liste
                }
            }
            Console.WriteLine();
            Console.WriteLine("Appuyez sur une touche pour continuer...");
            Console.ReadKey();
            Console.Clear();
        }

        // Méthode pour lancer un Duel entre 2 guerrier qu'on peut chosir dans la liste

        static void LancerDuel()
        {

            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════╗");
            Console.WriteLine("║              LANCER DUEL               ║");
            Console.WriteLine("╚════════════════════════════════════════╝");
            Console.WriteLine();


            // Condition pour vérifier qu'il y a au moins 2 guerriers dans la liste pour lancer un duel 
            if (listeCombattants.Count < 2)
            {
                Console.WriteLine("Il faut au moins 2 combattants pour lancer un duel !");
                Console.WriteLine("Appuyez sur une touche pour revenir au menu principal..");
                Console.ReadKey();
                Console.Clear();
                return;
            }
            
            Console.WriteLine("\n=== LANCEMENT DU DUEL ===");

            // On affiche la liste des guerriers disponibles 
            Console.WriteLine("\nCombattant disponibles :\n");
            for (int i = 0; i < listeCombattants.Count; i++) // On parcourt la boucle pour afficher la liste de guerriers
            {
                Console.WriteLine($"{i + 1}. {listeCombattants[i].GetNom()} (PV: {listeCombattants[i].GetPointsDeVie()}) (Type : {listeCombattants[i].GetTypeCombattant()})\n");
            }

            // Système de choix avec avec saisi du numero du premier guerrier qu'on choisi 
            int choix1 = LireChoixUtilisateur("Chisissez votre Premier Combattant : ", 1, (listeCombattants.Count));

            // Choisir le deuxième guerrier
            int choix2 = LireChoixUtilisateur("Chisissez votre Deuxieme Combattant", 1, (listeCombattants.Count));

            if (choix1 == choix2)
            {
                Console.WriteLine("Vous devez choisir deux Combattants différents !");
                return;
            }

            // On eécupéree les deux guerriers avec un -1 car la liste commence à 0
            ICombattant combattant1 = listeCombattants[choix1 - 1];
            ICombattant combattant2 = listeCombattants[choix2 - 1];

            // On Sauvegardee les PV originaux
            int pvOriginal1 = combattant1.GetPointsDeVie();
            int pvOriginal2 = combattant2.GetPointsDeVie();

            Console.WriteLine($"\n  DUEL : {combattant1.GetNom()} VS {combattant2.GetNom()}");

            // On lance une boucle de combat jusqu'à ce qu'un guerrier soit vaincu 
            int tour = 1;
            while (combattant1.GetPointsDeVie() > 0 && combattant2.GetPointsDeVie() > 0)
            {
                Console.WriteLine($"\n--- Tour {tour} ---\n");

                // On affiche l'état des guerriers au début 
                combattant1.AfficherInfos();
                combattant2.AfficherInfos();

                // On initialise les attaques :  Guerrier 1 attaque Guerrier 2
                int degats1 = combattant1.Attaquer();
                Console.WriteLine($"{combattant1.GetNom()} attaque et inflige {degats1} dégâts !");
                combattant2.SubirDegats(degats1);

                // Vérifier si Guerrier 2 est vaincu 
                if (combattant2.GetPointsDeVie() <= 0)
                {
                    Console.WriteLine($"{combattant2.GetNom()} est vaincu !");
                    break;
                }

                // Guerrier 2 attaque Guerrier 1
                int degats2 = combattant2.Attaquer();
                Console.WriteLine($"{combattant2.GetNom()} attaque et inflige {degats2} dégâts !");
                combattant1.SubirDegats(degats2);

                // Vérifier si Guerrier 1 est vaincu 
                if (combattant1.GetPointsDeVie() <= 0)
                {
                    Console.WriteLine($"{combattant1.GetNom()} est vaincu !");
                    break;
                }

                tour++;
            }

            // On déterminer qui est le vainqueur poaur l'afficher avec une condition qui verifier les PV de chaque guerrier
            if (combattant1.GetPointsDeVie() > 0)
            {
                Console.WriteLine($"\n Le {combattant1.GetTypeCombattant()} : {combattant1.GetNom()} remporte le duel !");
            }
            else
            {
                Console.WriteLine($"\n Le {combattant2.GetTypeCombattant()} : {combattant2.GetNom()} remporte le duel !");
            }

            // Restaurer les PV
            combattant1.SetPointsDeVie(pvOriginal1);
            combattant2.SetPointsDeVie(pvOriginal2);

            Console.WriteLine();
            Console.WriteLine("Appuyez sur une touche pour revenir au menu principal..");
            Console.ReadKey();
            Console.Clear();
        }

        // Methode pour lancer un tournoi par elimination 
        public static void LancerTournoi()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════╗");
            Console.WriteLine("║             TOURNOI                    ║");
            Console.WriteLine("╚════════════════════════════════════════╝");
            Console.WriteLine();

            // Vérifier qu'il y a au moins 2 guerriers
            if (listeCombattants.Count < 2)
            {
                Console.WriteLine("Il faut au moins 2 Combattants pour lancer un Tournoi !");
                Console.WriteLine("Appuyez sur une touche pour revenir au menu principal...");
                Console.ReadKey();
                Console.Clear();
                return;
            }

            Console.WriteLine("\n=== LANCEMENT DU TOURNOI ===");

            // On Créé une copie de la liste pour ne pas modifier l'originale et on sauvegarde leur PV 
            List<ICombattant> participants = new List<ICombattant>();
            Dictionary<ICombattant, int> pvOriginaux = new Dictionary<ICombattant, int>();

            foreach (var combattant in listeCombattants)
            {
                // Ajout du guerrier avec ses stats originales dans la nouvel liste 
                participants.Add(combattant);
                pvOriginaux[combattant] = combattant.GetPointsDeVie();
            }

            Console.WriteLine($"Tournoi lancé avec {participants.Count} participants !");

            // On affiche les participants
            Console.WriteLine("\nParticipants :");
            foreach (var participant in participants)
            {
                participant.AfficherInfos();
            }

            int tour = 1;

            // Le tournoir continue tant qu'il reste plus d'un guerrier dans la liste 
            while (participants.Count > 1)
            {
                Console.WriteLine($"\n==================== TOUR {tour} ====================");

                // On crée une liste de survicant à partir de la liste de vainque de la manche precedante 
                List<ICombattant> survivants = new List<ICombattant>();

                // Organiser les combats (2 par 2)
                for (int i = 0; i < participants.Count; i += 2)
                {
                    if (i + 1 < participants.Count)
                    {
                        // Combat entre deux guerriers
                        ICombattant Combattant1 = participants[i];
                        ICombattant Combattant2 = participants[i + 1];

                        Console.WriteLine($"\n  COMBAT : {Combattant1.GetNom()} VS {Combattant2.GetNom()}");

                        // Combat jusqu'à ce qu'un guerrier perde
                        while (Combattant1.GetPointsDeVie() > 0 && Combattant2.GetPointsDeVie() > 0)
                        {
                            // Guerrier 1 attaque
                            int degats1 = Combattant1.Attaquer();
                            Combattant2.SubirDegats(degats1);

                            if (Combattant2.GetPointsDeVie() <= 0)
                                break;

                            // Guerrier 2 attaque
                            int degats2 = Combattant2.Attaquer();
                            Combattant1.SubirDegats(degats2);
                        }

                        // Condition pour déterminer le vainqueur en fonction des PV de chaque guerrier
                        if (Combattant1.GetPointsDeVie() > 0)
                        {
                            Console.WriteLine($"  {Combattant1.GetNom()} remporte le combat !");
                            survivants.Add(Combattant1);
                        }
                        else
                        {
                            Console.WriteLine($"  {Combattant2.GetNom()} remporte le combat !");
                            survivants.Add(Combattant2);
                        }
                    }
                    else
                    {
                        // Si on une liste avec un nbr de Guerrier impair il passe automatiquement au tour suivant 
                        Console.WriteLine($"  {participants[i].GetNom()} passe automatiquement au tour suivant !");
                        survivants.Add(participants[i]);
                    }
                }

                // Mise à jour de la liste des participants
                participants = survivants;

                // on aAffiche les survivants de la manche precedante
                Console.WriteLine($"\nSurvivants du tour {tour} :");
                foreach (var survivant in participants)
                {
                    survivant.AfficherInfos();
                }

                tour++;

                // Pause entre les tours
                if (participants.Count > 1)
                {
                    Console.WriteLine("\nAppuyez sur une touche pour continuer vers le prochain tour...");
                    Console.ReadKey();
                }
            }

            // Conditoin pour afficher le vainqueur du tournoi si il reste que un seul gierrier dans la liste des participant 
            if (participants.Count == 1)
            {
                Console.WriteLine($"\n         CHAMPION DU TOURNOI : {participants[0].GetNom()} !");
                participants[0].AfficherInfos();
            }

            // On reinitialise les PV des combattants pour le prochain tournoi
            foreach (var combattant in listeCombattants)
            {
                if (pvOriginaux.ContainsKey(combattant))
                {
                    combattant.SetPointsDeVie(pvOriginaux[combattant]);
                }
            }

            Console.WriteLine("\nAppuyez sur une touche pour continuer...");
            Console.ReadKey();
            Console.Clear();

        }

    }
}
