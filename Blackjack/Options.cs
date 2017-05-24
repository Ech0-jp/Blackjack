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
    public partial class Options : Form
    {
        public Options(string _username, int _chips)
        {
            InitializeComponent();
            username = _username;
            chips = _chips;
            BackgroundOptions();
        }

        string username;
        int chips;
        string info;

        int option = 1;
        int optionsBack = 1;

        List<Image> option1 = new List<Image> 
        { 
            Blackjack.Properties.Resources.cardl_c05,
            Blackjack.Properties.Resources.cardl_s05,
            Blackjack.Properties.Resources.cardl_h05,
            Blackjack.Properties.Resources.cardl_d05
        };

        List<Image> option2 = new List<Image> 
        { 
            Blackjack.Properties.Resources.cards_c05,
            Blackjack.Properties.Resources.cards_s05,
            Blackjack.Properties.Resources.cards_h05,
            Blackjack.Properties.Resources.cards_d05
        };

        List<Image> backgroundOption = new List<Image>
        {
            Blackjack.Properties.Resources.menu1,
            Blackjack.Properties.Resources.AnimeMenu1,
            Blackjack.Properties.Resources.AnimeMenu2,
            Blackjack.Properties.Resources.AnimeMenu3
        };

        private void BackgroundOptions()
        {
            info = username + "_Info.dll";

            StreamReader sr = new StreamReader(info);
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

        private void setOption()
        {
            info = username + "_Info.dll";
            TextWriter tw = new StreamWriter(info);

            tw.WriteLine(chips);
            tw.WriteLine(option);
            tw.WriteLine(optionsBack);

            tw.Close();
            this.Close();
        }

        private void choseCardOption1()
        {
            optionCardPic1.BringToFront();
            optionCardPic2.BringToFront();
            optionCardPic3.BringToFront();
            optionCardPic4.BringToFront();

            optionCardPic1.BackgroundImage = option1[0];
            optionCardPic2.BackgroundImage = option1[1];
            optionCardPic3.BackgroundImage = option1[2];
            optionCardPic4.BackgroundImage = option1[3];
        }

        private void choseCardOption2()
        {
            optionCardPic1.BringToFront();
            optionCardPic2.BringToFront();
            optionCardPic3.BringToFront();
            optionCardPic4.BringToFront();

            optionCardPic1.BackgroundImage = option2[0];
            optionCardPic2.BackgroundImage = option2[1];
            optionCardPic3.BackgroundImage = option2[2];
            optionCardPic4.BackgroundImage = option2[3];
        }

        private void choseBackgroundOption1()
        {
            optionBackground.BringToFront();
            optionBackground.BackgroundImage = backgroundOption[0];
        }

        private void choseBackgroundOption2()
        {
            optionBackground.BringToFront();
            optionBackground.BackgroundImage = backgroundOption[1];
        }

        private void choseBackgroundOption3()
        {
            optionBackground.BringToFront();
            optionBackground.BackgroundImage = backgroundOption[2];
        }

        private void choseBackgroundOption4()
        {
            optionBackground.BringToFront();
            optionBackground.BackgroundImage = backgroundOption[3];
        }

        private void lbl_cardTraditional_Click(object sender, EventArgs e)
        {
            choseCardOption1();
            option = 1;
        }

        private void lbl_cardAnime_Click(object sender, EventArgs e)
        {
            choseCardOption2();
            option = 2;
        }

        private void lbl_accept_Click(object sender, EventArgs e)
        {
            setOption();
            UserMenu form = new UserMenu(username);
            this.Dispose();
            form.ShowDialog();
        }

        private void lbl_cancel_Click(object sender, EventArgs e)
        {
            UserMenu form = new UserMenu(username);
            this.Dispose();
            form.ShowDialog();
        }

        private void lbl_cardOption1_Click(object sender, EventArgs e)
        {
            choseBackgroundOption1();
            optionsBack = 1;
        }

        private void lbl_cardOption2_Click(object sender, EventArgs e)
        {
            choseBackgroundOption2();
            optionsBack = 2;
        }

        private void lbl_cardOption3_Click(object sender, EventArgs e)
        {
            choseBackgroundOption3();
            optionsBack = 3;
        }

        private void lbl_cardOption4_Click(object sender, EventArgs e)
        {
            choseBackgroundOption4();
            optionsBack = 4;
        }

        bool clickedCard = false;
        private void lbl_card_Click(object sender, EventArgs e)
        {
            if (clickedCard)
            {
                lbl_cardTraditional.Visible = false;
                lbl_cardAnime.Visible = false;
                clickedCard = false;
            }
            else
            {
                lbl_cardTraditional.Visible = true;
                lbl_cardAnime.Visible = true;
                clickedCard = true;
            }
        }

        bool backgroundClicked = false;
        private void lbl_Background_Click_1(object sender, EventArgs e)
        {
            if (backgroundClicked)
            {
                lbl_cardOption1.Visible = false;
                lbl_cardOption2.Visible = false;
                lbl_cardOption3.Visible = false;
                lbl_cardOption4.Visible = false;
                backgroundClicked = false;
            }
            else
            {
                lbl_cardOption1.Visible = true;
                lbl_cardOption2.Visible = true;
                lbl_cardOption3.Visible = true;
                lbl_cardOption4.Visible = true;
                backgroundClicked = true;
            }
        }
    }
}
