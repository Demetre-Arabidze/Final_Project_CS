namespace NumberGuessing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            int min = 1;
            int max = 100;

            int secretNumber = random.Next(min, max + 1);
            int attempts = 0;
            bool guessedCorrectly = false;

            Console.WriteLine("Welcome to the Guess the Number Game");
            Console.WriteLine($"I'm thinking of a number between {min} and {max}.");

            while (!guessedCorrectly)
            {
                Console.Write("Enter your guess: ");
                string input = Console.ReadLine();

                int guess;

                if (!int.TryParse(input, out guess))
                {
                    Console.WriteLine("Please enter a valid number.");
                    continue;
                }

                if (guess < min || guess > max)
                {
                    Console.WriteLine($"Please enter a number between {min} and {max}.");
                    continue;
                }

                attempts++;

                if (guess < secretNumber)
                {
                    Console.WriteLine("Its low. Try a higher number.");
                }
                else if (guess > secretNumber)
                {
                    Console.WriteLine("its high. Try a lower number.");
                }
                else
                {
                    guessedCorrectly = true;
                    Console.WriteLine($"Congrats! The number was {secretNumber}.");
                    Console.WriteLine($"You guessed it in {attempts} attempts.");
                }
            }

            Console.WriteLine("Thanks for playing!");
        }
    }
}
