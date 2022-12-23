using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladores
{
    public class listPlayer
    {
        // lista de jugadores para el juego
        static List<Player> players;

        // Constructor
        public listPlayer()
        {
            players = new List<Player>();
        }

        // Se ingresa un nuevo jugador a la lista
        public void addPlayer(Player p)
        {
            players.Add(p);
        }

        public void clearPlayer()
        {
            players.Clear();
        }

        /* Funcion para cambiar la posicion tras tirar el dado
                Requiero un entero para saber de que jugador es el turno
                Dice es el valor del dado tirado
         */
        public void turnPlay(int i, int dice)
        {
            int count = 1;
            foreach (Player p in players)
            {
                // Con la sentencia if verifico que cambiara la posicion del jugador en turno, restringiendo que no puedan repetir turnos
                if (count == i)
                {
                    p.Postion += dice;
                    break;;
                }
                count++;
            }
        }

        /* Funcion para verificar que no cai en una serpiente o escalera
                Requiero un entero para saber de que jugador es el turno
                lstP es la llista de casillas donde inician y terminan las escalera y serpientes
         */
        public void vlidateJump(int i, listPoints lstP)
        {
            int count = 1;
            foreach (Player p in players)
            {
                // Busco que jugador esta en su turno
                if (count == i)
                {
                    // En caso de que la posicion actual sea una posicion de escalera o serpiente la posicion cambiara, caso contrario se mantendra
                    p.Postion = lstP.verifyJump(p.Postion);
                    break;
                }
                count++;
            }
        }
    }
}
