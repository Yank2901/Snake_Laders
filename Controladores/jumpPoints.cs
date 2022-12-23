using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladores
{
    public class jumpPoints
    {
        /*
         * Casillas donde se ubican la serpiente y escalera
         *  start sera la casilla donde inicia la escalera o donde se encuentra la cabeza de la serpiente
         *  end sera la casilla donde termina la escalera o donde se encuentra la cola de la serpiente
         */
        private int _start;
        private int _end;

        // Constructor
        public jumpPoints(int _start, int _end)
        {
            this._start = _start;
            this._end = _end;
        }

         // Getter y Setters
        public int Start{
            get { return _start; }
            set { _start = value; }
        }

        public int End
        {
            get { return _end;}
            set { _end = value; }
        }
    }
}
