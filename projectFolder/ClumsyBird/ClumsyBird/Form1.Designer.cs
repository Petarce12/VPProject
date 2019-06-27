namespace ClumsyBird
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnHighScore = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.soundLabel = new System.Windows.Forms.Label();
            this.lbBackToMainMenu = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnPlay
            // 
            this.btnPlay.BackColor = System.Drawing.Color.Transparent;
            this.btnPlay.FlatAppearance.BorderSize = 0;
            this.btnPlay.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnPlay.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlay.Font = new System.Drawing.Font("Ravie", 30F);
            this.btnPlay.Location = new System.Drawing.Point(166, 369);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(384, 81);
            this.btnPlay.TabIndex = 0;
            this.btnPlay.Text = "PLAY";
            this.btnPlay.UseVisualStyleBackColor = false;
            this.btnPlay.Click += new System.EventHandler(this.btnPlayClick);
            this.btnPlay.MouseEnter += new System.EventHandler(this.btnPlay_MouseEnter);
            this.btnPlay.MouseLeave += new System.EventHandler(this.btnPlay_MouseLeave);
            // 
            // btnHighScore
            // 
            this.btnHighScore.BackColor = System.Drawing.Color.Transparent;
            this.btnHighScore.FlatAppearance.BorderSize = 0;
            this.btnHighScore.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnHighScore.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnHighScore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHighScore.Font = new System.Drawing.Font("Ravie", 30F);
            this.btnHighScore.Location = new System.Drawing.Point(-38, 457);
            this.btnHighScore.Name = "btnHighScore";
            this.btnHighScore.Size = new System.Drawing.Size(810, 124);
            this.btnHighScore.TabIndex = 1;
            this.btnHighScore.Text = "SHOW STATS";
            this.btnHighScore.UseVisualStyleBackColor = false;
            this.btnHighScore.Click += new System.EventHandler(this.btnHighScore_Click);
            this.btnHighScore.MouseEnter += new System.EventHandler(this.btnHighScore_MouseEnter);
            this.btnHighScore.MouseLeave += new System.EventHandler(this.btnHighScore_MouseLeave);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Ravie", 30F);
            this.btnExit.Location = new System.Drawing.Point(166, 583);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(384, 94);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "EXIT";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            this.btnExit.MouseEnter += new System.EventHandler(this.btnExit_MouseEnter);
            this.btnExit.MouseLeave += new System.EventHandler(this.btnExit_MouseLeave);
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // soundLabel
            // 
            this.soundLabel.AutoSize = true;
            this.soundLabel.BackColor = System.Drawing.Color.Transparent;
            this.soundLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.soundLabel.Location = new System.Drawing.Point(12, 22);
            this.soundLabel.Name = "soundLabel";
            this.soundLabel.Size = new System.Drawing.Size(148, 31);
            this.soundLabel.TabIndex = 3;
            this.soundLabel.Text = "Sound: ON";
            this.soundLabel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.label1_MouseClick);
            // 
            // lbBackToMainMenu
            // 
            this.lbBackToMainMenu.AutoSize = true;
            this.lbBackToMainMenu.BackColor = System.Drawing.Color.Transparent;
            this.lbBackToMainMenu.Font = new System.Drawing.Font("Ravie", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBackToMainMenu.Location = new System.Drawing.Point(33, 623);
            this.lbBackToMainMenu.Name = "lbBackToMainMenu";
            this.lbBackToMainMenu.Size = new System.Drawing.Size(198, 54);
            this.lbBackToMainMenu.TabIndex = 4;
            this.lbBackToMainMenu.Text = "<-BACK";
            this.lbBackToMainMenu.Click += new System.EventHandler(this.lbBackToMainMenu_Click);
            this.lbBackToMainMenu.MouseEnter += new System.EventHandler(this.lbBackToMainMenu_MouseEnter);
            this.lbBackToMainMenu.MouseLeave += new System.EventHandler(this.lbBackToMainMenu_MouseLeave);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 709);
            this.Controls.Add(this.lbBackToMainMenu);
            this.Controls.Add(this.soundLabel);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnHighScore);
            this.Controls.Add(this.btnPlay);
            this.DoubleBuffered = true;
            this.MaximumSize = new System.Drawing.Size(738, 748);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(738, 748);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnHighScore;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label soundLabel;
        private System.Windows.Forms.Label lbBackToMainMenu;
    }
}

