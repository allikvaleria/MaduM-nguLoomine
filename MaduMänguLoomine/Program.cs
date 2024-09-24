using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using NAudio;
using NAudio.Wave;
using static System.Formats.Asn1.AsnWriter;

namespace MaduMänguLoomine
{
    public class Program
    {
        static void Main(string[] args)
        {
            Players players = new Players();
            Sound sound = new Sound("../../../");
            sound.Play("../../../fonovaya.mp3");

            Console.WriteLine("Kas alustada mängu? \n1 - Yes 2 - No");
            string userInput = Console.ReadLine();

            Console.Write("Sisesta oma nimi : ");
            string playerName = Console.ReadLine();
            Start start = new Start();
            Score score = new Score();

            Console.WriteLine("Выберите цвет змейки: \n1 - Красный \n2 - Зеленый \n3 - Синий \n4 - Желтый ");
            ColorManager colorManager = new ColorManager();
            int colorOption = int.Parse(Console.ReadLine());
            ConsoleColor snakeColor = colorManager.ChooseSnakeColor(colorOption);

            Console.Clear();

            Console.SetWindowSize(80, 25);
            Walls walls = new Walls(80, 25);
            walls.Draw();

            //Punktide joonistamine 
            Point p = new Point(4, 5, '~');
            Snake snake = new Snake(p, 4, Direction.Right, snakeColor);
            snake.Draw();

            char[] food_Symbols = { '♠', '♣', '♥', '♦' };
            FoodCreator foodCreator = new FoodCreator(80, 25, food_Symbols);
            List<Point> foodItems = foodCreator.food_for_snake(4);
            
            foreach (var food in foodItems)
            {
                food.Draw();
            }

            while (true)
            {
                if (walls.IsHit(snake) || snake.IsHitTail())
                {
                    sound.PlayGameOver();
                    Thread.Sleep(1000);

                    players.Salvesta_faili(playerName, score);
                    break;
                }
                for (int i = 0; i < foodItems.Count; i++)
                {
                    if (snake.Eat(foodItems[i]))
                    {
                        score.Score_points(foodItems[i].sym);
                        score.Scored();
                        sound.PlayEat();
                        //Kui toit on söödud, loome selle uude kohta (Если еда съедена, создаём её на новом месте)
                        Point newFood = foodCreator.CreateFood();
                        foodItems[i] = newFood;
                        newFood.Draw();
                    }
                }
                snake.Move();
                Thread.Sleep(100);
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKey(key.Key);
                }
            }
            sound.Stop();
            sound.PlayGameOver();
            Console.Clear();
            players.Naitab_faili();
        }
    }
}
