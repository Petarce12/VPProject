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
        public static int Count = 1;
        public static readonly int MAXIMUM = 10;
        public Point Point { get; set; }
        public Side side { get; set; }
        public static Random random = new Random();
        private Image spikeImage;

        public Spike(Side side, List<Spike> spikes)
        {
            spikeImage = ((side == Side.RIGHT) ? Resources.SpikesRight : Resources.SpikesLeft);
            this.side = side;
            generatePoint(spikes);
            
        }
        private void generatePoint(List<Spike> spikes)
        {
            int x = ((side == Side.RIGHT) ? Form1.formWidth - spikeImage.Width - 10 : -5);
            int y = random.Next(10, Form1.formHeight - spikeImage.Height - 48);
            foreach (Spike s in spikes)
            {
                if ((y < s.Point.Y + s.spikeImage.Height && y > s.Point.Y) || (y + spikeImage.Height < s.Point.Y + s.spikeImage.Height && y + spikeImage.Height > s.Point.Y))//is colliding
                {
                    generatePoint(spikes);
                    return;
                }
            }

            Point = new Point(x, y);

        }
        public void Draw(Graphics g)
        {
            g.DrawImageUnscaled(spikeImage, Point);
        }
        public bool isHit(Bird bird)
        {
            Point birdBottomRight = new Point(bird.Point.X + bird.birdLeft.Width, bird.Point.Y + bird.birdLeft.Height);
            Point birdTopLeft = new Point(bird.Point.X, bird.Point.Y);
            Point spikeBottomRight = new Point(Point.X + spikeImage.Width, Point.Y + spikeImage.Height);
            Point spikeTopLeft = new Point(Point.X, Point.Y);
            if (birdTopLeft.X < spikeBottomRight.X && birdBottomRight.X > spikeTopLeft.X && birdTopLeft.Y < spikeBottomRight.Y && birdBottomRight.Y > spikeTopLeft.Y)
                return true;
            return false;
        }
    }
}
