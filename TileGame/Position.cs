using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGame
{
  
    public class Position
    {

        // Private fields to store the coordinates
        private int x;
        private int y;


        // Constructor to initialize the coordinates
        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        // Properties to access and modify the coordinates
        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }
    }
}
