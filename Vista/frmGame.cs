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
        static int jugadores = 2;
        static int turno = 0;
        private int[] posicion = new int[jugadores];
        private List<Panel> lstInfoUser=new List<Panel>();
        private List<Label> lstPosiciones=new List<Label>();
        private List<Label> lstnameUsers = new List<Label>();
        private listPoints lstPoints = new listPoints();
        private listPlayer lstPlayer=new listPlayer();

        private int[,] puntos =
        {
            { 2, 38 }, { 7, 14 }, { 8, 31 }, { 15, 26 }, { 21, 42 }, { 28, 84 }, { 36, 44 }, { 51, 67 }, { 78, 98 },
            { 71, 91 }, { 87, 94 }, { 99, 80 }, { 95, 75 }, { 92, 88 }, { 89, 68 }, { 74, 53 }, { 62, 19 }, { 49, 11 },
            { 46, 25 }, { 16, 6 }
        };
        public frmGame()
        {
            InitializeComponent();
        }

        private void frmGame_Load(object sender, EventArgs e)
        {
            string path = @"C:\Users\User\source\repos\Snakes and laders\Vista\Imagenes\dice";
            pctDice.Image = Image.FromFile(path + ".png");
            inicializarPaneles();
            Posiciones();
            nombresUsuarios();
            crearUsuarios();
            crearPuntos();
        }

        private void pctDice_Click(object sender, EventArgs e)
        {
            string path = @"C:\Users\User\source\repos\Snakes and laders\Vista\Imagenes\dice";
            Random random = new Random();
            int num = random.Next(1, 6);
            pctDice.Image = Image.FromFile(path + num + ".png");
            posicion[turno] = cambiarPosicion(posicion[turno], num);
            lstPosiciones[turno].Text = "Casilla: " + posicion[turno].ToString();
            if (posicion[turno] == 100)
            {

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


    }
}
