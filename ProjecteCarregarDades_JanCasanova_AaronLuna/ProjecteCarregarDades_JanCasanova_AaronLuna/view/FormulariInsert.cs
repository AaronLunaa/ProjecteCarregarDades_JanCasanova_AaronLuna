using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ProjecteCarregarDades_JanCasanova_AaronLuna.view
{
    public partial class FormulariInsert : Form
    {
        public FormulariInsert()
        {
            InitializeComponent();
        }

        private void FormulariInsert_Load(object sender, EventArgs e)
        {
            btInsertar.Click += btInsertar_Click;
        }

        private void btInsertar_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=db4free.net;Port=3306;Database=projectem02_m04;Uid=administrador123;Pwd=administrador";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO movies (title, genre, director, year, rating) VALUES (@title, @genre, @director, @year, @rating)";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@title", tbTitol.Text);
                    command.Parameters.AddWithValue("@genre", tbGenere.Text);
                    command.Parameters.AddWithValue("@director", tbDirector.Text);
                    command.Parameters.AddWithValue("@year", Convert.ToInt32(tbAny.Text));
                    command.Parameters.AddWithValue("@rating", Convert.ToDecimal(tbPuntuacio.Text));
                    command.ExecuteNonQuery();
                    MessageBox.Show("Inserció realitzada amb èxit.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error en la inserció: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}
