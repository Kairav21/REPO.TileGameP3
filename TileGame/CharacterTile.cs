using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGame
{

    
    public abstract class CharacterTile : Tile
    {
        protected int hitPoints;
        protected int maxHitPoints;   // Protected  ints
        protected int attackPower;
        protected int doubleDamageCount; // part 3 added

        protected Tile[] vision;  



        public CharacterTile(Position position, int hitPoints, int attackPower) : base(position)
        {
            this.hitPoints = hitPoints;
            this.maxHitPoints = hitPoints;
            this.attackPower = attackPower;
            this.vision = new Tile[4];
        }
        public int HitPoints
        {
            get { return hitPoints; }
            set { hitPoints = value; }
        }

        public int MaxHitPoints
        {
            get { return maxHitPoints; }
            set { maxHitPoints = value; }
        }

        public int AttackPower
        {
            get { return attackPower; }
            set { attackPower = value; }
        }

        public Tile[] Vision
        {
            get { return vision; }
            set { vision = value; }
        }




        public void UpdateVision(Level level)
        {
            int x = this.X;
            int y = this.Y;

           
            vision[0] = level.Tiles[x, y - 1]; // Up
            vision[1] = level.Tiles[x + 1, y ]; // Down
            vision[2] = level.Tiles[x, y+1]; // Left
            vision[3] = level.Tiles[x - 1, y]; // Right
        }

        public void TakeDamage(int damage)
        {
            hitPoints -= damage;
            if (hitPoints < 0)
            {
                hitPoints = 0;
            }
        }

        public void Attack(CharacterTile target)
        {
           
            
                int damage = attackPower;
            if (doubleDamageCount > 0)
            {
                damage *= 2;
                doubleDamageCount--;
            }
            target.TakeDamage(damage);
        }

        public bool IsDead
        {
            get { return hitPoints <= 0; }
        }

        public void Heal(int health)
        {
            hitPoints += health;    
            if (hitPoints >maxHitPoints) 
            {
                hitPoints = maxHitPoints;
            }
        }

        public void SetDoubleDamage(int count)
        {
            doubleDamageCount += count;
        }

        public int DoubleDamageCount
        {
            get {return doubleDamageCount;}
            set { doubleDamageCount = value; }
        }
        
    }
     

}
