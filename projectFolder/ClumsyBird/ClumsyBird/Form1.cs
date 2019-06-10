using ClumsyBird.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClumsyBird
{
    public partial class Form1 : Form
    {

        public static int formWidth;
        public static int formHeight;
        public int secondCounter;

        private bool startMenu { set; get; }
        private bool inPlayMode { get; set; }
        private bool inHighScoreMode { set; get; }
        private bool isMenuSndPlaing { set; get; }

        private Scene scene;

        private SoundPlayer birdFlapSnd;
        private SoundPlayer menuSound;

        private Image backgroundImage;
        private Image gameNameImage;

        public Form1()
        {
            InitializeComponent();
            InitializeImages();
            InitialiseSounds();
            setMainMenuMode();
            formWidth = Width;
            formHeight = Height;
            secondCounter = 1;
            scene = new Scene();
        }

        private void InitialiseSounds()
        {
            birdFlapSnd = new SoundPlayer(Resources.flap_sound);
            menuSound = new SoundPlayer(Resources.nature_piano);
        }

        private void InitializeImages()
        {
            backgroundImage = Resources.cloud_example;
            gameNameImage = Resources.Untitled;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);

            if (startMenu)
            {
                paintMainMenu(e.Graphics);
            }
            else if(inPlayMode)
            {
                paintPlayMode(e.Graphics);
            }
            else if(inHighScoreMode)
            {
                //power up speed up/down
            }

        }

        private void paintPlayMode(Graphics g)
        {
            Brush b = new SolidBrush(Color.Brown);
            Brush brush = new SolidBrush(Color.White);
            g.DrawImageUnscaled(backgroundImage, new Point(0, 0));
            g.FillRectangle(b, new Rectangle(new Point(0, 0), new Size(Width, 10)));
            g.FillRectangle(b, new Rectangle(new Point(0, Height - 48), new Size(Width, 10)));
            Font f = new Font("Helvetica", 50,FontStyle.Bold);
            
            g.DrawString(Scene.score.ToString(), f, brush, Width / 2 - 50, 150);
            scene.Draw(g);
            b.Dispose();
        }

        private void paintMainMenu(Graphics g)
        {
            g.DrawImageUnscaled(backgroundImage, new Point(0, 0));
            g.DrawImageUnscaled(gameNameImage, new Point(200, 150));
        }

        private void btnHighScore_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void enableButtons()
        {
            btnPlay.Enabled = true;
            btnPlay.Visible = true;
            btnHighScore.Enabled = true;
            btnHighScore.Visible = true;
            btnExit.Enabled = true;
            btnExit.Visible = true;
        }

        private void disableButtons()
        {
            btnPlay.Enabled = false;
            btnPlay.Visible = false;
            btnHighScore.Enabled = false;
            btnHighScore.Visible = false;
            btnExit.Enabled = false;
            btnExit.Visible = false;
        }

        private void setPlayMode()
        {
            startMenu = false;
            inPlayMode = true;
            inHighScoreMode = false;
            menuSound.Stop();
        }


        private void setMainMenuMode()
        {
            startMenu = true;
            inPlayMode = false;
            inHighScoreMode = false;
            menuSound.PlayLooping();
        }

        
        private void setHighScoreMode()
        {
            startMenu = false;
            inPlayMode = false;
            inHighScoreMode = true;
            menuSound.Stop();
        }


        private void btnPlayClick(object sender, EventArgs e)
        {
            disableButtons();
            setPlayMode();
            timer1.Start();
            Invalidate(true);
        }

        private void btnPlay_MouseLeave(object sender, EventArgs e)
        {
            btnPlay.Font = new Font("Ravie", 30);
        }

        private void btnHighScore_MouseEnter(object sender, EventArgs e)
        {
            btnHighScore.Font = new Font("Ravie", 40);
        }

        private void btnHighScore_MouseLeave(object sender, EventArgs e)
        {
            btnHighScore.Font = new Font("Ravie", 30);
        }

        private void btnPlay_MouseEnter(object sender, EventArgs e)
        {
            btnPlay.Font = new Font("Ravie", 40);
        }

        private void btnExit_MouseEnter(object sender, EventArgs e)
        {
            btnExit.Font = new Font("Ravie", 40);
        }

        private void btnExit_MouseLeave(object sender, EventArgs e)
        {
            btnExit.Font = new Font("Ravie", 30);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(secondCounter % 400 == 0)
            {
                scene.coins.Add(new Coin());
                //secondCounter = 0;
            }
            if (secondCounter % 1600 == 0)
            {
                scene.clouds.Add(new Cloud());
                secondCounter = 0;
            }
            secondCounter++;
            scene.Move();
            scene.removeClouds();
            if (scene.checkHit())
                timer1.Stop();//setMainMenuMode();//should be gameover mode
            Invalidate(true);
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (inPlayMode)
            {
                birdFlapSnd.Play();
                scene.birdReset();
            }
        }
    }
}
