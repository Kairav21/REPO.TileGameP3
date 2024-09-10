using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGame
{
    public class HeroTile : CharacterTile
    {
        
     
        public HeroTile(Position position) : base(position, 40, 5)
        {

          
           
        }

         public override char Display
    {
        get { return IsDead ? 'X' : '▼'; }
    }
    }
}
