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
    public partial class GetChips : Form
    {
        public GetChips(string _username)
        {
            InitializeComponent();
            username = _username;
            setChips();

            BackgroundOptions();
        }

        public int chips = 0;
        public string username;
        private int option;
        private int optionsBack;

        private string userInfo;

        private bool picked10 = true;
        private bool picked25 = false;
        private bool picked50 = false;
        private bool picked100 = false;

        private bool readChips = true;
        private bool writeChips = false;

        private void BackgroundOptions()
        {
            userInfo = username + "_Info.dll";

            StreamReader sr = new StreamReader(userInfo);
            chips = Convert.ToInt32(sr.ReadLine());
            option = Convert.ToInt32(sr.ReadLine());
            optionsBack = Convert.ToInt32(sr.ReadLine());
            sr.Close();

            if (optionsBack == 1)
                this.BackgroundImage = Blackjack.Properties.Resources.menu1;
            else if (optionsBack == 2)
                this.BackgroundImage = Blackjack.Properties.Resources.AnimeMenu1;
            else if (optionsBack == 3)
                this.BackgroundImage = Blackjack.Properties.Resources.AnimeMenu2;
            else if (optionsBack == 4)
                this.BackgroundImage = Blackjack.Properties.Resources.AnimeMenu3;
        }

        private void setChips()
        {
            userInfo = username + "_Info.dll";

            Console.WriteLine(userInfo);

            if (readChips)
            {
                StreamReader sr = new StreamReader(userInfo);
                chips = Convert.ToInt32(sr.ReadLine());
                sr.Close();
                readChips = false;
            }

            else if (writeChips)
            {
                TextWriter tw = new StreamWriter(userInfo);
                tw.WriteLine(chips);
                tw.WriteLine(option);
                tw.WriteLine(optionsBack);
                tw.Close();
                writeChips = false;
            }

            Console.WriteLine(chips);
        }

        private void lbl_10_Click(object sender, EventArgs e)
        {
            picked10 = true;
            picked25 = false;
            picked50 = false;
            picked100 = false;

            lbl_10back.BackColor = Color.Gold;
            lbl_25back.BackColor = Color.Transparent;
            lbl_50back.BackColor = Color.Transparent;
            lbl_100back.BackColor = Color.Transparent;
        }

        private void lbl_25_Click(object sender, EventArgs e)
        {
            picked10 = false;
            picked25 = true;
            picked50 = false;
            picked100 = false;

            lbl_10back.BackColor = Color.Transparent;
            lbl_25back.BackColor = Color.Gold;
            lbl_50back.BackColor = Color.Transparent;
            lbl_100back.BackColor = Color.Transparent;
        }

        private void lbl_50_Click(object sender, EventArgs e)
        {
            picked10 = false;
            picked25 = false;
            picked50 = true;
            picked100 = false;

            lbl_10back.BackColor = Color.Transparent;
            lbl_25back.BackColor = Color.Transparent;
            lbl_50back.BackColor = Color.Gold;
            lbl_100back.BackColor = Color.Transparent;
        }

        private void lbl_100_Click(object sender, EventArgs e)
        {
            picked10 = false;
            picked25 = false;
            picked50 = false;
            picked100 = true;

            lbl_10back.BackColor = Color.Transparent;
            lbl_25back.BackColor = Color.Transparent;
            lbl_50back.BackColor = Color.Transparent;
            lbl_100back.BackColor = Color.Gold;
        }

        private void lbl_accept_Click(object sender, EventArgs e)
        {

            if (picked10)
            {
                chips += 100;
            }
            else if (picked25)
            {
                chips += 250;
            }
            else if (picked50)
            {
                chips += 500;
            }
            else if (picked100)
            {
                chips += 1000;
            }

            writeChips = true;
            setChips();
            this.Close();
        }

        private void lbl_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
