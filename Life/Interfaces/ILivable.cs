using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Life.Interfaces
{
    interface ILivable
    {
        /// <summary>  
        /// Deze functie zorgt ervoor dat de zorgt ervoor het object loopt
        /// Lopen kan alleen horizontaal, verticaal of in een hoek van 45 graden.
        /// </summary>
        /// <param name="currentPosition">Geef de huidige positie mee</param>
        /// <returns>Point De functie geeft de nieuwe locatie terug</returns>
        Point walk(Point currentPosition);

        /// <summary>
        /// Deze functie zorgt ervoor dat de zorgt ervoor het object zwemt in water
        /// </summary>
        /// <param name="currentPosition">geeft de huidige positie mee</param>
        /// <returns>De functie geeft de nieuwe locatie terug</returns>
        Point swim(Point currentPosition);

        /// <summary>
        /// Deze functie zorgt ervoor dat er gegeten kan worden
        /// Eten kan alleen als er een plant in de buurt staat.
        /// </summary>
        int eat();

        /// <summary>
        /// Deze functie gaat jagen met andere livable opbjecten
        /// </summary>
        /// <param name="L">Het object waar op gejaagd word</param>
        /// <returns>De functie geeft terug welk object wint.</returns>
        ILivable hunt(ILivable L);

        /// <summary>
        /// Als iets leefbaar is moet het ook dood kunnen gaan.
        /// </summary>
        void die();

        /// <summary>
        /// Deze functie zorgt ervoor dat 2 of meerdere objecten kunnen paren
        /// </summary>
        /// <param name="objects">er moet een lijst met objecten meegestuurd worden die samen paren</param>
        /// <returns>Geeft het kind terug als livable object</returns>
        ILivable mate(List<ILivable> objects);
    }
}
