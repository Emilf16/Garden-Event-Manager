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
    public partial class Ver_Reservaciones : Form
    {
        int ID_Jardin = 0;
        int id;
        string nombre, apellido;

        class Reservas
        {
            public string Titulo { get; set; }
            public string Descripcion { get; set; }
            public string Precio { get; set; }
            public string Ubicacion { get; set; }
            public string Fecha_Reserva { get; set; }
            public int Cantidad_Personas { get; set; }
            public string Hora_Inicio { get; set; }
            public string Hora_Cierre { get; set; }
            public string Imagen { get; set; }
        }

        #region Conexión Base de Datos
        public static MySqlConnection ObtenerConexion()
        {
            MySqlConnection conectar = new MySqlConnection("server = 127.0.0.1; database = jardines; Uid = root; pwd = 1234;");
            conectar.Open();
            return conectar;
        }
        #endregion

        int max = 0;
        public Ver_Reservaciones(int ID, string Nombre, string Apellido)
        {
            InitializeComponent();
            id = ID;
            nombre = Nombre;
            apellido = Apellido;

            var items = new List<Reservas>();

            try
            {
                MySqlConnection conexion = ObtenerConexion();
                MySqlCommand comando = new MySqlCommand(String.Format("select titulo_jardin, descripcion_jardin, precio, ubicacion, fecha_reserva, cantidad_personas, hora_inicio, hora_cierre, titulo_imagen from jardines join reservas on jardines.id = reservas.id_jardines and reservas.id_usuario = {0};", id), conexion);
                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    items.Add(new Reservas()
                    {
                        Titulo = Convert.ToString(reader["titulo_jardin"]),
                        Descripcion = Convert.ToString(reader["descripcion_jardin"]),
                        Precio = Convert.ToString(reader["precio"]),
                        Ubicacion = Convert.ToString(reader["ubicacion"]),
                        Fecha_Reserva = Convert.ToString(reader["fecha_reserva"]),
                        Cantidad_Personas = Convert.ToInt32(reader["cantidad_personas"]),
                        Hora_Inicio = Convert.ToString(reader["hora_inicio"]),
                        Hora_Cierre = Convert.ToString(reader["hora_cierre"]),
                        Imagen = Convert.ToString(reader["titulo_imagen"]),
                    });
                    max++;
                }
                conexion.Close();
                var reservas = items.ElementAt(0);
                label12.Text = reservas.Titulo.ToString();
                label2.Text = reservas.Precio.ToString();
                label4.Text = reservas.Descripcion.ToString();
                label9.Text = reservas.Ubicacion.ToString();
                dtp_Fecha_De_Apertura.Text = reservas.Fecha_Reserva.ToString();
                label13.Text = reservas.Cantidad_Personas.ToString();
                label14.Text = reservas.Hora_Inicio.ToString();
                label15.Text = reservas.Hora_Cierre.ToString();
                pictureBox4.Image = System.Drawing.Image.FromFile("D:/OneDrive - INTEC/Proyecto Final/Proyecto-Final-Desarrollo-de-Software-II/Proyecto Final/Proyecto Final/Fotos/" + reservas.Imagen.ToString());
            }
            catch
            {
            }
        }
        int m, mx, my;
        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void Ver_Reservaciones_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
            if (m == 1)
            {
                this.SetDesktopLocation(MousePosition.X - mx, MousePosition.Y - my);
            }
        }

        private void pictureBox7_Click_1(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void pictureBox8_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_Siguiente_Click(object sender, EventArgs e)
        {
            if (ID_Jardin == max - 1)
            {
                MessageBox.Show("No posee más reservas.");
            }
            else
            {
                ID_Jardin++;
                var items = new List<Reservas>();

                try
                {
                    MySqlConnection conexion = ObtenerConexion();
                    MySqlCommand comando = new MySqlCommand(String.Format("select titulo_jardin, descripcion_jardin, precio, ubicacion, fecha_reserva, cantidad_personas, hora_inicio, hora_cierre, titulo_imagen from jardines join reservas on jardines.id = reservas.id_jardines and reservas.id_usuario = {0};", id), conexion);
                    MySqlDataReader reader = comando.ExecuteReader();

                    while (reader.Read())
                    {
                        items.Add(new Reservas()
                        {
                            Titulo = Convert.ToString(reader["titulo_jardin"]),
                            Descripcion = Convert.ToString(reader["descripcion_jardin"]),
                            Precio = Convert.ToString(reader["precio"]),
                            Ubicacion = Convert.ToString(reader["ubicacion"]),
                            Fecha_Reserva = Convert.ToString(reader["fecha_reserva"]),
                            Cantidad_Personas = Convert.ToInt32(reader["cantidad_personas"]),
                            Hora_Inicio = Convert.ToString(reader["hora_inicio"]),
                            Hora_Cierre = Convert.ToString(reader["hora_cierre"]),
                            Imagen = Convert.ToString(reader["titulo_imagen"]),
                        });
                    }

                    conexion.Close();
                    var reservas = items.ElementAt(ID_Jardin);
                    label12.Text = reservas.Titulo.ToString();
                    label2.Text = reservas.Precio.ToString();
                    label4.Text = reservas.Descripcion.ToString();
                    label9.Text = reservas.Ubicacion.ToString();
                    dtp_Fecha_De_Apertura.Text = reservas.Fecha_Reserva.ToString();
                    label13.Text = reservas.Cantidad_Personas.ToString();
                    label14.Text = reservas.Hora_Inicio.ToString();
                    label15.Text = reservas.Hora_Cierre.ToString();
                    pictureBox4.Image = System.Drawing.Image.FromFile("D:/OneDrive - INTEC/Proyecto Final/Proyecto-Final-Desarrollo-de-Software-II/Proyecto Final/Proyecto Final/Fotos/" + reservas.Imagen.ToString());
                }
                catch
                {

                }
            }
        }

        private void btn_Atras_Click(object sender, EventArgs e)
        {
            if (ID_Jardin == 0)
            {
                MessageBox.Show("No posee más reservas.");
            }
            else
            {
                ID_Jardin--;
                var items = new List<Reservas>();

                try
                {
                    MySqlConnection conexion = ObtenerConexion();
                    MySqlCommand comando = new MySqlCommand(String.Format("select titulo_jardin, descripcion_jardin, precio, ubicacion, fecha_reserva, cantidad_personas, hora_inicio, hora_cierre, titulo_imagen from jardines join reservas on jardines.id = reservas.id_jardines and reservas.id_usuario = {0};", id), conexion);
                    MySqlDataReader reader = comando.ExecuteReader();

                    while (reader.Read())
                    {
                        items.Add(new Reservas()
                        {
                            Titulo = Convert.ToString(reader["titulo_jardin"]),
                            Descripcion = Convert.ToString(reader["descripcion_jardin"]),
                            Precio = Convert.ToString(reader["precio"]),
                            Ubicacion = Convert.ToString(reader["ubicacion"]),
                            Fecha_Reserva = Convert.ToString(reader["fecha_reserva"]),
                            Cantidad_Personas = Convert.ToInt32(reader["cantidad_personas"]),
                            Hora_Inicio = Convert.ToString(reader["hora_inicio"]),
                            Hora_Cierre = Convert.ToString(reader["hora_cierre"]),
                            Imagen = Convert.ToString(reader["titulo_imagen"]),
                        });
                    }

                    conexion.Close();
                    var reservas = items.ElementAt(ID_Jardin);
                    label12.Text = reservas.Titulo.ToString();
                    label2.Text = reservas.Precio.ToString();
                    label4.Text = reservas.Descripcion.ToString();
                    label9.Text = reservas.Ubicacion.ToString();
                    dtp_Fecha_De_Apertura.Text = reservas.Fecha_Reserva.ToString();
                    label13.Text = reservas.Cantidad_Personas.ToString();
                    label14.Text = reservas.Hora_Inicio.ToString();
                    label15.Text = reservas.Hora_Cierre.ToString();
                    pictureBox4.Image = System.Drawing.Image.FromFile("D:/OneDrive - INTEC/Proyecto Final/Proyecto-Final-Desarrollo-de-Software-II/Proyecto Final/Proyecto Final/Fotos/" + reservas.Imagen.ToString());
                }
                catch
                {

                }
            }
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            Form cliente = new Reservar(id, nombre, apellido);
            cliente.Show();
            this.Hide();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_MouseUp(object sender, MouseEventArgs e)
        {
            m = 0;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            m = 1;
            mx = e.X;
            my = e.Y;

        }
    
    }
}
