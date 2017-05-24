using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Blackjack
{
    public partial class UserMenu : Form
    {
        public UserMenu(string _username)
        {
            InitializeComponent();
            username = _username;
            BackgroundOptions();
        }
        private void UserMenu_Load_1(object sender, EventArgs e)
        {
            lbl_welcome.Text = "Welcome " + username + " to Blackjack!";
            setChips();
            BackgroundOptions();
        }

        GetChips form;
        public int chips = 0;
        public string username = "user";
        private int options = 1;
        private int optionsBack = 1;

        private string userInfo;

        private void setChips()
        {
            userInfo = username + "_Info.dll";

            TextWriter tw;
            StreamReader sr;

            if (!File.Exists(userInfo))
            {
                tw = new StreamWriter(userInfo);
                tw.WriteLine(0);
                tw.WriteLine(1);
                tw.WriteLine(1);
                tw.Close();
            }
            else
            {
                sr = new StreamReader(userInfo);
                chips = Convert.ToInt32(sr.ReadLine());
                options = Convert.ToInt32(sr.ReadLine());
                optionsBack = Convert.ToInt32(sr.ReadLine());
                sr.Close();
            }

            lbl_chips.Text = chips.ToString();
        }

        private void BackgroundOptions()
        {
            if (optionsBack == 1)
                this.BackgroundImage = Blackjack.Properties.Resources.menu1;
            else if (optionsBack == 2)
                this.BackgroundImage = Blackjack.Properties.Resources.AnimeMenu1;
            else if (optionsBack == 3)
                this.BackgroundImage = Blackjack.Properties.Resources.AnimeMenu2;
            else if (optionsBack == 4)
                this.BackgroundImage = Blackjack.Properties.Resources.AnimeMenu3;
                
        }

        private void lbl_getChips_Click(object sender, EventArgs e)
        {
            form = new GetChips(username);
            form.FormClosed += new FormClosedEventHandler(form_formClosed);
            form.ShowDialog();
        }

        private void lbl_joinLobby_Click(object sender, EventArgs e)
        {
            GameLobby form = new GameLobby(username, chips);
            this.Dispose();
            form.ShowDialog();

        }

        private void lbl_logout_Click(object sender, EventArgs e)
        {
            LoginMenu form = new LoginMenu();
            this.Dispose();
            form.ShowDialog();
        }

        private void lbl_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void form_formClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
            setChips();
            Console.WriteLine("Chip value (Closing): " + chips);
            lbl_chips.Text = chips.ToString();
        }

        private void lbl_options_Click(object sender, EventArgs e)
        {
            Options form = new Options(username, chips);
            this.Dispose();
            form.ShowDialog();
        }

        private void lbl_help_Click(object sender, EventArgs e)
        {
            Help form = new Help();
            this.Hide();
            form.FormClosed += new FormClosedEventHandler(form_formClosed);
            form.ShowDialog();
        }
    }
}
