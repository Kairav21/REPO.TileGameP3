using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGame
{
    
    public class WarlockTile : EnemyTile
    {
        // Constructor
        public WarlockTile(Position position, Level level) : base(position, level, 10, 5) // addded hit points and attack power
        {


        }


        public override char Display
        {
            get
            {
                return IsDead ? 'X' : 'ᐂ'; // 'X' if dead, 'ᐂ' if alive
            }
        }


        // Implemet getmove Warlocks cannot move,  GetMove will return false and the target is null
        public override bool GetMove(out Tile targetTile)
        {
            targetTile = null; // Warlocks don't move
            return false;
        }


       


        // Helper method to add a CharacterTile to the list if it exists at the given position
        private void AddTargetIfCharacter(List<CharacterTile> targets, int x, int y)
        {
            if (x >= 0 && x < level.Width && y >= 0 && y < level.Height)
            {
                CharacterTile character = level.Tiles[x, y] as CharacterTile;
                if (character != null)
                {
                    targets.Add(character);
                }
            }

        }

        // Do it Lists way
        public override CharacterTile[] GetTargets()
        {
            List<CharacterTile> targets = new List<CharacterTile>();

            // Check all adjacent tiles for CharacterTiles
            AddTargetIfCharacter(targets, Position.X, Position.Y - 1); // Up
            AddTargetIfCharacter(targets, Position.X + 1, Position.Y); // Right
            AddTargetIfCharacter(targets, Position.X, Position.Y + 1); // Down
            AddTargetIfCharacter(targets, Position.X - 1, Position.Y); // Left

            return targets.ToArray();
        }

    }

   
   
}



