# Quiz Program

Un programme de quiz en ligne écrit en C#.

## Installation

1. Clonez le dépôt Git : `https://github.com/MarsaColombo/QuizzConsoleC-.git`
2. Ouvrez le projet dans votre IDE favori.
3. Compilez le projet.

## Comment contribuer

Les contributions sont les bienvenues ! Si vous souhaitez apporter des améliorations ou corriger des problèmes, veuillez soumettre une pull request.

## Fonctionnement

Ce programme C# est une application de quiz interactive qui permet aux utilisateurs de tester leurs connaissances dans diverses catégories. L'application utilise un fichier JSON (`quizzes.json`) pour stocker des données sur les questions, les catégories, les options et les réponses correctes.

1. **Chargement des données** :

   - Le programme commence par charger les données du fichier JSON (`quizzes.json`), qui contient différentes catégories de quiz.
   - Les données sont désérialisées à l'aide de la classe `QuizData`, qui a une liste de catégories (`Category`).

2. **Menu principal** :

   - L'utilisateur est accueilli par le programme, qui affiche le nombre de catégories chargées à partir du fichier JSON.
   - L'utilisateur peut choisir entre deux options :
     - **Sélectionner une catégorie spécifique** (choix 1).
     - **Choisir une catégorie au hasard** (choix 2).

3. **Sélection d'une catégorie spécifique** :

   - Si l'utilisateur choisit l'option de sélection, le programme affiche la liste des catégories avec les numéros associés.
   - L'utilisateur peut entrer le numéro de la catégorie qu'il souhaite jouer.
   - Le quiz pour la catégorie sélectionnée est ensuite lancé.

4. **Choix d'une catégorie au hasard** :

   - Si l'utilisateur choisit l'option au hasard, le programme sélectionne aléatoirement une catégorie parmi celles chargées.
   - Le programme affiche la catégorie choisie et lance le quiz correspondant.

5. **Jouer au quiz** :

   - Le jeu de quiz est géré par la méthode `PlayQuiz`.
   - Les questions, options et réponses correctes sont affichées à l'utilisateur.
   - L'utilisateur entre ses réponses et le programme vérifie si les réponses sont correctes.
   - À la fin du quiz, le programme affiche le score final de l'utilisateur pour la catégorie.

6. **Méthode de validation des réponses** :

   - La méthode `GetReponse` s'assure que la saisie de l'utilisateur est valide en vérifiant qu'il s'agit d'un entier et qu'il est dans la plage des options disponibles.

7. **Structure des données** :

   - Les données du quiz sont organisées dans les classes `QuizData` et `Category`.
   - Chaque catégorie a un nom, des questions, des options et des réponses correctes.

8. **Chargement des quiz à partir d'un fichier JSON** :
   - La méthode `LoadQuizzesFromJson` est responsable du chargement des données à partir du fichier JSON.

## Comment utiliser le programme

1. Assurez-vous d'avoir un fichier JSON valide (`quizzes.json`) contenant des données de quiz.
2. Compilez et exécutez le programme.
3. Suivez les instructions pour sélectionner une catégorie spécifique ou en choisir une au hasard.
4. Répondez aux questions du quiz et découvrez votre score final.

Amusez-vous à tester vos connaissances avec ce programme de quiz interactif en C#!
