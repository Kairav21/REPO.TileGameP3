using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGame
{
    public class Level
    {
        
        private Tile[,] tiles;
        private int width;
        private int height;
        private HeroTile hero;
        private ExitTile exitTile;

        public ExitTile ExitTile
        {
            get { return exitTile; }
        }



        public enum TileType
        {
            Empty,
            Wall,
            Hero,
            Exit
        }

        public enum Direction
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


        public Level(int width, int height, HeroTile hero = null)
        {
            this.width = width;
            this.height = height;
            tiles = new Tile[width, height];

            InitialiseTiles();

            Position randomPosition = GetRandomEmptyPosition();



            if (hero == null)
            {
                this.hero = (HeroTile)CreateTile(TileType.Hero, randomPosition);
            }
            else
            {
                hero.Position = randomPosition;

                this.hero = hero;
                tiles[randomPosition.X, randomPosition.Y] = hero;
            }


            Position exitPostion = GetRandomEmptyPosition();
            exitTile =(ExitTile)CreateTile(TileType.Exit, exitPostion);
          

        }

   
        public int Width
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
        }

        public HeroTile Hero
        {
            get { return hero; }
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


            }
            tiles[position.X, position.Y] = tile;
            return tile;
        }

       
        private Tile CreateTile(TileType type, int x, int y)
        {
            Position position = new Position(x, y);
            return CreateTile(type, position);
        }


        private void InitialiseTiles()
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

        public void SwopTiles( Tile tile1,   Tile tile2)
        {

            //tiles[tile1.X, tile1.Y] = tile2;
            //tiles[tile2.X, tile2.Y] = tile1;


            //int tempX = tile1.X;
            //int tempY = tile1.Y;           // logic not working
            //tile1.X = tile2.X;
            //tile1.Y = tile2.Y;
            //tile2.X = tempX;
            //tile2.Y = tempY;


            //tiles[tile1.X, tile1.Y] = tile2;
            //tiles[tile2.X, tile2.Y] = tile1;

            //Position tempPostion = new Position(tile1.X, tile1.Y);         // works
            //tile1.Position = tile2.Position;
            //tile2.Position = tempPostion;


            Position tempPosition = tile1.Position;
            
            tile1.Position = tile2.Position;
            tile2.Position = tempPosition;

            tiles[tile1.Position.X, tile1.Position.Y] = tile1;
            tiles[tile2.Position.X, tile2.Position.Y] = tile2;






        }




        public override string ToString()
        {
            StringBuilder levelString = new StringBuilder();
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    levelString.Append(tiles[x, y].Display);
                }
                levelString.AppendLine();
            }
            return levelString.ToString();
        }
    }
}
