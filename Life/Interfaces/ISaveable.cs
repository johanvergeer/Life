using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Life.Interfaces
{
    interface ISaveable
    {
        /// <summary>
        /// Door middel van deze functie kan het object worden opgeslagen
        /// </summary>
        /// <returns>Geeft aan of het opslaan gelukt is</returns>
        bool save();

        /// <summary>
        /// Inladen van object
        /// </summary>
        /// <returns>Geeft aan of het laden gelukt is</returns>
        bool load();
    }
}
