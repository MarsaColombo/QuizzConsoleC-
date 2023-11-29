using System;

class QuizProgram
{
    static void Main()
    {
        string filePath = "quizzes.json";
        QuizData? quizData = QuizLoader.LoadQuizzesFromJson(filePath);

        if (quizData == null || quizData.Categories == null)
        {
            Console.WriteLine("Erreur lors du chargement des quizzes depuis le fichier JSON.");
            Console.WriteLine("Le programme sera fermé.");
            Console.ReadKey();
            return;
        }

        Console.WriteLine($"Nombre de catégories chargées : {quizData.Categories.Count}");

        Console.WriteLine("Bienvenue dans le programme de quiz !");

        Console.WriteLine("Choisissez une option :");
        Console.WriteLine("1. Sélectionner une catégorie spécifique");
        Console.WriteLine("2. Choisir une catégorie au hasard");

        int choice = QuizGame.GetResponse(2);

        if (choice == 1)
        {
            QuizGame.SelectCategory(quizData);
        }
        else if (choice == 2)
        {
            QuizGame.RandomCategory(quizData);
        }
    }
}
