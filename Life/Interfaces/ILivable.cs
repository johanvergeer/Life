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
        /*
        * Deze functie zorgt ervoor dat de zorgt ervoor het object loopt
        * Lopen kan alleen horizontaal, verticaal of in een hoek van 45 graden.
        * @Param currentPosition geeft de huidige positie mee
        * @Return Point De functie geeft de nieuwe locatie terug
        */
        Point walk(Point currentPosition);

        /*
        * Deze functie zorgt ervoor dat de zorgt ervoor het object zwemt in water
        * @Param currentPosition geeft de huidige positie mee
        * @Return Point De functie geeft de nieuwe locatie terug
        */
        Point swim(Point currentPosition);
        /*
        * Deze functie zorgt ervoor dat er gegeten kan worden
        * Eten kan alleen als er een plant in de buurt staat.
        */
        int eat();

        /*
        * Deze functie gaat jagen met andere livable opbjecten
        * @Param ILivable Het object waar op gejaagd word
        * @Return ILivable De functie geeft terug welk object wint.
        */
        ILivable hunt(ILivable L);

        /*
        * Als iets leefbaar is moet het ook dood kunnen gaan.
        * Dat regelt deze functie
        */
        void die();

        /*
        * Deze functie zorgt ervoor dat 2 of meerdere objecten kunnen paren
        * @Param List<ILiveable> er moet een lijst met objecten meegestuurd worden die samen paren
        * @Return ILivable Geeft het kind terug als livable object
        */
        ILivable mate(List<ILivable> objects);
    }
}
