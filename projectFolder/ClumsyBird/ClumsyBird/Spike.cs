using ClumsyBird.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClumsyBird
{
    public class Spike
    {
        public enum Side{
            RIGHT, //bird is going Right
            LEFT   //bird is going Left
        }
        public Point Point { get; set; }
        public Side side { get; set; }
        public static Random random = new Random();
        private Image spikeImage;

        public Spike(Side side)
        {
            //spikeImage = ((side == Side.RIGHT) ? Resources.SpikesRight : Resources.SpikesLeft);
            if (side == Side.RIGHT)
            {
                spikeImage = Resources.SpikesRight;
            }
            else
            {
                spikeImage = Resources.SpikesLeft;
            }
            this.side = side;
            int x = ((side == Side.RIGHT) ? Form1.formWidth - spikeImage.Width : 0);
            int y = random.Next(Form1.formHeight - spikeImage.Height);
            Point = new Point(x, y);
        }
        public void Draw(Graphics g)
        {
            g.DrawImageUnscaled(spikeImage, Point);
        }
    }
}
