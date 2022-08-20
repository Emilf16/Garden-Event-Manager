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
    public partial class Agregar_Jardines : Form
    {
        int id;
        string nombre, apellido;
        bool check, checkImage = false;

        public Agregar_Jardines(int ID, string Nombre, string Apellido)
        {
            InitializeComponent();
            int id = ID;
            string nombre = Nombre;
            string apellido = Apellido;

            btn_Agregar.Enabled = true;
            btn_Foto.Enabled = false;
            btn_Guardar.Enabled = false;
            btn_Eliminar.Enabled = false;
            btn_Modificar.Enabled = true;
            btn_Cancelar.Enabled = true;

            gb_jardines.Enabled = false;
            dgv_jardines.ReadOnly = true;

            try
            {
                MySqlConnection conexion = ObtenerConexion();

                using (MySqlDataAdapter adapter = new MySqlDataAdapter("select * from jardines;", conexion))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dgv_jardines.DataSource = ds.Tables[0];
                }
                conexion.Close();
            }
            catch
            {
                MessageBox.Show("Error al cargar datos de la base de datos.");
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbx_Descripcion_Del_Jardin_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            m = 1;
            mx = e.X;
            my = e.Y;

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Agregar_Jardines_Load(object sender, EventArgs e)
        {

        }

        private void tbx_Nombre_Del_Jardin_Enter_1(object sender, EventArgs e)
        {
            if (tbx_Nombre_Del_Jardin.Text == "Nombre del Jardin")
            {
                tbx_Nombre_Del_Jardin.Text = "";
                tbx_Nombre_Del_Jardin.ForeColor = Color.White;
            }
        }

        private void tbx_Nombre_Del_Jardin_Leave_1(object sender, EventArgs e)
        {
            if (tbx_Nombre_Del_Jardin.Text == "")
            {
                tbx_Nombre_Del_Jardin.Text = "Nombre del Jardin";
                tbx_Nombre_Del_Jardin.ForeColor = Color.White;
            }
        }

        private void tbx_Longitud_Del_Jardin_Enter(object sender, EventArgs e)
        {
            if (tbx_Longitud_Del_Jardin.Text == "Precio del Jardin")
            {
                tbx_Longitud_Del_Jardin.Text = "";
                tbx_Longitud_Del_Jardin.ForeColor = Color.White;
            }
        }

        private void tbx_Longitud_Del_Jardin_Leave(object sender, EventArgs e)
        {
            if (tbx_Longitud_Del_Jardin.Text == "")
            {
                tbx_Longitud_Del_Jardin.Text = "Precio del Jardin";
                tbx_Longitud_Del_Jardin.ForeColor = Color.White;
            }
        }

        private void tbx_Descripcion_Del_Jardin_Enter_1(object sender, EventArgs e)
        {
            if (tbx_Descripcion_Del_Jardin.Text == "Descripcion del Jardin")
            {
                tbx_Descripcion_Del_Jardin.Text = "";
                tbx_Descripcion_Del_Jardin.ForeColor = Color.White;
            }
        }

        private void tbx_Descripcion_Del_Jardin_Leave_1(object sender, EventArgs e)
        {
            if (tbx_Descripcion_Del_Jardin.Text == "")
            {
                tbx_Descripcion_Del_Jardin.Text = "Descripcion del Jardin";
                tbx_Descripcion_Del_Jardin.ForeColor = Color.White;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tbx_Longitud_Del_Jardin_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            btn_Agregar.Enabled = true;
            btn_Foto.Enabled = false;
            btn_Guardar.Enabled = false;
            btn_Eliminar.Enabled = true;
            btn_Modificar.Enabled = true;
            btn_Cancelar.Enabled = true;

            gb_jardines.Enabled = false;

        }

        private void btn_Agregar_Click(object sender, EventArgs e)
        {
            btn_Agregar.Enabled = false;
            btn_Foto.Enabled = true;
            btn_Guardar.Enabled = true;
            btn_Eliminar.Enabled = true;
            btn_Modificar.Enabled = false;
            btn_Cancelar.Enabled = true;

            gb_jardines.Enabled = true;
            dgv_jardines.ReadOnly = false;

            check = true;
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            btn_Agregar.Enabled = true;
            btn_Foto.Enabled = false;
            btn_Guardar.Enabled = false;
            btn_Eliminar.Enabled = true;
            btn_Modificar.Enabled = true;
            btn_Cancelar.Enabled = true;

            dgv_jardines.ReadOnly = false;

            Guardar();
            Form reiniciar = new Agregar_Jardines(id, nombre, apellido);
            reiniciar.Show();
            this.Hide();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            Form administrador = new Administrador(id, nombre, apellido);
            administrador.Show();
            this.Hide();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void pbx_Agregar_Foto_Click(object sender, EventArgs e)
        {

        }

        private void dtp_Fecha_De_Apertura_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Ubicación del Jardín")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.White;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Ubicación del Jardín";
                textBox2.ForeColor = Color.White;
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (m == 1)
            {
                this.SetDesktopLocation(MousePosition.X - mx, MousePosition.Y - my);
            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "Gama del Jardín:")
            {
                textBox3.Text = "";
                textBox3.ForeColor = Color.White;
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.Text = "Gama del Jardín:";
                textBox3.ForeColor = Color.White;
            }
        }

        private void btn_Foto_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string imagen = openFileDialog1.FileName;
                    pbx_Agregar_Foto.Image = Image.FromFile(imagen);
                }
                checkImage = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("El archivo seleccionado no es un tipo de imagen válido");
            }
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            MySqlConnection conexion = ObtenerConexion();
            MySqlCommand comando = new MySqlCommand(String.Format("delete from jardines where id = {0};", dgv_jardines.Rows[dgv_jardines.CurrentRow.Index].Cells[0].Value.ToString()), conexion);

            comando.ExecuteNonQuery();
            MessageBox.Show("Jardín eliminado correctamente.");
            conexion.Close();
            Datos();
            conexion.Close();

            Form reiniciar = new Agregar_Jardines(id, nombre, apellido);
            reiniciar.Show();
            this.Hide();
        }

        private void btn_Modificar_Click(object sender, EventArgs e)
        {
            btn_Agregar.Enabled = false;
            btn_Foto.Enabled = true;
            btn_Guardar.Enabled = true;
            btn_Eliminar.Enabled = true;
            btn_Modificar.Enabled = false;
            btn_Cancelar.Enabled = true;

            gb_jardines.Enabled = true;
            dgv_jardines.ReadOnly = false;

            check = false;
        }

        private void dgv_jardines_CellClick(object sender, DataGridViewCellEventArgs e)
        {
         
        }

        private void dgv_jardines_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conexion = ObtenerConexion();
                MySqlCommand comando = new MySqlCommand(String.Format("select * from jardines where id = {0};", dgv_jardines.Rows[dgv_jardines.CurrentRow.Index].Cells[0].Value.ToString()), conexion);
                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    tbx_Nombre_Del_Jardin.Text = Convert.ToString(reader["titulo_jardin"]);
                    tbx_Descripcion_Del_Jardin.Text = Convert.ToString(reader["descripcion_jardin"]);
                    tbx_Longitud_Del_Jardin.Text = Convert.ToString(reader["precio"]);
                    textBox2.Text = Convert.ToString(reader["ubicacion"]);
                    textBox3.Text = Convert.ToString(reader["gama"]);
                    cbx_Maximo_De_Personas.Text = Convert.ToString(reader["maximo_de_personas"]);
                    pbx_Agregar_Foto.Image = System.Drawing.Image.FromFile("D:/OneDrive - INTEC/Proyecto Final/Proyecto-Final-Desarrollo-de-Software-II/Proyecto Final/Proyecto Final/Fotos/" + Convert.ToString(reader["titulo_imagen"]));
                }
                conexion.Close();
            }
            catch
            {
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            m = 0;
        }

        private void Datos()
        {
            try
            {
                MySqlConnection conexion = ObtenerConexion();
                using (MySqlDataAdapter adapter = new MySqlDataAdapter("select * from jardines;", conexion))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dgv_jardines.DataSource = ds.Tables[0];
                }
                conexion.Close();
                }
            catch
            {
                MessageBox.Show("Error al cargar datos de la base de datos.");
            }
        }
        private void Guardar()
        {
            #region Almacenamiento de Jardin
            try
            {
                pbx_Agregar_Foto.Tag = openFileDialog1.FileName;
                string Imagen_Nombre = Path.GetFileName(pbx_Agregar_Foto.Tag.ToString());

                MySqlConnection conexion = ObtenerConexion();
                MySqlCommand comando;

                if (check == true)
                {
                    comando = new MySqlCommand(String.Format("insert into jardines (titulo_jardin, descripcion_jardin, precio, ubicacion, gama, maximo_de_personas, titulo_imagen) values ('{0}', '{1}', '{2}', '{3}', '{4}', {5}, '{6}');", tbx_Nombre_Del_Jardin.Text, tbx_Descripcion_Del_Jardin.Text, tbx_Longitud_Del_Jardin.Text, textBox2.Text, textBox3.Text, Convert.ToInt32(cbx_Maximo_De_Personas.Text), Imagen_Nombre), conexion);
                }

                else
                {
                    if (checkImage == true)
                    {
                        comando = new MySqlCommand(String.Format("update jardines set titulo_jardin = '{0}', descripcion_jardin = '{1}', precio = '{2}', ubicacion = '{3}', gama = '{4}', maximo_de_personas = {5}, titulo_imagen = '{6}' where id = {7};", tbx_Nombre_Del_Jardin.Text, tbx_Descripcion_Del_Jardin.Text, tbx_Longitud_Del_Jardin.Text, textBox2.Text, textBox3.Text, Convert.ToInt32(cbx_Maximo_De_Personas.Text), Imagen_Nombre, dgv_jardines.Rows[dgv_jardines.CurrentRow.Index].Cells[0].Value.ToString()), conexion);
                    }
                    else
                    {
                        comando = new MySqlCommand(String.Format("update jardines set titulo_jardin = '{0}', descripcion_jardin = '{1}', precio = '{2}', ubicacion = '{3}', gama = '{4}', maximo_de_personas = {5} where id = {6};", tbx_Nombre_Del_Jardin.Text, tbx_Descripcion_Del_Jardin.Text, tbx_Longitud_Del_Jardin.Text, textBox2.Text, textBox3.Text, Convert.ToInt32(cbx_Maximo_De_Personas.Text), dgv_jardines.Rows[dgv_jardines.CurrentRow.Index].Cells[0].Value.ToString()), conexion);
                    }
                }

                comando.ExecuteNonQuery();
                conexion.Close();
                MessageBox.Show("Jardín guardado correctamente.");
                Datos();
            }
            catch
            {
                MessageBox.Show("Error");
            }
            #endregion

        }
    }
}
