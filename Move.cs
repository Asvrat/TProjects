using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TProjects
{
    class PMove
    {
        private static MoveDirection direction;
        public void setdirection(MoveDirection dir)
        {
            direction = dir;
        }
        public static MoveDirection getdirection()
        {
            return direction;
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
