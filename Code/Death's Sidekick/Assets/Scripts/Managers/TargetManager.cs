﻿using System.Collections.Generic;

namespace Assets.Scripts.Managers
{
    /// <summary>
    /// Class which manage the Targets of the current Week
    /// </summary>
    public class TargetManager
    {
        //Objects
        public List<Target> currentTargets = new List<Target>();
        private TargetScreenLoad targetScreenLoad = new TargetScreenLoad();
        private Target tempTarget;

        /// <summary>
        /// Method which create new Targets and add them to the currentTargets
        /// </summary>
        /// <param name="type">Special Type</param>
        /// <param name="nbr">Number of specials types</param>
        public void Create(string type = "base", int nbr = 5)
        {
            currentTargets.Clear();
            for (int i = 0; i < 5; ++i)
            {
                if (i < nbr)
                {
                    tempTarget = new Target(type);
                }
                else
                {
                    tempTarget = new Target();
                }
                currentTargets.Add(tempTarget);
            }
            tempTarget = null;
            Show();
        }

        /// <summary>
        /// Method which show the TargetScreen with all the currentTargets
        /// </summary>
        public void Show()
        {
            targetScreenLoad.DrawBasicScreen();
            foreach(Target target in currentTargets)
            {
                targetScreenLoad.DrawTarget(target);
            }
        }
    }
}
