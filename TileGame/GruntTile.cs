using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGame
{
    //Q2.2 Part 2
    // 1st
    public class GruntTile : EnemyTile
    {

        // Constructor
        public GruntTile(Position position) : base(position, hitPoints: 10, attackPower: 1) // hit points = 10, attack power = 1
        {
        }

        // Override the Display property to return "X" or "x" if dead
        public override char Display
        {
            get
            {
                return IsDead ? 'W' : 'X';
            }
        }

        public override bool GetMove(out Tile targetTile)
        {
            

            Random random = new Random();

            if (vision[0] is EmptyTile || vision[1] is EmptyTile || Vision[2] is EmptyTile || Vision[3] is EmptyTile)
            {
                do
                {
                    targetTile = Vision[random.Next(Vision.Length)];
                } while (!(targetTile is EmptyTile));

                return true;
            }
            else
            {
                targetTile = null;
                return false;
            }
        }

        // Implement the GetTargets method
        public override CharacterTile[] GetTargets()
        {
            // Check for HeroTile in the vision array
            CharacterTile hero = Array.Find(Vision, tile => tile is HeroTile) as CharacterTile;

            if (hero != null)
            {
                return new CharacterTile[] { hero };
            }

            return new CharacterTile[0];
        }




    }



   

   

}