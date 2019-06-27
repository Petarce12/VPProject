using ClumsyBird.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
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
        private bool isSoundOn { set; get; }

        private Scene scene;
        public static List<Player> players { set; get; }

        private SoundPlayer birdFlapSnd;
        private SoundPlayer menuSound;

        private Image backgroundImage;
        private Image gameNameImage;

        public Form1()
        {
            InitializeComponent();
            players = new List<Player>();
            isSoundOn = true;
            newGame();
        }

        private void newGame()
        {
            InitializeImages();
            InitialiseSounds();
            setMainMenuMode();
            formWidth = Width;
            formHeight = Height;
            secondCounter = 1;
            scene = new Scene();
            //enableButtons();
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
                paintHighScoreMode(e.Graphics);
            }

        }

        private void paintHighScoreMode(Graphics g)
        {
            g.DrawImageUnscaled(backgroundImage, new Point(0, 0));
            players.Sort();
            int heigth = 150;
            Brush b = new SolidBrush(Color.Black);
            if(players.Count == 0)
                g.DrawString("No info yet", new Font("Ravie", 30),b,new Point(Width/2-170,150));
            else
            {
                int end = players.Count;
                if (players.Count > 5) end = 5;
                for(int i=0;i<end;i++)
                {
                    g.DrawString((i+1)+"."+players.ElementAt(i).ToString(), new Font("Ravie", 30), b, new Point(Width / 2 - 150, heigth));
                    heigth += 100;
                }
            }
            b.Dispose();
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
            setHighScoreMode();
            disableButtons();
            Invalidate(true);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            StreamWriter fi = File.CreateText("HighScore.txt");

            foreach (Player p in players)
            {
                fi.WriteLine(p.ToString());
            }

            fi.Flush();
            fi.Close();
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
            disableButtons();
            lbBackToMainMenu.Enabled = false;
            lbBackToMainMenu.Visible = false;
            hideSoundLabel();
            timer1.Start();
            startMenu = false;
            inPlayMode = true;
            inHighScoreMode = false;
            menuSound.Stop();
        }


        private void setMainMenuMode()
        {
            showSoundLabel();
            lbBackToMainMenu.Enabled = false;
            lbBackToMainMenu.Visible = false;
            startMenu = true;
            inPlayMode = false;
            inHighScoreMode = false;

            if (isSoundOn)
            {
                menuSound.PlayLooping();
            }
        }
        
        private void setHighScoreMode()
        {
            hideSoundLabel();
            lbBackToMainMenu.Enabled = true;
            lbBackToMainMenu.Visible = true;
            startMenu = false;
            inPlayMode = false;
            inHighScoreMode = true;
            menuSound.Stop();
        }

        public void showSoundLabel()
        {
            soundLabel.Enabled = true;
            soundLabel.Visible = true;
        }

        public void hideSoundLabel()
        {
            soundLabel.Enabled = false;
            soundLabel.Visible = false;
        }

        private void btnPlayClick(object sender, EventArgs e)
        {
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
                if (scene.coins.Count > 2)
                    scene.coins.RemoveAt(0);
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
            checkHitAndInserScore();
            Invalidate(true);
        }

        private void checkHitAndInserScore()
        {
            if (scene.checkHit())
            {
                timer1.Stop();//setMainMenuMode();//should be gameover mode

                EndGameScore obj = new EndGameScore();

                if(obj.ShowDialog() == DialogResult.Yes)
                {
                    newGame();
                    setPlayMode();
                }
                else
                {
                    newGame();
                    enableButtons();
                }
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (inPlayMode)
            {
                birdFlapSnd.Play();
                scene.birdReset();
            }
        }

        private void label1_MouseClick(object sender, MouseEventArgs e)
        {
            isSoundOn = !isSoundOn;
            if (isSoundOn)
            {
                soundLabel.Text = "Sound: ON";
                menuSound.PlayLooping();
            }
            else
            {
                soundLabel.Text = "Sound: OFF";
                menuSound.Stop();
            }
        }

        private void lbBackToMainMenu_MouseEnter(object sender, EventArgs e)
        {
            lbBackToMainMenu.Font = new Font("Ravie", 40);
        }

        private void lbBackToMainMenu_MouseLeave(object sender, EventArgs e)
        {
            lbBackToMainMenu.Font = new Font("Ravie", 30);
        }

        private void lbBackToMainMenu_Click(object sender, EventArgs e)
        {
            setMainMenuMode();
            enableButtons();
            Invalidate(true);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists("HighScore.txt"))
            {
               StreamReader fo = File.OpenText("HighScore.txt");
               while(!fo.EndOfStream)
               { 
                    String s = fo.ReadLine();
                    players.Add(new Player(s));
                }
                fo.Close();
            }
        }
    }
}
