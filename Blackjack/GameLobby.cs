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
    public partial class GameLobby : Form
    {
        public GameLobby(string _username, int _chips)
        {
            InitializeComponent();
            chips = _chips;
            username = _username;
            SetValues();
        }

        private void GameLobby_Load(object sender, EventArgs e)
        {
            lbl_chips.Text = chips.ToString();
        }

        private List<string> cards = new List<string>
        { 
            "c1", "c2", "c3", "c4", "c5", "c6", "c7", "c8", "c9", "c10", "c11", "c12", "c13", // 0-12
            "s1", "s2", "s3", "s4", "s5", "s6", "s7", "s8", "s9", "s10", "s11", "s12", "s13", // 13-25
            "h1", "h2", "h3", "h4", "h5", "h6", "h7", "h8", "h9", "h10", "h11", "h12", "h13", // 26-38
            "d1", "d2", "d3", "d4", "d5", "d6", "d7", "d8", "d9", "d10", "d11", "d12", "d13"  // 39-51
        };

        private List<Image> option1 = new List<Image> 
        {
            //CLUBS
            Blackjack.Properties.Resources.cardl_c01,
            Blackjack.Properties.Resources.cardl_c02,
            Blackjack.Properties.Resources.cardl_c03,
            Blackjack.Properties.Resources.cardl_c04,
            Blackjack.Properties.Resources.cardl_c05,
            Blackjack.Properties.Resources.cardl_c06,
            Blackjack.Properties.Resources.cardl_c07,
            Blackjack.Properties.Resources.cardl_c08,
            Blackjack.Properties.Resources.cardl_c09,
            Blackjack.Properties.Resources.cardl_c10,
            Blackjack.Properties.Resources.cardl_c11,
            Blackjack.Properties.Resources.cardl_c12,
            Blackjack.Properties.Resources.cardl_c13,
            //SPADES
            Blackjack.Properties.Resources.cardl_s01,
            Blackjack.Properties.Resources.cardl_s02,
            Blackjack.Properties.Resources.cardl_s03,
            Blackjack.Properties.Resources.cardl_s04,
            Blackjack.Properties.Resources.cardl_s05,
            Blackjack.Properties.Resources.cardl_s06,
            Blackjack.Properties.Resources.cardl_s07,
            Blackjack.Properties.Resources.cardl_s08,
            Blackjack.Properties.Resources.cardl_s09,
            Blackjack.Properties.Resources.cardl_s10,
            Blackjack.Properties.Resources.cardl_s11,
            Blackjack.Properties.Resources.cardl_s12,
            Blackjack.Properties.Resources.cardl_s13,
            //HEARTS
            Blackjack.Properties.Resources.cardl_h01,
            Blackjack.Properties.Resources.cardl_h02,
            Blackjack.Properties.Resources.cardl_h03,
            Blackjack.Properties.Resources.cardl_h04,
            Blackjack.Properties.Resources.cardl_h05,
            Blackjack.Properties.Resources.cardl_h06,
            Blackjack.Properties.Resources.cardl_h07,
            Blackjack.Properties.Resources.cardl_h08,
            Blackjack.Properties.Resources.cardl_h09,
            Blackjack.Properties.Resources.cardl_h10,
            Blackjack.Properties.Resources.cardl_h11,
            Blackjack.Properties.Resources.cardl_h12,
            Blackjack.Properties.Resources.cardl_h13,
            //DIAMONDS
            Blackjack.Properties.Resources.cardl_d01,
            Blackjack.Properties.Resources.cardl_d02,
            Blackjack.Properties.Resources.cardl_d03,
            Blackjack.Properties.Resources.cardl_d04,
            Blackjack.Properties.Resources.cardl_d05,
            Blackjack.Properties.Resources.cardl_d06,
            Blackjack.Properties.Resources.cardl_d07,
            Blackjack.Properties.Resources.cardl_d08,
            Blackjack.Properties.Resources.cardl_d09,
            Blackjack.Properties.Resources.cardl_d10,
            Blackjack.Properties.Resources.cardl_d11,
            Blackjack.Properties.Resources.cardl_d12,
            Blackjack.Properties.Resources.cardl_d13
        };

        private List<Image> option2 = new List<Image> 
        {
            //CLUBS
            Blackjack.Properties.Resources.cards_c01,
            Blackjack.Properties.Resources.cards_c02,
            Blackjack.Properties.Resources.cards_c03,
            Blackjack.Properties.Resources.cards_c04,
            Blackjack.Properties.Resources.cards_c05,
            Blackjack.Properties.Resources.cards_c06,
            Blackjack.Properties.Resources.cards_c07,
            Blackjack.Properties.Resources.cards_c08,
            Blackjack.Properties.Resources.cards_c09,
            Blackjack.Properties.Resources.cards_c10,
            Blackjack.Properties.Resources.cards_c11,
            Blackjack.Properties.Resources.cards_c12,
            Blackjack.Properties.Resources.cards_c13,
            //SPADES
            Blackjack.Properties.Resources.cards_s01,
            Blackjack.Properties.Resources.cards_s02,
            Blackjack.Properties.Resources.cards_s03,
            Blackjack.Properties.Resources.cards_s04,
            Blackjack.Properties.Resources.cards_s05,
            Blackjack.Properties.Resources.cards_s06,
            Blackjack.Properties.Resources.cards_s07,
            Blackjack.Properties.Resources.cards_s08,
            Blackjack.Properties.Resources.cards_s09,
            Blackjack.Properties.Resources.cards_s10,
            Blackjack.Properties.Resources.cards_s11,
            Blackjack.Properties.Resources.cards_s12,
            Blackjack.Properties.Resources.cards_s13,
            //HEARTS
            Blackjack.Properties.Resources.cards_h01,
            Blackjack.Properties.Resources.cards_h02,
            Blackjack.Properties.Resources.cards_h03,
            Blackjack.Properties.Resources.cards_h04,
            Blackjack.Properties.Resources.cards_h05,
            Blackjack.Properties.Resources.cards_h06,
            Blackjack.Properties.Resources.cards_h07,
            Blackjack.Properties.Resources.cards_h08,
            Blackjack.Properties.Resources.cards_h09,
            Blackjack.Properties.Resources.cards_h10,
            Blackjack.Properties.Resources.cards_h11,
            Blackjack.Properties.Resources.cards_h12,
            Blackjack.Properties.Resources.cards_h13,
            //DIAMONDS
            Blackjack.Properties.Resources.cards_d01,
            Blackjack.Properties.Resources.cards_d02,
            Blackjack.Properties.Resources.cards_d03,
            Blackjack.Properties.Resources.cards_d04,
            Blackjack.Properties.Resources.cards_d05,
            Blackjack.Properties.Resources.cards_d06,
            Blackjack.Properties.Resources.cards_d07,
            Blackjack.Properties.Resources.cards_d08,
            Blackjack.Properties.Resources.cards_d09,
            Blackjack.Properties.Resources.cards_d10,
            Blackjack.Properties.Resources.cards_d11,
            Blackjack.Properties.Resources.cards_d12,
            Blackjack.Properties.Resources.cards_d13
        };

        private Image cardBack1         = Blackjack.Properties.Resources.cardl_back;
        private Image cardBack2         = Blackjack.Properties.Resources.cards_back;

        int[] usedCards = new int[52];

        // USER INFO AND DATA.
        public string username;
        private string userInfo;
        private int options = 1;
        private int optionsBack = 1;

        // DRAW CARD SCENARIOS.
        private bool dealerDraw = false; // dealers turn to draw;
        private bool playerDraw = false; // players turn to draw;
        private bool player = false; // checkCards() -> player;
        private bool dealer = false; // checkCards() -> dealer;
        private int playerSlot = 1;     // What card slot the image will go to when player hits;
        private int sPlayerSlot = 1;
        private int dealerslot = 1;     // what card slot the image will go to when dealer hits;

        // BET/DEAL/HIT SCENARIOS.
        private bool canBet = true; // If player can bet or not;
        private bool canDeal = true; // If cards can be dealt or not;
        private bool canDrawCard = false; // if player can draw a card;
        private bool canDD = false; // if player can double down/split;
        private bool cardSplit = false; // if player has split;

        // INFORMATION ON CHIPS, HANDS, ETC.
        public int chips = 0;
        private int bet = 0;
        private int sBet = 0;
        private int earnings = 0;
        private int playerHand = 0;
        private int dealerHand = 0;
        private bool hasAce = false;
        private bool hasSAce = false;
        private bool canBlackjack = true;

        // CARD SELECTING
        private string chosenCard;
        private Image cardDirectory;

        // SPLIT
        private string splitCard1;
        private string splitCard2;
        private int splitCard;
        private int playerHandSplit;
        private int splitNum;

        private int result = 0;
        private int sResult = 0;

        Random random = new Random();

        private void SetValues()
        {
            userInfo = username + "_Info.dll";

            StreamReader sr = new StreamReader(userInfo);
            chips = Convert.ToInt32(sr.ReadLine());
            options = Convert.ToInt32(sr.ReadLine());
            optionsBack = Convert.ToInt32(sr.ReadLine());
            sr.Close();

            if (optionsBack == 1)
                this.BackgroundImage = Blackjack.Properties.Resources.Blackjack_tabledeal;
            else if (optionsBack == 2)
                this.BackgroundImage = Blackjack.Properties.Resources.AnimeBack1deal;
            else if (optionsBack == 3)
                this.BackgroundImage = Blackjack.Properties.Resources.AnimeBack2deal;
            else if (optionsBack == 4)
                this.BackgroundImage = Blackjack.Properties.Resources.AnimeBack3deal;

            if (optionsBack == 1)
            {
                lbl_bet1.Visible = true;
                lbl_bet5.Visible = true;
                lbl_bet10.Visible = true;
                lbl_bet25.Visible = true;
                lbl_bet50.Visible = true;
                lbl_bet100.Visible = true;
                lbl_bet250.Visible = true;
            }
            else
            {
                lbl_AnimeBet1.Visible = true;
                lbl_AnimeBet5.Visible = true;
                lbl_AnimeBet10.Visible = true;
                lbl_AnimeBet25.Visible = true;
                lbl_AnimeBet50.Visible = true;
                lbl_AnimeBet100.Visible = true;
                lbl_AnimeBet250.Visible = true;
            }

            lbl_chips.Text = chips.ToString();
        }

        // SETS THE USERS CHIP VALUE
        private void setChips()
        {
            userInfo = username + "_Info.dll";
            TextWriter tw = new StreamWriter(userInfo);
            tw.WriteLine(chips);
            tw.WriteLine(options);
            tw.WriteLine(optionsBack);
            tw.Close();
        }

        // RESETS THE USED CARD ARRAY SO CARDS CAN BE USED AGAIN
        private void resetUsedCards()
        {
            int x;

            for (x = 0; x < 52; x++)
            {
                usedCards[x] = -1;
            }
        }

        // CHECKS WHAT CARD WHAT WAS SELECTED AND RETURNS THE CORRECT PICTURE DIRECTORY FOR THE CARD
        private void checkCards()
        {
            int x;

            for (x = 0; x < 52; x++)
            {
                string y = cards[x];

                if (chosenCard == y)
                {
                    if (options == 1)
                        cardDirectory = option1[x];
                    else if (options == 2)
                        cardDirectory = option2[x];

                    if (player)
                    {
                        if (x == 0 || x == 13 || x == 26 || x == 39) // aces can equal 1 or 11
                        {
                            splitCard = 11;
                            if (cardSplit)
                            {
                                if (splitNum == 1)
                                {
                                    if (playerHandSplit < 11)
                                        playerHandSplit += 11;
                                    else
                                        playerHandSplit += 1;
                                }
                                else if (splitNum == 0)
                                {
                                    hasAce = true;
                                    if (playerHand < 11)
                                        playerHand += 11;
                                    else
                                        playerHand += 1;
                                }
                            }
                            else if (cardSplit == false)
                            {
                                hasAce = true;
                                if (playerHand < 11)
                                    playerHand += 11;
                                else
                                    playerHand += 1;
                            }
                        }

                        else if (x >= 10 && x <= 12 || x >= 23 && x <= 25 || x >= 36 && x <= 38 || x >= 49 && x <= 51) // makes all jacks, queens, and kings = 10
                        {
                            splitCard = 10;
                            if (cardSplit)
                            {
                                if (splitNum == 1)
                                    playerHandSplit += 10;
                                else if (splitNum == 0)
                                    playerHand += 10;
                            }
                            else if (cardSplit == false)
                                playerHand += 10;
                        }
                        else if (x >= 1 && x <= 9) // 2 - 10 of clubs
                        {
                            splitCard = x + 1;
                            if (cardSplit)
                            {
                                if (splitNum == 1)
                                    playerHandSplit += x + 1;
                                else if (splitNum == 0)
                                    playerHand += x + 1;
                            }
                            else if (cardSplit == false)
                                playerHand += x + 1;
                        }
                        else if (x >= 14 && x <= 22) // 2 - 10 of Spades
                        {
                            splitCard = x - 12;

                            if (cardSplit)
                            {
                                if (splitNum == 1)
                                    playerHandSplit += x - 12;
                                else if (splitNum == 0)
                                    playerHand += x - 12;
                            }
                            else if (cardSplit == false)
                                playerHand += x - 12;
                        }
                        else if (x >= 27 && x <= 35) // 2 - 10 of Hearts
                        {
                            splitCard = x - 25;

                            if (cardSplit)
                            {
                                if (splitNum == 1)
                                    playerHandSplit += x - 25;
                                else if (splitNum == 0)
                                    playerHand += x - 25;
                            }
                            else if (cardSplit == false)
                                playerHand += x - 25;
                        }
                        else if (x >= 40 && x <= 48) // 2 - 10 of Diamonds
                        {
                            splitCard = x - 38;

                            if (cardSplit)
                            {
                                if (splitNum == 1)
                                    playerHandSplit += x - 38;
                                else if (splitNum == 0)
                                    playerHand += x - 38;
                            }
                            else if (cardSplit == false)
                                playerHand += x - 38;
                        }

                        lbl_playerHand.Text = playerHand.ToString();
                        lbl_sPlayerHand.Text = playerHandSplit.ToString();
                        player = false;
                    }
                    else if (dealer)
                    {
                        if (x == 0 || x == 13 || x == 26 || x == 39) // aces can equal 1 or 11
                        {
                            if (dealerHand < 11)
                                dealerHand += 11;
                            else
                                dealerHand += 1;
                        }

                        else if (x >= 10 && x <= 12 || x >= 23 && x <= 25 || x >= 36 && x <= 38 || x >= 49 && x <= 51) // makes all jacks, queens, and kings = 10
                            dealerHand += 10;

                        else if (x >= 1 && x <= 9) // 2 - 10 of clubs
                            dealerHand += x + 1;

                        else if (x >= 14 && x <= 22) // 2 - 10 of Spades
                            dealerHand += x - 12;

                        else if (x >= 27 && x <= 35) // 2 - 10 of Hearts
                            dealerHand += x - 25;

                        else if (x >= 40 && x <= 48) // 2 - 10 of Diamonds
                            dealerHand += x - 38;

                        lbl_dealerHand.Text = dealerHand.ToString();
                        dealer = false;
                    }
                    Console.WriteLine(chosenCard);
                    return;
                }
            }
        }

        // DEALS THE PLAYERS INITIAL CARDS
        private void dealPlayerCards()
        {
            while (card_player1.BackgroundImage == null)
            {
                player = true;
                int randomCardNum = random.Next(cards.Count);
                String randomCard = cards[randomCardNum];

                card_player1.Tag = randomCard;
                chosenCard = randomCard;

                if (randomCardNum == usedCards[randomCardNum])
                {
                    card_player1.Tag = null;
                    chosenCard = null;
                    return;
                }
                else
                {
                    usedCards[randomCardNum] = randomCardNum;
                    checkCards();
                    card_player1.BackgroundImage = cardDirectory;
                    player = false;
                    if (splitNum == 0)
                    {
                        splitCard1 = randomCard;
                        splitNum++;
                    }
                    else if (splitNum == 1)
                    {
                        splitCard2 = randomCard;
                        splitNum--;
                    }
                }
            }

            while (card_player2.BackgroundImage == null)
            {
                player = true;
                int randomCardNum = random.Next(cards.Count);
                String randomCard = cards[randomCardNum];

                card_player2.Tag = randomCard;
                chosenCard = randomCard;

                if (randomCardNum == usedCards[randomCardNum])
                {
                    card_player2.Tag = null;
                    chosenCard = null;
                    return;
                }
                else
                {
                    usedCards[randomCardNum] = randomCardNum;
                    checkCards();
                    card_player2.BackgroundImage = cardDirectory;
                    player = false;
                    if (splitNum == 0)
                    {
                        splitCard1 = randomCard;
                        splitNum++;
                    }
                    else if (splitNum == 1)
                    {
                        splitCard2 = randomCard;
                        splitNum--;
                    }
                }
            }
        }

        // DEALS THE DEALERS INITIAL CARDS
        private void dealDealerCards()
        {
            if (options == 1)
                card_dealer1.BackgroundImage = cardBack1;
            else if (options == 2)
                card_dealer1.BackgroundImage = cardBack2;

            while (card_dealer2.BackgroundImage == null)
            {
                dealer = true;

                int randomCardNum = random.Next(cards.Count);
                String randomCard = cards[randomCardNum];

                card_dealer2.Tag = randomCard;
                chosenCard = randomCard;

                if (randomCardNum == usedCards[randomCardNum])
                {
                    card_dealer2.Tag = null;
                    chosenCard = null;
                    return;
                }
                else
                {
                    usedCards[randomCardNum] = randomCardNum;
                    checkCards();
                    card_dealer2.BackgroundImage = cardDirectory;
                    dealer = false;
                }
            }
        }

        // DRAWS A CARD
        private void drawCard()
        {
            int x = 0;

            while (x == 0)
            {
                int randomCardNum = random.Next(cards.Count);
                String randomCard = cards[randomCardNum];

                if (randomCardNum == usedCards[randomCardNum])
                {
                    return;
                }
                else
                {
                    usedCards[randomCardNum] = randomCardNum;
                    chosenCard = randomCard;
                    checkCards();

                    if (playerDraw)
                    {
                        if (playerSlot == 1)
                        {
                            card_player3.Tag = chosenCard;
                            card_player3.BackgroundImage = cardDirectory;
                            card_player3.BringToFront();
                        }
                        else if (playerSlot == 2)
                        {
                            card_player4.Tag = chosenCard;
                            card_player4.BackgroundImage = cardDirectory;
                            card_player4.BringToFront();
                        }
                        else if (playerSlot == 3)
                        {
                            card_player5.Tag = chosenCard;
                            card_player5.BackgroundImage = cardDirectory;
                            card_player5.BringToFront();
                        }
                        else if (playerSlot == 4)
                        {
                            card_player6.Tag = chosenCard;
                            card_player6.BackgroundImage = cardDirectory;
                            card_player6.BringToFront();
                        }
                        playerSlot++;
                    }
                    else if (dealerDraw)
                    {
                        if (dealerslot == 1)
                        {
                            card_dealer1.Tag = chosenCard;
                            card_dealer1.BackgroundImage = cardDirectory;
                        }
                        else if (dealerslot == 2)
                        {
                            card_dealer3.Tag = chosenCard;
                            card_dealer3.BackgroundImage = cardDirectory;
                            card_dealer3.BringToFront();
                        }
                        else if (dealerslot == 3)
                        {
                            card_dealer4.Tag = chosenCard;
                            card_dealer4.BackgroundImage = cardDirectory;
                            card_dealer4.BringToFront();
                        }
                        else if (dealerslot == 4)
                        {
                            card_dealer5.Tag = chosenCard;
                            card_dealer5.BackgroundImage = cardDirectory;
                            card_dealer5.BringToFront();
                        }
                        else if (dealerslot == 5)
                        {
                            card_dealer6.Tag = chosenCard;
                            card_dealer6.BackgroundImage = cardDirectory;
                            card_dealer6.BringToFront();
                        }
                        dealerslot++;
                    }

                    playerDraw = false;
                    dealerDraw = false;
                    x = 1;
                }
            }
        }

        private void stand()
        {
            if (cardSplit)
            {
                while (dealerHand <= 16 && dealerHand < playerHand && dealerHand < playerHandSplit)
                {
                    dealerDraw = true;
                    dealer = true;
                    drawCard();
                }
                if (dealerHand > 16)
                {
                    if (dealerHand == playerHand)
                    {
                        result = 2;
                        splitResult();

                    }
                    else if (dealerHand < playerHand || dealerHand > 21)
                    {
                        result = 1;
                        splitResult();
                    }
                    else
                    {
                        result = 4;
                        splitResult();
                    }

                    if (dealerHand == playerHandSplit)
                    {
                        sResult = 2;
                        splitResult();
                    }
                    else if (dealerHand < playerHandSplit || dealerHand > 21)
                    {
                        sResult = 1;
                        splitResult();
                    }
                    else
                    {
                        sResult = 4;
                        splitResult();
                    }

                    splitResult();
                }
            }
            else if (playerHand <= 21)
            {
                while (dealerHand <= 16 && dealerHand < playerHand)
                {
                    dealerDraw = true;
                    dealer = true;
                    drawCard();
                }
                if (dealerHand > 16)
                {
                    if (dealerHand == playerHand)
                    {
                        result = 2;
                        handResult();
                    }
                    else if (dealerHand < playerHand || dealerHand > 21)
                    {
                        result = 1;
                        handResult();
                    }
                    else
                    {
                        result = 4;
                        handResult();
                    }
                }
            }
            else
            {
                result = 4;
                handResult();
            }
        }

        // SPLIT THE CARDS
        private void split()
        {
            int x; // first
            int y; // second

            for (x = 0; x < 52; x++)
            {
                string f = cards[x];

                if (splitCard1 == f)
                {
                    for (y = 0; y < 52; y++)
                    {
                        string s = cards[y];

                        if (splitCard2 == s)
                        {
                            if (x == y - 13 || x == y - 26 || x == y - 39 || y == x - 13 || y == x - 26 || y == x - 39)
                            {
                                chosenCard = cards[y];
                                if (options == 1)
                                    cardDirectory = option1[y];
                                else if (options == 2)
                                    cardDirectory = option2[y];
                                playerHand -= splitCard;
                                playerHandSplit += splitCard;

                                card_player1.BringToFront();
                                card_player2.Tag = null;
                                card_player2.BackgroundImage = null;
                                sCard1.BackgroundImage = cardDirectory;

                                lbl_sPlayerHand.Visible = true;
                                lbl_sPlayerHand.Text = playerHandSplit.ToString();
                                lbl_playerHand.Text = playerHand.ToString();
                                lbl_playerHand.Cursor = Cursors.Hand;

                                canDD = false;
                                cardSplit = true;

                                if (optionsBack == 1)
                                    this.BackgroundImage = Blackjack.Properties.Resources.Blackjack_tabledeal2;
                                else if (optionsBack == 2)
                                    this.BackgroundImage = Blackjack.Properties.Resources.AnimeBack1deal2;
                                else if (optionsBack == 3)
                                    this.BackgroundImage = Blackjack.Properties.Resources.AnimeBack2deal2;
                                else if (optionsBack == 4)
                                    this.BackgroundImage = Blackjack.Properties.Resources.AnimeBack3deal2;

                                lbl_doubledown.Visible = false;
                                lbl_split.Visible = false;

                                lbl_highlight.Visible = true;
                                lbl_sHighlight.Visible = true;

                                chips -= bet;
                                sBet += bet;
                                lbl_currBet.Text = "Bet: " + bet + " : " + sBet;
                                lbl_chips.Text = chips.ToString();
                            }
                        }
                    }
                }
            }
        }

        // DEALS THE CARDS IF ITS SPLIT
        private void dealSplit()
        {
            int x = 0;

            while (x == 0)
            {
                int randomCardNum = random.Next(cards.Count);
                String randomCard = cards[randomCardNum];

                if (randomCardNum == usedCards[randomCardNum])
                {
                    return;
                }
                else
                {
                    usedCards[randomCardNum] = randomCardNum;
                    chosenCard = randomCard;
                    checkCards();

                    if (splitNum == 0)
                    {
                        if (playerSlot == 1)
                        {
                            card_player2.Tag = chosenCard;
                            card_player2.BackgroundImage = cardDirectory;
                            card_player2.BringToFront();
                        }
                        else if (playerSlot == 2)
                        {
                            card_player3.Tag = chosenCard;
                            card_player3.BackgroundImage = cardDirectory;
                            card_player3.BringToFront();
                        }
                        else if (playerSlot == 3)
                        {
                            card_player4.Tag = chosenCard;
                            card_player4.BackgroundImage = cardDirectory;
                            card_player4.BringToFront();
                        }
                        else if (playerSlot == 4)
                        {
                            card_player5.Tag = chosenCard;
                            card_player5.BackgroundImage = cardDirectory;
                            card_player5.BringToFront();
                        }
                        else if (playerSlot == 5)
                        {
                            card_player6.Tag = chosenCard;
                            card_player6.BackgroundImage = cardDirectory;
                            card_player6.BringToFront();
                        }
                        playerSlot++;
                    }
                    else if (splitNum == 1)
                    {
                        if (sPlayerSlot == 1)
                        {
                            sCard2.Tag = chosenCard;
                            sCard2.BackgroundImage = cardDirectory;
                            sCard2.BringToFront();
                        }
                        else if (sPlayerSlot == 2)
                        {
                            sCard3.Tag = chosenCard;
                            sCard3.BackgroundImage = cardDirectory;
                            sCard3.BringToFront();
                        }
                        else if (sPlayerSlot == 3)
                        {
                            sCard4.Tag = chosenCard;
                            sCard4.BackgroundImage = cardDirectory;
                            sCard4.BringToFront();
                        }
                        else if (sPlayerSlot == 4)
                        {
                            sCard5.Tag = chosenCard;
                            sCard5.BackgroundImage = cardDirectory;
                            sCard5.BringToFront();
                        }
                        sPlayerSlot++;
                    }

                    x++;
                }
                checkSplit();
            }
        }

        private void checkSplit()
        {
            if (hasAce)
            {
                if (playerHand > 21)
                {
                    playerHand -= 10;
                }
            }
            if (playerHand > 21)
            {
                result = 4;
                splitNum = 1;
                lbl_sHighlight.BackColor = Color.Gold;
                lbl_highlight.BackColor = Color.Transparent;
            }

            if (hasSAce)
            {
                if (playerHandSplit > 21)
                {
                    playerHandSplit -= 10;
                }
            }
            if (playerHandSplit > 21)
            {
                sResult = 4;
                splitNum = 0;
                lbl_highlight.BackColor = Color.Gold;
                lbl_sHighlight.BackColor = Color.Transparent;
            }

            if (playerHandSplit > 21 && playerHand > 21)
                splitResult();
        }

        private void splitResult()
        {
            if (result == 1) // Player won
            {
                chips += bet * 2;
                earnings += bet;
                bet = 0;
                lbl_result.Text = "PLAYER WON";
            }
            else if (result == 2) // draw
            {
                chips += bet;
                bet = 0;
                lbl_result.Text = "DRAW";
            }
            else if (result == 4) // player loss
            {
                earnings -= bet;
                bet = 0;
                lbl_result.Text = "DEALER WON";
            }

            if (sResult == 1) // Player won
            {
                chips += sBet * 2;
                earnings += sBet;
                sBet = 0;
                lbl_result.Text += " : PLAYER WON";
            }
            else if (sResult == 2) // draw
            {
                chips += sBet;
                sBet = 0;
                lbl_result.Text += " : DRAW";
            }
            else if (sResult == 4) // player loss
            {
                earnings -= sBet;
                sBet = 0;
                lbl_result.Text += " : DEALER WON";
            }

            lbl_earnings.Text = "Earnings: " + earnings;
            lbl_currBet.Text = "Bet: " + bet;
            lbl_chips.Text = chips.ToString();

            if (optionsBack == 1)
                this.BackgroundImage = Blackjack.Properties.Resources.Blackjack_tabledeal;
            else if (optionsBack == 2)
                this.BackgroundImage = Blackjack.Properties.Resources.AnimeBack1deal;
            else if (optionsBack == 3)
                this.BackgroundImage = Blackjack.Properties.Resources.AnimeBack2deal;
            else if (optionsBack == 4)
                this.BackgroundImage = Blackjack.Properties.Resources.AnimeBack3deal;

            lbl_stay.Visible = false;
            lbl_hit.Visible = false;
            lbl_deal.Visible = true;
            lbl_result.Visible = true;

            canDeal = true;
            canBet = true;
            canDD = false;
            canDrawCard = false;
            cardSplit = false;
        }

        private void checkHand()
        {
            if (hasAce)
            {
                if (playerHand > 21)
                {
                    playerHand -= 10;
                }
            }

            if (playerHand > 21)
            {
                result = 4;
                dealerDraw = true;
                dealer = true;
                playerDraw = false;
                drawCard();
                handResult();
            }
            if (canBlackjack)
            {
                if (playerHand == 21)
                {
                    result = 3;
                    handResult();
                }
            }
        }

        private void handResult()
        {
            if (result == 1) // Player won
            {
                chips += bet * 2;
                earnings += bet;
                bet = 0;
                lbl_result.Text = "PLAYER WON";
            }
            else if (result == 2) // draw
            {
                chips += bet;
                bet = 0;
                lbl_result.Text = "DRAW";
            }
            else if (result == 3) // blackjack
            {
                chips += bet / 2 * 3;
                earnings += bet;
                bet = 0;
                lbl_result.Text = "BLACKJACK";
            }
            else if (result == 4) // player loss
            {
                earnings -= bet;
                bet = 0;
                lbl_result.Text = "DEALER WON";
            }

            lbl_earnings.Text = "Earnings: " + earnings;
            lbl_currBet.Text = "Bet: " + bet;
            lbl_chips.Text = chips.ToString();

            if (optionsBack == 1)
                this.BackgroundImage = Blackjack.Properties.Resources.Blackjack_tabledeal;
            else if (optionsBack == 2)
                this.BackgroundImage = Blackjack.Properties.Resources.AnimeBack1deal;
            else if (optionsBack == 3)
                this.BackgroundImage = Blackjack.Properties.Resources.AnimeBack2deal;
            else if (optionsBack == 4)
                this.BackgroundImage = Blackjack.Properties.Resources.AnimeBack3deal;

            lbl_stay.Visible = false;
            lbl_hit.Visible = false;
            lbl_deal.Visible = true;
            lbl_result.Visible = true;

            canDeal = true;
            canBet = true;
            canDD = false;
            canDrawCard = false;
            cardSplit = false;
        }

        // BUTTON CLICKS

        private void lbl_cashier_Click(object sender, EventArgs e)
        {
            setChips();
            this.Hide();
            GetChips form = new GetChips(username);
            form.FormClosed += new FormClosedEventHandler(form_formClosed);
            form.ShowDialog();
        }

        private void lbl_deal_Click(object sender, EventArgs e)
        {
            if (canDeal)
            {
                if (bet > 0)
                {
                    if (optionsBack == 1)
                        this.BackgroundImage = Blackjack.Properties.Resources.Blackjack_tabledeal1;
                    else if (optionsBack == 2)
                        this.BackgroundImage = Blackjack.Properties.Resources.AnimeBack1deal1;
                    else if (optionsBack == 3)
                        this.BackgroundImage = Blackjack.Properties.Resources.AnimeBack2deal1;
                    else if (optionsBack == 4)
                        this.BackgroundImage = Blackjack.Properties.Resources.AnimeBack3deal1;

                    card_player1.BackgroundImage = null;
                    card_player2.BackgroundImage = null;
                    card_player3.BackgroundImage = null;
                    card_player4.BackgroundImage = null;
                    card_player5.BackgroundImage = null;
                    card_player6.BackgroundImage = null;

                    card_player3.SendToBack();
                    card_player4.SendToBack();
                    card_player5.SendToBack();
                    card_player6.SendToBack();

                    card_dealer1.BackgroundImage = null;
                    card_dealer2.BackgroundImage = null;
                    card_dealer3.BackgroundImage = null;
                    card_dealer4.BackgroundImage = null;
                    card_dealer5.BackgroundImage = null;
                    card_dealer6.BackgroundImage = null;

                    card_dealer3.SendToBack();
                    card_dealer4.SendToBack();
                    card_dealer5.SendToBack();
                    card_dealer6.SendToBack();

                    sCard1.BackgroundImage = null;
                    sCard2.BackgroundImage = null;
                    sCard3.BackgroundImage = null;
                    sCard4.BackgroundImage = null;
                    sCard5.BackgroundImage = null;

                    sCard2.SendToBack();
                    sCard3.SendToBack();
                    sCard4.SendToBack();
                    sCard5.SendToBack();

                    lbl_sPlayerHand.Visible = false;
                    lbl_sHighlight.Visible = false;

                    lbl_result.Visible = false;

                    lbl_deal.Visible = false;
                    lbl_hit.Visible = true;
                    lbl_stay.Visible = true;
                    lbl_doubledown.Visible = true;
                    lbl_split.Visible = true;

                    dealerHand = 0;
                    playerHand = 0;
                    playerSlot = 1;
                    dealerslot = 1;

                    resetUsedCards();
                    dealPlayerCards();
                    dealDealerCards();
                    checkHand();

                    canBet = false;
                    canDeal = false;
                    canDrawCard = true;
                    canDD = true;
                    canBlackjack = true;

                    lbl_playerHand.Visible = true;
                    lbl_dealerHand.Visible = true;
                }
            }
        }

        private void lbl_hit_Click(object sender, EventArgs e)
        {
            if (canDrawCard)
            {
                if (optionsBack == 1)
                    this.BackgroundImage = Blackjack.Properties.Resources.Blackjack_tabledeal2;
                else if (optionsBack == 2)
                    this.BackgroundImage = Blackjack.Properties.Resources.AnimeBack1deal2;
                else if (optionsBack == 3)
                    this.BackgroundImage = Blackjack.Properties.Resources.AnimeBack2deal2;
                else if (optionsBack == 4)
                    this.BackgroundImage = Blackjack.Properties.Resources.AnimeBack3deal2;

                lbl_doubledown.Visible = false;
                lbl_split.Visible = false;
                player = true;

                if (cardSplit)
                {
                    canBlackjack = false;
                    dealSplit();
                    checkSplit();
                }
                else
                {
                    canDD = false;
                    canBlackjack = false;
                    playerDraw = true;
                    drawCard();
                    checkHand();
                }
            }
        }

        private void lbl_stay_Click(object sender, EventArgs e)
        {
            if (canDrawCard)
                stand();
        }

        private void lbl_split_Click(object sender, EventArgs e)
        {
            if (canDD)
                split();
        }

        private void lbl_doubledown_Click(object sender, EventArgs e)
        {
            if (canDrawCard)
            {
                if (canDD)
                {
                    if (chips >= bet)
                    {
                        chips -= bet;
                        bet += bet;
                        lbl_currBet.Text = "Bet: " + bet;
                        lbl_chips.Text = "Chips: " + chips;

                        playerDraw = true;
                        player = true;
                        drawCard();

                        stand();
                    }
                }
            }
        }

        private void lbl_bet1_Click(object sender, EventArgs e)
        {
            if (canBet)
            {
                if (chips > 0)
                {
                    chips -= 1;
                    bet += 1;
                    lbl_chips.Text = chips.ToString();
                    lbl_currBet.Text = "Bet: " + bet;
                    setChips();
                }
            }
        }

        private void lbl_bet5_Click(object sender, EventArgs e)
        {
            if (canBet)
            {
                if (chips > 4)
                {
                    chips -= 5;
                    bet += 5;
                    lbl_chips.Text = chips.ToString();
                    lbl_currBet.Text = "Bet: " + bet;
                    setChips();
                }
            }
        }

        private void lbl_bet10_Click(object sender, EventArgs e)
        {
            if (chips > 9)
            {
                chips -= 10;
                bet += 10;
                lbl_chips.Text = chips.ToString();
                lbl_currBet.Text = "Bet: " + bet;
                setChips();
            }
        }

        private void lbl_bet25_Click(object sender, EventArgs e)
        {
            if (canBet)
            {
                if (chips > 24)
                {
                    chips -= 25;
                    bet += 25;
                    lbl_chips.Text = chips.ToString();
                    lbl_currBet.Text = "Bet: " + bet;
                    setChips();
                }
            }
        }

        private void lbl_bet50_Click(object sender, EventArgs e)
        {
            if (canBet)
            {
                if (chips > 49)
                {
                    chips -= 50;
                    bet += 50;
                    lbl_chips.Text = chips.ToString();
                    lbl_currBet.Text = "Bet: " + bet;
                    setChips();
                }
            }
        }

        private void lbl_bet100_Click(object sender, EventArgs e)
        {
            if (canBet)
            {
                if (chips > 99)
                {
                    chips -= 100;
                    bet += 100;
                    lbl_chips.Text = chips.ToString();
                    lbl_currBet.Text = "Bet: " + bet;
                    setChips();
                }
            }
        }

        private void lbl_bet250_Click(object sender, EventArgs e)
        {
            if (canBet)
            {
                if (chips > 249)
                {
                    chips -= 250;
                    bet += 250;
                    lbl_chips.Text = chips.ToString();
                    lbl_currBet.Text = "Bet: " + bet;
                    setChips();
                }
            }
        }

        private void lbl_AnimeBet1_Click(object sender, EventArgs e)
        {
            if (canBet)
            {
                if (chips > 0)
                {
                    chips -= 1;
                    bet += 1;
                    lbl_chips.Text = chips.ToString();
                    lbl_currBet.Text = "Bet: " + bet;
                    setChips();
                }
            }
        }

        private void lbl_AnimeBet5_Click(object sender, EventArgs e)
        {
            if (canBet)
            {
                if (chips > 4)
                {
                    chips -= 5;
                    bet += 5;
                    lbl_chips.Text = chips.ToString();
                    lbl_currBet.Text = "Bet: " + bet;
                    setChips();
                }
            }
        }

        private void lbl_AnimeBet10_Click(object sender, EventArgs e)
        {
            if (chips > 9)
            {
                chips -= 10;
                bet += 10;
                lbl_chips.Text = chips.ToString();
                lbl_currBet.Text = "Bet: " + bet;
                setChips();
            }
        }

        private void lbl_AnimeBet25_Click(object sender, EventArgs e)
        {
            if (canBet)
            {
                if (chips > 24)
                {
                    chips -= 25;
                    bet += 25;
                    lbl_chips.Text = chips.ToString();
                    lbl_currBet.Text = "Bet: " + bet;
                    setChips();
                }
            }
        }

        private void lbl_AnimeBet50_Click(object sender, EventArgs e)
        {
            if (canBet)
            {
                if (chips > 49)
                {
                    chips -= 50;
                    bet += 50;
                    lbl_chips.Text = chips.ToString();
                    lbl_currBet.Text = "Bet: " + bet;
                    setChips();
                }
            }
        }

        private void lbl_AnimeBet100_Click(object sender, EventArgs e)
        {
            if (canBet)
            {
                if (chips > 99)
                {
                    chips -= 100;
                    bet += 100;
                    lbl_chips.Text = chips.ToString();
                    lbl_currBet.Text = "Bet: " + bet;
                    setChips();
                }
            }
        }

        private void lbl_AnimeBet250_Click(object sender, EventArgs e)
        {
            if (canBet)
            {
                if (chips > 249)
                {
                    chips -= 250;
                    bet += 250;
                    lbl_chips.Text = chips.ToString();
                    lbl_currBet.Text = "Bet: " + bet;
                    setChips();
                }
            }
        }

        private void lbl_menu_Click(object sender, EventArgs e)
        {
            setChips();
            UserMenu form = new UserMenu(username);
            this.Dispose();
            form.ShowDialog();
        }

        private void lbl_close_Click(object sender, EventArgs e)
        {
            if (canBet)
                chips += bet;

            setChips();
            this.Close();
        }

        private void form_formClosed(object sender, FormClosedEventArgs e)
        {
            SetValues();
            this.Show();
        }

        private void lbl_playerHand_Click(object sender, EventArgs e)
        {
            if (cardSplit)
            {
                if (playerHand < 22)
                {
                    splitNum = 0;
                    lbl_highlight.BackColor = Color.Gold;
                    lbl_sHighlight.BackColor = Color.Transparent;
                }
            }
        }

        private void lbl_sPlayerHand_Click(object sender, EventArgs e)
        {
            if (playerHandSplit < 22)
            {
                splitNum = 1;
                lbl_sHighlight.BackColor = Color.Gold;
                lbl_highlight.BackColor = Color.Transparent;
            }
        }
    }
}
