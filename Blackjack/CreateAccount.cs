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
    public partial class CreateAccount : Form
    {
        string[] info = new string[100];

        private string filename = "data.dll";

        // INFROMATION BOOLIANS
        private bool userTaken = false;
        private bool userValid = false;
        private bool passwordValid = false;

        // INFORMATION VARIABLES
        private string username = "";
        private string password = "";
        private string REpassword = "";
        private string testUser;
        private string testPW;

        public CreateAccount()
        {
            InitializeComponent();
            setCredentials();
        }

        private void checkCredentials()
        {
            int x;

            // USERNAME CHECK
            if (username.Length >= 6 && username.Length <= 24)
            {
                for (x = 0; x < 99; x += 2)
                {
                    if (username == info[x])
                    {
                        userTaken = true;
                        label2.ForeColor = Color.Red;
                        label4.Text = "Username already taken";
                        return;
                    }
                }
                if (userTaken == false)
                    userValid = true;
            }
            if (new[] { " ", "`", "~", "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "-", "_", "=", "+", "\\", "|", "[", "{", "]", "}", ";", ":", "'", "\"", ",", "<", ".", ">", "/", "?" }.Any(i => username.IndexOf(i) >= 0))
            {
                userValid = false;
                label2.ForeColor = Color.Red;
                label4.Text = "Username contains invalid characters";
                label5.Text = "Username can only contain characters a-z, A-Z, 1-0. \n Any special characters are considered invalid.";
                return;
            }
            else if (username.Length < 6)
            {
                userValid = false;
                label2.ForeColor = Color.Red;
                label4.Text = "Username too short";
                return;
            }
            else if (username.Length > 24)
            {
                userValid = false;
                label2.ForeColor = Color.Red;
                label4.Text = "Username too Too long";
                return;
            }

            // PASSWORD CHECK
            if (REpassword == password)
            {
                if (password.Length >= 6 && password.Length <= 24)
                    passwordValid = true;
                else if (password.Length < 6)
                {
                    label3.ForeColor = Color.Red;
                    passwordValid = false;
                    label4.Text = "Password too short";
                    return;
                }
                else if (password.Length > 24)
                {
                    label3.ForeColor = Color.Red;
                    passwordValid = false;
                    label4.Text = "Password too long";
                    return;
                }
            }
            if (new[] { " ", "`", "~", "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "-", "_", "=", "+", "\\", "|", "[", "{", "]", "}", ";", ":", "'", "\"", ",", "<", ".", ">", "/", "?" }.Any(i => password.IndexOf(i) >= 0))
            {
                passwordValid = false;
                label4.Text = "Password contains invalid characters";
                label5.Text = "Password can only contain characters a-z, A-Z, 1-0. \n Any special characters are considered invalid.";
                return;
            }
            else if (REpassword != password)
            {
                label1.ForeColor = Color.Red;
                label3.ForeColor = Color.Red;
                label4.Text = "Passwords do not match";
                passwordValid = false;
                return;
            }
        }

        private void createUsername()
        {
            if (userValid == false || passwordValid == false)
            {
                return;
            }
            else if (userValid && passwordValid)
            {
                FileStream fs = new FileStream(filename, FileMode.Append, FileAccess.Write);
                StreamWriter writer = new StreamWriter(fs);

                writer.WriteLine(username);
                writer.WriteLine(password);

                writer.Close();
                fs.Close();
                this.Close();
            }
        }

        private void setCredentials()
        {
            int x;
            StreamReader sr = new StreamReader(filename);

            for (x = 0; x < 99; x++)
            {
                testUser = sr.ReadLine();
                testPW = sr.ReadLine();

                info[x] = testUser;
                info[x + 1] = testPW;
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
            REpassword = txt_REpassword.Text;
            txt_REpassword.PasswordChar = '*';
        }

        private void btn_CreateAccount_Click(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Black;
            label2.ForeColor = Color.Black;
            label3.ForeColor = Color.Black;
            label4.Text = "";
            label5.Text = "";

            checkCredentials();

            createUsername();
        }
    }
}
