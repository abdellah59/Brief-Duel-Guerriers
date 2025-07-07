# Duels de Guerriers

## Présentation

Ce projet en C# simule des duels entre différents types de guerriers (Guerrier, Gobelin, Sorcière, Sorcier) dans une interface console interactive. Il illustre des concepts fondamentaux de la programmation orientée objet : classes, héritage, encapsulation, polymorphisme et interfaces.

---

## Structure du Projet

- `Guerrier.cs` : Classe de base représentant un combattant standard.
- `Gobelin.cs` : Hérite de Guerrier, dispose d’une armure réduisant les dégâts.
- `Sorcière.cs` : Hérite de Guerrier, inflige toujours des dégâts minimums.
- `Sorcier.cs` : Hérite de Guerrier, utilise des sorts et de la mana.
- `ICombattant.cs` : Interface commune pour tous les types de combattants.
- `Program.cs` : Contient l’interface utilisateur, la gestion des combats et du tournoi.

---

## Fonctionnalités

### Partie I : Classe de Base `Guerrier`

- Attributs : `nom`, `pointsDeVie`, `nbDesAttaque`.
- Méthodes :
  - `AfficherInfos()` : Affiche les informations du guerrier.
  - `Attaquer()` : Lance un nombre de dés pour infliger des dégâts.
  - `SubirDegats(int)` : Réduit les points de vie du guerrier.

### Partie II : Classes Spécialisées

#### Gobelin

- Attribut spécifique : `armureLourde`.
- Réduction des dégâts de moitié si l’armure est activée.

#### Sorcière

- Redéfinit `Attaquer()` pour toujours infliger un minimum de dégâts (au moins égal au nombre de dés).

### Partie III : Interface Console Basique

- Menu principal avec options pour :
  - Créer un guerrier.
  - Lister les guerriers.
  - Lancer un tournoi.
- Liste globale des guerriers stockée en mémoire.
- Système de duel entre les guerriers jusqu’à ce qu’un seul reste.

### Partie IV : Interface Utilisateur Interactive

- Navigation dans un menu clair (1–6) :
  1. Créer un combattants - Ajoutez un nouveau combattant à votre armée
  2. Supprimer un combattant - Retirez un combattant de la liste
  3. Afficher la liste - Consultez tous vos guerriers
  4. Lancer un duel  - Organisez un combat entre deux combattants
  5. Lancer un tournoi - Organisez un combat à élimination
  6. Afficher l'historique - Consultez les champions précédents
  7. Afficher le guide utlisateur 
  8. Quitter - Fermez le programme

  
- Fonctions de validation de saisie.
- Affichage d’un guide utilisateur détaillé.
- Ajout de la classe `Sorcier` :
  - Gère des sorts avec un système de mana.
  - Sorts : Boule de Feu, Soin, Bouclier Magique.
  - Réduction des dégâts avec bouclier actif.

### Partie V : Tournoi Avancé et Expérience Utilisateur

- Mise en place de l’interface `ICombattant`.
- Utilisation de couleurs pour une meilleure lisibilité en console.
- Validation renforcée des entrées utilisateur.

---

## Exécution

1. Compiler le projet.
2. Lancer l'exécutable en console.
3. Naviguer dans le menu pour créer des guerriers, lancer des combats ou consulter l’historique.

---

## Prérequis

- Environnement de développement compatible (Visual Studio, VS Code)

---

## Objectifs Pédagogiques

- Comprendre les principes de l’héritage et du polymorphisme.
- Maîtriser la manipulation de listes et de menus interactifs en console.
- Structurer proprement un projet C# orienté objet.

---

## Auteurs

Ce projet a été réalisé à deux dans le cadre d’un travail collaboratif de programmation orientée objet en C#.  
Noms des auteurs : **Abdellah** et **Nicolas**

### Outils Utilisés

- ![GitHub](https://img.shields.io/badge/github-%23121011.svg?style=for-the-badge&logo=github&logoColor=white)
- ![Visual Studio](https://img.shields.io/badge/Visual%20Studio-5C2D91.svg?style=for-the-badge&logo=visual-studio&logoColor=white)
- ![Visual Studio Code](https://img.shields.io/badge/Visual%20Studio%20Code-0078d7.svg?style=for-the-badge&logo=visual-studio-code&logoColor=white)
- ![Markdown](https://img.shields.io/badge/markdown-%23000000.svg?style=for-the-badge&logo=markdown&logoColor=white)
