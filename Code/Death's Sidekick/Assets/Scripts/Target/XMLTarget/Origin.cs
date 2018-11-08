using System.Collections.Generic;

namespace Assets.Scripts.Target.XMLTarget
{
    /// <summary>
    /// Class which contains all the informations of an origin
    /// </summary>
    public class Origin
    {
        //Variables
        string name;
        int nbr;

        //Objects
        List<Country> lstCountries = new List<Country>();

        //Constructor
        public Origin(string Name, int Nbr, List<Country> LstCountries)
        {
            name = Name;
            nbr = Nbr;
            lstCountries = LstCountries;
        }
    }
}
