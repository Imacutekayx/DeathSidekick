namespace Assets.Scripts.Player.XMLPlayer
{
    /// <summary>
    /// Class which contains the informations of a power
    /// </summary>
    public class Power
    {
        //Variables
        public string name;
        public int week;
        public int waitTime;
        public int actualWaitTime;
        public bool unlocked;

        //Constructor
        public Power(string Name, int Week, int WaitTime, int ActualWaitTime)
        {
            name = Name;
            week = Week;
            waitTime = WaitTime;
            actualWaitTime = ActualWaitTime;
        }
    }
}
