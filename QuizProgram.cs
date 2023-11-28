using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

class QuizProgram
{
    static void Main()
    {
        string jsonFilePath = "quizzes.json";
        QuizData? quizData = LoadQuizzesFromJson(jsonFilePath);

        if (quizData == null || quizData.Categories == null)
        {
            Console.WriteLine("Erreur lors du chargement des quizzes depuis le fichier JSON.");
            Console.WriteLine("Le programme sera ferme.");
            Console.ReadKey();
        }

        Console.WriteLine($"Nombre de catégories chargées : {quizData.Categories.Count}");

        Console.WriteLine("Bienvenue dans le programme de quiz !");

        Console.WriteLine("Choisissez une option :");
        Console.WriteLine("1. Sélectionner une catégorie spécifique");
        Console.WriteLine("2. Choisir une catégorie au hasard");

        int choice = GetReponse(2);

        if (choice == 1)
        {
            SelectCategory(quizData);
        }
        else if (choice == 2)
        {
            RandomCategory(quizData);
        }
    }

    static void SelectCategory(QuizData quizData)
    {
        Console.WriteLine("Choisissez une catégorie :");
        for (int i = 0; i < quizData.Categories.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {quizData.Categories[i]?.Name}");
        }

        int categoryChoice = GetReponse(quizData.Categories.Count);

        if (categoryChoice < 1 || categoryChoice > quizData.Categories.Count)
        {
            Console.WriteLine("Catégorie invalide.");
            return;
        }

        PlayQuiz(quizData.Categories[categoryChoice - 1]);
    }

    static void RandomCategory(QuizData quizData)
    {
        Random random = new Random();
        int randomIndex = random.Next(0, quizData.Categories.Count);

        Console.WriteLine($"Catégorie choisie au hasard : {quizData.Categories[randomIndex]?.Name}");

        PlayQuiz(quizData.Categories[randomIndex]);
    }

    static void PlayQuiz(Category? currentCategory)
    {
        if (currentCategory == null)
        {
            Console.WriteLine("La catégorie est nulle.");
            return;
        }

        string? categoryName = currentCategory.Name;
        string[]? questions = currentCategory.Questions;
        string[][]? options = currentCategory.Options;
        int[]? correctAnswers = currentCategory.CorrectAnswers;

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

            int userChoice = GetReponse(options?[i]?.Length ?? 0);

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

    // Méthode pour obtenir la réponse de l'utilisateur en s'assurant qu'elle est valide
    static int GetReponse(int numberOfOptions)
   {
    int choix;
    bool isInvalidChoice;

    do
    {
        Console.Write($"Entrez le numéro de votre réponse (1-{numberOfOptions}) : ");
        isInvalidChoice = !int.TryParse(Console.ReadLine(), out choix) || choix < 1 || choix > numberOfOptions;

        if (isInvalidChoice)
        {
            Console.WriteLine("Erreur : Veuillez entrer un chiffre entre 1 et 4.");
        }
    } while (isInvalidChoice);

    return choix;
    }

    // Classe pour représenter la structure des quizzes
    public class QuizData
    {
        public List<Category>? Categories { get; set; }
    }

    public class Category
    {
        public string? Name { get; set; }
        public string[]? Questions { get; set; }
        public string[][]? Options { get; set; }
        public int[]? CorrectAnswers { get; set; }
    }

    // Méthode pour charger les quizzes depuis un fichier JSON
    static QuizData? LoadQuizzesFromJson(string filePath)
    {
        try
        {
            string jsonText = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<QuizData>(jsonText);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading JSON file: {ex.Message}");
            return null;
        }
    }
}
