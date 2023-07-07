namespace Another_HangMan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("HangMan Project\n");
            const char PLACEHOLDER = '_';
            List<string> wordsToGuess = new List<string> { "employer", "supplier", "manager", "contractor" };

            Random random = new Random();
            int index = random.Next(wordsToGuess.Count);
            String randomWordToGuess = wordsToGuess[index];
            char[] guessedWord = new char[randomWordToGuess.Length];

            int rightLetterCount = 0;
            int maxTriesLeft = randomWordToGuess.Length;

            for (int placeholderCount = 0; placeholderCount < guessedWord.Length; placeholderCount++)
            {
                guessedWord[placeholderCount] = PLACEHOLDER;
            }

            Console.WriteLine(guessedWord);
            Console.WriteLine();

            Console.WriteLine("Please enter a guess: \n");
            while (true)
            {
                char userInput = char.Parse(Console.ReadLine());
                Console.WriteLine();

                if (randomWordToGuess.Contains(userInput))
                {
                    for (int rightGuessCount = 0; rightGuessCount < randomWordToGuess.Length; rightGuessCount++)
                    {
                        if (userInput == randomWordToGuess[rightGuessCount])
                        {
                            guessedWord[rightGuessCount] = userInput;
                            ++rightLetterCount;
                        }
                    }
                    Console.WriteLine($"{userInput} is a right guess");
                    Console.WriteLine(guessedWord);
                    Console.WriteLine("Number of correctly guessed letters = {0}", rightLetterCount);
                    Console.WriteLine("---------------------\n");
                    if (guessedWord.Length == rightLetterCount)
                    {
                        Console.WriteLine("You win");
                        Console.WriteLine($"The hidden word is: {randomWordToGuess}");
                        break;
                    }
                }
                else if (!randomWordToGuess.Contains (userInput)) 
                {
                    --maxTriesLeft;
                    Console.WriteLine($"{userInput} is a wrong guess; try again. Guesses left = {maxTriesLeft}");

                    if (maxTriesLeft == 0)
                    {
                        Console.WriteLine("You lose");
                        break;
                    }
                }
            }
            Console.WriteLine("End of the game");
        }
    }
}