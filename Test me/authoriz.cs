using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace Test_me
{
    public partial class authoriz : Form
    {
        DataBase dataBase = new DataBase();
        public authoriz()
        {
            InitializeComponent();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            register register = new register();
            register.Show();
            Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var logInUser = textBox1.Text;
            var passUser = textBox2.Text;

            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
            DataTable table = new DataTable();

            string querystring = $"select id, login, password from login_tbl where login = '{logInUser}' and password = '{passUser}'";

            NpgsqlCommand command = new NpgsqlCommand(querystring, dataBase.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count == 1)
            {
                
                {
                    MessageBox.Show("Вы успешно вошли!", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Mainform mainform = new Mainform();
                    this.Hide();
                    mainform.ShowDialog();
                }
            } 
            else
            {
                MessageBox.Show("Такого аккаунта не существует!", "Аккаунта не существует!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }
    }
}
