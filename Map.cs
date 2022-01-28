using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TProjects
{
    class Map
    {
        public string fullmap;
        private string name;
        private static int sizeY = 30;
        private static int sizeX = 100;
        private int[,] xy = new int[sizeY, sizeX];

        public void drawmap()
        { 
            Random idRandom = new Random();
            for (int i = 0; i < sizeY; i++)
            {
                for(int j = 0; j < sizeX; j++)
                {
                    xy[i, j] = idRandom.Next(0,2);
                }
            }
        }
        public void bakemap()
        {
            //Объекты на карте
            player wall = new player();
            wall.createplayer('*', 1);
            wall.type = "wall";
            player space = new player();
            space.createplayer(' ', 0);
            space.type = "space";
            player line = new player();
            line.createplayer('#', -1);
            line.type = "line";

            //Применение текстур для объектов
            for (int i = 0; i < sizeY; i++)
            {
                for (int j = 0; j < sizeX; j++)
                {
                    switch (xy[i, j])
                    {
                        case 1:
                            fullmap += wall.symbol;
                            break;
                        case 0:
                            fullmap += space.symbol;
                            break;
                        case -1:
                            fullmap += line.symbol;
                            break;
                    }
                }
            }

            //Удобный вид карты
        }
        public void printmap()
        {
            char[] SymMap = new char[fullmap.Length];
            int Iel = 0;
            foreach(char el in fullmap)
            {
                SymMap[Iel] = el;
                Iel++;
            }
            for(int i = 0; i < sizeY; i++)
            {
                for(int j = 0; j < sizeX; j++)
                {
                    switch(xy[i, j])
                    {
                        case -1:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(SymMap[i*sizeX+j]);
                        Console.ResetColor();
                            break;
                        default:
                            Console.ResetColor();
                            Console.Write(SymMap[i * sizeX + j]);
                            Console.ResetColor();
                            break;
                        /*case 1:
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write(SymMap[i * sizeX + j]);
                            Console.ResetColor();
                            break;*/
                    }
                }
                                    Console.Write("\n");
            }
        }
        public void drawline()
        {
            for(int i = 0; i < sizeY; i++)
            {
                xy[i, 0] = -1;
                xy[i, sizeX-1] = -1;
            }
            for (int i = 0; i < sizeX; i++)
            {
                xy[0, i] = -1;
                xy[sizeY - 1, i] = -1;
            }
        }

    }
    class player
    {
        public char symbol;
        public int id;
        public string type;
        private static int[] arSymb = new int[30];
        public player()
        {
            arSymb[id] = symbol;
        }
        public void createplayer(char symbol, int id)
        {
            this.symbol = symbol;
            this.id = id;
        }
    }
}
