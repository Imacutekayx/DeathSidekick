using System.Collections.Generic;

namespace Assets.Scripts.Target.XMLTarget
{
    /// <summary>
    /// Class which contains all the informations of an area
    /// </summary>
    public class Area
    {
        //Variables
        public string name;
        public int nbr;

        //Objects
        public List<Country> lstCountries = new List<Country>();

        //Constructor
        public Area(string Name, int Nbr, List<Country> LstCountries)
        {
            name = Name;
            nbr = Nbr;
            foreach (Country country in LstCountries)
            {
                lstCountries.Add(country);
            }
        }
    }
}
