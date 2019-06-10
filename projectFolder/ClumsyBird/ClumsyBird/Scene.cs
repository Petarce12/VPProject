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
        public List<Cloud> clouds { get; set; }

        public static int score { get; set; }

        public Scene()
        {
            score = 0;
            bird = new Bird(Form1.formWidth, Form1.formHeight);
            coins = new List<Coin>();
            spikes = new List<Spike>();
            clouds = new List<Cloud>();
        }

        public void Draw(Graphics g)
        {
            bird.Draw(g);
            foreach (Coin c in coins)
                c.Draw(g);
            foreach (Spike s in spikes)
                s.Draw(g);
            foreach (Cloud c in clouds)
                c.Draw(g);
        }

        public void birdReset()
        {
            bird.Reset();
        }

        public bool checkHit()
        {
            for(int i=0; i<coins.Count; i++)
            {
                if (coins.ElementAt(i).isHit(bird.Point))
                {
                    coins.RemoveAt(i);
                    score++;
                    if (score % 5 == 0 && Spike.Count < Spike.MAXIMUM)
                        Spike.Count++;
                }
            }
            foreach(Spike s in spikes)
            {
                if (s.isHit(bird))
                {
                    return true;
                }
            }
            foreach(Cloud c in clouds)
            {
                if (c.isHit(bird))
                {
                    return true;
                }
            }
            return false;
        }

        public void Move()
        {
            bird.Move(Form1.formWidth, Form1.formHeight, spikes);
        }

        public void removeClouds()
        {
            for (int i=0; i<clouds.Count; i++)
            {
                if (clouds.ElementAt(i).stateCount < 0)
                    clouds.RemoveAt(i);
            }
        }
    }
}
