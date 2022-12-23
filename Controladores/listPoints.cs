using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladores
{
    public class listPoints
    {
        // lista global de todas las escaleras y serpientes del tablero
        static List<jumpPoints> points;

        // Constructor
        public listPoints()
        {
            points=new List<jumpPoints>();
        }

        // Añade escaleras y serpientes
        public void addPoints(jumpPoints jp)
        {
            points.Add(jp);
        }

        public void clearPoints()
        {
            points.Clear();
        }

        // verifica si la posicion p es una casilla donde inicia la escalera o donde se encuentra la cabeza de la serpiente
        public int verifyJump(int p)
        {
            foreach (jumpPoints jp in points)
            {
                // En caso de que la posicion si sea parte de la escalera o serpiente cambia la posicion de la casilla 
                if (p == jp.Start)
                {
                    p = jp.End;
                    break;
                }
            }
            return p;
        }
    }
}
