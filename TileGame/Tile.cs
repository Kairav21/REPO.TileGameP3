using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGame
{
   
    public abstract class Tile
    {
      
    private Position position;   // Private field of type Position


     
        public Position Position 


        { get { return position; }   // 
        
            set { position = value; }
        
        }

        




      
        public Tile(Position position) // Constructor that accepts a Position object and assigns it to the position field
        {
        this.position = position;
    }



 
    public int X
    {
        get { return position.X; }
    }

    
    public int Y
    {
        get { return position.Y; }
    }

    public abstract char Display { get; }
    }
}
