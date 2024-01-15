using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test_me
{
    internal class DataBase
    {
        NpgsqlConnection npgsqlConnection = new NpgsqlConnection("Server=localhost;Port=5432;Database=register;User Id=postgres;Password=123456789");

        public void openConnection()
        {
            if(npgsqlConnection.State == System.Data.ConnectionState.Closed)
            {
                npgsqlConnection.Open();
            }
        }

        public void closeConnection()
        {
            if (npgsqlConnection.State == System.Data.ConnectionState.Open)
            {
                npgsqlConnection.Close();
            }
        }

        public NpgsqlConnection getConnection()
        {
            return npgsqlConnection;
        }

    }
}
