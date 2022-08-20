using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using MySql.Data.MySqlClient;

namespace Proyecto_Final
{
    public partial class Olvidar_Contraseña : Form
    {
        public Olvidar_Contraseña()
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

        private void Btn_Acceder_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tbx_Usuario_Enter(object sender, EventArgs e)
        {
            if (tbx_Usuario.Text == "Usuario")
            {
                tbx_Usuario.Text = "";
                tbx_Usuario.ForeColor = Color.Black;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form login = new LogIn();
            login.Show();
            this.Hide();
        }

        private void Btn_Acceder_Click(object sender, EventArgs e)
        {
            if (tbx_Contraseña.Text == textBox1.Text)
            {
                #region Cambio de contraseña
                try
                {
                    MySqlConnection conexion = ObtenerConexion();
                    MySqlCommand comando = new MySqlCommand(String.Format("update usuario set contraseña = '" + tbx_Contraseña.Text + "' where username = '" + tbx_Usuario.Text + "' and pregunta_seguridad = '" + textBox2.Text + "';"), conexion);
                    comando.ExecuteNonQuery();
                    conexion.Close();
                    MessageBox.Show("Contraseña actualizada correctamente.");
                    Form login = new LogIn();
                    login.Show();
                    this.Hide();
                }
                catch
                {
                    MessageBox.Show("Error al cambiar la contraseña. Revise las credenciales.");
                }
                #endregion
            }
            else
            {
                MessageBox.Show("Error al cambiar la contraseña. Revise las credenciales.");
            }
        }

        private void tbx_Usuario_Leave(object sender, EventArgs e)
        {
            if (tbx_Usuario.Text == "")
            {
                tbx_Usuario.Text = "Usuario";
                tbx_Usuario.ForeColor = Color.Black;

            }
        }

        private void tbx_Contraseña_Enter(object sender, EventArgs e)
        {
            if (tbx_Contraseña.Text == "Nueva contraseña")
            {
                tbx_Contraseña.Text = "";
                tbx_Contraseña.ForeColor = Color.Black;
            }
        }

        private void tbx_Contraseña_Leave(object sender, EventArgs e)
        {
            if (tbx_Contraseña.Text == "")
            {
                tbx_Contraseña.Text = "Nueva contraseña";
                tbx_Contraseña.ForeColor = Color.Black;

            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Confirmar contraseña")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Confirmar contraseña";
                textBox1.ForeColor = Color.Black;

            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "¿Cómo apodarías a tu mascota?")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Black;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "¿Cómo apodarías a tu mascota?";
                textBox2.ForeColor = Color.Black;

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}
