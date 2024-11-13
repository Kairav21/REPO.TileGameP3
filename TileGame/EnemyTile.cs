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

        protected Level level; // Protected field to store the reference to the level  PART 3 Q2.1  


        // Constructor 
        public EnemyTile(Position position,Level level,int hitPoints, int attackPower)
            : base(position, hitPoints, attackPower) // added level 2.1 PART 3
        {
            this.level = level; // Store the level reference PART 3 added 2.1
        }

        // Abstract method 
        public abstract bool GetMove(out Tile targetTile);

        // Abstract method 
        public abstract CharacterTile[] GetTargets();
    }
}


