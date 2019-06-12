using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClumsyBird
{
    public class Player : IComparable<Player>
    {

        public string name { get; set; }
        public int score { get; set; }

        public Player(string name, int score)
        {
            this.name = name;
            this.score = score;
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", name, score);
        }

        public int CompareTo(Player obj)
        {
            int n = this.score.CompareTo(obj.score);

            if (n == 0)
            {
                return this.name.CompareTo(obj.name);
            }
            else return n * -1;
        }
    }
}
