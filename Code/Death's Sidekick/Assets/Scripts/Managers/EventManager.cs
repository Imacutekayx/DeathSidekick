using UnityEngine;

namespace Assets.Scripts.Managers
{
    /// <summary>
    /// Class which manage all the specials events of the Game
    /// </summary>
    public class EventManager
    {
        //Objects
        EventManagerScripts.Saving saving = new EventManagerScripts.Saving();

        /// <summary>
        /// Create a new Week
        /// </summary>
        public void CreateNewWeek()
        {
            Globals.soulCrystal = false;
            //TODO Create Events and add small references to History Events (killers, events)
            switch (Globals.week)
            {
                default:
                    break;
            }
            //TargetManager
            Debug.Log("Eventmanager");
            Globals.targetManager.NewWeek();
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
            Save();
            CreateNewWeek();
        }
    }
}
