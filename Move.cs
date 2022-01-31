using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TProjects
{
    static class Input
    {
        public static void move()
        {
            int a;
            int b;
            Random ran = new Random();
            while (true)
            {
                ConsoleKey Key;
                Key = Console.ReadKey().Key;
                if (Key != ConsoleKey.Escape)
                {
                    switch (Key)
                    {
                        case ConsoleKey.S:
                            {
                                Console.SetCursorPosition(0,0);        
                                Map.move(Map.searchX(100), Map.searchY(100), MoveDirection.down);
                                Map.showmap();
                            }
                            break;
                        case ConsoleKey.W:
                            {
                                Console.SetCursorPosition(0, 0);
                                Map.move(Map.searchX(100), Map.searchY(100), MoveDirection.up);
                                Map.showmap();
                            }
                            break;
                        case ConsoleKey.A:
                            {
                                Console.SetCursorPosition(0, 0);
                                Map.move(Map.searchX(100), Map.searchY(100), MoveDirection.left);
                                Map.showmap();
                            }
                            break;
                        case ConsoleKey.D:
                            {
                                Console.SetCursorPosition(0, 0);
                                Map.move(Map.searchX(100), Map.searchY(100), MoveDirection.right);
                                Map.showmap();
                            }
                            break;
                    }
                    a = ran.Next(0, 4) + 1;
                    b = ran.Next(0, 4) + 1;
                    switch (a)
                    {
                        case 1: Map.move(Map.searchX(101), Map.searchY(101), MoveDirection.down); break;
                        case 2: Map.move(Map.searchX(101), Map.searchY(101), MoveDirection.up); break;
                        case 3: Map.move(Map.searchX(101), Map.searchY(101), MoveDirection.right); break;
                        case 4: Map.move(Map.searchX(101), Map.searchY(101), MoveDirection.left); break;
                    }
                    switch (b)
                    {
                        case 1: Map.move(Map.searchX(102), Map.searchY(102), MoveDirection.down); break;
                        case 2: Map.move(Map.searchX(102), Map.searchY(102), MoveDirection.up); break;
                        case 3: Map.move(Map.searchX(102), Map.searchY(102), MoveDirection.right); break;
                        case 4: Map.move(Map.searchX(102), Map.searchY(102), MoveDirection.left); break;
                    }
                }
                else break;
            }
        }
    }
    enum MoveDirection
    {
        up,
        down,
        left,
        right
    };
}
