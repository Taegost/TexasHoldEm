using System;
using TexasHoldEm.Library;
using static System.Console;

namespace TexasHoldEm
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine(
                "Welcome to Wheway's World of Texas Hold'Em!\n" +
                "Buy in is $50, each chip is worth $1.");
            bool exitLoop = false;
            ConsoleKey response;
            do
            {

                Write("Do you want to play? (y/n)");
                response = ReadKey().Key;
                WriteLine();
                if ((response == ConsoleKey.Y) || (response == ConsoleKey.N)) { break; }
                else
                { WriteLine("Please choose either Y or N"); }
            } while (exitLoop == false);

            if (response == ConsoleKey.N)
            {
                WriteLine("Maybe next time!");
                return;
            } // if (response == ConsoleKey.N)

            WriteLine("Thank you!  What is your name?");
            PlayingField playField = new PlayingField(ReadLine());
            Game newGame = new Game(playField);
            newGame.Launch();
            WriteLine("Thank you for playing, we hope you had a great time!");
            WriteLine("Press any key to continue...");
            ReadKey();
        } // Main
    }
}
