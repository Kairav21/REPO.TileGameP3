using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGame
{
    
    public class TyrantTile : EnemyTile
    {

        public TyrantTile(Position position, Level level) : base(position, level, 15, 5)
        {
        }

        // Override the Display property to return "§" or "X" if the tyrant is dead
        public override char Display
        {
            get { return IsDead ? 'X' : '§'; }
        }

      
        public override bool GetMove(out Tile targetTile)
        {
            

            if (level.Hero.Y < Y && Vision[0] is EmptyTile)
            {
                targetTile = Vision[0];
                return true;
            }
            else if (level.Hero.X > X && Vision[1] is EmptyTile)
            {
                targetTile = Vision[1];
                return true;
            }
            else if (level.Hero.Y > Y && Vision[2] is EmptyTile)
            {
                targetTile = Vision[2];
                return true;
            }
            else if (level.Hero.X < X && Vision[3] is EmptyTile)
            {
               targetTile = Vision[3];
                return true;
            }
            else
            {
                targetTile = null;
                return false;
            }
        }

        

        public override CharacterTile[] GetTargets()
        {
            List<CharacterTile> targetList = new List<CharacterTile>();
            for (int x = 0; x < level.Tiles.GetLength(0); x++)
            {
                if (level.Tiles[x, Y] is CharacterTile && x != X)
                {
                    targetList.Add((CharacterTile)level.Tiles[x, Y]);
                }
            }

            for (int y = 0; y < level.Tiles.GetLength(1); y++)
            {
                if (level.Tiles[X, y] is CharacterTile && y != Y)
                {
                    targetList.Add((CharacterTile)level.Tiles[X, y]);
                }
            }

            CharacterTile[] targets = targetList.ToArray();
            return targets;
        }





    }
    }

