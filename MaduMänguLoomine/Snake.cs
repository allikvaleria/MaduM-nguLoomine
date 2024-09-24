using MaduMänguLoomine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaduMänguLoomine
{
    class Snake : Figure
    {
        private Direction direction;
        private ConsoleColor color;

        public Snake(Point startPoint, int length, Direction direction, ConsoleColor color)
        {
            this.direction = direction;
            this.color = color;
            pList = new List<Point> { startPoint };
            for (int i = 0; i < length; i++)
            {
                Point p = new Point(startPoint);
                p.Move(i, direction);
                pList.Add(p);
            }
        }

        internal void Move()
        {
            Point tail = pList.First();
            pList.Remove(tail);
            Point head = GetNextPoint();
            pList.Add(head);
            Console.ForegroundColor = color;
            tail.Clear();
            head.Draw();
            Console.ResetColor();
        }

        public Point GetNextPoint()
        {
            Point head = pList.Last();
            pList.Last().sym = '*';
            Point nextPoint = new Point(head);
            nextPoint.Move(1, direction);
            return nextPoint;
        }


        internal bool IsHitTail()
        {
            var head = pList.Last();
            for (int i = 0; i < pList.Count - 2; i++)
            {
                if (head.IsHit(pList[i]))
                    return true;
            }
            return false;
        }

        public void HandleKey(ConsoleKey key)
        {
            if (key == ConsoleKey.LeftArrow)
                direction = Direction.Left;
            else if (key == ConsoleKey.RightArrow)
                direction = Direction.Right;
            else if (key == ConsoleKey.DownArrow)
                direction = Direction.Down;
            else if (key == ConsoleKey.UpArrow)
                direction = Direction.Up;
        }

        internal bool Eat(Point food)
        {
            Point head = GetNextPoint();
            if (head.IsHit(food))
            {
                pList.Add(food);
                return true;
            }
            else
                return false;
        }

        public void Drow()
        {
            foreach (var point in pList)
            {
                Console.ForegroundColor = color;
                point.Draw();
            }
            Console.ResetColor();
        }
    }
}
