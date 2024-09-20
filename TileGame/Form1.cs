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
        }





        //private void PlayerInput(object sender, KeyEventArgs e)


        //{


        //    //if (gameEngine.TriggerMovement(Direction.Up))
        //    //{
        //    //    UpdateDisplay();
        //    //}
        //    //if (gameEngine.TriggerMovement(Direction.Down))
        //    //{
        //    //    UpdateDisplay();
        //    //}
        //    //if (gameEngine.TriggerMovement(Direction.Left))
        //    //{
        //    //    UpdateDisplay();
        //    //}
        //    //if (gameEngine.TriggerMovement(Direction.Right))
        //    //{
        //    //    UpdateDisplay();
        //    //}

      


        //    //  bool moveMade = false;
        //    switch (e.KeyCode)
        //    {
        //        case Keys.W:
        //            gameEngine.TriggerMovement(Direction.Up);

        //            break;
        //        case Keys.S:
        //            gameEngine.TriggerMovement(Direction.Down);
        //            break;
        //        case Keys.A:
        //            gameEngine.TriggerMovement(Direction.Left);
        //            break;
        //        case Keys.D:
        //            gameEngine.TriggerMovement(Direction.Right);
        //            break;


        //    }
        //    UpdateDisplay();
        //}

        //private void btnUp_Click(object sender, EventArgs e)
        //{
        //    gameEngine.TriggerMovement(Direction.Up);
        //    UpdateDisplay();
        //}

        //private void btnDown_Click(object sender, EventArgs e)
        //{
        //    gameEngine.TriggerMovement(Direction.Down);
        //    UpdateDisplay();

        //}

        //private void btnLeft_Click(object sender, EventArgs e)
        //{
        //    gameEngine.TriggerMovement(Direction.Left);
        //    UpdateDisplay();
        //}

        //private void btnRight_Click(object sender, EventArgs e)
        //{
        //    gameEngine.TriggerMovement(Direction.Right);
        //    UpdateDisplay();
        //}

        private void InitializeComponent()
        {
            this.lblDisplay = new System.Windows.Forms.Label();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblDisplay
            // 
            this.lblDisplay.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisplay.Location = new System.Drawing.Point(27, 25);
            this.lblDisplay.Name = "lblDisplay";
            this.lblDisplay.Size = new System.Drawing.Size(317, 321);
            this.lblDisplay.TabIndex = 0;
            this.lblDisplay.Text = "label1";
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(673, 99);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(75, 23);
            this.btnUp.TabIndex = 1;
            this.btnUp.Text = "Up";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click_1);
            // 
            // btnLeft
            // 
            this.btnLeft.Location = new System.Drawing.Point(583, 194);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(75, 23);
            this.btnLeft.TabIndex = 2;
            this.btnLeft.Text = "Left";
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click_1);
            // 
            // btnRight
            // 
            this.btnRight.Location = new System.Drawing.Point(777, 194);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(75, 23);
            this.btnRight.TabIndex = 3;
            this.btnRight.Text = "Right";
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click_1);
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(673, 273);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(75, 23);
            this.btnDown.TabIndex = 4;
            this.btnDown.Text = "Down";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click_1);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(934, 534);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnRight);
            this.Controls.Add(this.btnLeft);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.lblDisplay);
            this.Name = "Form1";
            this.ResumeLayout(false);

        }

        private void btnUp_Click_1(object sender, EventArgs e)
        {
            gameEngine.TriggerMovement(Direction.Up);
            UpdateDisplay();
        }

        private void btnDown_Click_1(object sender, EventArgs e)
        {
            gameEngine.TriggerMovement(Direction.Down);
            UpdateDisplay();
        }

        private void btnLeft_Click_1(object sender, EventArgs e)
        {
            gameEngine.TriggerMovement(Direction.Left);
            UpdateDisplay();
        }

        private void btnRight_Click_1(object sender, EventArgs e)
        {
            gameEngine.TriggerMovement(Direction.Right);
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
