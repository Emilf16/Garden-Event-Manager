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
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }
        int m,mx,my;//variables que permiten el movimiento del form

        #region Conexi�n Base de Datos
        public static MySqlConnection ObtenerConexion()
        {
            MySqlConnection conectar = new MySqlConnection("server = 127.0.0.1; database = jardines; Uid = root; pwd = 1234;");
            conectar.Open();
            return conectar;
        }
        #endregion

        private void tbx_Usuario_Enter(object sender, EventArgs e)
        {
            if(tbx_Usuario.Text == "Usuario")
            {
                tbx_Usuario.Text = "";
                tbx_Usuario.ForeColor = Color.Black;
            }
        }

        private void tbx_Usuario_Leave(object sender, EventArgs e)
        {
            if(tbx_Usuario.Text == "")
            {
                tbx_Usuario.Text = "Usuario";
                tbx_Usuario.ForeColor = Color.Black;
            }
        }

        private void tbx_Contrase�a_Enter(object sender, EventArgs e)
        {
            if (tbx_Contrase�a.Text == "Contrase�a")
            {
                tbx_Contrase�a.Text = "";
                tbx_Contrase�a.ForeColor = Color.Black;
                tbx_Contrase�a.UseSystemPasswordChar = true;
            }
        }

        private void tbx_Contrase�a_Leave(object sender, EventArgs e)
        {
            if (tbx_Contrase�a.Text == "")
            {
                tbx_Contrase�a.Text = "Contrase�a";
                tbx_Contrase�a.ForeColor = Color.Black;
                tbx_Contrase�a.UseSystemPasswordChar = false;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Btn_Minimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void Btn_Cerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            
        }

        private void linkLabel2_Click(object sender, EventArgs e)
        {
            var openregistro = new Registro();
            openregistro.Show();
            this.Hide();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void Btn_Acceder_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conexion = ObtenerConexion();
                MySqlCommand comando = new MySqlCommand(String.Format("select id, nombre, apellido, username, contrase�a, rol from usuario where username = '" + tbx_Usuario.Text + "' AND contrase�a = '" + tbx_Contrase�a.Text + "';"), conexion);
                MySqlDataReader reader = comando.ExecuteReader();
                int Length = 0, ID = -1;
                string Username = "", Contrase�a = "", Nombre = "", Apellido = "", Rol = "U";

                while (reader.Read())
                {
                    ID = reader.GetInt32(0);
                    Nombre = reader.GetString(1);
                    Apellido = reader.GetString(2);
                    Username = reader.GetString(3);
                    Contrase�a = reader.GetString(4);
                    Rol = reader.GetString(5);
                    Length++;
                }
                conexion.Close();
                if (Username == tbx_Usuario.Text && tbx_Contrase�a.Text == Contrase�a)
                {
                    if (Rol == "A")
                    {
                        var admintest = new Administrador(ID, Nombre, Apellido);
                        admintest.Show();
                        this.Hide();
                    }
                    else
                    {
                        var cliente = new Reservar(ID, Nombre, Apellido);
                        cliente.Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Usuario y/o contrase�a inv�lidos.");
                }

            }
            catch
            {
                MessageBox.Show("Usuario y/o contrase�a inv�lidos.");
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox3_MouseDown_1(object sender, MouseEventArgs e)
        {
            m = 1;
            mx = e.X;
            my = e.Y;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox7_MouseMove(object sender, MouseEventArgs e)
        {
            if (m == 1)
            {
                this.SetDesktopLocation(MousePosition.X - mx, MousePosition.Y - my);
            }
        }

        private void pictureBox7_MouseDown(object sender, MouseEventArgs e)
        {
            m = 1;
            mx = e.X;
            my = e.Y;
            
        }

        private void pictureBox7_MouseUp(object sender, MouseEventArgs e)
        {
            m = 0;
        }

        private void LogIn_Load(object sender, EventArgs e)
        {

        }

        private void tbx_Usuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var actualizar_contrase�a = new Olvidar_Contrase�a();
            actualizar_contrase�a.Show();
            this.Hide();
        }

        private void pictureBox3_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (m == 1)
            {
                this.SetDesktopLocation(MousePosition.X - mx, MousePosition.Y - my);
            }
        }

        private void pictureBox3_MouseUp_1(object sender, MouseEventArgs e)
        {
            m = 0;
        }

        
    }
}