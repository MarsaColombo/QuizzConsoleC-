using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

class QuizGame
{
    private static int userChoice;

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

        if (questions == null || options == null || correctAnswers == null || questions.Length != options.Length || questions.Length != correctAnswers.Length)
        {
            Console.WriteLine("Erreur : Les données de la catégorie sont invalides.");
            return;
        }

        bool[] isAnswerCorrect = new bool[questions.Length];

        for (int i = 0; i < questions.Length; i++)
        {
            Console.WriteLine(questions[i]);

            if (options != null && i < options.Length && options[i] != null)
            {
                foreach (var option in options[i])
                {
                    Console.WriteLine(option);
                }
            }

            userChoice = 0;

            // Set up a timer for 10 seconds in a separate thread
            var cts = new CancellationTokenSource();
            var stopwatch = new Stopwatch();
            var timerTask = Task.Run(() => StartTimer(10000, i, stopwatch, cts.Token));

            stopwatch.Start(); // Start the stopwatch

            Console.WriteLine("Entrez votre réponse : ");

            // Wait for the user to respond or for the timer to expire
            GetUserInput(options?[i]?.Length ?? 0, cts);

            // Stop the timer
            cts.Cancel();
            stopwatch.Stop(); // Stop the stopwatch

            if (userChoice == 0)
            {
                Console.WriteLine($"Aucune réponse donnée à temps ! Temps écoulé : {stopwatch.Elapsed.TotalSeconds} secondes");
                Console.WriteLine("Appuyer entrer pour continuer");
            }
            else
            {
                isAnswerCorrect[i] = (correctAnswers != null && i < correctAnswers.Length && correctAnswers[i] == userChoice);

                if (isAnswerCorrect[i])
                {
                    Console.WriteLine("\nCorrect !");
                    Console.WriteLine($"\nTemps écoulé : {stopwatch.Elapsed.TotalSeconds} secondes\n");
                }
                else if (options != null && i < options.Length && correctAnswers != null && i < correctAnswers.Length)
                {
                    int correctIndex = correctAnswers[i] - 1;

                    if (correctIndex >= 0 && correctIndex < options[i].Length)
                    {
                        Console.WriteLine($"\nIncorrect. La réponse correcte était : {options[i][correctIndex]}.");
                        Console.WriteLine($"\nTemps écoulé : {stopwatch.Elapsed.TotalSeconds} secondes\n");
                    }
                    else
                    {
                        Console.WriteLine("\nErreur : L'indice de la réponse correcte est hors des limites.\n");
                    }
                }
            }
        }

        int score = isAnswerCorrect.Count(c => c);

        Console.WriteLine($"Votre score final pour la catégorie '{categoryName}' : {score} sur {questions.Length}");

        Console.ReadLine(); // Attendre une entrée utilisateur à la fin du quiz
    }

    private static void StartTimer(int milliseconds, int questionIndex, Stopwatch stopwatch, CancellationToken cancellationToken)
    {
        try
        {
            Task.Delay(milliseconds, cancellationToken).Wait();

            if (userChoice == 0)
            {
                Console.WriteLine($"Temps écoulé pour la question {questionIndex + 1} ! Temps total : {stopwatch.Elapsed.TotalSeconds} secondes");
                userChoice = -1; // Set a special value to indicate that time has expired
            }
        }
        catch (TaskCanceledException)
        {
            // Timer was canceled by user input
        }
    }

    private static void GetUserInput(int numberOfOptions, CancellationTokenSource cts)
    {
        int choice;
        bool isInvalidChoice;

        do
        {
            if (userChoice == -1)
            {
                // Skip user input if the time has expired
                return;
            }

            isInvalidChoice = !int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > numberOfOptions;

            if (isInvalidChoice)
            {
                Console.WriteLine("Erreur : Veuillez entrer un chiffre entre 1 et 4.");
            }
            else
            {
                userChoice = choice;
            }
        } while (isInvalidChoice && !cts.Token.IsCancellationRequested);
    }

    public static int GetResponse(int numberOfOptions)
    {
        int choice;
        bool isInvalidChoice;

        do
        {
            isInvalidChoice = !int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > numberOfOptions;

            if (isInvalidChoice)
            {
                Console.WriteLine("Erreur : Veuillez entrer un chiffre entre 1 et 4.");
            }
        } while (isInvalidChoice);

        return choice;
    }
}
