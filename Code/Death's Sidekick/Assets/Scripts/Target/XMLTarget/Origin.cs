using System.Collections.Generic;

namespace Assets.Scripts.Target.XMLTarget
{
    /// <summary>
    /// Class which contains all the informations of an origin
    /// </summary>
    public class Origin
    {
        //Variables
        public string name;
        public int nbr;

        //Objects
        public List<Area> lstArea = new List<Area>();

        //Constructor
        public Origin(string Name, int Nbr, List<Area> LstArea)
        {
            name = Name;
            nbr = Nbr;
            foreach(Area area in LstArea)
            {
                lstArea.Add(area);
            }
        }
    }
}
