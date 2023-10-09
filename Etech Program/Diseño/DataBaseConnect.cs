using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Diseño
{
    class DataBaseConnect


    {





        public static MySqlConnection Conectarse(string uid, string pwd)
        {
            //requisitos para la conexion (informacion del base de datos):


            string servidor = "localhost";
            string port = "3306";
            string database = "etech_db";
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
                MessageBox.Show("Mensaje técnico:\n\n" + e.Message, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
        }
    }
}
