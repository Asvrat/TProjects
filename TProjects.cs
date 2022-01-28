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
            lvl1.drawline();
            lvl1.bakemap();
            lvl1.printmap();
            Console.WriteLine(lvl1.fullmap);
        }
    }
}