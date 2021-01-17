using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace Brutus
{

    public partial class Login : Form
    {

        String loginUser;
        String passUser;
        public Login()
        {
            InitializeComponent();
            textBox1.Text = "Username";
            textBox2.Text = "Password";
            textBox1.ForeColor = Color.Lime;
            textBox2.ForeColor = Color.Lime;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void login_button_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Username")
            {

                MessageBox.Show("Enter the Username");
                return;
            }

            if (textBox2.Text == "Password")
            {
                MessageBox.Show("Enter the Password");
                return;
            }
            else
            {
                if (textBox2.Text == "")
                {
                    MessageBox.Show("Enter the Password");
                    return;
                }
            }



            loginUser = textBox1.Text;
            passUser = textBox2.Text;

            database db = new database();

            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @uL AND `password` = @uP", db.GetConnection());
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = loginUser;
            command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = passUser;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                this.Hide();
                EnterForm enter = new EnterForm();//////////////////////////////////////////////////////////////////////
                enter.Show();
            }
            else
            {
                textBox3.ForeColor = Color.Red;
            }

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            loginUser = textBox4.Text;
        }



        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        Point lastP;
        private void panel5_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastP.X;
                this.Top += e.Y - lastP.Y;
            }
        }

        private void panel5_MouseDown(object sender, MouseEventArgs e)
        {
            lastP = new Point(e.X, e.Y);
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Username")
            {
                textBox1.Text = "";

            }

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Username";
            }
        }



        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register registerform = new Register();
            registerform.Show();
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Password")
            {
                textBox2.Text = "";
            }
        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            textBox2.PasswordChar = '*';
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox3.ForeColor = System.Drawing.Color.FromArgb(34, 36, 49);
        }

        string myPass;
        public bool crack(char[] word)
        {

            myPass = "";
            for (int i = 0; i < word.Length; i++)
                myPass += word[i];

            if (textBox1.Text == "Username")
            {

                MessageBox.Show("Enter the Username");

            }
            
            if (textBox2.Text == "Password")
            {

            }
            else
            {
                if (textBox2.Text == "")
                {

                }
            }
            



            loginUser = textBox4.Text;
            passUser = myPass;

            database db = new database();

            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @uL AND `password` = @uP", db.GetConnection());
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = loginUser;
            command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = passUser;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                return true;
                MessageBox.Show($"Password is {passUser}");
            }
            else
            {
                textBox3.ForeColor = Color.Red;

                return false;
            }



            

            /*textBox2.Text = myPass;
                
            if (password != myPass)
            {
                return "";
            }
            else
            {
                Console.WriteLine("Finded!");
                Console.WriteLine(myPass);
                return myPass;
            }*/
        }

        public bool control(char[] word)
        {
            bool answer = true;
            for (int i = 0; i < word.Length; i++)
                if (word[i] != 'z')
                    answer = false;

            return answer;
        }

        public void role()
        {
            int nr = 1;
            char[] word = new char[nr];
            word[0] = '0';

            int poz = 0;

            while (!crack(word))
            {
                string myPass = "";
                for (int i = 0; i < word.Length; i++)
                    myPass += word[i];
                passUser = myPass;
                //Afisarea parolelor posibile
                //Console.WriteLine(myPass);

                if (poz == word.Length - 1)
                {
                    if (control(word) == true)
                    {
                        nr++;
                        word = new char[nr];
                        poz = nr - 1;
                        for (int i = 0; i < word.Length; i++)
                            word[i] = '0';

                    }
                    else
                    if (word[poz] == 'z')
                    {
                        word[poz] = '0';
                        poz--;

                    }
                    else
                    {
                        word[poz] = (char)((int)word[poz] + 1);

                        if (word[poz] == (char)((int)'9' + 1))
                            word[poz] = 'A';
                        else if (word[poz] == (char)((int)'Z' + 1))
                            word[poz] = 'a';
                    }
                }
                else
                {
                    if (word[poz] == 'z')
                    {
                        for (int i = poz; i < word.Length; i++)
                            word[i] = '0';
                        poz--;
                    }
                    else
                    {
                        word[poz] = (char)((int)word[poz] + 1);

                        if (word[poz] == (char)((int)'9' + 1))
                            word[poz] = 'A';
                        else if (word[poz] == (char)((int)'Z' + 1))
                            word[poz] = 'a';
                        poz++;
                    }

                }
            }
        }

        public void button2_Click_2(object sender, EventArgs e)
        {
            loginUser = textBox4.Text;
            textBox1.Text = loginUser;
            role();

            textBox2.Text = passUser;
            login_button_Click(sender, e);









        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    /*
    class Class2
    {

        

        static void kaboom()
        {
            Console.WriteLine("Input username.. ");
            String password = Console.ReadLine();
            role(password);
        }

    }
    */



}
