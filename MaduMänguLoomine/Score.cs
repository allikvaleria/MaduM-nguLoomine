using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaduMänguLoomine
{
    class Score
    {
        private int score;
        public Score()
        {
            score = 0;
        }
        public void Score_points(char Food) 
        {
            if (Food == '♠')
            {
                score = score - 10;
            }
            else if (Food == '♣')
            {
                score += 10;
            }
            else if (Food == '♥')
            {
                score += 5;
            }
            else if (Food == '♦')
            {
                score += 15;
            }
            else
            {
                score = 0;
            }

        }
        public void Scored()
        {
            Console.SetCursorPosition(0, 2); 
            Console.WriteLine("Sinu mängu tulemus : " + score);
        }
        public int Tulemus()
        {
            return score;
        }
    }
}
