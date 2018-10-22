using System.Collections.Generic;

namespace Assets.Scripts.Managers
{
    /// <summary>
    /// Class which manage the Targets of the current Week
    /// </summary>
    public class TargetManager
    {
        //Objects
        public List<Target.Target> currentTargets = new List<Target.Target>();
        public List<Target.XML.Job> jobs = new List<Target.XML.Job>();
        public List<Target.XML.Forname> fornames = new List<Target.XML.Forname>();
        public List<Target.XML.Lastname> lastnames = new List<Target.XML.Lastname>();
        public List<string> origins = new List<string>();
        private Target.TargetScreenLoad targetScreenLoad = new Target.TargetScreenLoad();
        private Target.Target tempTarget;

        //Constructor
        public TargetManager()
        {
            //TODO Add Jobs from XML to jobs
            //TODO Add Fornames from XML to fornames
            //TODO Add Lastnames from XML to lastnames
            //TODO Add Origins from XML to origins
        }

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
                    tempTarget = new Target.Target(type);
                }
                else
                {
                    tempTarget = new Target.Target();
                }
                currentTargets.Add(tempTarget);
            }
            tempTarget = null;
            ShowTargets();
        }

        /// <summary>
        /// Method which show the TargetScreen with all the currentTargets
        /// </summary>
        public void ShowTargets()
        {
            targetScreenLoad.DrawBasicScreen();
            foreach(Target.Target target in currentTargets)
            {
                targetScreenLoad.DrawTarget(target);
            }
        }
    }
}