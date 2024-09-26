using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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

        private int successfulHeroMoves = 0; // Variabal  2.4
        private int currentLevelNumber = 1; // added 2.4



        private GameState gameState = GameState.InProgress;

        

        public GameState CurrentGameState
        {
            get { return gameState; }
        }


      


        public GameEngine(int numberOfLevels,int numberofEnemies=3) // made 3
        {
            this.numberOfLevels = numberOfLevels;
            random = new Random();

          

            

            int width = random.Next(MIN_SIZE, MAX_SIZE + 1);
            int height = random.Next(MIN_SIZE, MAX_SIZE + 1);
            currentLevel = new Level(width, height,currentLevelNumber,1, null); //p2 Q 2.3
           
        }

       // Q2.4
        private void MoveEnemies()
        {
            foreach (EnemyTile enemy in currentLevel.Enemies)
            {


                if (enemy.GetMove(out Tile targetTile) && enemy.IsDead == false)
                {
                    currentLevel.SwopTiles(enemy, targetTile);
                }
            }

            currentLevel.UpdateVision();

            //foreach (EnemyTile enemy in currentLevel.Enemies)
            //{
            //    if (enemy.IsDead == false && enemy.GetMove(out Tile targetTile) == true)              // 
            //    {
            //        currentLevel.SwopTiles(enemy, targetTile);
            //    }
            //    currentLevel.UpdateVision();
            //}
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
                    targetTile = currentLevel.Hero.Vision[1]; // Right                  // FIXED !!!!!!!!!!!
                    break;
                case Direction.Down:
                    targetTile = currentLevel.Hero.Vision[2]; // Down
                    break;
                case Direction.Left:
                    targetTile = currentLevel.Hero.Vision[3]; // Left
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
            else if (targetTile is PickupTile)
            {
                foreach (PickupTile pickup in currentLevel.Pickups)
                {
                    if (targetTile.Position==pickup.Position)
                    {
                        pickup.ApplyEffect(currentLevel.Hero);
                        currentLevel.SwopTiles(currentLevel.Hero, targetTile);
                        currentLevel.Tiles[targetTile.X, targetTile.Y] = new EmptyTile(targetTile.Position);
                    
                        return true;
                    }
                }
            }

           else  if (targetTile is EmptyTile)
            {
                currentLevel.SwopTiles(currentLevel.Hero, targetTile);
                currentLevel.Hero.UpdateVision(currentLevel);
                currentLevel.UpdateVision(); // added 2.4 p2
                return true;
            }

            return false;




        }


        // Q3.1
        private bool HeroAttack(Direction direction)
        {
            Tile targetTile = null;
            switch (direction)
            {
                case Direction.Up:
                    targetTile = currentLevel.Hero.Vision[0]; // Up
                    break;
                case Direction.Right:
                    targetTile = currentLevel.Hero.Vision[1]; // Right
                    break;
                case Direction.Down:
                    targetTile = currentLevel.Hero.Vision[2]; // Down
                    break;
                case Direction.Left:
                    targetTile = currentLevel.Hero.Vision[3]; // Left
                    break;
                case Direction.None:
                    return false;
            }

            if (targetTile is CharacterTile character)
            {
                currentLevel.Hero.Attack(character);
                return true;
            }

            return false;
        }

        public void TriggerAttack(Direction direction)
        {
            //if (HeroAttack(direction))
            //{

            //    EnemiesAttack();

                


            //}

            if (gameState != GameState.GameOver && HeroAttack (direction)== true)
            {
                EnemiesAttack();
                if (currentLevel.Hero.IsDead==true)
                {
                    gameState = GameState.GameOver; 
                }
            }

            //  HeroAttack(direction);


        }

        public string HeroStats
        {

            
                get 
            { 
               return $"{currentLevel.Hero.HitPoints}/{currentLevel.Hero.MaxHitPoints}";
            }
            
        }


        //Q3.2

        private void EnemiesAttack()
        {
            foreach (EnemyTile enemy in currentLevel.Enemies)
            {
                
                if (enemy.IsDead == false)
                {
                    CharacterTile[] targets = enemy.GetTargets();


                    foreach (CharacterTile target in targets )
                    {

                        enemy.Attack(target);
                    }
                }

                
           

               
                
            }
        }



        private void NextLevel()
        {


            currentLevelNumber++;
            levelnumber++;
            HeroTile temphero=this.currentLevel.Hero;   
            Level level = new Level(random.Next(MIN_SIZE,MAX_SIZE),random.Next(MIN_SIZE,MAX_SIZE),currentLevelNumber,1, temphero);
            this.currentLevel = level;
        }



       
        public  void  TriggerMovement(Direction direction)
        {
            //MoveHero(direction);
            //currentLevel.Hero.UpdateVision(currentLevel);
           
            //    successfulHeroMoves++;
            //    //MoveHero(direction);
            //    // Call MoveEnemies for every 2 successful moves made by the hero
            //    if (successfulHeroMoves % 2 == 0)
            //    {
            //        MoveEnemies();

            //    }

            if ( gameState == GameState.InProgress)
            {
                currentLevel.Hero.UpdateVision(currentLevel);
                if (successfulHeroMoves ==1)
                {
                    MoveHero(direction);
                    MoveEnemies();
                    successfulHeroMoves = 0;
                }
                else if (MoveHero(direction)) 
                {

                    successfulHeroMoves++;
                }
            }
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
            else if (gameState == GameState.GameOver)
            {
                return "You Lose!";
            }
            else
            {
                return levelnumber.ToString();
            }
            
        }
    }
}
