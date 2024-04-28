using System;

class Program
{
    static void Main(string[] args)
    {
        /*
            the grading scheme:
            A >= 90, B >= 80, C >= 70, D >= 60, F < 60
            Add '+' last number is >= 7, else '-'. There's no A+
        */

        Console.Write("Enter the your grade (please omit the '%' sign ): ");
        string theGrade = Console.ReadLine();

        if (int.TryParse(theGrade, out int studentGrade))
        {
            string letterGrade = "";
            char plusOrMinus = studentGrade % 10 >= 7 ? '+' : '-';

            if (studentGrade >= 90)
            {
                letterGrade = $"A{(plusOrMinus == '+' ? ' ' : plusOrMinus)}";
            }

            else if (studentGrade >= 80 && studentGrade <= 89 )
            {
              letterGrade = $"B{plusOrMinus}";
            }

            else if (studentGrade >= 70 && studentGrade <= 79 )
            {
              letterGrade = $"C{plusOrMinus}";
            }

            else if (studentGrade >= 60 && studentGrade <= 69 )
            {
              letterGrade = $"D{plusOrMinus}";
            }

            else if (studentGrade <= 59)
            {
              letterGrade = "F";
            }

            Console.WriteLine($"You got a {letterGrade}. {(letterGrade == "F" ? "I believe in you. You are going to get it next time" : "Congratulations, you passed.")}");
        }
        else
        {
            Console.WriteLine("Please enter a valid number not a world");
        }
    }
}