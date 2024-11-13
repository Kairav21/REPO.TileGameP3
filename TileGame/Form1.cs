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
            lblbuffs.Text = gameEngine.Currentlevel.Hero.DoubleDamageCount.ToString();
        }






        private void InitializeComponent()
        {
            this.lblDisplay = new System.Windows.Forms.Label();
            this.lbltest = new System.Windows.Forms.Label();
            this.lblbuffs = new System.Windows.Forms.Label();
            this.btnSaveGame = new System.Windows.Forms.Button();
            this.btnLoadGame = new System.Windows.Forms.Button();
            this.lblkeys = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
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
            this.lbltest.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltest.Location = new System.Drawing.Point(617, 190);
            this.lbltest.Name = "lbltest";
            this.lbltest.Size = new System.Drawing.Size(162, 31);
            this.lbltest.TabIndex = 1;
            this.lbltest.Text = "TESTINGG";
            this.lbltest.Click += new System.EventHandler(this.lbltest_Click);
            // 
            // lblbuffs
            // 
            this.lblbuffs.AutoSize = true;
            this.lblbuffs.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblbuffs.Location = new System.Drawing.Point(634, 259);
            this.lblbuffs.Name = "lblbuffs";
            this.lblbuffs.Size = new System.Drawing.Size(71, 29);
            this.lblbuffs.TabIndex = 2;
            this.lblbuffs.Text = "Buffs";
            // 
            // btnSaveGame
            // 
            this.btnSaveGame.Location = new System.Drawing.Point(618, 369);
            this.btnSaveGame.Name = "btnSaveGame";
            this.btnSaveGame.Size = new System.Drawing.Size(150, 57);
            this.btnSaveGame.TabIndex = 3;
            this.btnSaveGame.Text = "Save Game";
            this.btnSaveGame.UseVisualStyleBackColor = true;
            this.btnSaveGame.Click += new System.EventHandler(this.btnSaveGame_Click);
            // 
            // btnLoadGame
            // 
            this.btnLoadGame.Location = new System.Drawing.Point(620, 447);
            this.btnLoadGame.Name = "btnLoadGame";
            this.btnLoadGame.Size = new System.Drawing.Size(148, 59);
            this.btnLoadGame.TabIndex = 4;
            this.btnLoadGame.Text = "Load";
            this.btnLoadGame.UseVisualStyleBackColor = true;
            this.btnLoadGame.Click += new System.EventHandler(this.btnLoadGame_Click);
            // 
            // lblkeys
            // 
            this.lblkeys.AutoSize = true;
            this.lblkeys.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblkeys.Location = new System.Drawing.Point(848, 356);
            this.lblkeys.Name = "lblkeys";
            this.lblkeys.Size = new System.Drawing.Size(282, 186);
            this.lblkeys.TabIndex = 5;
            this.lblkeys.Text = "ATTACK KEYBINDS\r\n\r\nL-ATTACK UP\r\nJ-ATTACK Left\r\nK-ATTACK Down\r\nL-ATTACK Right";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(819, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(332, 186);
            this.label1.TabIndex = 6;
            this.label1.Text = "MOVEMENT KEYBINDS\r\n\r\nW -UP\r\nA-LEFT\r\nS-DOWN\r\nD-RIGHT";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1085, 656);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblkeys);
            this.Controls.Add(this.btnLoadGame);
            this.Controls.Add(this.btnSaveGame);
            this.Controls.Add(this.lblbuffs);
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

                case Keys.I:
                    {
                        gameEngine.TriggerAttack(Direction.Up);
                    }
                    break;
                    case Keys.K:
                    {
                        gameEngine.TriggerAttack(Direction.Down);
                    }
                    break;
                    case Keys.J: 
                    {
                        gameEngine.TriggerAttack(Direction.Left);
                    }
                    break;

                    case Keys.L: 
                    {
                        gameEngine.TriggerAttack(Direction.Right);
                    }
                    break;
              



            }
            UpdateDisplay();    
        }

        private void lbltest_Click(object sender, EventArgs e)
        {

        }

        private void btnSaveGame_Click(object sender, EventArgs e)
        {
            ////string filePath = "saveGameData.txt";
            ////gameEngine.SaveGame(filePath);
            ////MessageBox.Show("Game saved successfully!");

            //gameEngine.SaveGame();
            //MessageBox.Show("Game Saved Successfully!");

            gameEngine.SaveGame(gameEngine.NumberOfLevels, gameEngine.LevelNumber, gameEngine.Currentlevel.ToString(), gameEngine.Currentlevel.Tiles, gameEngine.Currentlevel.Hero, gameEngine.Currentlevel.Enemies);
            btnSaveGame.Enabled = false;
            btnLoadGame.Enabled = false;

        }

        private void btnLoadGame_Click(object sender, EventArgs e)
        {
            //string filePath = "saveGameData.txt";

            //try
            //{ 
            //    gameEngine.LoadGame(filePath); 
            //    MessageBox.Show("Game loaded successfully!");
            //    UpdateDisplay(); 
            //}
            //catch 
            //{ 
            //    MessageBox.Show("Game Cannot load");
            //}




            gameEngine.LoadGame();
            btnLoadGame.Enabled = false;
            btnSaveGame.Enabled = false;
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
