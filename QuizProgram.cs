class QuizProgram
{
    static void Main()
    {
        // Créer des catégories
        string[] categories = { "Géographie", "Littérature", "Science", "Histoire"};

        // Créer un dictionnaire pour stocker les questions, options et réponses correctes pour chaque catégorie
        Dictionary<string, (string[], string[][], int[])> quizzes = new Dictionary<string, (string[], string[][], int[])>
        {
            {
                "Géographie", (
                    new string[]
                    {
                        "Quel est le plus grand océan du monde ?",
                        "Quelle est la capitale du Japon ?",
                        "Quel est le plus grand désert du monde en termes de superficie ?",
                        "Quelle est la plus grande île du monde ?",
                        "Quel est le pays le plus peuplé au monde ?",
                        "Quelle est la capitale de la France ?",
                        "Quel est le plus haut sommet d'Afrique ?",
                        "Quel est le plus long fleuve d'Europe ?"
                    },
                    new string[][]
                    {
                        new string[] { "1. Océan Atlantique", "2. Océan Indien", "3. Océan Pacifique", "4. Océan Arctique" },
                        new string[] { "1. Tokyo", "2. Pékin", "3. Séoul", "4. Bangkok" },
                        new string[] { "1. Sahara", "2. Gobi", "3. Antarctique", "4. Kalahari" },
                        new string[] { "1. Groenland", "2. Madagascar", "3. Borneo", "4. Nouvelle-Guinée" },
                        new string[] { "1. Chine", "2. Inde", "3. États-Unis", "4. Indonésie" },
                        new string[] { "1. Paris", "2. Berlin", "3. Londres", "4. Rome" },
                        new string[] { "1. Kilimandjaro", "2. Mont Elbrouz", "3. Mont Everest", "4. Mont McKinley" },
                        new string[] { "1. Volga", "2. Danube", "3. Tamise", "4. Rhin" }
                    },
                    new int[] { 3, 1, 1, 1, 1, 1, 3, 1 }
                )
            },
            {
                "Littérature", (
                    new string[]
                    {
                        "Qui a écrit la pièce de théâtre 'Roméo et Juliette' ?",
                        "Qui a peint la Joconde ?",
                        "Qui a écrit 'Hamlet' ?",
                        "Quel écrivain français a écrit 'Les Misérables' ?",
                        "Quelle auteure a écrit 'Orgueil et Préjugés' ?",
                        "Quel poète a écrit 'Le Corbeau' ?",
                        "Qui a écrit 'Don Quichotte' ?",
                        "Quelle écrivaine américaine a écrit 'To Kill a Mockingbird' ?"
                    },
                    new string[][]
                    {
                        new string[] { "1. William Shakespeare", "2. Victor Hugo", "3. Molière", "4. Anton Tchekhov" },
                        new string[] { "1. Leonardo da Vinci", "2. Michel-Ange", "3. Pablo Picasso", "4. Vincent van Gogh" },
                        new string[] { "1. William Shakespeare", "2. Christopher Marlowe", "3. Thomas Kyd", "4. John Webster" },
                        new string[] { "1. Victor Hugo", "2. Gustave Flaubert", "3. Alexandre Dumas", "4. Emile Zola" },
                        new string[] { "1. Jane Austen", "2. Charlotte Brontë", "3. Emily Brontë", "4. Louisa May Alcott" },
                        new string[] { "1. Edgar Allan Poe", "2. Emily Dickinson", "3. Walt Whitman", "4. Robert Frost" },
                        new string[] { "1. Miguel de Cervantes", "2. Gabriel Garcia Marquez", "3. Jorge Luis Borges", "4. Isabel Allende" },
                        new string[] { "1. Harper Lee", "2. J.K. Rowling", "3. Sylvia Plath", "4. Toni Morrison" }
                    },
                    new int[] { 1, 1, 1, 2, 1, 1, 1, 1 }
                )
            },
           {
                "Science", (
                    new string[]
                    {
                        "Quel est le modèle atomique de base ?",
                        "Quelle est la planète la plus proche du soleil ?",
                        "Quel est l'élément chimique le plus abondant dans l'univers ?",
                        "Quelle est la formule chimique de l'eau ?",
                        "Quelle est la plus grande planète du système solaire ?",
                        "Quelle est la première loi de Newton ?",
                        "Quel est l'organe le plus grand du corps humain ?",
                        "Quelle est la vitesse de la lumière dans le vide ?"
                    },
                    new string[][]
                    {
                        new string[] { "1. Modèle de Dalton", "2. Modèle de Rutherford", "3. Modèle de Bohr", "4. Modèle quantique" },
                        new string[] { "1. Mercure", "2. Vénus", "3. Terre", "4. Mars" },
                        new string[] { "1. Hydrogène", "2. Hélium", "3. Oxygène", "4. Carbone" },
                        new string[] { "1. H2O", "2. CO2", "3. N2", "4. O2" },
                        new string[] { "1. Jupiter", "2. Saturne", "3. Uranus", "4. Neptune" },
                        new string[] { "1. Loi de la gravitation universelle", "2. Loi de la conservation de l'énergie", "3. Loi de l'inertie", "4. Loi de l'action et de la réaction" },
                        new string[] { "1. Cœur", "2. Foie", "3. Cerveau", "4. Poumons" },
                        new string[] { "1. 299,792 kilomètres par seconde", "2. 150,000 kilomètres par seconde", "3. 450,000 kilomètres par seconde", "4. 600,000 kilomètres par seconde" }
                    },
                    new int[] { 3, 1, 1, 1, 1, 3, 4, 1 }
                )
            },
            {
                "Histoire", (
                    new string[]
                    {
                        "En quelle année a eu lieu la Révolution française ?",
                        "Qui était le premier président des États-Unis ?",
                        "Quel événement a marqué le début de la Première Guerre mondiale ?",
                        "Quelle civilisation a construit les pyramides de Gizeh ?",
                        "En quelle année le mur de Berlin est-il tombé ?",
                        "Quelle bataille a mis fin à la Guerre de Cent Ans ?",
                        "Qui était le roi de Grande-Bretagne pendant la Révolution américaine ?",
                        "Quel empire a été le plus vaste de l'histoire ?"
                    },
                    new string[][]
                    {
                        new string[] { "1. 1789", "2. 1804", "3. 1830", "4. 1917" },
                        new string[] { "1. Thomas Jefferson", "2. George Washington", "3. John Adams", "4. Abraham Lincoln" },
                        new string[] { "1. L'assassinat de l'archiduc François-Ferdinand", "2. L'attaque de Pearl Harbor", "3. Le traité de Versailles", "4. L'Armistice de 1918" },
                        new string[] { "1. Égyptiens", "2. Grecs", "3. Romains", "4. Mayas" },
                        new string[] { "1. 1989", "2. 1991", "3. 1975", "4. 1963" },
                        new string[] { "1. Bataille de Castillon", "2. Bataille d'Azincourt", "3. Bataille d'Orléans", "4. Bataille de Crécy" },
                        new string[] { "1. George III", "2. George IV", "3. George Washington", "4. George V" },
                        new string[] { "1. Empire romain", "2. Empire mongol", "3. Empire ottoman", "4. Empire britannique" }
                    },
                    new int[] { 1, 2, 1, 1, 1, 1, 1, 4 }
                )
            },

            // Ajoutez d'autres catégories ici...
        };

        //Welcoming !
        Console.WriteLine("Welcome to the Quiz Program!");

        // Afficher les catégories disponibles
        Console.WriteLine("Choisissez une catégorie :");
        for (int i = 0; i < categories.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {categories[i]}");
        }

        // Obtenir la catégorie choisie par l'utilisateur
        int categoryChoice = GetReponse(categories.Length);

        // Récupérer les questions, options et réponses correctes pour la catégorie choisie
        var currentQuiz = quizzes[categories[categoryChoice - 1]];

        string[] questions = currentQuiz.Item1;
        string[][] options = currentQuiz.Item2;
        int[] correctAnswers = currentQuiz.Item3;

        // Créer un tableau pour stocker les réponses correctes
        bool[] isAnswerCorrect = new bool[questions.Length];

        // Afficher les questions et obtenir les réponses
        for (int i = 0; i < questions.Length; i++)
        {
            Console.WriteLine(questions[i]);

            // Afficher les options
            for (int j = 0; j < options[i].Length; j++)
            {
                Console.WriteLine(options[i][j]);
            }

            // Obtenir la réponse de l' 
            int userChoice = GetReponse(options[i].Length);

            // Vérifier si la réponse est correcte et enregistrer le résultat / True ou false
            isAnswerCorrect[i] = (userChoice == correctAnswers[i]);

            // Afficher le message en fonction de la réponse
            if (isAnswerCorrect[i])
            {
                Console.WriteLine("Correct !\n");
            }
            else
            {
                Console.WriteLine($"Incorrect. La réponse correcte était : {options[i][correctAnswers[i] - 1]}\n");
            }
        }

        // Calculer le score
        int score = isAnswerCorrect.Count(c => c);

        // Afficher le score
        Console.WriteLine($"Votre score final : {score} sur {questions.Length}");

        // Ajoutez d'autres traitements en fonction des réponses ici

        Console.ReadLine();
    }

    static int GetReponse(int numberOfOptions)
    {
        int choix;
        do
        {
            Console.Write($"Entrez le numéro de votre réponse (1-{numberOfOptions}) : ");
        } while (!int.TryParse(Console.ReadLine(), out choix) || choix < 1 || choix > numberOfOptions);

        return choix;
    }
}
