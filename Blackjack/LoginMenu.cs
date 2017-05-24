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
    public partial class LoginMenu : Form
    {
        string[] info = new string[100];

        private string filename = "data.dll";

        private bool error = false;
        private bool usernameMatch = false;
        private bool passwordMatch = false;

        public int test = 1234;

        private string username = "";
        private string password = "";
        private string testUser;
        private string testPW;
        public string sendUsername;

        public LoginMenu()
        {
            InitializeComponent();
            setCredentials();
        }

        private void checkCredentials()
        {
            int x;
            int y;

            for (x = 0; x < 99; x += 2)
            {
                if (username == info[x])
                {
                    usernameMatch = true;
                    error = false;

                    if (password == info[x + 1])
                    {
                        passwordMatch = true;
                        error = false;
                    }
                }
            }
            if (passwordMatch == false || usernameMatch == false)
            {
                usernameMatch = false;
                passwordMatch = false;
                error = true;
                lbl_error.Text = "The username or password that you entered is not valid. Please try again.";
            }
        }

        private void setCredentials()
        {
            int x;
            TextWriter tw;

            if (!File.Exists("data.dll"))
            {
                tw = new StreamWriter("data.dll");
                tw.Close();
            }

            StreamReader sr = new StreamReader(filename);
            for (x = 0; x < 99; x += 2)
            {
                testUser = sr.ReadLine();
                testPW = sr.ReadLine();

                info[x] = testUser;
                info[x + 1] = testPW;
                Console.WriteLine(x + ": " + testUser);
                Console.WriteLine((x + 1) + ": " + testPW);
            }

            sr.Close();
        }

        private void UserUpdate(object sender, EventArgs e)
        {
            username = txt_username.Text;
        }

        private void PasswordUpdate(object sender, EventArgs e)
        {
            password = txt_password.Text;
            txt_password.PasswordChar = '*';
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            checkCredentials();
            if (error)
                return;
            else if (usernameMatch && passwordMatch)
            {
                this.Hide();

                usernameMatch = false;
                passwordMatch = false;

                UserMenu form = new UserMenu(username);
                form.FormClosed += new FormClosedEventHandler(form_gameFormsClosed);
                form.ShowDialog();
            }
        }

        private void btn_createAccount_Click(object sender, EventArgs e)
        {
            this.Hide();

            CreateAccount createAccount = new CreateAccount();
            createAccount.FormClosed += new FormClosedEventHandler(form_formClosed);
            createAccount.ShowDialog();
        }

        private void form_formClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
            setCredentials();
        }

        private void form_gameFormsClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}
