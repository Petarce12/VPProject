using ClumsyBird.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClumsyBird
{
    public class Coin
    {
        public static Random rnd = new Random();
        public Point point { set; get; }
        public Image picture;

        public Coin()
        {
            int x = rnd.Next(70, Form1.formWidth - 100);
            int y = rnd.Next(60, Form1.formHeight - 110);
            picture = Resources.coin;
            point = new Point(x, y);
        }

        public void Draw(Graphics g)
        {
            g.DrawImageUnscaled(picture, point);
        }


    }
}
