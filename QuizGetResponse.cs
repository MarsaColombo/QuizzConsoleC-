
partial class QuizGame
{
    public static int GetResponse(int numberOfOptions)
    {
        int choice;
        bool isInvalidChoice;

        do
        {
            isInvalidChoice = !int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > numberOfOptions;

            if (isInvalidChoice)
            {
                Console.WriteLine("Error: Please enter a number between 1 and " + numberOfOptions + ".");
            }
        } while (isInvalidChoice);

        return choice;
    }
}
