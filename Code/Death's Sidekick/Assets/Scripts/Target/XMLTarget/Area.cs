using System.Collections.Generic;

namespace Assets.Scripts.Target.XMLTarget
{
    /// <summary>
    /// Class which contains all the informations of an area
    /// </summary>
    public class Area
    {
        //Variables
        string name;
        int nbr;

        //Objects
        public List<Country> lstCountries = new List<Country>();

        //Constructor
        public Area(string Name, int Nbr, List<Country> LstCountries)
        {
            name = Name;
            nbr = Nbr;
            lstCountries = LstCountries;
        }
    }
}
