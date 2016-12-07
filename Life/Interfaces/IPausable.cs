using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Life.Interfaces
{
    interface IPausable
    {
        /*
        * Functies moeten gepauzeerd worden
        */
        void pause();

        /*
        * Functies moeten dus ook gestart worden
        */
        void start();
    }
}
