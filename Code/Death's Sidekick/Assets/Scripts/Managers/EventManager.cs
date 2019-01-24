using UnityEngine;

namespace Assets.Scripts.Managers
{
    /// <summary>
    /// Class which manage all the specials events of the Game
    /// </summary>
    public class EventManager
    {
        //Objects
        private EventManagerScripts.Saving saving = new EventManagerScripts.Saving();

        /// <summary>
        /// Create a new Week
        /// </summary>
        public void CreateNewWeek()
        {
            Globals.soulCrystal = false;
            Globals.day = 1;
            Globals.partOfDay = 0;
            //TODO Create Events and add small references to History Events (killers, events)
            switch (Globals.week)
            {
                default:
                    break;
            }

            //Notice Managers
            Globals.playerManager.NewWeek();
            Globals.targetManager.NewWeek();
            Globals.screenManager.NewScreen("targetScreen");
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
                Save();
                CreateNewWeek();
            }
            else
            {
                //TODO GameOver scene
                Load();
            }
        }

        /// <summary>
        /// Method which notice the other managers when a day passed
        /// </summary>
        public void EndDay()
        {
            Globals.playerManager.DayPassed();
        }

        /// <summary>
        /// Method which save the game
        /// </summary>
        public void Save()
        {
            saving.Save();
        }

        /// <summary>
        /// Method which load a version of the game
        /// </summary>
        public void Load()
        {
            saving.Load();
            CreateNewWeek();
        }
    }
}
