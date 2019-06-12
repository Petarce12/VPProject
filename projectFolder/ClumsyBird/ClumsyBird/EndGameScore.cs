using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClumsyBird
{
    public partial class EndGameScore : Form
    {
        public bool isNameInserted { set; get; }

        public EndGameScore()
        {
            InitializeComponent();
        }



        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            if (isNameInserted)
            {
                insertPlayerScore();
                DialogResult = DialogResult.No;
            }
            else
            {
                errorProvider1.SetError(textBox1, "Vnesi ime !");
            }
        }


        private void btnNewGame_Click(object sender, EventArgs e)
        {
            if (isNameInserted)
            {
                insertPlayerScore();
                DialogResult = DialogResult.Yes;
            }
            else
            {
                errorProvider1.SetError(textBox1, "Vnesi ime !");
            }
        }

        private void insertPlayerScore()
        {
            Form1.players.Add(new Player(textBox1.Text, Scene.score));
            Scene.score = 0;
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (textBox1.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(textBox1, "Vnesi ime !");
                isNameInserted = false;
                e.Cancel = true;

            }
            else
            {
                errorProvider1.SetError(textBox1, null);
                isNameInserted = true;
                e.Cancel = false;
            }
        }
    }
}
