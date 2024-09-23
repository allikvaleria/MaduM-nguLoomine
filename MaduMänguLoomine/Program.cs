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
            Console.WriteLine("Start game? (1 - Yes, 2 - No)");
            string userInput = Console.ReadLine();
            Console.Write("Sisesta oma nimi: ");
            string playerName = Console.ReadLine();
            Start start = new Start();
            Console.ReadLine();

            Score score = new Score();


            Console.Clear();

            Console.SetWindowSize(80, 25);
            Walls walls = new Walls(80, 25);
            walls.Draw();

            //Punktide joonistamine 
            Point p = new Point(4, 5, '=');
            Snake snake = new Snake(p, 4, Direction.Right);
            snake.Draw();

            char[] food_Symbols = { '♠', '♣', '♥', '♦' };
            FoodCreator foodCreator = new FoodCreator(80, 25, food_Symbols);
            List<Point> foodItems = foodCreator.food_for_snake(4);
            Point food = foodCreator.CreateFood();
            food.Draw();

            while (true)
            {
                if (walls.IsHit(snake) || snake.IsHitTail())
                {

                    players.Salvesta_faili(playerName, score);
                    break;
                }
                for (int i = 0; i < foodItems.Count; i++)
                {
                    if (snake.Eat(foodItems[i]))
                    {
                        score.Score_points(foodItems[i].sym);
                        score.Scored();
                        //Kui toit on söödud, loome selle uude kohta (Если еда съедена, создаём её на новом месте)
                        Point newFood = foodCreator.CreateFood();
                        foodItems[i] = newFood;
                        newFood.Draw();
                        food = foodCreator.CreateFood();
                        food.Draw();
                    }
                }
                if (snake.Eat(food))
                {
                    

                    
                    IWavePlayer kusanie = new WaveOutEvent();
                    AudioFileReader file = new AudioFileReader("../../../poedanie.mp3");
                    kusanie.Init(file);
                    kusanie.Play();
                }
                snake.Move();
                Thread.Sleep(100);
                if (Console.KeyAvailable)

                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKey(key.Key);
                }
            }
            Console.Clear();
            players.Naitab_faili();
        }
    }
}




