using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace WinFormsApp1_PingPong
{
    public partial class Juego : Form
    {
        public Juego()
        {
            InitializeComponent();
        }

        int velocidad = 20;
        int contador = 0; //medir el puntaje para velocidad
        int puntaje = 0;

        bool Arriba;
        bool Izquierda;
         









        private void Juego_Load(object sender, EventArgs e)
        {


            this.Text = "Puntaje 0";
            Random aleatorio = new Random();
            pictureBox1.Location = new Point(0,aleatorio.Next(this.Height));
            Arriba = true;
            Izquierda = true;
            timer1.Enabled= true;
            puntaje = 0;


        }

        private void Juego_FormClosing(object sender, FormClosingEventArgs e)
        {
          
        }

        private void timer1_Tick(object sender, EventArgs e)
        {



            if (pictureBox1.Left > pictureBox2.Left)
            {
                timer1.Enabled = false;
                MessageBox.Show("Puntaje: " + puntaje.ToString() + "veces!");
                puntaje = 0;
                velocidad = 20;
                contador = 0;

            }
            //Rebote de la pelota
            if(pictureBox1.Left+ pictureBox1.Width >= pictureBox2.Left && //verifica que este dentro de el rango de izq a derecha de la barra
               pictureBox1.Left+ pictureBox1.Width <= pictureBox2.Left+pictureBox2.Width &&//verifica que no pase de la posicion de la barra
               pictureBox1.Top+ pictureBox1.Height >= pictureBox2.Top &&//verifica que no se pase de la parte de arriba de la barra
               pictureBox1.Top+ pictureBox1.Height <= pictureBox2.Top+pictureBox2.Height+20)////verifica que no se pase de la parte de abajo de la barra
              {
                Izquierda = false;
                puntaje += 1;
                this.Text = "Puntuacion: "+puntaje.ToString()+"";
                contador +=1;
                if(contador>5)
                {
                    velocidad += 1;
                    contador = 0;
                }
            }





                #region   Movimiento de la pelota
                if (Izquierda)
            {
                pictureBox1.Left += velocidad;// va para la derecha
            }else
            {
                pictureBox1.Left -= velocidad;//va para la izquierda
            }

            if(Arriba)
            {
                pictureBox1.Top += velocidad;//va para abajo
            }
            else
            {
                pictureBox1.Top -= velocidad;//va para arriba
            }

            if(pictureBox1.Top>= this.Height -60)//que si pega e la pared de abajo
            {
                Arriba = false;
            }

            if(pictureBox1.Top<=0)//si pega en la pared de arriba
            {
                Arriba = true;

            }

            if (pictureBox1.Left <= 0)//si pega en la pared de la izquierda
            {
                Izquierda = true;
            }
           
            #endregion 






        }

        private void Juego_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox2.Top = e.Y;
        }

        private void Juego_Click(object sender, EventArgs e)
        {

        }

        private void Juego_Load(object sender, MouseEventArgs e)
        {

        }
    }
}