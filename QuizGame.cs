using System;
using System.Linq;

class QuizGame
{
    public static void SelectCategory(QuizData quizData)
    {
        Console.WriteLine("Choisissez une catégorie :");
        for (int i = 0; i < quizData.Categories.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {quizData.Categories[i]?.Name}");
        }

        int categoryChoice = GetResponse(quizData.Categories.Count);

        if (categoryChoice < 1 || categoryChoice > quizData.Categories.Count)
        {
            Console.WriteLine("Catégorie invalide.");
            return;
        }

        PlayQuiz(quizData.Categories[categoryChoice - 1]);
    }

    public static void RandomCategory(QuizData quizData)
    {
        Random random = new();
        int randomIndex = random.Next(0, quizData.Categories.Count);

        Console.WriteLine($"Catégorie choisie au hasard : {quizData.Categories[randomIndex]?.Name}");

        PlayQuiz(quizData.Categories[randomIndex]);
    }

    public static void PlayQuiz(Category currentCategory)
    {
        if (currentCategory == null)
        {
            Console.WriteLine("La catégorie est nulle.");
            return;
        }

        var categoryName = currentCategory.Name;
        var questions = currentCategory.Questions;
        var options = currentCategory.Options;
        var correctAnswers = currentCategory.CorrectAnswers;

        if (questions == null || questions.Length == 0 || correctAnswers == null)
        {
            Console.WriteLine("Aucune question n'a été récupérée pour cette catégorie.");
            return;
        }

        bool[] isAnswerCorrect = new bool[questions.Length];

        for (int i = 0; i < questions.Length; i++)
        {
            Console.WriteLine(questions[i]);

            for (int j = 0; options != null && j < options[i].Length; j++)
            {
                Console.WriteLine(options[i][j]);
            }

            int userChoice = GetResponse(options?[i]?.Length ?? 0);

            isAnswerCorrect[i] = (correctAnswers?[i] == userChoice);

            if (isAnswerCorrect[i])
            {
                Console.WriteLine("Correct !\n");
            }
            else
            {
                Console.WriteLine($"Incorrect. La réponse correcte était : {options?[i][correctAnswers[i] - 1]}\n");
            }
        }

        int score = isAnswerCorrect.Count(c => c);

        Console.WriteLine($"Votre score final pour la catégorie '{categoryName}' : {score} sur {questions.Length}");

        Console.ReadLine();
    }

    public static int GetResponse(int numberOfOptions)
    {
        int choice;
        bool isInvalidChoice;

        do
        {
            Console.Write($"Entrez le numéro de votre réponse (1-{numberOfOptions}) : ");
            isInvalidChoice = !int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > numberOfOptions;

            if (isInvalidChoice)
            {
                Console.WriteLine("Erreur : Veuillez entrer un chiffre entre 1 et 4.");
            }
        } while (isInvalidChoice);

        return choice;
    }
}
