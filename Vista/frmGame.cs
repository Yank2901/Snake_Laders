using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controladores;
namespace Vista
{
    public partial class frmGame : Form
    {
        static int jugadores;
        static int turno = 0;
        private int[] posicion;
        private List<Panel> lstInfoUser=new List<Panel>();
        private List<Label> lstPosiciones=new List<Label>();
        private List<Label> lstnameUsers = new List<Label>();
        private listPoints lstPoints = new listPoints();
        private listPlayer lstPlayer=new listPlayer();
        private List<PictureBox> lstImages=new List<PictureBox>();
        private int[,] puntos =
        {
            { 2, 38 }, { 7, 14 }, { 8, 31 }, { 15, 26 }, { 21, 42 }, { 28, 84 }, { 36, 44 }, { 51, 67 }, { 78, 98 },
            { 71, 91 }, { 87, 94 }, { 99, 80 }, { 95, 75 }, { 92, 88 }, { 89, 68 }, { 74, 53 }, { 62, 19 }, { 49, 11 },
            { 46, 25 }, { 16, 6 }
        };

        // En esta matriz se deben colocar las ubicaciones que tomaran las fichas por cada casilla dentro del tablero
        // No es completamente exacta en mi caso debido al autoescalado de visual al 125%
        private int[,] celdas =
        {
            { 0, 632 }, { 84, 632 }, { 168, 632 }, { 252, 632 }, { 336, 632 }, { 420, 632 }, { 504, 632 }, { 588, 632 }, { 672, 632 }, { 756, 632 },
            { 864, 557 }, { 768, 557 }, { 672, 557 }, { 576, 557 }, { 480, 557 }, { 384, 557 }, { 288, 557 }, { 186, 557 }, { 96, 557 }, { 0, 557 },
            { 0, 482 }, { 84, 482 }, { 168, 482 }, { 252, 482 }, { 336, 482 }, { 420, 482 }, { 504, 482 }, { 588, 482 }, { 672, 482 }, { 756, 482 },
            { 864, 407 }, { 768, 407 }, { 672, 407 }, { 576, 407 }, { 480, 407 }, { 384, 407 }, { 288, 407 }, { 186, 407 }, { 96, 407 }, { 0, 407 },
            { 0, 332 }, { 84, 332 }, { 168, 332 }, { 252, 332 }, { 336, 332 }, { 420, 332 }, { 504, 332 }, { 588, 332 }, { 672, 332 }, { 756, 332 },
            { 864, 257 }, { 768, 257 }, { 672, 257 }, { 576, 257 }, { 480, 257 }, { 384, 257 }, { 288, 257 }, { 186, 257 }, { 96, 257 }, { 0, 257 },
            { 0, 182 }, { 84, 182 }, { 168, 182 }, { 252, 182 }, { 336, 182 }, { 420, 182 }, { 504, 182 }, { 588, 182 }, { 672, 182 }, { 756, 182 },
            { 864, 107 }, { 768, 107 }, { 672, 107 }, { 576, 107 }, { 480, 107 }, { 384, 107 }, { 288, 107 }, { 186, 107 }, { 96, 107 }, { 0, 107 },
            { 0, 62 }, { 84, 62 }, { 168, 62 }, { 252, 62 }, { 336,62 }, { 420, 62 }, { 504, 62 }, { 588, 62 }, { 672, 62 }, { 756,62 },
            { 864, 0 }, { 768, 0 }, { 672, 0 }, { 576, 0 }, { 480, 0 }, { 384, 0 }, { 288, 0 }, { 186, 0 }, { 96, 0 }, { 0, 0 }
        };
        public frmGame()
        {
            InitializeComponent();
        }

        private void frmGame_Load(object sender, EventArgs e)
        {
            jugadores=int.Parse(numP.Text);
            posicion = new int[jugadores];
            string path = @"C:\Users\User\source\repos\Snakes and laders\Vista\Imagenes\dice";
            pctDice.Image = Image.FromFile(path + ".png");
            inicializarPaneles();
            Posiciones();
            nombresUsuarios();
            crearUsuarios();
            crearPuntos();
            iniciarImagenes();
        }

