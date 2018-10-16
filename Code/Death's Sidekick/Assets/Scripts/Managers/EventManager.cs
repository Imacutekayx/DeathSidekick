namespace Assets.Scripts.Managers
{
    /// <summary>
    /// Class which manage all the specials events of the Game
    /// </summary>
    public class EventManager
    {
        /// <summary>
        /// Create a new Week
        /// </summary>
        public void CreateNewWeek()
        {
            Globals.soulCrystal = false;
            //TODO Create Events
            switch (Globals.week)
            {
                default:
                    Globals.targetManager.Create();
                    break;
            }
        }

        /// <summary>
        /// End the current Week
        /// </summary>
        public void EndWeek()
        {
            if (Globals.soulCrystal)
            {
                //TODO GoodWeek scene
                ++Globals.week;
            }
            else
            {
                //TODO GameOver scene
            }
        }
    }
}
