using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MaduMänguLoomine
{
    internal class Players
    {
        private string fail = @"..\..\..\Nimi.txt"; 
        public Players() { }
        public void Salvesta_faili(string playerName, Score scored_)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(fail, true))
                {
                    sw.WriteLine($"{playerName}: {scored_.Tulemus()} points");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void Naitab_faili()
        {
            try
            {
                StreamReader sr = new StreamReader(fail);
                string lines = sr.ReadToEnd();
                Console.WriteLine(lines);
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
