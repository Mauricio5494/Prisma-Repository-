using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Diseño
{
    internal class DataBaseConnect
    {
        private MySqlConnection conectar;

        public void conectarse()
        {
            string uid = "root";
            string pwd = "";
            string servidor = "localhost";
            int port = 3306;
            string database = "etech_celulares";

            string server = $"Server={servidor}; Uid={uid}; Pwd={pwd}; Port={port}; Database={database}";

            MySqlConnection conn = new MySqlConnection(server);

            try
            {
                conn.Open();
                MessageBox.Show("Estado:\n\nConectado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + "Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void desconectarse()
        {
            try
            {
                if (conectar != null && conectar.State == ConnectionState.Open)
                {
                    conectar.Close();
                    MessageBox.Show("Conexión Cerrada", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("No hay Base de Datos de la cuál Desconectarse \nError Message:\n\n" + e.Message);
            }
        }
    }
}
