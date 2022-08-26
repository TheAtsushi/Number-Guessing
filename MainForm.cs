using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Color = System.Drawing.Color;

namespace Number_Guessing
{
    public partial class MainForm : Form
    {
        public int p = 0;
        public bool lang = false;
        public int d;
        public Random random = new Random();
        public MainForm()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            try
            {
                if (lang)
                {
                    Button.Image = Properties.Resources.Hu_Button;
                    Title.Text = Properties.Resources.Title_HU;
                }
                else
                {
                    Title.Text = Properties.Resources.Title;
                    Button.Image = Properties.Resources.En_Button;
                }
                if (Ilustrason.Visible != true) Ilustrason.Visible = true;
                int t = int.Parse(inputGuess.Text);
                if (t == p)
                {
                    if (lang) Message.Text = Properties.Resources.Win_HU;
                    else Message.Text = Properties.Resources.Win;
                    Panel.BackColor = Color.FromArgb(164, 194, 168);
                    Panel.Visible = true;
                    Message.Visible = true;
                    Ilustrason.Image = Properties.Resources.medal;
                    SoundPlayer sound = new SoundPlayer(Properties.Resources.Winning);
                    sound.Play();
                    Task.Delay(9000).Wait();
                    Thread.Sleep(1000);
                    New_game();
                }
                if (t > p)
                {
                    if (lang) Message.Text = Properties.Resources.High_HU;
                    else Message.Text = Properties.Resources.High;
                    Panel.BackColor = Color.FromArgb(187, 160, 202);
                    Panel.Visible = true;
                    Message.Visible = true;
                    Ilustrason.Image = Properties.Resources.up_arrow;
                    SoundPlayer sound_1 = new SoundPlayer(Properties.Resources.Notifi);
                    sound_1.Play();
                    inputGuess.Text = "";
                }
                if (t < p)
                {
                    if (lang) Message.Text = Properties.Resources.Low_HU;
                    else Message.Text = Properties.Resources.Low;
                    Panel.BackColor = Color.FromArgb(164, 194, 168);
                    Panel.Visible = true;
                    Message.Visible = true;
                    Ilustrason.Image = Properties.Resources.down_arrow;
                    SoundPlayer sound_1 = new SoundPlayer(Properties.Resources.Notifi);
                    sound_1.Play();
                    inputGuess.Text = "";
                }
            }
            catch
            {
                if (inputGuess.Text == "")
                {
                    if (lang) Message.Text = Properties.Resources.Error_1_HU;
                    else Message.Text = Properties.Resources.Error_1;
                    Panel.BackColor = Color.FromArgb(209, 113, 113);
                    Panel.Visible = true;
                    Message.Visible = true;
                    Ilustrason.Image = Properties.Resources.delete_button;
                    SoundPlayer sound_1 = new SoundPlayer(Properties.Resources.Notifi);
                    sound_1.Play();
                    inputGuess.Text = "";
                }
                if (int.TryParse(inputGuess.Text, out d) == false && inputGuess.Text != "")
                {
                    if (lang) Message.Text = Properties.Resources.Error_2_HU;
                    else Message.Text = Properties.Resources.Error_2;
                    Panel.BackColor = Color.FromArgb(209, 113, 113);
                    Panel.Visible = true;
                    Message.Visible = true;
                    Ilustrason.Image = Properties.Resources.delete_button;
                    SoundPlayer sound_1 = new SoundPlayer(Properties.Resources.Notifi);
                    sound_1.Play();
                    inputGuess.Text = "";
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            p = random.Next(5, 100);
        }

        private void New_game()
        {
            Message.Visible = false;
            Ilustrason.Visible = false;
            Panel.Visible = false;
            if (lang) Button.Image = Properties.Resources.Hu_Game;
            else Button.Image = Properties.Resources.En_Game;
            p = random.Next(5, 100);    
        }

        private void Langus_CheckedChanged(object sender, EventArgs e)
        {
            if (Langus.Checked) lang = true;
            else lang = false;
        }
    }
}
