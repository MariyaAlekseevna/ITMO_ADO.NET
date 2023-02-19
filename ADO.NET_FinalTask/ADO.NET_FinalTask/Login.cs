using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ADO.NET_FinalTask
{
    public partial class Login : Form
    {
        public bool Inputsuccess = false;
        public Login()
        {
            InitializeComponent();
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            
            string conString = $"Persist Security Info=False; User ID={textBoxLogin.Text}; Password={textBoxPassword.Text}; Initial Catalog=Northwind;Data Source={textBoxServerName.Text}";
            using (SqlConnection connection = new SqlConnection(conString))
            {
                try
                {
                    connection.Open();
                    Inputsuccess = true;
                    ServerConnection.name = textBoxServerName.Text;
                    ServerConnection.login = textBoxLogin.Text;
                    ServerConnection.password = textBoxPassword.Text;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Не удалось подключиться к серверу  c базой данных Northwind \n Ошибка: {ex.Message}");
                }
                finally
                {
                    Close(); 
                }
            }
        }
    }
    static class ServerConnection
    {
        public static string name;
        public static string login;
        public static string password;
    }

}
