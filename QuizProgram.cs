
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

class QuizProgram
{
    static void Main()
    {
        // Charger les données des quizzes depuis un fichier JSON
        string jsonFilePath = "quizzes.json";
        QuizData? quizData = LoadQuizzesFromJson(jsonFilePath);

        if (quizData == null || quizData.Categories == null)
        {
            Console.WriteLine("Erreur lors du chargement des quizzes depuis le fichier JSON.");
            return;
        }

        Console.WriteLine($"Nombre de catégories chargées : {quizData.Categories.Count}");

        // Welcoming !
        Console.WriteLine("Bienvenue dans le programme de quiz !");

        // Afficher les catégories disponibles
        Console.WriteLine("Choisissez une catégorie :");
        for (int i = 0; i < quizData.Categories.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {quizData.Categories[i]?.Name}");
        }

        int categoryChoice = GetReponse(quizData.Categories.Count);

        // Vérifier si la catégorie choisie est valide
        if (categoryChoice < 1 || categoryChoice > quizData.Categories.Count)
        {
            Console.WriteLine("Catégorie invalide.");
            return;
        }

        // Récupérer les questions, options et réponses correctes pour la catégorie choisie
        var currentCategory = quizData.Categories[categoryChoice - 1];

        string? categoryName = currentCategory?.Name;
        string[]? questions = currentCategory?.Questions;
        string[][]? options = currentCategory?.Options;
        int[]? correctAnswers = currentCategory?.CorrectAnswers;

        // Créer un tableau pour stocker les réponses correctes
        if (questions == null || questions.Length == 0 || correctAnswers == null)
        {
            Console.WriteLine("Aucune question n'a été récupérée pour cette catégorie.");
            return;
        }

        bool[] isAnswerCorrect = new bool[questions.Length];

        // Afficher les questions et obtenir les réponses
        for (int i = 0; i < questions.Length; i++)
        {
            Console.WriteLine(questions[i]);

            // Afficher les options
            for (int j = 0; options != null && j < options[i].Length; j++)
            {
                Console.WriteLine(options[i][j]);
            }

            // Obtenir la réponse de l'utilisateur
            int userChoice = GetReponse(options?[i]?.Length ?? 0);

            // Vérifier si la réponse est correcte et enregistrer le résultat (True ou False)
            isAnswerCorrect[i] = (correctAnswers?[i] == userChoice);

            // Afficher le message en fonction de la réponse
            if (isAnswerCorrect[i])
            {
                Console.WriteLine("Correct !\n");
            }
            else
            {
                Console.WriteLine($"Incorrect. La réponse correcte était : {options?[i][correctAnswers[i] - 1]}\n");
            }
        }

        // Calculer le score
        int score = isAnswerCorrect.Count(c => c);

        // Afficher le score
        Console.WriteLine($"Votre score final pour la catégorie '{categoryName}' : {score} sur {questions.Length}");

        // Ajouter d'autres traitements en fonction des réponses ici

        Console.ReadLine();
    }

    // Méthode pour obtenir la réponse de l'utilisateur en s'assurant qu'elle est valide
    static int GetReponse(int numberOfOptions)
    {
        int choix;
        do
        {
            Console.Write($"Entrez le numéro de votre réponse (1-{numberOfOptions}) : ");
        } while (!int.TryParse(Console.ReadLine(), out choix) || choix < 1 || choix > numberOfOptions);

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
