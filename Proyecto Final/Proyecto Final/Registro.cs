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
    public partial class Registro : Form
    {
        public Registro()
        {
            InitializeComponent();
        }
        int m, mx, my;

        #region Conexión Base de Datos
        public static MySqlConnection ObtenerConexion()
        {
            MySqlConnection conectar = new MySqlConnection("server = 127.0.0.1; database = jardines; Uid = root; pwd = 1234;");
            conectar.Open();
            return conectar;
        }
        #endregion

        private void tbx_Usuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

            WindowState = FormWindowState.Minimized;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox4_MouseDown(object sender, MouseEventArgs e)
        {
            m = 1;
            mx = e.X;
            my = e.Y;
        }

        private void tbx_Nombre_Enter(object sender, EventArgs e)
        {
            if (tbx_Nombre.Text == "Nombre")
            {
                tbx_Nombre.Text = "";
                tbx_Nombre.ForeColor = Color.Black;
            }
        }

        private void tbx_Nombre_Leave(object sender, EventArgs e)
        {
            if (tbx_Nombre.Text == "")
            {
                tbx_Nombre.Text = "Nombre";
                tbx_Nombre.ForeColor = Color.Black;
            }
        }

        private void tbx_Apellido_Enter(object sender, EventArgs e)
        {
            if (tbx_Apellido.Text == "Apellido")
            {
                tbx_Apellido.Text = "";
                tbx_Apellido.ForeColor = Color.Black;
            }
        }

        private void tbx_Apellido_Leave(object sender, EventArgs e)
        {
            if (tbx_Apellido.Text == "")
            {
                tbx_Apellido.Text = "Apellido";
                tbx_Apellido.ForeColor = Color.Black;
            }
        }

        private void tbx_Usuario_Enter(object sender, EventArgs e)
        {
            
                
            if (tbx_Usuario.Text == "Nombre de Usuario")
            {
                tbx_Usuario.Text = "";
                tbx_Usuario.ForeColor = Color.Black;
                
            }
        }

        private void tbx_Usuario_Leave(object sender, EventArgs e)
        {
            if (tbx_Usuario.Text == "")
            {
                tbx_Usuario.Text = "Nombre de Usuario";
                tbx_Usuario.ForeColor = Color.Black;

            }
        }

        private void tbx_Contraseña_Enter(object sender, EventArgs e)
        {
            if (tbx_Contraseña.Text == "Contraseña")
            {
                tbx_Contraseña.Text = "";
                tbx_Contraseña.ForeColor = Color.Black;
                tbx_Contraseña.UseSystemPasswordChar = true;

            }
        }

        private void tbx_Contraseña_Leave(object sender, EventArgs e)
        {
            if (tbx_Contraseña.Text == "")
            {
                tbx_Contraseña.Text = "Contraseña";
                tbx_Contraseña.ForeColor = Color.Black;
                tbx_Contraseña.UseSystemPasswordChar = false;
            }
        }

        private void tbx_Confirmar_Contraseña_Enter(object sender, EventArgs e)
        {
            if (tbx_Confirmar_Contraseña.Text == "Confirmar Contraseña")
            {
                tbx_Confirmar_Contraseña.Text = "";
                tbx_Confirmar_Contraseña.ForeColor = Color.Black;
                tbx_Confirmar_Contraseña.UseSystemPasswordChar = true;

            }
        }
        private void tbx_Confirmar_Contraseña_Leave(object sender, EventArgs e)
        {
            if (tbx_Confirmar_Contraseña.Text == "")
            {
                tbx_Confirmar_Contraseña.Text = "Confirmar Contraseña";
                tbx_Confirmar_Contraseña.ForeColor = Color.Black;
                tbx_Confirmar_Contraseña.UseSystemPasswordChar = false;

            }
        }

        private void tbx_Correo_Electronico_Enter(object sender, EventArgs e)
        {
            if (tbx_Correo_Electronico.Text == "Correo Electronico")
            {
                tbx_Correo_Electronico.Text = "";
                tbx_Correo_Electronico.ForeColor = Color.Black;

            }
        }

        private void tbx_Correo_Electronico_Leave(object sender, EventArgs e)
        {
            if (tbx_Correo_Electronico.Text == "")
            {
                tbx_Correo_Electronico.Text = "Correo Electronico";
                tbx_Correo_Electronico.ForeColor = Color.Black;

            }
        }
    
        private void tbx_Pregunta_De_Seguridad_Enter(object sender, EventArgs e)
        {
            if (tbx_Pregunta_De_Seguridad.Text == "¿Cómo apodarías a tu mascota?")
            {
                tbx_Pregunta_De_Seguridad.Text = "";
                tbx_Pregunta_De_Seguridad.ForeColor = Color.Black;

            }
        }

        private void tbx_Pregunta_De_Seguridad_Leave(object sender, EventArgs e)
        {
            if (tbx_Pregunta_De_Seguridad.Text == "")
            {
                tbx_Pregunta_De_Seguridad.Text = "¿Cómo apodarías a tu mascota?";
                tbx_Pregunta_De_Seguridad.ForeColor = Color.Black;

            }
        }

        private void btn_Crear_Click(object sender, EventArgs e)
        {
            if (tbx_Contraseña.Text == tbx_Confirmar_Contraseña.Text)
            {
                string nombre = tbx_Nombre.Text;
                string apellido = tbx_Apellido.Text;
                string username = tbx_Usuario.Text;
                string correo = tbx_Correo_Electronico.Text;
                string contraseña = tbx_Contraseña.Text;
                string año = (dateTimePicker1.Value.Year).ToString();
                string mes = (dateTimePicker1.Value.Month).ToString();
                string dia = (dateTimePicker1.Value.Day).ToString();
                string fecha_de_nacimiento = año + "-" + mes + "-" + dia;
                año = (DateTime.Now.Year).ToString();
                mes = (DateTime.Now.Month).ToString();
                dia = (DateTime.Now.Day).ToString();
                string hora = (DateTime.Now.Hour).ToString();
                string minuto = (DateTime.Now.Minute).ToString();
                string segundo = (DateTime.Now.Second).ToString();
                string fecha_de_registro = año + "-" + mes + "-" + dia + " " + hora + ":" + minuto + ":" + segundo;
                string pregunta_seguridad = tbx_Pregunta_De_Seguridad.Text;
                string rol = "U";

                #region Almacenamiento de Usuario
                try
                {
                    MySqlConnection conexion = ObtenerConexion();
                    MySqlCommand comando = new MySqlCommand(String.Format("insert into usuario (nombre, apellido, username, correo, contraseña, fecha_nacimiento, fecha_registro, pregunta_seguridad, rol) values ('" + nombre + "', '" + apellido + "', '" + username + "', '" + correo + "', '" + contraseña + "', '" + fecha_de_nacimiento + "', '" + fecha_de_registro + "', '" + pregunta_seguridad + "', '" + rol + "');"), conexion);
                    comando.ExecuteNonQuery();
                    conexion.Close();
                    MessageBox.Show("Usuario registrado correctamente.");
                    Form login = new LogIn();
                    login.Show();
                    this.Hide();
                }
                catch
                {
                    MessageBox.Show("Error");
                }
                #endregion
            }
            else
            {
                MessageBox.Show("No coinciden las contraseñas. Intentar de nuevo");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form login = new LogIn();
            login.Show();
            this.Hide();
        }

        private void pictureBox4_MouseMove(object sender, MouseEventArgs e)
        {
            if (m == 1)
            {
                this.SetDesktopLocation(MousePosition.X - mx, MousePosition.Y - my);
            }
        }

        private void pictureBox4_MouseUp(object sender, MouseEventArgs e)
        {
            m = 0;
        }
    }
}
