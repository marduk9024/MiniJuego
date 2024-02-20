using System.Diagnostics;
using System.Media;

namespace VegaJuego
{
    public partial class Level1 : Form
    {
        Link Player;
        Broncas Enemigo1;
        public Level1()
        {
            InitializeComponent();
            IniciarPersonajes();
            IniciarOpcionesDelMapa();
        }
        private void IniciarOpcionesDelMapa()
        {
            labelVida.Text = "Salud->" + Player.Salud;
            labelEscudo.Text = "Escudo->" + Player.Escudo;
            labelArma.Text = "Arma->" + Player.Arma;
        }
        private void IniciarPersonajes()
        {
            // Lienzo, coordX, coordY, salud, escudo y arma
            Player = new Link(this, 0, 0, 30, 0, 0);
            Enemigo1 = new Broncas(this, 0, 300);
        }

        private void Level1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Player.mover(e);
            Debug.WriteLine("[X" + Player.Caja.Location.X + ",y" + Player.Caja.Location.Y + "]");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelVida.Text = "Salud->" + Player.Salud;
            labelEscudo.Text = "Escudo->" + Player.Escudo;
            labelArma.Text = "Arma->" + Player.Arma;

            if (Player.Caja.Bounds.IntersectsWith(Enemigo1.Caja.Bounds))
            {
                Player.Salud = Player.Salud - 1;
            }
            Enemigo1.mover();

            if (Player.Salud<=0)
            {
                this.Hide();
                Final End = new Final();
                // Paramos el temporizador
                MovEnemigos.Stop();
                End.Show();
            }
        }
    }
}