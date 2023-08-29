using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Diseño
{
    class DataBaseConnect
    {
        public static MySqlConnection conectarse()
        {
            //requisitos para la conexion (informacion del base de datos):
            string uid = "root";
            string pwd = "";
            string servidor = "localhost";
            string port = "3306";
            string database = "Etech_db";
            string requisitos = $"Server={servidor}; Uid={uid}; Pwd={pwd}; Port={port}; Database={database}";
            //instancia del metodo:
            MySqlConnection ConnectionDB = new MySqlConnection(requisitos);

            try
            {
                return ConnectionDB;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al conectar a la Base de Datos\n\nMensaje de Error:\n" + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("Mensaje técnico:\n\n" + e.StackTrace, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
        }

        //Parece ser que podemos prescindir de este metodo
        public static MySqlConnection desconectarse()
        {
            MySqlConnection ConnectionDB = new MySqlConnection();
            try
            {
                if (ConnectionDB != null && ConnectionDB.State == ConnectionState.Open)
                {
                    ConnectionDB.Close();
                    MessageBox.Show("Conexión Cerrada", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("No hay Base de Datos de la cuál Desconectarse \nMensaje de Error:\n\n" + e.Message);
            }
            return null;
        }
    }
}
