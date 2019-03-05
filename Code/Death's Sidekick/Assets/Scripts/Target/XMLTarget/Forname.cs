namespace Assets.Scripts.Target.XMLTarget
{
    /// <summary>
    /// Class which contains the informations of a Forname
    /// </summary>
    public class Forname
    {
        //Variables
        public bool sex;   //true == Male / false == Female
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
