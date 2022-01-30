using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TProjects
{
    class Map
    {
        private static int sizeY = 30;
        private static int sizeX = 100;
        private int PlX;
        private int PlY;
        private int[,] map = new int[sizeY, sizeX];
        public void drawmap()
        {
            //Создание объектов
            Wall wall = new Wall();
            wall.setobj(1, true, ListColor.cyan, "░");
            Wall wall2 = new Wall();
            wall2.setobj(11, true, ListColor.cyan, "►");
            Wall wall3 = new Wall();
            wall3.setobj(12, true, ListColor.cyan, "¤");
            Line mainline = new Line();
            mainline.setobj(-1, true, ListColor.red, "░");
            Space space = new Space();
            space.setobj(0, false, ListColor.none, " ");
            //Создание игрока
            Player player = new Player();
            player.setobj(2, true, ListColor.green, "☻");


            //Создание обычной карты
            drawobjects(space.getid(), wall.getid());
            drawObj(wall.getid(), space.getid(), randomX(sizeX - 2, sizeX - 1), randomY(sizeY - 2, sizeY - 1));
            drawRail(wall2.getid(), space.getid(), player.getid(), randomX(sizeX-2, sizeX - 1), randomY(2, 2));
            drawline(mainline.getid());
            //Создание игрока
            //player.setX(randomX(1,sizeX - 1));
            //player.setY(randomY(1, sizeY - 1));
            writemap();
        }
        public void writemap() //Текстуры для карты
        {
            for (int i = 0; i < sizeY; i++)
            {
                for (int j = 0; j < sizeX; j++)
                {
                    DefualtObject.print(map[i, j]);
                }
                Console.Write('\n');
            }
        }
        private void drawline(int lineid)
        {
            for(int i = 0; i < sizeY; i++)
            {
                map[i, 0] = lineid;
                map[i, sizeX-1] = lineid;
            }
            for (int i = 0; i < sizeX; i++)
            {
                map[0, i] = lineid;
                map[sizeY - 1, i] = lineid;
            }
        }
        private void drawobjects(int begid, int endid)
        {

            //Создание объектов на карте
            Random idRandom = new Random();
            int a;
            for (int i = 0; i < sizeY; i++)
            {
                for (int j = 0; j < sizeX; j++)
                {
                    switch (idRandom.Next(1, 3))
                    {
                        case 2: a = begid;break;
                        default: a = endid; break;
                    }
                    map[i, j] = a;
                }
            }
        }

        private void drawRail(int id, int space, int plid, int Xsize, int Ysize)
        {
            int x = randomX(1, sizeX - Xsize);
            int y = randomX(5, sizeY - Ysize-5);
            for (int i = y; i <= y+Ysize; i++)
            {
                for (int j = x; j <= x+Xsize; j++)
                {
                    if (i == y+Math.Round(Convert.ToDouble(Ysize) / 2) && j == x)
                    {
                        coordPlayer(plid,j,i);
                    }
                    else if (i == y + Math.Round(Convert.ToDouble(Ysize) / 2) || j % 8 ==0 )
                    {
                        map[i, j] = space;
                    }
                    else map[i, j] = id;
                }
            }
        }
        private void drawObj(int id, int space, int Xsize, int Ysize)
        {
            int x = randomX(1, sizeX - Xsize);
            int y = randomX(1, sizeY - Ysize);
            int a;
            for (int i = y; i <= y+Ysize; i++)
            {
                for (int j = x; j <= x+Xsize; j++)
                {
                    a = randomX(1, 3);
                    switch (a)
                    {
                        case 1:
                            if (j % 2 == 0 || j % 3 == 0)
                            {
                                map[i, j] = space;
                            }
                            else map[i, j] = id;
                            break;
                        case 2:
                            if (i % 2 == 0 || i % 3 == 0)
                            {
                                map[i, j] = space;
                            }
                            else map[i, j] = id;
                            break;
                    }
                }
            }
        }
        private int randomX(int a, int b)
        {
            Random Random = new Random();
            int x = Random.Next(a, b);
            return x;
        }
        private int randomY(int a, int b)
        {
            Random Random = new Random();
            int y = Random.Next(a, b);
            return y;
        }

        private void coordPlayer(int id, int x, int y)
        {
            map[y, x] = id;
            PlX = x;
            PlY = y;
        }
        public void move(MoveDirection direction)
        {
            int x = PlX;
            int y = PlY;
            int a = map[y, x];
            switch (direction)
            {
                case MoveDirection.down: y--;break;
                case MoveDirection.up: y++;break;
                case MoveDirection.right: x++; break;
                case MoveDirection.left: x--; break;
            }

            int b = map[y, x];
            ListType info = DefualtObject.gettypeinfo(map[y, x]+1);
            if (info == ListType.SPACE)
            {
                map[y, x] = a;
                PlX = x;
                PlY = y;
                switch (direction)
                {
                    case MoveDirection.down: y++; break;
                    case MoveDirection.up: y--; break;
                    case MoveDirection.right: x--; break;
                    case MoveDirection.left: x++; break;
                }
                map[y, x] = b;
            } 
        }

    }
}
