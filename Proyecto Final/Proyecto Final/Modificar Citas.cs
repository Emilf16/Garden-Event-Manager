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
    public partial class Modificar_Citas : Form
    {
        int id;
        string nombre, apellido;
        public Modificar_Citas(int ID, string Nombre, string Apellido)
        {
            id = ID;
            nombre = Nombre;
            apellido = Apellido;
            InitializeComponent();
            btn_Guardar.Enabled = false;
            btn_Eliminar.Enabled = true;
            btn_Modificar.Enabled = true;
            btn_Cancelar.Enabled = false;

            gbx_Panel_Modificar_Citas.Enabled = false;
            //Tambien se le podría colocar con ReadOnly
            dgv_No_Disponibles.Enabled = true;

            Datos();
        }
        int m, mx, my;//variables que permiten el movimiento del form
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            m = 1;
            mx = e.X;
            my = e.Y;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dgv_Disponibles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void dgv_No_Disponibles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }




        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbx_Nombre_Del_Usuario_Enter(object sender, EventArgs e)
        {
            if (tbx_Nombre_Del_Usuario.Text == "Nombre de Usuario")
            {
                tbx_Nombre_Del_Usuario.Text = "";
                tbx_Nombre_Del_Usuario.ForeColor = Color.White;
            }
        }

        private void tbx_Nombre_Del_Usuario_Leave(object sender, EventArgs e)
        {
            if (tbx_Nombre_Del_Usuario.Text == "")
            {
                tbx_Nombre_Del_Usuario.Text = "Nombre de Usuario";
                tbx_Nombre_Del_Usuario.ForeColor = Color.White;
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Modificar_Citas_Load(object sender, EventArgs e)
        {

        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            btn_Guardar.Enabled = false;
            btn_Eliminar.Enabled = true;
            btn_Modificar.Enabled = true;
            btn_Cancelar.Enabled = false;

            gbx_Panel_Modificar_Citas.Enabled = false;
            dgv_No_Disponibles.Enabled = true;

        }

        private void btn_Crear_Click(object sender, EventArgs e)
        {
            
            btn_Guardar.Enabled = true;
            btn_Eliminar.Enabled = true;
            btn_Modificar.Enabled = true;
            btn_Cancelar.Enabled = true;

            gbx_Panel_Modificar_Citas.Enabled = true;
            dgv_No_Disponibles.Enabled = true;
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            btn_Guardar.Enabled = false;
            btn_Eliminar.Enabled = true;
            btn_Modificar.Enabled = true;
            btn_Cancelar.Enabled = false;

            gbx_Panel_Modificar_Citas.Enabled = false;
            dgv_No_Disponibles.Enabled = true;


            Guardar();
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void btn_Modificar_Click(object sender, EventArgs e)
        {
            
            btn_Guardar.Enabled = true;
            btn_Eliminar.Enabled = true;
            btn_Modificar.Enabled = true;
            btn_Cancelar.Enabled = true;

            gbx_Panel_Modificar_Citas.Enabled = true;
            dgv_No_Disponibles.Enabled = true;
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            Form administrador = new Administrador(id, nombre, apellido);
            administrador.Show();
            this.Hide();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (m == 1)
            {
                this.SetDesktopLocation(MousePosition.X - mx, MousePosition.Y - my);
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dgv_No_Disponibles_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conexion = ObtenerConexion();
                MySqlCommand comando = new MySqlCommand(String.Format("select Reservas.id as 'ID Reserva', titulo_jardin as 'Nombre Jardin', username as 'Usuario', fecha_reserva as 'Fecha reserva', hora_inicio as 'Hora inicio', hora_cierre as 'Hora finalización', cantidad_personas as 'Cantidad Personas' from reservas join jardines on jardines.id = reservas.id_jardines join usuario on reservas.id_usuario = usuario.id where Reservas.id = {0};", dgv_No_Disponibles.Rows[dgv_No_Disponibles.CurrentRow.Index].Cells[0].Value.ToString()), conexion);
                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    cbx_jardin.Text = reader.GetString("Nombre Jardin");
                    tbx_Nombre_Del_Usuario.Text = Convert.ToString(reader["Usuario"]);
                    dateTimePicker1.Text = Convert.ToString(reader["Fecha reserva"]);
                    comboBox3.Text = Convert.ToString(reader["Cantidad Personas"]);
                    comboBox2.Text = Convert.ToString(reader["Hora inicio"]);
                    comboBox1.Text = Convert.ToString(reader["Hora finalización"]);
                }
                conexion.Close();
            }
            catch
            {
                MessageBox.Show("Error al cargar los datos");
            }
            try
            {
                MySqlConnection conexion = ObtenerConexion();
                
                MySqlDataAdapter da = new MySqlDataAdapter("select titulo_jardin from jardines;", conexion);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cbx_jardin.ValueMember = "titulo_jardin";
                cbx_jardin.DisplayMember = "titulo_jardin";
                cbx_jardin.DataSource = dt;
                conexion.Close();
            }
            catch
            {
                MessageBox.Show("Error al buscar Jardines");
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            m = 0;
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            #region Eliminar Reserva
            try
            {
                MySqlConnection conexion = ObtenerConexion();
                MySqlCommand comando;
                comando = new MySqlCommand(String.Format("delete from reservas where id = {0};",  dgv_No_Disponibles.Rows[dgv_No_Disponibles.CurrentRow.Index].Cells[0].Value.ToString()), conexion);
                comando.ExecuteNonQuery();
                conexion.Close();
                MessageBox.Show("Reserva eliminada correctamente.");
                Datos();
            }
            catch
            {
                MessageBox.Show("Error");
            }
            #endregion
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            Form buscarusuario = new Form1();
            buscarusuario.Show();
        }

        #region Conexión Base de Datos
        public static MySqlConnection ObtenerConexion()
        {
            MySqlConnection conectar = new MySqlConnection("server = 127.0.0.1; database = jardines; Uid = root; pwd = 1234;");
            conectar.Open();
            return conectar;
        }
        #endregion

        private void Datos()
        {
            try
            {
                MySqlConnection conexion = ObtenerConexion();
                using (MySqlDataAdapter adapter = new MySqlDataAdapter("select Reservas.id as 'ID Reserva', titulo_jardin as 'Nombre Jardin', username as 'Usuario', fecha_reserva as 'Fecha reserva', hora_inicio as 'Hora inicio', hora_cierre as 'Hora finalización', cantidad_personas as 'Cantidad Personas' from reservas join jardines on jardines.id = reservas.id_jardines join usuario on reservas.id_usuario = usuario.id;", conexion))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dgv_No_Disponibles.DataSource = ds.Tables[0];
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
            #region Actualización de Reservas
            try
            {
                string año = dateTimePicker1.Value.Year.ToString();
                string mes = dateTimePicker1.Value.Month.ToString();
                string dia = dateTimePicker1.Value.Day.ToString();
                string fecha = año + "-" + mes + "-" + dia;
                MySqlConnection conexion = ObtenerConexion();
                MySqlCommand comando;
                comando = new MySqlCommand(String.Format("update reservas set id_jardines = (select id from jardines where titulo_jardin = '{0}'), id_usuario = (select id from usuario where username = '{1}'), fecha_reserva = '{2}', cantidad_personas = {3}, hora_inicio = '{4}', hora_cierre = '{5}'  where id = {6};", cbx_jardin.Text, tbx_Nombre_Del_Usuario.Text, fecha, comboBox3.Text, comboBox2.Text, comboBox1.Text, dgv_No_Disponibles.Rows[dgv_No_Disponibles.CurrentRow.Index].Cells[0].Value.ToString()), conexion);
                comando.ExecuteNonQuery();
                conexion.Close();
                MessageBox.Show("Reserva guardada correctamente.");
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
