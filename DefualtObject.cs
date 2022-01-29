using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TProjects
{
    class DefualtObject
    {
        private int id;
        private ListColor color;
        private string symbol;
        private bool notspace;
        protected ListType type;
        private const int maxobj = 30;
        private static ListColor[] colorinfo = new ListColor[maxobj];
        private static string[] symbolinfo = new string[maxobj];
        private static ListType[] typeinfo = new ListType[maxobj];

        public void setobj(int id, bool notspace, ListColor color, string symbol)
        {
            this.id = id;
            this.notspace = notspace;
            this.symbol = symbol;
            this.color = color;
            symbolinfo[id+1] = symbol;
            colorinfo[id+1] = color;
            typeinfo[id+1] = type;
        }

        public int getid()
        {
            return id;
        }
        public static ListType gettypeinfo(int id)
        {
            return typeinfo[id];
        }
        public static void print(int id)
        {
            switch (colorinfo[id + 1])
            {
                case ListColor.red:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write(symbolinfo[id + 1]);
                    break;
                case ListColor.none:
                    Console.ResetColor();
                    Console.Write(symbolinfo[id + 1]);
                    break;
                case ListColor.blue:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(symbolinfo[id + 1]);
                    break;
                case ListColor.cyan:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write(symbolinfo[id + 1]);
                    break;
                case ListColor.yellow:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(symbolinfo[id + 1]);
                    break;
                case ListColor.green:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(symbolinfo[id + 1]);
                    break;
            }
            Console.ResetColor();
        }
    }
    class Wall : DefualtObject
    {
        public Wall()
        {
            type = ListType.WALL;
        }
    }
    class Line : DefualtObject
    {
        public Line()
        {
            type = ListType.LINE;
        }
    }
    class Space : DefualtObject
    {
        public Space()
        {
            type = ListType.SPACE;
        }
    }
    class Player : DefualtObject
    {
        private int playerX;
        private int playerY;
        public Player()
        {
            type = ListType.PLAYER;
        }
        public void setX(int x)
        {
            playerX = x;
        }
        public int getX()
        {
            return playerX;
        }
        public void setY(int y)
        {
            playerY = y;
        }
        public int getY()
        {
            return playerY;
        }
    }
    public enum ListType : byte
    {
        WALL,
        SPACE,
        LINE,
        PLAYER
    };
    public enum ListColor : byte
    {
        none,
        red,
        blue,
        green,
        yellow,
        cyan
    };
}
