using ClumsyBird.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace ClumsyBird
{
    public class Bird
    {
        public Point Point { get; set; }
        public double Angle { get; set; }
        public int Speed { get; set; }
        public bool isGoingLeft { get; set; }
        public bool isGoingRight { get; set; }
        public int Y { get; set; }

        private SoundPlayer coinHitSnd;
        
        private Image birdLeft;
        private Image birdRight;

        public Bird(int formWidth, int formHeight)
        {
            Point = new Point(formWidth / 2 - 30, formHeight / 2 - 30);
            Speed = 2;
            Angle = 0;
            Y = Point.Y;
            InitializeImages();
            InitialiseSounds();
            makeBirdGoRight();
        }

        private void InitialiseSounds()
        {
            coinHitSnd = new SoundPlayer(Resources.coin_sound);
        }

        private void InitializeImages()
        {
            birdLeft = Resources.BirdLeft;
            birdRight = Resources.BirdRight;
        }
        private void makeBirdGoLeft()
        {
            isGoingLeft = true;
            isGoingRight = false;
        }
        private void makeBirdGoRight()
        {
            isGoingRight = true;
            isGoingLeft = false;
        }
        public void Draw(Graphics g)
        {
            if (isGoingLeft)
            {
                g.DrawImageUnscaled(birdLeft, Point);
            }
            else
            {
                g.DrawImageUnscaled(birdRight, Point);
            }
        }
        public void Move(int width, int height, List<Spike> spikes)
        {
            if (isGoingLeft)
            {
                moveBirdLeft(width, height, spikes);
            }
            else
            {
                moveBirdRight(width,height, spikes);
            }
        }

        private void moveBirdRight(int width, int height, List<Spike> spikes)
        {
            if (Point.X + 80 > width)
            {
                makeBirdGoLeft();
                moveBirdLeft(width, height, spikes);
                spikes.Add(new Spike(Spike.Side.LEFT));
                Scene.score++;
                return;
            }
            else if (Angle >= -Math.PI)
            {
                int x, y;
                x = Point.X + Speed;
                Angle -= 10 * 0.005;
                y = (int)(75 * Math.Sin(Angle)) + Y;
                Point = new Point(x, y);
            }
            else
            {
                int x, y;
                y = Point.Y + Speed * 3;
                x = Point.X + Speed;
                Point = new Point(x, y);
            }
        }

        private void moveBirdLeft(int width, int height, List<Spike> spikes)
        {
            if (Point.X < 1)
            {
                makeBirdGoRight();
                moveBirdRight(width, height, spikes);
                spikes.Add(new Spike(Spike.Side.RIGHT));
                Scene.score++;
                return;
            }            
            else if (Angle >= -Math.PI)
            {
                int x, y;
                x = Point.X - Speed;
                Angle -= 10 * 0.005;
                y = (int)(75 * Math.Sin(Angle)) + Y;
                Point = new Point(x, y);
            }
            else
            {
                int x, y;
                y = Point.Y + Speed * 3;
                x = Point.X - Speed;
                Point = new Point(x, y);
            }
        }

        internal void Reset()
        {
            Y = Point.Y;
            Angle = 0;
        }

        public bool isHit(Point p)
        {
            double num = Math.Sqrt((p.X - Point.X) * (p.X - Point.X) + (p.Y - Point.Y) * (p.Y - Point.Y));
            if (num <= 50)
            {
                coinHitSnd.Play();
                return true;
            }
            return false;
        }

    }
}
