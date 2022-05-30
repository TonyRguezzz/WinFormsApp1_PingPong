namespace WinFormsApp1_PingPong
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonJuega_Click(object sender, EventArgs e)
        {
            Juego ventanajuego = new Juego();
            ventanajuego.Show(this);
            this.Hide();
        }
    }
}