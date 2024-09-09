using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaduMänguLoomine
{
    internal class Figure
    {
        protected List<Point> pList; //protected - Et muutuv pList oleks pärijatel nähtav

        public void Drow()
        {
            foreach (Point p in pList)
            {
                p.Draw();
            }
        }
    }
}
