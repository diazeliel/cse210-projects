using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("----------------- Welcome to GUESS THE MAGICNUMBER -----------------------\n");
        bool isContinue = true;

        static int GetMagicNumber()
        {
            Random randomNum = new();
            return randomNum.Next(1, 101);
        }

        static void PlayGame()
        {
            int magicNumber = GetMagicNumber();
            int userGuess;
            Console.WriteLine($"The computer is thinking of a magic number from 1 - 100");
            int count = 0;
            string message = "";


            do
            {
                
                Console.Write("Guess the magic number: "); 
                userGuess = int.Parse(Console.ReadLine());
                Console.Clear();

                if (userGuess == magicNumber)
                {
                    message = $"You guessed right!.. The magic number is: {magicNumber}\nYou got it right in {count} try(ies).";
                }

                else if (userGuess > magicNumber)
                {
                message = " lower ";
                }

                else if (userGuess < magicNumber)
                {
                message = " higher ";
                }

                count++;
                Console.WriteLine(message);

            } while (magicNumber != userGuess);
            
        }

        while (isContinue)
        {
          PlayGame();
          Console.Write("\nWant to give another try? (type 'Yes' to continue): ");
          string userChoice = Console.ReadLine().ToLower();
          isContinue = userChoice == "yes" ? isContinue : false;
          Console.Clear();
        }
    
    }
}