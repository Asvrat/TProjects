using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TProjects
{
    internal class Map
    {
        private const int maxSizeX = 120;
        private const int maxSizeY = 30;
        private static int[,] map = new int[maxSizeX + 2, maxSizeY + 2];

        public void SetMap()
        {
            Wall wall = new Wall();
            Wall wall2 = new Wall();
            Wall wall3 = new Wall();
            Wall wall4 = new Wall();
            Wall wall5 = new Wall();
            Wall wall6 = new Wall();
            Wall wall7 = new Wall();
            Redline redline = new Redline();
            Space space = new Space();
            wall.setObj(2, '░', ListColor.Yellow);
            wall2.setObj(3, '╔', ListColor.Yellow);
            wall3.setObj(4, '╚', ListColor.Yellow);
            wall4.setObj(5, '╗', ListColor.Yellow);
            wall5.setObj(6, '╝', ListColor.Yellow);
            wall6.setObj(7, '║', ListColor.Yellow);
            wall7.setObj(8, '═', ListColor.Yellow);
            redline.setObj(1, '░', ListColor.Red);
            space.setObj(0, ' ', ListColor.None);
            drawmap(wall.getid(), space.getid(), redline.getid());
            drawbox(wall2.getid(), space.getid(), space.getid());
            spawnplayer(wall2.getid(), space.getid());
            spawnenemy(wall2.getid(), space.getid(), 101);
            spawnenemy(wall2.getid(), space.getid(), 102);
        }
        public static void drawmap(int wall, int space, int redline)
        {
            for (int i = 0; i <= maxSizeX + 1; i++)
            {
                for (int j = 0; j <= maxSizeY + 1; j++)
                {
                    if (i == 0 || i == maxSizeX + 1 || j == 0 || j == maxSizeY + 1)
                    {
                        map[i, j] = redline;
                    }
                    else if (i % 2 == 0 || i % 3 == 0 || j % 2 == 0 || j % 3 == 0)
                    {
                        map[i, j] = space;
                    }
                    else map[i, j] = wall;
                }
            }
        }
        public static void showmap()
        {
            for (int i = 0; i <= maxSizeY + 1; i++)
            {
                for (int j = 0; j <= maxSizeX + 1; j++)
                {
                    switch (Object.getcolfromid(map[j, i]))
                    {
                        case ListColor.Black:
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                            }
                            break;
                        case ListColor.Blue:
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                            }
                            break;
                        case ListColor.Green:
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                            }
                            break;
                        case ListColor.Cyan:
                            {
                                Console.ForegroundColor = ConsoleColor.Cyan;
                            }
                            break;
                        case ListColor.Red:
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                            }
                            break;
                        case ListColor.White:
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            break;
                        case ListColor.Yellow:
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                            }
                            break;
                        case ListColor.None:
                            {
                                Console.ResetColor();
                            }
                            break;
                    }
                    Console.Write(Object.getsymbfromid(map[j, i]));
                }
                Console.Write("\n");
            }
            Console.ResetColor();
        }
        public static int spawnplayer(int wall, int space)
        {
            Player player = new Player();
            player.setObj(100, '☺', ListColor.Green);
            drawbox(wall, space, player.getid());
            return player.getid();
        }
        public static int spawnenemy(int wall, int space, int id)
        {
            Player enemy = new Player();
            enemy.setObj(id, '☺', ListColor.Red);
            drawbox(wall, space, enemy.getid());
            return enemy.getid();
        }
        public static void drawbox(int wall2, int space, int entity)
        {
            Random randomX = new Random();
            int size = 3;
            int x = randomX.Next(1, maxSizeX - size);
            int y = randomX.Next(1, maxSizeY - size);
            int[] mas = new int[2];
            for (int i = x; i <= x + size - 1; i++)
            {
                for (int j = y; j <= y + size - 1; j++)
                {
                    if (i == x && j == y)
                    {
                        map[i, j] = wall2;
                    }
                    else if (i == x && j == y + size - 1)
                    {
                        map[i, j] = wall2 + 1;
                    }
                    else if (i == x + size - 1 && j == y)
                    {
                        map[i, j] = wall2 + 2;
                    }
                    else if (i == x + size - 1 && j == y + size - 1)
                    {
                        map[i, j] = wall2 + 3;
                    }
                    else if (i == x + (size / 2) && j == y + (size / 2))
                    {
                        map[i, j] = entity;
                    }
                    else map[i, j] = space;
                }
            }
        }
        public static int searchX(int id)
        {
            int a = 0;
            for (int i = 1; i <= maxSizeX; i++)
            {
                for (int j = 1; j <= maxSizeY; j++)
                {
                    if (map[i, j] == id)
                    {
                        a = i;
                    }
                }
            }
            return a;
        }
        public static int searchY(int id)
        {
            int a = 0;
            for (int i = 1; i <= maxSizeX; i++)
            {
                for (int j = 1; j <= maxSizeY; j++)
                {
                    if (map[i, j] == id)
                    {
                        a = j;
                    }
                }
            }
            return a;

        }
        public static void move(int x, int y, MoveDirection dir)
        {
            int a;
            switch (dir)
            {
                case MoveDirection.up:
                    {
                        if (Object.gettypefromid(map[x, y - 1]) == ListType.space)
                        {
                            a = map[x, y - 1];
                            map[x, y - 1] = map[x, y];
                            map[x, y] = a;
                        }
                    }
                    break;
                case MoveDirection.down:
                    {
                        if (Object.gettypefromid(map[x, y + 1]) == ListType.space)
                        {
                            a = map[x, y + 1];
                            map[x, y + 1] = map[x, y];
                            map[x, y] = a;
                        }
                    }
                    break;
                case MoveDirection.left:
                    {
                        if (Object.gettypefromid(map[x - 1, y]) == ListType.space)
                        {
                            a = map[x - 1, y];
                            map[x - 1, y] = map[x, y];
                            map[x, y] = a;
                        }
                    }
                    break;
                case MoveDirection.right:
                    {
                        if (Object.gettypefromid(map[x + 1, y]) == ListType.space)
                        {
                            a = map[x + 1, y];
                            map[x + 1, y] = map[x, y];
                            map[x, y] = a;
                        }
                    }
                    break;
            }
        }
    }
}