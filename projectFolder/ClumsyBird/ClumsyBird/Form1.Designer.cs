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
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnHighScore = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
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
            this.btnPlay.MouseHover += new System.EventHandler(this.btnPlay_MouseHover);
            // 
            // btnHighScore
            // 
            this.btnHighScore.BackColor = System.Drawing.Color.Transparent;
            this.btnHighScore.FlatAppearance.BorderSize = 0;
            this.btnHighScore.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnHighScore.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnHighScore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHighScore.Font = new System.Drawing.Font("Ravie", 30F);
            this.btnHighScore.Location = new System.Drawing.Point(166, 471);
            this.btnHighScore.Name = "btnHighScore";
            this.btnHighScore.Size = new System.Drawing.Size(384, 91);
            this.btnHighScore.TabIndex = 1;
            this.btnHighScore.Text = "SHOW STATS";
            this.btnHighScore.UseVisualStyleBackColor = false;
            this.btnHighScore.Click += new System.EventHandler(this.btnHighScore_Click);
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
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 711);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnHighScore);
            this.Controls.Add(this.btnPlay);
            this.MaximumSize = new System.Drawing.Size(739, 750);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(739, 750);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnHighScore;
        private System.Windows.Forms.Button btnExit;
    }
}

