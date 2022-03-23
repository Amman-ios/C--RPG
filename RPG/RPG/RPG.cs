using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Engine;

namespace RPG
{
    public partial class RPG : Form
    {
        private Player _player;
        public RPG()
        {
            InitializeComponent();

            Location location = new Location(1, "Home", "This is your house.");

            //Base Player Information
            _player = new Player();

            _player.CurrentHP = 10;
            _player.MaxHP = 10;
            _player.Gold = 20;
            _player.XP = 0;
            _player.LVL = 1;

            lblHitPoints.Text = _player.CurrentHP.ToString();
            lblGold.Text = _player.Gold.ToString();
            lblExperience.Text = _player.XP.ToString();
            lblLevel.Text = _player.LVL.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
