using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TProjects
{
    internal class Object
    {
        private int id;
        private char symbol;
        private ListColor color;
        protected ListType type;
        private static char[] ArSymb = new char[300];
        private static ListColor[] ArCol = new ListColor[300];
        private static ListType[] ArType = new ListType[300];
        public void setObj(int id, char symbol, ListColor color)
        {
            this.id = id;
            this.symbol = symbol;
            this.color = color;
            ArSymb[id] = symbol;
            ArCol[id] = color;
            ArType[id] = type;
        }
        public int getid()
        {
            return id;
        }
        public static char getsymbfromid(int id)
        {
            return ArSymb[id];
        }
        public static ListColor getcolfromid(int id)
        {
            return ArCol[id];
        }
        public static ListType gettypefromid(int id)
        {
            return ArType[id];
        }
    }
    enum ListType { wall, space, redline, player };
    enum ListColor{Red, White, Black, Green, Yellow, Blue, Cyan,None};
    class Player : Object
    {
        bool live = true;
        public Player()
        {
            type = ListType.player;
        }
    }
    class Wall : Object
    {
        public Wall()
        {
            type = ListType.wall;
        }
    }
    class Redline : Object
    {
        public Redline()
        {
            type = ListType.redline;
        }
    }
    class Space : Object
    {
        public Space()
        {
            type = ListType.space;
        }
    }
}
