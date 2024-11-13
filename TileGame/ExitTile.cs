using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGame
{
 
    public class ExitTile : Tile
    {

        private bool isLocked=true;


        public bool Islocked
        {
            get { return isLocked; }
            set { isLocked = value; }
        }

            
        public ExitTile (Position position) : base (position)
        {

        }
        public override char Display
        {
            get { if (isLocked == false) { return '▒'; } else { return '▓'; } }
        }

    }
}
