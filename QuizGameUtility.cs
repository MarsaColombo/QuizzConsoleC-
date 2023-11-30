using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

partial class QuizGame
{
    private static void StartTimer(int milliseconds, int questionIndex, Stopwatch stopwatch, CancellationToken cancellationToken)
    {
        try
        {
            Task.Delay(milliseconds, cancellationToken).Wait();

            if (userChoice == 0)
            {
                Console.WriteLine($"Temps écoulé pour la question {questionIndex + 1} ! Temps total : {stopwatch.Elapsed.TotalSeconds} secondes");
                Console.WriteLine("\nAppuyer entrer pour continuer...");
                userChoice = -1; // Set a special value to indicate that time has expired
            }
        }
        catch (TaskCanceledException)
        {
            // Timer was canceled by user input
        }
    }

    public static void GetUserInput(int numberOfOptions, CancellationTokenSource cts)
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
}
