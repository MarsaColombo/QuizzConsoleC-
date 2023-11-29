using System;
using System.IO;

class QuizLoader
{
    public static QuizData? LoadQuizzesFromJson(string filePath)
    {
        try
        {
            string jsonText = File.ReadAllText(filePath);
            return System.Text.Json.JsonSerializer.Deserialize<QuizData>(jsonText);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur lors du chargement du fichier JSON : {ex.Message}");
            return null;
        }
    }
}
