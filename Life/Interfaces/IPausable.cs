using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Life.Interfaces
{
    interface IPausable
    {
        /// <summary>
        /// Functies moeten gepauzeerd worden
        /// </summary>
        void pause();

        /// <summary>
        /// Functies moeten dus ook gestart worden
        /// </summary>
        void start();
    }
}
