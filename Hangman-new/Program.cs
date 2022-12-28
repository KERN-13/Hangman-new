using System;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Hangman! You'll have 6 guesses to try and guess the correct word. Good luck!");
            while (true)
            {

                // Create a dictionary of categories and their corresponding words.
                Dictionary<string, string[]> categories = new Dictionary<string, string[]>();
                categories["FRUIT"] = new string[] { "apple", "orange", "banana", "grape", "strawberry" };
                categories["VEGETABLES"] = new string[] { "carrot", "tomato", "lettuce", "potato", "onion" };
                categories["ANIMALS"] = new string[] { "lion", "tiger", "elephant", "giraffe", "hippo" };

                // Prompt the user to choose a category.
                Console.WriteLine("\nChoose a category: ");
                foreach (string category in categories.Keys)
                {
                    Console.WriteLine($"\n {category}");
                }

                Console.WriteLine("\n");
                string chosenCategory = Console.ReadLine().ToUpper();

                // Choose a random word from the selected category.
                string[] chosenWords = categories[chosenCategory];
                Random rnd = new Random();
                int index = rnd.Next(chosenWords.Length);
                string word = chosenWords[index];

                // Create an array of underscores the same length as the word, to track the user's progress.
                char[] progress = new char[word.Length];
                for (int i = 0; i < progress.Length; i++)
                {
                    progress[i] = '_';
                }

                int remainingGuesses = 6;

                // Keep looping until the user has either won or lost.
                while (true)
                {
                    // Print the current progress and remaining guesses.
                    Console.WriteLine(progress);
                    Console.WriteLine($"You have {remainingGuesses} guesses remaining.");

                    // Get the user's next guess.
                    Console.Write("Enter a letter: ");
                    char guess = Console.ReadLine().ToLower()[0];

                    // Check if the guess is in the word.
                    bool isCorrect = false;
                    for (int i = 0; i < word.Length; i++)
                    {
                        if (word[i] == guess)
                        {
                            progress[i] = guess;
                            isCorrect = true;
                        }
                    }

                    // If the guess was incorrect, decrement the remaining guesses.
                    if (!isCorrect)
                    {
                        remainingGuesses--;
                    }

                    // Check if the user has won or lost.
                    bool hasWon = true;
                    for (int i = 0; i < progress.Length; i++)
                    {
                        if (progress[i] == '_')
                        {
                            hasWon = false;
                            break;
                        }
                    }

                    if (hasWon)
                    {
                        Console.WriteLine("You win!");
                        break;
                    }
                    else if (remainingGuesses == 0)
                    {
                        Console.WriteLine("You lose!");
                        break;
                    }
                }
                Console.WriteLine("Do you want to play again (y/n)? ");
                string input = Console.ReadLine().ToLower();

                // If the user doesn't want to play again, break out of the loop.
                if (input != "y")
                {
                    break;
                }
            }
        }
    }
}