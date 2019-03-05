namespace Assets.Scripts.Target.XMLTarget
{
    /// <summary>
    /// Class which contains all the informations of a country
    /// </summary>
    public class Country
    {
        //Variables
        public string name;
        public int nbr;

        //Constructor
        public Country(string Name, int Nbr)
        {
            name = Name;
            nbr = Nbr;
        }
    }
}
