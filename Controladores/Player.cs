using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladores
{
    public class Player
    {
        /* Datos de un jugador:
            name: nombre del jugador 
            position: posicion dentro del tablero que inicia en la casilla 1
         */
        private string _name;
        private int _position;

        // Constructor
        public Player(string _name)
        {
            this._name= _name;
            this._position=1;
        }
        
        // Metodos getters y setters
        public string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }

        public int Postion
        {
            get { return this._position; }
            set { this._position = value; }
        }
    }
}
