using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClumsyBird
{
    public class Scene
    {
        public Bird bird { get; set; }
        public List<Coin> coins { get; set; }
        public List<Spike> spikes { get; set; }

        public static int score { get; set; }

        public Scene()
        {
            score = 0;
            bird = new Bird(Form1.formWidth, Form1.formHeight);
            coins = new List<Coin>();
            spikes = new List<Spike>();
        }

        public void Draw(Graphics g)
        {
            bird.Draw(g);
            foreach (Coin c in coins)
                c.Draw(g);
            foreach (Spike s in spikes)
                s.Draw(g);
        }

        public void birdReset()
        {
            bird.Reset();
        }

        public void checkHit()
        {
            for(int i=0; i<coins.Count; i++)
            {
                if (bird.isHit(new Point(coins.ElementAt(i).point.X, coins.ElementAt(i).point.Y)))
                {
                    coins.RemoveAt(i);
                    score++;
                }
            }
        }

        public void Move()
        {
            bird.Move(Form1.formWidth, Form1.formHeight, spikes);
        }


    }
}