        private void pctDice_Click(object sender, EventArgs e)
        {
            string path = @"C:\Users\User\source\repos\Snakes and laders\Vista\Imagenes\dice";
            Random random = new Random();
            int num = random.Next(1, 6);
            pctDice.Image = Image.FromFile(path + num + ".png");
            posicion[turno] = cambiarPosicion(posicion[turno], num);
            lstPosiciones[turno].Text = "Casilla: " + posicion[turno].ToString();
            moverFicha(posicion[turno]);
            if (posicion[turno] == 100)
            {
                MessageBox.Show("El juador: " + lstnameUsers[turno].Text + " ha ganado el juego!", "Fin del Juego",
                    MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            turno++;
            if (turno >= jugadores)
                turno-=jugadores;
        }

        private void inicializarPaneles()
        {
            lstInfoUser.Clear();
            lstInfoUser.Add(pnlPlayer1);
            lstInfoUser.Add(pnlPlayer2);
            lstInfoUser.Add(pnlPlayer3);
            lstInfoUser.Add(pnlPlayer4);
            lstInfoUser.Add(pnlPlayer5);
            lstInfoUser.Add(pnlPlayer6);
            lstInfoUser.Add(pnlPlayer7);
            lstInfoUser.Add(pnlPlayer8);
            lstInfoUser.Add(pnlPlayer9);
            for (int i = jugadores - 1; i >= 0; i--)
            {
                lstInfoUser[i].Visible = true;
                posicion[i] = 1;
            }
        }

        private void Posiciones()
        {
            lstPosiciones.Clear();
            lstPosiciones.Add(posicion1);
            lstPosiciones.Add(posicion2);
            lstPosiciones.Add(posicion3);
            lstPosiciones.Add(posicion4);
            lstPosiciones.Add(posicion5);
            lstPosiciones.Add(posicion6);
            lstPosiciones.Add(posicion7);
            lstPosiciones.Add(posicion8);
            lstPosiciones.Add(posicion9);
            for (int i = 0; i < jugadores; i++)
            {
                posicion[i] = 1;
            }
        }

        private void nombresUsuarios()
        {
            lstnameUsers.Clear();
            lstnameUsers.Add(lblPlayer1);
            lstnameUsers.Add(lblPlayer2);
            lstnameUsers.Add(lblPlayer3);
            lstnameUsers.Add(lblPlayer4);
            lstnameUsers.Add(lblPlayer5);
            lstnameUsers.Add(lblPlayer6);
            lstnameUsers.Add(lblPlayer7);
            lstnameUsers.Add(lblPlayer8);
            lstnameUsers.Add(lblPlayer9);
        }

        private void crearUsuarios()
        {
            lstPlayer.clearPlayer();
            for (int i = 0; i < jugadores; i++)
            {
                string name = "Player: " + (i + 1);
                Player a = new Player(name);
                lstPlayer.addPlayer(a);
                lstnameUsers[i].Text = name;
            }
        }

        private void crearPuntos()
        {
            lstPoints.clearPoints();
            for (int i = 0; i < 20; i++)
            {
                jumpPoints a = new jumpPoints(puntos[i, 0], puntos[i,1]);
                lstPoints.addPoints(a);
            }
        }

        private int cambiarPosicion(int posicion, int dado)
        {
            int value = posicion + dado;
            for (int i = 0; i < 20; i++)
            {
                if (value == puntos[i, 0])
                {
                    value = puntos[i, 1];
                    break;
                }
            }

            if (value > 100)
                value = posicion;
            return value;
        }

        private void iniciarImagenes()
        {
            lstImages.Clear();
            lstImages.Add(pctImg1);
            lstImages.Add(pctImg2);
            lstImages.Add(pctImg3);
            lstImages.Add(pctImg4);
            lstImages.Add(pctImg5);
            lstImages.Add(pctImg6);
            lstImages.Add(pctImg7);
            lstImages.Add(pctImg8);
            lstImages.Add(pctImg9);
            for (int i = jugadores - 1; i >= 0; i--)
            {
                lstImages[i].Visible = true;
            }
        }

        private void moverFicha(int posicion)
        {
            int eje = posicion - 1;
            int x = celdas[eje, 0];
            int y = celdas[eje, 1];
            lstImages[turno].Location = new Point(x,y);
        }
    }
}
