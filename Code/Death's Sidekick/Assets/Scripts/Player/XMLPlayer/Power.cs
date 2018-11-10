namespace Assets.Scripts.Player.XMLPlayer
{
    /// <summary>
    /// Class which contains the informations of a power
    /// </summary>
    public class Power
    {
        //Variables
        public string name;
        public string effect;
        public int waitTime;
        public int actualWaitTime;
        public bool unlocked;

        //Constructor
        public Power(string Name, string Effect, int WaitTime, int ActualWaitTime, bool Unlocked)
        {
            name = Name;
            effect = Effect;
            waitTime = WaitTime;
            actualWaitTime = ActualWaitTime;
            unlocked = Unlocked;
        }
    }
}
