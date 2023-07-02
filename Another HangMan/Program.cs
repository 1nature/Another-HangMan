namespace Another_HangMan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("HangMan Project\n");
            const char PLACEHOLDER = '_';


            List<string> wordsToGuess = new List<string>();

            wordsToGuess.Add("supplier");
            wordsToGuess.Add("employer");
            wordsToGuess.Add("contractor");
            wordsToGuess.Add("manager");

            Random random = new Random();
            int index = random.Next(wordsToGuess.Count);
            String randomWordToGuess = wordsToGuess[index];
            char[] guessedWord = new char[randomWordToGuess.Length];
            
            int rightLetterCount = 0;
            int maxTriesLeft = randomWordToGuess.Length;


            for (int y = 0; y < guessedWord.Length; y++)
            {
                guessedWord[y] = PLACEHOLDER;
            }

            Console.WriteLine(randomWordToGuess);
            Console.WriteLine(guessedWord);
            Console.WriteLine();
            bool isGuessCorrect = false;

            while (true)
            {
                Console.WriteLine("Please enter a guess: \n");
                char userInput = char.Parse(Console.ReadLine());
                Console.WriteLine();

                if (randomWordToGuess.Contains(userInput))
                {
                    isGuessCorrect = true;

                }
                else {isGuessCorrect = false;}

                if (isGuessCorrect)
                {
                    for (int i = 0; i < randomWordToGuess.Length; i++)
                    {
                        if (userInput == randomWordToGuess[i])
                        {
                            
                            guessedWord[i] = userInput;
                            
                            Console.WriteLine("Number of guesses made: {0}", rightLetterCount++);
                            
                        }
                    }
                    Console.WriteLine($"{userInput}: right guess");
                    Console.WriteLine(guessedWord);
                    Console.WriteLine("---------------------\n");


                    if (guessedWord.Length == rightLetterCount)
                    {
                        Console.WriteLine("You win");
                        break;
                    }
                }
                else if (!isGuessCorrect)
                {
                    Console.WriteLine($"{userInput} is a wrong guess; try again");
                    
                    Console.WriteLine("Number of guesses left: {0}", maxTriesLeft--);

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