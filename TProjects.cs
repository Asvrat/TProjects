using System;

namespace TProjects
{
    class ProjStarter
    {
        static void Main()
        {
            game();
        }
        static void additional()
        {

        }
        static void game()
        {
            Map lvl1 = new Map();
            lvl1.drawmap();
            while (true)
            {
                ConsoleKey Key = Console.ReadKey().Key;
                if (Key != ConsoleKey.O)
                {
                    switch (Key)
                    {
                        case ConsoleKey.S:
                            lvl1.move(MoveDirection.up); Console.SetCursorPosition(0, 0); lvl1.writemap();
                            break;
                        case ConsoleKey.W:
                            lvl1.move(MoveDirection.down); Console.SetCursorPosition(0, 0); lvl1.writemap();
                            break;
                        case ConsoleKey.A:
                            lvl1.move(MoveDirection.left); Console.SetCursorPosition(0, 0); lvl1.writemap();
                            break;
                        case ConsoleKey.D:
                            lvl1.move(MoveDirection.right); Console.SetCursorPosition(0,0); lvl1.writemap();
                            break;
                    }
                }
                else break;
            }
        }
    }
}