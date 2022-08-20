using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Final
{
    public partial class Reservar : Form
    {
        int id;
        string nombre, apellido;
        public Reservar(int ID, string Nombre, string Apellido)
        {
            id = ID;
            nombre = Nombre;
            apellido = Apellido;
            InitializeComponent();
            lbl_bienvenido.Text += Nombre + " " + Apellido;
        }
        int m, mx, my;
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            m = 1;
            mx = e.X;
            my = e.Y;

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (m == 1)
            {
                this.SetDesktopLocation(MousePosition.X - mx, MousePosition.Y - my);
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            m = 0;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btn_Reservar_Click(object sender, EventArgs e)
        {
            var reservar = new Hacer_Reserva(id, nombre, apellido);
            reservar.Show();
            this.Hide();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            var login = new LogIn();
            login.Show();
            this.Hide();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Reservar_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var openReservaciones = new Ver_Reservaciones(id, nombre, apellido);
            openReservaciones.Show();
            this.Hide();
        }
    }
}
