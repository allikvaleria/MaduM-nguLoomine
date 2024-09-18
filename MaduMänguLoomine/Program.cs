using System;
using System.Collections.Generic;
using System.Linq;
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
            Console.Write("Sisesta oma nimi: ");
            string playerName = Console.ReadLine();
            int score = 0;
            Players player = new Players(playerName, score);

            Console.SetWindowSize(80, 25);
            Walls walls = new Walls(80, 25);
            walls.Draw();

            //Punktide joonistamine 
            Point p = new Point(4, 5, '=');
            Snake snake = new Snake(p, 4, Direction.Right);
            snake.Draw();

            FoodCreator foodCreator = new FoodCreator(80, 25, '¤');
            Point food = foodCreator.CreateFood();
            food.Draw();

            while (true)
            {
                if (walls.IsHit(snake) || snake.IsHitTail())
                {
                    break;
                }
                if (snake.Eat(food))
                {
                    food = foodCreator.CreateFood();
                    food.Draw();


                    //Esimene iseseisev uue funktsiooni lisamine koodi - Heli lisamine

                    IWavePlayer kusanie = new WaveOutEvent();
                    AudioFileReader file = new AudioFileReader("../../../poedanie.mp3");
                    kusanie.Init(file);
                    kusanie.Play();
                }
                else
                {
                    snake.Move();
                }
                Thread.Sleep(100);
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKey(key.Key);
                }
            }
            
            player = new Players(playerName, score);
            Console.WriteLine($"\nMäng läbi, {playerName}! Sinu lõpptulemus on {score} punkti.");
            Console.WriteLine($"\nTulemused salvestatud. Aitäh, et mängisite!");
            Console.ReadLine();
        }
    }
}


