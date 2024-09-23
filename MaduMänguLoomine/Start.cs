using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaduMänguLoomine
{
    public class Start 
    {
        public static void ShowStartScreen()
        {
            Console.WriteLine("Start game? (1 - Yes, 2 - No)");
            string userInput = Console.ReadLine();

            if (userInput == "1")
            {
                StartGame();
            }
            else if (userInput == "2")
            {
                Console.WriteLine("Mäng lõppenud");
                return;
            }
            else
            {
                Console.WriteLine("Vale sisend. Palun käivitage mäng uuesti ja sisestage 1 või 2.");
            }

            static void StartGame()
            {
                Console.Write("Sisesta oma nimi: ");

            }



        }
    }
}


