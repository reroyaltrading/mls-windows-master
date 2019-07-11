using CanadaHousing.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanadaHousing.Controller
{
    public class DatabaseControl
    {
        public static String GetConnectionString()
        {
            //"Server=localhost;Database=real_state;Uid=root;Pwd=";
            AppSettings settings = AppSettings.GetAppSettings();
            return String.Format("Server={0};Database={1};Uid={2};Pwd={3}",
                settings.db_server, settings.db_name, settings.db_user, settings.db_password);
        }

        public static Boolean SendInsert(String Command)
        {
            var connection = new MySqlConnection(GetConnectionString());
            var command = connection.CreateCommand();

            try
            {
                connection.Open();
                command.CommandText = Command;
                Console.WriteLine(Command);
                command.ExecuteNonQuery();
                return true;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();

            }

            return false;

        }

        public static Boolean TestConnection()
        {
            var connection = new MySqlConnection(GetConnectionString());
            var command = connection.CreateCommand();
            bool enabled = false;

            try
            {
                connection.Open();
                enabled = true;
            }
            catch(Exception ex)
            {
                enabled = false;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();

            }

            return enabled;
        }

        public static Boolean SendUpdate(String Command)
        {
            var connection = new MySqlConnection(GetConnectionString());
            var command = connection.CreateCommand();

            try
            {
                connection.Open();
                command.CommandText = Command;
                Console.WriteLine(Command);
                command.ExecuteNonQuery();
                return true;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();

            }

            return false;

        }
    }
}
