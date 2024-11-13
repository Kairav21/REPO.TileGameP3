using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
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


        public int LevelNumber
        {
            get { return levelnumber; }
            set { levelnumber = value; }
        }

        public int NumberOfLevels
        {
            get { return numberOfLevels; }
            set { numberOfLevels = value; }
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



            if (targetTile is ExitTile && levelnumber == numberOfLevels && currentLevel.Exit.Islocked==false)
            {
                gameState = GameState.Complete;
                return false;
            }
          else if ( targetTile is ExitTile && levelnumber < numberOfLevels && currentLevel.Exit.Islocked == false)
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
            

            if (gameState != GameState.GameOver && HeroAttack (direction)== true)
            {
                EnemiesAttack();
                if (currentLevel.Hero.IsDead==true)
                {
                    gameState = GameState.GameOver; 
                }
                currentLevel.UpdateExit();
               
            }

            

            


        }

        public Level Currentlevel
        {
            get { return currentLevel; }
            set { currentLevel = value; }
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

      


        public void SaveGame(int numLevels, int levelNum, string level, Tile[,] tiles, HeroTile heroTile, EnemyTile[] enemyTiles)
        {
            const char DELIMITER = ',';
            const string FILE_NAME = "SaveFile.txt";

            
            FileStream stream = new FileStream(FILE_NAME, FileMode.Create, FileAccess.Write);
          
            StreamWriter writer = new StreamWriter(stream);

          
            writer.WriteLine(
                numLevels.ToString() + DELIMITER +
                levelNum.ToString() + DELIMITER +
                tiles.GetLength(0).ToString() + DELIMITER +
                tiles.GetLength(1).ToString() + DELIMITER +
                heroTile.HitPoints + DELIMITER +
                heroTile.DoubleDamageCount
                );

            foreach (EnemyTile enemyTile in enemyTiles)
            {
                if (enemyTile is GruntTile)
                {
                    writer.Write($"Grunt:");
                }
                if (enemyTile is WarlockTile)
                {
                    writer.Write($"Warlock:");
                }
                if (enemyTile is TyrantTile)
                {
                    writer.Write($"Tyrant:");
                }
                writer.Write(DELIMITER + enemyTile.HitPoints.ToString() + DELIMITER +
                        enemyTile.X.ToString() + DELIMITER +
                        enemyTile.Y.ToString() + DELIMITER);
            }

            writer.Write("\n" + level);

            writer.Close(); 
            stream.Close(); 
        }



        public void LoadGame()
        {
         
            FileStream stream = new FileStream("SaveFile.txt", FileMode.Open, FileAccess.Read);
   
            StreamReader reader = new StreamReader(stream);

            string recordIn;
            string[] fields;

       
            HeroTile loadedHero = null;
            ExitTile loadedExitTile = null;
            List<EnemyTile> enemyList = new List<EnemyTile>();
            List<PickupTile> pickupList = new List<PickupTile>();

            recordIn = reader.ReadLine();
            fields = recordIn.Split(',');

       
            numberOfLevels = Int32.Parse(fields[0]);
            levelnumber = Int32.Parse(fields[1]);
            Tile[,] loadedTiles = new Tile[Int32.Parse(fields[2]), Int32.Parse(fields[3])];

          
            int hitpoints = Int32.Parse(fields[4]);
            int doubleDamageCount = Int32.Parse(fields[5]);

    
            recordIn = reader.ReadLine();
            string[] enemyStats = recordIn.Split(',');

            int y = 0;
            int x = 0;
            recordIn = reader.ReadLine();
            while (recordIn != null)
            {
           
                foreach (char c in recordIn) 
                {
                    Tile tile = null;
                    if (c == '█')
                    {
                        tile = new WallTile(new Position(x, y));
                    }
                    else if (c == '.')
                    {
                        tile = new EmptyTile(new Position(x, y));
                    }
                    else if (c == 'Ϫ')
                    {
                        tile = new GruntTile(new Position(x, y), this.currentLevel);
                        enemyList.Add((EnemyTile)tile);
                    }
                    else if (c == '§')
                    {
                        tile = new TyrantTile(new Position(x, y), this.currentLevel);
                        enemyList.Add((EnemyTile)tile);
                    }
                    else if (c == 'ᐂ')
                    {
                        tile = new WarlockTile(new Position(x, y), this.currentLevel);
                        enemyList.Add((EnemyTile)tile);
                    }
                    else if (c == 'x')
                    {
                        GruntTile grunt = new GruntTile(new Position(x, y), this.currentLevel);
                        grunt.HitPoints = 0;
                        tile = grunt;
                    }
                    else if (c == '▼')
                    {
                        tile = new HeroTile(new Position(x, y));
                        loadedHero = (HeroTile)tile;
                    }
                    else if (c == '▓')
                    {
                        tile = new ExitTile(new Position(x, y));
                        loadedExitTile = (ExitTile)tile;
                    }
                    else if (c == '▒')
                    {
                        ExitTile exit = new ExitTile(new Position(x, y));
                        exit.Islocked = false;
                        tile = exit;
                        loadedExitTile = exit;
                    }
                    else if (c == '+')
                    {
                        tile = new HealthPickup(new Position(x, y));
                        pickupList.Add((PickupTile)tile);
                    }
                    else if (c == '*')
                    {
                        tile = new AttackBuffPickupTile(new Position(x, y));
                        pickupList.Add((PickupTile)tile);
                    }
                    loadedTiles[x, y] = tile;
                    x++;
                }
                recordIn = reader.ReadLine();
                x = 0;
                y++;
            }

          
            reader.Close();
            stream.Close();

            Level loadedLevel = new Level(loadedTiles.GetLength(0), loadedTiles.GetLength(1), levelnumber, 1);
            loadedLevel.Tiles = loadedTiles;
            loadedLevel.Enemies = enemyList.ToArray();
            loadedLevel.Pickups = pickupList.ToArray();
            loadedLevel.Exit = loadedExitTile;
            loadedHero.HitPoints = hitpoints;
            loadedHero.DoubleDamageCount = doubleDamageCount;
            loadedLevel.Hero = loadedHero;

            for (int i = 0; i < loadedLevel.Enemies.GetLength(0); i++)
            {
                if (loadedLevel.Enemies[i] is GruntTile && enemyStats[i] == "Grunt:" &&
                    loadedLevel.Enemies[i].X == int.Parse(enemyStats[i + 2]) &&
                    loadedLevel.Enemies[i].Y == int.Parse(enemyStats[i + 3]))
                {
                    loadedLevel.Enemies[i].HitPoints = int.Parse(enemyStats[i + 1]);
                }
                else if (loadedLevel.Enemies[i] is WarlockTile && enemyStats[i] == "Warlock:" &&
                         loadedLevel.Enemies[i].X == int.Parse(enemyStats[i + 2]) &&
                         loadedLevel.Enemies[i].Y == int.Parse(enemyStats[i + 3]))
                {
                    loadedLevel.Enemies[i].HitPoints = int.Parse(enemyStats[i + 1]);
                }
                else if (loadedLevel.Enemies[i] is TyrantTile && enemyStats[i] == "Tyrant:" &&
                         loadedLevel.Enemies[i].X == int.Parse(enemyStats[i + 2]) &&
                         loadedLevel.Enemies[i].Y == int.Parse(enemyStats[i + 3]))
                {
                    loadedLevel.Enemies[i].HitPoints = int.Parse(enemyStats[i + 1]);
                }
            }

          
            this.currentLevel = loadedLevel;
        }










    }


}
