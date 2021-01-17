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

namespace Brutus
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
            textBox12.ForeColor = Color.Lime;
            textBox11.ForeColor = Color.Lime;
            textBox10.Text = "Username";
            textBox10.ForeColor = Color.Lime;
            textBox9.Text = "Password";
            textBox9.ForeColor = Color.Lime;
        }

  

        private void label8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        Point lastP;
        private void panel9_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastP.X;
                this.Top += e.Y - lastP.Y;
            }
        }

        private void panel9_MouseDown(object sender, MouseEventArgs e)
        {
            lastP = new Point(e.X, e.Y);
        }

        private void textBox12_Enter(object sender, EventArgs e)
        {
            if(textBox12.Text == "Name")
            {
                textBox12.Text = "";
            }

        }

        private void textBox12_Leave(object sender, EventArgs e)
        {
            if(textBox12.Text == "")
            {
                textBox12.Text = "Name";
            }
        }

        private void textBox11_Enter(object sender, EventArgs e)
        {
            if(textBox11.Text == "Surname")
            {
                textBox11.Text = "";
            }
        }

        private void textBox11_Leave(object sender, EventArgs e)
        {
            if(textBox11.Text == "")
            {
                textBox11.Text = "Surname";
            }
        }

        private void textBox10_Enter(object sender, EventArgs e)
        {
            if(textBox10.Text == "Username")
            {
                textBox10.Text = "";
            }
        }


        private void textBox10_Leave(object sender, EventArgs e)
        {
            if (textBox10.Text == "")
            {
                textBox10.Text = "Username";
            }
        }

        private void textBox9_Enter(object sender, EventArgs e)
        {
            if (textBox9.Text == "Password")
            {
                textBox9.Text = "";
            }
        }

        private void textBox9_MouseClick(object sender, MouseEventArgs e)
        {
            textBox9.PasswordChar = '*';
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(textBox12.Text == "Name")
            {
                MessageBox.Show("Enter the Name");
                return;
            }

            if (textBox11.Text == "Surname")
            {
                MessageBox.Show("Enter the Surname");
                return;
            }

            if (textBox10.Text == "Username")
            {
                MessageBox.Show("Enter the Username");
                return;
            }

            if (textBox9.Text == "Password" )
            {
                MessageBox.Show("Enter the Password");
                return;
            }
            else
            {
                if (textBox9.Text == "")
                {
                    MessageBox.Show("Enter the Password");
                    return;
                }
            }

 

            if (userCheck())
            {
                return;
            }

            database db = new database();
            MySqlCommand command = new MySqlCommand("INSERT INTO `users` (`login`, `password`, `nume`, `prenume`) VALUES (@log, @pass, @nume, @prenume)", db.GetConnection());

            command.Parameters.Add("@log", MySqlDbType.VarChar).Value = textBox10.Text;
            command.Parameters.Add("@nume", MySqlDbType.VarChar).Value = textBox12.Text;
            command.Parameters.Add("@prenume", MySqlDbType.VarChar).Value = textBox11.Text;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = textBox9.Text;

            db.ConnectionOpen();

            if(command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Registred!");
            }
            else
            {
                MessageBox.Show("Something wrong, i can feel it");
            }

            db.ConnectionClose();
        }

        public Boolean userCheck()
        {
            database db = new database();

            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @uL", db.GetConnection());
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = textBox10.Text;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Login already exists");
                return true;
            }
            else
            {
                return false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login loginform = new Login();
            loginform.Show();
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }
    }
   
  }
