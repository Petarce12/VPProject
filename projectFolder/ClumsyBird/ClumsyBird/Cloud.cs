using ClumsyBird.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClumsyBird
{
    public class Cloud
    {
        private static Random rnd = new Random();
        public Point Point { get; set; }
        public Point LightningPoint { get; set; }
        public int stateCount { get; set; }

        private Image cloudWhite;
        private Image cloudGray;
        private Image cloudDark;
        private Image lightning;
        private bool isDisapearing;

        public Cloud()
        {
            lightning = Resources.Lightning;
            cloudWhite = Resources.WhiteCloud;
            cloudGray = Resources.GrayCloud;
            cloudDark = Resources.DarkCloud;
            int x = rnd.Next(Form1.formWidth / 3, Form1.formWidth - Form1.formWidth / 3 - cloudWhite.Width);
            int y = rnd.Next(cloudWhite.Height / 2, Form1.formHeight - cloudWhite.Height / 2 - cloudWhite.Height);
            Point = new Point(x, y);
            LightningPoint = new Point();
            stateCount = 0;
            isDisapearing = false;
        }
        public void Draw(Graphics g)
        {
            //stateCount++;
            if (stateCount < 200)
            {
                g.DrawImageUnscaled(cloudWhite, Point);
            }
            if (stateCount >= 200 && stateCount < 400)
            {
                g.DrawImageUnscaled(cloudGray, Point);
            }
            if (stateCount >= 400 && stateCount <= 650)
            {
                DrawLightning(g);
                g.DrawImageUnscaled(cloudDark, Point);
            }
            if (stateCount >= 650)
            {
                isDisapearing = true;
                stateCount--;
            }
            stateCount += ((isDisapearing) ? -1 : 1);  
        }
        public void DrawLightning(Graphics g)
        {
            if (stateCount >= 550)
            {
                if (stateCount % 25 == 0)
                {
                    int x = rnd.Next(Point.X + cloudDark.Width / 3, Point.X + cloudDark.Width - cloudDark.Width / 3 - lightning.Width);
                    int y = Point.Y + cloudDark.Height - 10;
                    LightningPoint = new Point(x, y);
                }
                g.DrawImageUnscaled(lightning, LightningPoint);
            }
        }
        public bool isHit(Bird bird)
        {
            Point birdBottomRight = new Point(bird.Point.X + bird.birdLeft.Width, bird.Point.Y + bird.birdLeft.Height);
            Point birdTopLeft = new Point(bird.Point.X, bird.Point.Y);
            Point lightningBottomRight = new Point(LightningPoint.X + lightning.Width, LightningPoint.Y + lightning.Height);
            Point lightningTopLeft = new Point(LightningPoint.X, LightningPoint.Y);
            if (birdTopLeft.X < lightningBottomRight.X && birdBottomRight.X > lightningTopLeft.X && birdTopLeft.Y < lightningBottomRight.Y && birdBottomRight.Y > lightningTopLeft.Y)
                return true;
            return false;
        }
    }
}
