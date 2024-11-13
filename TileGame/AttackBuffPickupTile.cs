using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGame
{
    [Serializable]
    public class AttackBuffPickupTile : PickupTile
    {

        // Constructor that accepts a Position parameter and initializes the base class
        public AttackBuffPickupTile(Position position) : base(position)
        {
        }

        // Override the Display property to return "*"
        public override char Display
        {
            get { return '*'; }
        }

        // Implement the ApplyEffect method to give double damage to the hero
        public override void ApplyEffect(CharacterTile target)
        {
            target.SetDoubleDamage(3); // Double damage for the next 3 attacks

        }
    }
}
