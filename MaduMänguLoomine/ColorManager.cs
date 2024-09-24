using System;

namespace MaduMänguLoomine
{
    public class ColorManager
    {
        public ConsoleColor ChooseSnakeColor(int colorOption)
        {
            ConsoleColor snakeColor;

            if (colorOption == 1)
            {
                snakeColor = ConsoleColor.Red;
            }
            else if (colorOption == 2)
            {
                snakeColor = ConsoleColor.Green;
            }
            else if (colorOption == 3)
            {
                snakeColor = ConsoleColor.Blue;
            }
            else if (colorOption == 4)
            {
                snakeColor = ConsoleColor.Yellow;
            }
            else
            {
                snakeColor = ConsoleColor.White; // Цвет по умолчанию
            }

            return snakeColor;
        }
    }
}