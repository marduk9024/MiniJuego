using System.Diagnostics;
using System.Media;

namespace VegaJuego
{
    public partial class Level1 : Form
    {
        Link Player;
        public Level1()
        {
            InitializeComponent();
            IniciarPersonajes();
        }
        private void IniciarPersonajes()
        {
            // Lienzo, coordX, coordY, salud, escudo y arma
            Player = new Link(this, 0, 0, 30, 0, 0);
        }

        private void Level1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Player.mover(e);
            Debug.WriteLine("[X" + Player.Caja.Location.X + ",y" + Player.Caja.Location.Y + "]");
        }
    }
}