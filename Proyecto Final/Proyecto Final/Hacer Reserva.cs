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
    

    public partial class Hacer_Reserva : Form
    {
        int ID_Jardin = 1;
        int id;
        string nombre, apellido;
        int ID_JARDIN_ACTUAL = 0;

        class Jardin
        {
            public int ID { get; set; }
            public string Titulo { get; set; }
            public string Descripcion { get; set; }
            public string Precio { get; set; }
            public string Ubicacion { get; set; }
            public string Gama { get; set; }
            public string Maximo_Personas { get; set; }
            public string Imagen { get; set; }
        }

        public Hacer_Reserva(int ID, string Nombre, string Apellido)
        {
            id = ID;
            nombre = Nombre;
            apellido = Apellido;

            InitializeComponent();

            var items = new List<Jardin>();

            try
            {
                MySqlConnection conexion = ObtenerConexion();
                MySqlCommand comando = new MySqlCommand(String.Format("select * from jardines;"), conexion);
                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    items.Add(new Jardin()
                    {
                        ID = Convert.ToInt32(reader["id"]),
                        Titulo = Convert.ToString(reader["titulo_jardin"]),
                        Descripcion = Convert.ToString(reader["descripcion_jardin"]),
                        Precio = Convert.ToString(reader["precio"]),
                        Ubicacion = Convert.ToString(reader["ubicacion"]),
                        Gama = Convert.ToString(reader["gama"]),
                        Maximo_Personas = Convert.ToString(reader["maximo_de_personas"]),
                        Imagen = Convert.ToString(reader["titulo_imagen"]),
                    });
                }
                conexion.Close();
                var jardin = items.ElementAt(ID_Jardin - 1);
                ID_JARDIN_ACTUAL = jardin.ID;
                label11.Text = jardin.Titulo.ToString();
                label2.Text = jardin.Precio.ToString();
                label4.Text = jardin.Descripcion.ToString();
                label9.Text = jardin.Ubicacion.ToString();
                pictureBox4.Image = System.Drawing.Image.FromFile("D:/OneDrive - INTEC/Proyecto Final/Proyecto-Final-Desarrollo-de-Software-II/Proyecto Final/Proyecto Final/Fotos/" + jardin.Imagen.ToString());
            }
            catch
            {
                MessageBox.Show("Ete hombre");
            }
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void dtp_Fecha_De_Apertura_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void tbx_Descripcion_Del_Jardin_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbx_Longitud_Del_Jardin_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbx_Nombre_Del_Jardin_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            m = 1;
            mx = e.X;
            my = e.Y;
        }

        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
            if (m == 1)
            {
                this.SetDesktopLocation(MousePosition.X - mx, MousePosition.Y - my);
            }
        }

        private void pictureBox3_MouseUp(object sender, MouseEventArgs e)
        {
            m = 0;
        }

        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {

        }

        private void pictureBox4_MouseDown(object sender, MouseEventArgs e)
        {
            m = 1;
            mx = e.X;
            my = e.Y;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Hacer_Reserva_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void cbx_Hora_De_Inicio_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void cbx_Cantidad_De_Personas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbx_Hora_De_Cierre_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_Atras_Click(object sender, EventArgs e)
        {
            if (ID_Jardin == 1)
            {
                MessageBox.Show("No puede volver atrás");
            }
            else
            {
                ID_Jardin--;

                var items = new List<Jardin>();
                pictureBox4.Image = null;
                try
                {
                    MySqlConnection conexion = ObtenerConexion();
                    MySqlCommand comando = new MySqlCommand(String.Format("select * from jardines;"), conexion);
                    MySqlDataReader reader = comando.ExecuteReader();

                    while (reader.Read())
                    {
                        items.Add(new Jardin()
                        {
                            ID = Convert.ToInt32(reader["id"]),
                            Titulo = Convert.ToString(reader["titulo_jardin"]),
                            Descripcion = Convert.ToString(reader["descripcion_jardin"]),
                            Precio = Convert.ToString(reader["precio"]),
                            Ubicacion = Convert.ToString(reader["ubicacion"]),
                            Gama = Convert.ToString(reader["gama"]),
                            Maximo_Personas = Convert.ToString(reader["maximo_de_personas"]),
                            Imagen = Convert.ToString(reader["titulo_imagen"]),
                        });
                    }
                    conexion.Close();
                    var jardin = items.ElementAt(ID_Jardin - 1);
                    ID_JARDIN_ACTUAL = jardin.ID;
                    label11.Text = jardin.Titulo.ToString();
                    label2.Text = jardin.Precio.ToString();
                    label4.Text = jardin.Descripcion.ToString();
                    label9.Text = jardin.Ubicacion.ToString();
                    pictureBox4.Image = System.Drawing.Image.FromFile("D:/OneDrive - INTEC/Proyecto Final/Proyecto-Final-Desarrollo-de-Software-II/Proyecto Final/Proyecto Final/Fotos/" + jardin.Imagen.ToString());
                }
                catch
                {

                }
            }
        }

        private void btn_Siguiente_Click(object sender, EventArgs e)
        {
            var items = new List<Jardin>();
            int max = 0;

            try
            {
                MySqlConnection conexion = ObtenerConexion();
                MySqlCommand comando = new MySqlCommand(String.Format("select * from jardines;"), conexion);
                MySqlDataReader reader = comando.ExecuteReader();
                
                while (reader.Read())
                {
                    items.Add(new Jardin()
                    {
                        ID = Convert.ToInt32(reader["id"]),
                        Titulo = Convert.ToString(reader["titulo_jardin"]),
                        Descripcion = Convert.ToString(reader["descripcion_jardin"]),
                        Precio = Convert.ToString(reader["precio"]),
                        Ubicacion = Convert.ToString(reader["ubicacion"]),
                        Gama = Convert.ToString(reader["gama"]),
                        Maximo_Personas = Convert.ToString(reader["maximo_de_personas"]),
                        Imagen = Convert.ToString(reader["titulo_imagen"]),
                    });
                    max++;
                }
                conexion.Close();
                if (ID_Jardin == max)
                {
                    MessageBox.Show("No existen más jardines");
                }
                else
                {
                    pictureBox4.Image = null;
                    ID_Jardin++;

                    var jardin = items.ElementAt(ID_Jardin - 1);
                    ID_JARDIN_ACTUAL = jardin.ID;
                    label11.Text = jardin.Titulo.ToString();
                    label2.Text = jardin.Precio.ToString();
                    label4.Text = jardin.Descripcion.ToString();
                    label9.Text = jardin.Ubicacion.ToString();
                    pictureBox4.Image = System.Drawing.Image.FromFile("D:/OneDrive - INTEC/Proyecto Final/Proyecto-Final-Desarrollo-de-Software-II/Proyecto Final/Proyecto Final/Fotos/" + jardin.Imagen.ToString());
                }

            }
            catch
            {

            }
        }

        private void btn_Reservar_Click(object sender, EventArgs e)
        {
            string año = (dtp_Fecha_De_Apertura.Value.Year).ToString();
            string mes = (dtp_Fecha_De_Apertura.Value.Month).ToString();
            string dia = (dtp_Fecha_De_Apertura.Value.Day).ToString();
            string fecha = año + "-" + mes + "-" + dia;

            #region Almacenamiento de Reserva
            MySqlConnection conexion = ObtenerConexion();
            MySqlCommand comando = new MySqlCommand(String.Format("select count(id) from reservas where fecha_reserva = '{0}' and id_jardines = {1};", fecha, ID_JARDIN_ACTUAL), conexion);
            MySqlDataReader reader = comando.ExecuteReader();
            int cantidad = 0;
            while (reader.Read())
            {
                cantidad = Convert.ToInt32(reader["count(id)"]);
            }
            conexion.Close();

            if (cantidad > 0)
            {
                MessageBox.Show("Jardin reservado el día seleccionado.");
            }
            else
            {
                try
                {
                    conexion = ObtenerConexion();
                    comando = new MySqlCommand(String.Format("insert into reservas (id_usuario, id_jardines, fecha_reserva, cantidad_personas, hora_inicio, hora_cierre) values (" + id + ", " + ID_JARDIN_ACTUAL + ", '" + año + "-" + mes + "-" + dia + "', " + Convert.ToInt32(cbx_Cantidad_De_Personas.Text) + ", '" + cbx_Hora_De_Inicio.Text + "', '" + cbx_Hora_De_Cierre.Text + "' );"), conexion);
                    comando.ExecuteNonQuery();
                    conexion.Close();
                    MessageBox.Show("Reserva registrada correctamente.");

                    Form cliente = new Reservar(id, nombre, apellido);
                    cliente.Show();
                    this.Hide();
                }
                catch
                {
                    MessageBox.Show("Error al registrar reserva.");
                }
            }
            #endregion
        }
                
            


        private void pictureBox12_Click(object sender, EventArgs e)
        {
            Form cliente = new Reservar(id, nombre, apellido);
            cliente.Show();
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
