using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGame
{

    // Part 2 
   // Q2.1
        public abstract class EnemyTile : CharacterTile
    {
        // Constructor
        public EnemyTile(Position position, int hitPoints, int attackPower)
            : base(position, hitPoints, attackPower)
        {
        }

        // Abstract method 
        public abstract bool GetMove(out Tile targetTile);

        // Abstract method 
        public abstract CharacterTile[] GetTargets();
    }
}


