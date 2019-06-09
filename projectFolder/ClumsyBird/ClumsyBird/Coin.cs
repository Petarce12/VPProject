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
    public class Coin
    {
        public static Random rnd = new Random();
        public Point Point { set; get; }

        public Image picture;
        private SoundPlayer coinHitSnd;

        public Coin()
        {
            int x = rnd.Next(70, Form1.formWidth - 100);
            int y = rnd.Next(60, Form1.formHeight - 110);
            picture = Resources.coin;
            Point = new Point(x, y);
            InitializeSounds();
        }
        private void InitializeSounds()
        {
            coinHitSnd = new SoundPlayer(Resources.coin_sound);
        }
        public void Draw(Graphics g)
        {
            g.DrawImageUnscaled(picture, Point);
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
