using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaduMänguLoomine
{
    public class Point
    {
        public int x;
        public int y;
        public char sym;



        public Point() 
        {
        }

        public Point(int x, int y, char sym)
        {
            this.x = x;
            this.y = y;
            this.sym = sym;
            
        }

        public Point(Point p) //for Snake
        {
            x=p.x;
            y=p.y;
            sym = p.sym;
            
        }

        internal void Move(int offset, Direction direction)
        {
            if (direction == Direction.Right)
            {
                x = x + offset;
            }
            else if (direction == Direction.Left)
            {
                x = x - offset;
            }
            else if (direction == Direction.Up)
            {
                y = y - offset;
            }
            else if (direction == Direction.Down)
            {
                y = y + offset;
            }
        }
        public bool IsHit(Point p)
        {
            return p.x == this.x && p.y == this.y;
        }
        
        public void Draw()
        {
            Console.SetCursorPosition(x,y);
            Console.Write(sym);
        }
        public void Clear()
        {
            sym = ' ';
            Draw();
        }
        public override string ToString()
        {
            return x + "," + y + "," + sym;
        }
    }
}
