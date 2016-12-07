using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Life.Interfaces
{
    interface ISaveable
    {
        /*
        * Doormiddel van deze functie kan het object worden opgeslagen
        * @Return bool geeft aan of het opslaan gelukt is
        */
        bool save();

        /*
        * Inladen van object
        * @return bool Geeft aan of het laden gelukt is
        */
        bool load();
    }
}
