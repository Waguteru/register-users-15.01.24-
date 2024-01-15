using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace Test_me
{
    public partial class register : Form
    {
        DataBase dataBase = new DataBase();
        public register()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            

            var login = textBox1.Text;
            var password = textBox2.Text;

            string querystring = $"insert into login_tbl (login, password) values ('{login}','{password}')";

            NpgsqlCommand command = new NpgsqlCommand(querystring, dataBase.getConnection());

            dataBase.openConnection();

            if (checkuser())
                return;
           
            
            if (command.ExecuteNonQuery() == 1)
            {
                
                MessageBox.Show("Аккаунт успешно создан!", "Успех!");
                authoriz authoriz = new authoriz();
                authoriz.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Аккаунт создать не удалось!");
            }
           

            dataBase.closeConnection();
            
        }

        private Boolean checkuser()
        {
            var loginUser = textBox1.Text;
            var passUser = textBox2.Text;

            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
            DataTable table = new DataTable();
            string querystring = $"select id, login, password from login_tbl where login = '{loginUser}' and password = '{passUser}'";

            NpgsqlCommand command = new NpgsqlCommand(querystring, dataBase.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Пользователь уже существует!");
                return true;
            } 
            else
            {
                return false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            authoriz authoriz = new authoriz();
            authoriz.Show();
            Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //проверка пароля
        
        bool IsNumber(TextBox text)
        {
            foreach (var item in text.Text.Reverse())
                if(char.IsNumber(item)) { return true; }
            return false;
        }

        bool IsLower(TextBox text)
        {
            foreach (var item in text.Text.Reverse())
                if (char.IsLower(item)) { return true; }
            return false;
        }

        bool IsUpper(TextBox text)
        {
            foreach (var item in text.Text.Reverse())
                if (char.IsUpper(item)) { return true; }
            return false;
        }

        bool IsSymbol(TextBox text)
        {
            foreach (var item in text.Text.Reverse())
                if (char.IsSymbol(item)) { return true; }
            return false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //должно быть больше 8
         //   if (textBox2.Text.Length > 8)
          //  {
          //      LbTitle1.ForeColor = Color.FromArgb(0, 189, 83);
           // }
          //  else
          //  {
           //     LbTitle1.ForeColor = Color.FromArgb(182, 53, 40);
          //  }

            //содержит число
            if (IsNumber(textBox2))
            {
                LbTitle2.ForeColor = Color.FromArgb(0, 189, 83);
            }
            else
            {
                LbTitle2.ForeColor = Color.FromArgb(182,53,40);
            }

            //верхний регистр
            if (IsUpper(textBox2))
            {
                LbTitle3.ForeColor = Color.FromArgb(0, 189, 83);
            }
            else
            {
                LbTitle3.ForeColor = Color.FromArgb(182,53,40);
            }

            //специальный символ
            if (IsSymbol(textBox2))
            {
                LbTitle4.ForeColor = Color.FromArgb(0, 189, 83);
            }
            else
            {
                LbTitle4.ForeColor = Color.FromArgb(182, 53, 40);
            }

            //нижний регистр
            if (IsLower(textBox2))
            {
                LbTitle5.ForeColor = Color.FromArgb(0, 189, 83);
            }
            else
            {
                LbTitle5.ForeColor = Color.FromArgb(182, 53, 40);
            }


        }

        
    }
}
