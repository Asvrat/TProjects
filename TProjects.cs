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
            lvl1.SetMap();
            Map.showmap();
            Input.move();
        }
    }
}