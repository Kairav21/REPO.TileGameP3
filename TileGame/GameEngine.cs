using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TileGame.Level;

namespace TileGame
{
    public class GameEngine
    {
     
        private Level currentLevel;
        private int numberOfLevels;
        private Random random;
        private int levelnumber=1;

        private const int MIN_SIZE = 10;
        private const int MAX_SIZE = 20;

        private GameState gameState = GameState.InProgress;

        

        public GameState CurrentGameState
        {
            get { return gameState; }
        }


      


        public GameEngine(int numberOfLevels)
        {
            this.numberOfLevels = numberOfLevels;
            random = new Random();

            int width = random.Next(MIN_SIZE, MAX_SIZE + 1);
            int height = random.Next(MIN_SIZE, MAX_SIZE + 1);
            currentLevel = new Level(width, height);
        }


        public GameEngine(Level level)
        {
            currentLevel = level;
        }

      
        private bool MoveHero(Direction direction)
        {

            Tile targetTile = null;
            switch (direction)
            {
                case Direction.Up:
                    targetTile = currentLevel.Hero.Vision[0]; // Up
                    break;
                case Direction.Right:
                    targetTile = currentLevel.Hero.Vision[3]; // Right                  // FIXED !!!!!!!!!!!
                    break;
                case Direction.Down:
                    targetTile = currentLevel.Hero.Vision[1]; // Down
                    break;
                case Direction.Left:
                    targetTile = currentLevel.Hero.Vision[2]; // Left
                    break;
                case Direction.None:
                    return false;
            }

            if (targetTile is ExitTile && levelnumber == numberOfLevels)
            {
                gameState = GameState.Complete;
                return false;
            }
            else if ( targetTile is ExitTile && levelnumber < numberOfLevels)
            {
                NextLevel();
                return true;    
            }

           else  if (targetTile is EmptyTile)
            {
                currentLevel.SwopTiles(currentLevel.Hero, targetTile);
                currentLevel.Hero.UpdateVision(currentLevel);
                return true;
            }

            return false;


        }

        private void NextLevel()
        {
            levelnumber++;
            HeroTile temphero=this.currentLevel.Hero;   
            Level level = new Level(random.Next(MIN_SIZE,MAX_SIZE),random.Next(MIN_SIZE,MAX_SIZE),temphero);
            this.currentLevel = level;
        }



















    public  void  TriggerMovement(Direction direction)
        {
            MoveHero(direction);
            currentLevel.Hero.UpdateVision(currentLevel);
        }


        public override string ToString()
        {
            if (gameState == GameState.InProgress)
            {
                return currentLevel.ToString(); 
            }
            else if(gameState == GameState.Complete)
                    { 
                return "YOU ARE A WINNER !!";
                      }
            return levelnumber.ToString();  
        }
    }
}
