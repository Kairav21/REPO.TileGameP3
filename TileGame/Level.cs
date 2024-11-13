using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGame
{
    // Part 3 

    



    public class Level
    {

        private Tile[,] tiles; // 2D array of type Tile
        private int width;
        private int height;
        private HeroTile hero;
        private ExitTile exitTile;
        private PickupTile[] pickups;

        // Store all enemies in this array
        private EnemyTile[] enemies;                                    // PART 2 ADDED 2.3


        //Property to expose the enemies array
        public EnemyTile[] Enemies                                      // Part 2 added 2.3
        {
            get { return enemies; }
            set { enemies = value; }
        }

        
        public ExitTile Exit
        {
            get { return exitTile; }
            set { exitTile = value; }
        }

        public PickupTile[] Pickups
        {
            get { return pickups; }
            set { pickups = value; }    
        }





        public enum TileType  // enum
        {
            Empty,
            Wall,
            Hero,
            Exit,
            Enemy,
            Pickup        // Part 2 updated 2.3

        }

        public enum Direction  //enums
        {
            Up = 0,
            Right = 1,
            Down = 2,
            Left = 3,
            None = 4
        }

        public enum GameState
        {
            InProgress,
            Complete,
            GameOver
        }


        public Level(int width, int height, int numberOfEnemies, int numPickups = 1, HeroTile hero = null) // Constructor that initializes the level  // Added int numEnemies PArt 2 /// made it 3
        {
            this.width = width;
            this.height = height;
            tiles = new Tile[width, height];
            pickups = new PickupTile[numPickups];

            InitialiseTiles(); // Initialize all tiles to EmptyTiles

            Position randomPosition = GetRandomEmptyPosition();

            if (hero == null)  // check if null
            {
                this.hero = (HeroTile)CreateTile(TileType.Hero, randomPosition);
            }
            else
            {
                hero.Position = randomPosition;

                this.hero = hero;
                tiles[randomPosition.X, randomPosition.Y] = hero;
            }

            // Place an ExitTile at a random empty position
            Position exitPostion = GetRandomEmptyPosition();
            exitTile = (ExitTile)CreateTile(TileType.Exit, exitPostion);


            // Initialize and place enemies
            enemies = new EnemyTile[numberOfEnemies];

            for (int i = 0; i < numberOfEnemies; i++)
            {
                Position enemyPosition = GetRandomEmptyPosition();
                enemies[i] = (EnemyTile)CreateTile(TileType.Enemy, enemyPosition);
            }
            for (int i = 0; i < numPickups; i++)
            {
                Position pickupPosition = GetRandomEmptyPosition();
                pickups[i] = (PickupTile)CreateTile(TileType.Pickup, pickupPosition);
            }






        }

        public void UpdateVision()  //Part 2   Q 2.3
        {
            hero.UpdateVision(this);
            foreach (EnemyTile enemy in enemies)                // Part 2
            {
                enemy.UpdateVision(this);
            }
        }




        public int Width     // Properties to expose width and height
        {
            get { return width; }
        }

        public int Height
        {
            get { return height; }
        }

        public Tile[,] Tiles
        {
            get { return tiles; }
            set { tiles = value; }
        }

        public HeroTile Hero
        {
            get { return hero; }
            set { hero = value; }
        }

      





        private EnemyTile CreateEnemyTile(Position position)
        {
            Random random = new Random();
            int rand = random.Next(100); //  a random number between 0 and 99

            if (rand < 50) // 50% chance for GruntTile
            {
                return new GruntTile(position, this);
            }
            else if (rand < 80) // 30% chance for WarlockTile
            {
                return new WarlockTile(position, this);
            }
            else // 20% chance for TyrantTile
            {
                return new TyrantTile(position, this);
            }
            //return new TyrantTile(position, this);

        }


        private Tile CreateTile(TileType type, Position position)
        {
            Tile tile = null;
            switch (type)
            {
                case TileType.Empty:
                    tile = new EmptyTile(position);
                    break;
                case TileType.Wall:
                    tile = new WallTile(position);
                    break;
                case TileType.Hero:
                    tile = new HeroTile(position);
                    break;
                case TileType.Exit:
                    tile = new ExitTile(position);
                    break;
                case TileType.Enemy:
                    tile = CreateEnemyTile(position);  // Part 2 added 2.3    // added "This" for level refernce Part 3 2.1 
                    break;
                case TileType.Pickup:
                    tile = CreatePickupTile(position);  // added part 3 
                    break;








            }
            tiles[position.X, position.Y] = tile;
            return tile;
        }


        private Tile CreateTile(TileType type, int x, int y)
        {
            Position position = new Position(x, y);
            return CreateTile(type, position);
        }


        private void InitialiseTiles() // Method to initialize all tiles in the level as EmptyTiles
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (x == 0 || y == 0 || x == width - 1 || y == height - 1)
                    {
                        CreateTile(TileType.Wall, x, y);
                    }
                    else
                    {
                        CreateTile(TileType.Empty, x, y);
                    }
                }
            }
        }



        private Position GetRandomEmptyPosition()
        {
            Random random = new Random();
            int x, y;
            do
            {
                x = random.Next(1, width - 1);
                y = random.Next(1, height - 1);
            } while (!(tiles[x, y] is EmptyTile));
            return new Position(x, y);
        }

        public void SwopTiles(Tile tile1, Tile tile2)
        {





            Position tempPosition = tile1.Position;

            tile1.Position = tile2.Position;
            tile2.Position = tempPosition;

            tiles[tile1.Position.X, tile1.Position.Y] = tile1;
            tiles[tile2.Position.X, tile2.Position.Y] = tile2;






        }




        public override string ToString()     // Override the ToString method to create a visual representation of the level
        {
             string tempString = "";

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    tempString += tiles[x, y].Display.ToString();
                }
                tempString += "\n";
            }
            return tempString;
        }

        private PickupTile CreatePickupTile(Position position)
        {
            Random random = new Random();
            int rand = random.Next(100); // Generates a random number between 0 and 99

            if (rand < 67) // 66.66% chance for HealthPickupTile
            {
                return new HealthPickup(position);
            }
            else // 33.33% chance for AttackBuffPickupTile
            {
                return new AttackBuffPickupTile(position);
            }




        }

        public void UpdateExit()
   

        {
            if (Array.TrueForAll(Enemies, enemies => enemies.IsDead == true))
            {
                exitTile.Islocked=false;


             }
        }


  

    }
}
