using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static TileGame.Level;

namespace TileGame
{
    public partial class Form1 : Form
    {

        private GameEngine gameEngine;

        public Form1()
        {
            InitializeComponent();


            gameEngine = new GameEngine(10);


            UpdateDisplay();          

             this.KeyPreview = true;
           
            
            






        }
        private void UpdateDisplay()
        {
            lblDisplay.Text = gameEngine.ToString();
            lbltest.Text = gameEngine.HeroStats.ToString();
        }






        private void InitializeComponent()
        {
            this.lblDisplay = new System.Windows.Forms.Label();
            this.lbltest = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblDisplay
            // 
            this.lblDisplay.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisplay.Location = new System.Drawing.Point(27, 25);
            this.lblDisplay.Name = "lblDisplay";
            this.lblDisplay.Size = new System.Drawing.Size(511, 481);
            this.lblDisplay.TabIndex = 0;
            this.lblDisplay.Text = "label1";
            // 
            // lbltest
            // 
            this.lbltest.AutoSize = true;
            this.lbltest.Location = new System.Drawing.Point(617, 190);
            this.lbltest.Name = "lbltest";
            this.lbltest.Size = new System.Drawing.Size(62, 13);
            this.lbltest.TabIndex = 1;
            this.lbltest.Text = "TESTINGG";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1085, 534);
            this.Controls.Add(this.lbltest);
            this.Controls.Add(this.lblDisplay);
            this.Name = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PlayerInput);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

      

        private void PlayerInput(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode) 
            {

                case Keys.W:
                    {
                        gameEngine.TriggerMovement(Direction.Up);
                        
                    }
                    break;


                    case Keys.A: 
                    {
                        gameEngine.TriggerMovement(Direction.Left);

                    }
                    break;

                    case Keys.S: 
                    {

                        gameEngine.TriggerMovement(Direction.Down);

                    }
                    break;


                    case Keys.D:
                    {
                        gameEngine.TriggerMovement(Direction.Right);
                    }
                    break;

                case Keys.Up:
                    {
                        gameEngine.TriggerAttack(Direction.Up);
                    }
                    break;
                    case Keys.Down:
                    {
                        gameEngine.TriggerAttack(Direction.Down);
                    }
                    break;
                    case Keys.Left: 
                    {
                        gameEngine.TriggerAttack(Direction.Left);
                    }
                    break;

                    case Keys.Right: 
                    {
                        gameEngine.TriggerAttack(Direction.Right);
                    }
                    break;
              



            }
            UpdateDisplay();    
        }

        //private void InitializeComponent()
        //{
        //    this.SuspendLayout();
        //    // 
        //    // Form1
        //    // 
        //    this.ClientSize = new System.Drawing.Size(284, 261);
        //    this.Name = "Form1";
        //    this.ResumeLayout(false);

        //}
    }
}
