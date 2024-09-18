using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaduMänguLoomine
{
    internal class Players
    {
        private string Nimi;
        private int Tulemus;
        public Players(string nimi, int tulemus)
        {
            this.Nimi = nimi;
            this.Tulemus = tulemus;
            SaveResult();
        }


        private void SaveResult()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"..\..\..\Nimi.txt", true))
                {
                    writer.WriteLine($"{Nimi}: {Tulemus} result");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Faili salvestamine ebaõnnestus");
            }
        }


        public static void DisplayResults()
        {
            try
            {
                if (File.Exists(@"..\..\..\Nimi.txt"))
                {
                    Console.WriteLine("\nSalvestatud tulemused:");

                    using (StreamReader reader = new StreamReader(@"..\..\..\Nimi.txt"))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            Console.WriteLine(line);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Tulemuste fail puudub.");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Tulemuste lugemine ebaõnnestus");
            }
            
        }
    }
}
