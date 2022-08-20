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

namespace Proyecto_Final
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region Conexión Base de Datos
        public static MySqlConnection ObtenerConexion()
        {
            MySqlConnection conectar = new MySqlConnection("server = 127.0.0.1; database = jardines; Uid = root; pwd = 1234;");
            conectar.Open();
            return conectar;
        }
        #endregion


        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btn_Reservar_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conexion = ObtenerConexion();

                MySqlDataAdapter da = new MySqlDataAdapter("select username from usuario where nombre = '"+ textBox1.Text + "' and apellido = '"+ textBox2.Text +"';", conexion);
                DataTable dt = new DataTable();
                da.Fill(dt);

                comboBox1.ValueMember = "username";
                comboBox1.DisplayMember = "username";
                comboBox1.DataSource = dt;
                conexion.Close();
            }
            catch
            {
                MessageBox.Show("Error al buscar usuario");
            }
        }
    }
}
