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
            Line mainline = new Line();
            mainline.setobj(-1, true, ListColor.red, "░");
            Space space = new Space();
            space.setobj(0, false, ListColor.none, " ");
            //Создание игрока
            Player player = new Player();
            player.setobj(2, true, ListColor.green, "☻");


            //Создание обычной карты
            drawobjects(space.getid(), wall.getid());
            drawline(mainline.getid());
            //Создание игрока
            player.setX(randomX());
            player.setY(randomY());
            coordPlayer(player.getid(),player.getX(),player.getY());
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
            for (int i = 0; i < sizeY; i++)
            {
                for (int j = 0; j < sizeX; j++)
                {
                    map[i, j] = idRandom.Next(begid, endid+1);
                }
            }
        }
        private int randomX()
        {
            Random Random = new Random();
            int x = Random.Next(1, sizeX-1);
            return x;
        }
        private int randomY()
        {
            Random Random = new Random();
            int y = Random.Next(1, sizeY-1);
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
