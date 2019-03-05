namespace Assets.Scripts.Target.XMLTarget
{
    /// <summary>
    /// Class which contains the informations of a job
    /// </summary>
    public class Job
    {
        //Variables
        public string name;
        public string place;
        public string hourBeginning;
        public string hourFinishing;

        //Constructor
        public Job(string Name, string Place, string HourBeginning, string HourFinishing)
        {
            name = Name;
            place = Place;
            hourBeginning = HourBeginning;
            hourFinishing = HourFinishing;
        }
    }
}
