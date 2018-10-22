namespace Assets.Scripts.Player
{
    /// <summary>
    /// Class whch contains the informations of a power
    /// </summary>
    class Power
    {
        //Variables
        public string name;
        public string effect;
        public int waitTime;
        public int actualWaitTime;

        //Constructor
        public Power(string Name, string Effect, int WaitTime, int ActualWaitTime)
        {
            name = Name;
            effect = Effect;
            waitTime = WaitTime;
            actualWaitTime = ActualWaitTime;
        }
    }
}
