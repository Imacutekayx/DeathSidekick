namespace Assets.Scripts.Target.XMLTarget
{
    /// <summary>
    /// Class which contains the informations of a Forname
    /// </summary>
    public class Forname
    {
        //Variables
        public bool sex;   //0 == Male / 1 == Female
        public string forname;
        public string origin;

        //Constructor
        public Forname(bool Sex, string Name, string Origin)
        {
            sex = Sex;
            forname = Name;
            origin = Origin;
        }
    }
}
