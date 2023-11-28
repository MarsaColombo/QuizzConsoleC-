# Quiz Program

Un programme de quiz en ligne en C#.

## Installation

1. Clonez le dépôt git : `https://github.com/MarsaColombo/QuizzConsoleC-.git`
2. Ouvrez le projet dans votre IDE favori.
3. Compilez le projet.

## Contribuer

Les contributions sont les bienvenues ! Si vous souhaitez apporter des améliorations ou corriger des problèmes, veuillez soumettre une pull request.
Bien sûr, voici le README converti en format Markdown (`.md`):

```markdown
# Quiz Program

This C# program is an interactive quiz application that allows users to test their knowledge in various categories. The application uses a JSON file (`quizzes.json`) to store data about questions, categories, options, and correct answers.

## How It Works

1. **Data Loading**:

   - The program starts by loading data from the JSON file (`quizzes.json`), which contains various quiz categories.
   - The data is deserialized using the `QuizData` class, which has a list of categories (`Category`).

2. **Main Menu**:

   - The user is greeted by the program, which displays the number of categories loaded from the JSON file.
   - The user can choose between two options:
     - **Select a Specific Category** (choice 1).
     - **Choose a Category at Random** (choice 2).

3. **Selecting a Specific Category**:

   - If the user chooses the selection option, the program displays the list of categories with associated numbers.
   - The user can enter the number of the category they want to play.
   - The quiz for the selected category is then started.

4. **Choosing a Category at Random**:

   - If the user chooses the random option, the program randomly selects a category from those loaded.
   - The program displays the chosen category and starts the corresponding quiz.

5. **Playing the Quiz**:

   - The quiz game is managed by the `PlayQuiz` method.
   - Questions, options, and correct answers are displayed to the user.
   - The user enters their responses, and the program checks if the answers are correct.
   - At the end of the quiz, the program displays the user's final score for the category.

6. **Response Validation Method**:

   - The `GetReponse` method ensures that the user's input is valid by making sure it is an integer and within the range of available options.

7. **Data Structure**:

   - Quiz data is organized in the `QuizData` and `Category` classes.
   - Each category has a name, questions, options, and correct answers.

8. **Loading Quizzes from a JSON File**:
   - The `LoadQuizzesFromJson` method is responsible for loading data from the JSON file.

## How to Use the Program

1. Ensure you have a valid JSON file (`quizzes.json`) containing quiz data.
2. Compile and run the program.
3. Follow the instructions to select a specific category or choose one at random.
4. Answer the quiz questions and discover your final score.

Enjoy testing your knowledge with this interactive C# quiz program!
```

## Licence
