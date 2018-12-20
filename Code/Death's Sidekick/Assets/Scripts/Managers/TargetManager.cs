using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    /// <summary>
    /// Class which manage the Targets of the current Week
    /// </summary>
    public class TargetManager
    {
        //Variables
        private string type = "base";
        private int nbr = 0;

        //Objects
        public List<Target.Target> currentTargets = new List<Target.Target>();
        public List<Target.XMLTarget.Job> jobs = new List<Target.XMLTarget.Job>();
        public List<Target.XMLTarget.Forname> fornames = new List<Target.XMLTarget.Forname>();
        public List<Target.XMLTarget.Lastname> lastnames = new List<Target.XMLTarget.Lastname>();
        public List<Target.XMLTarget.Origin> origins = new List<Target.XMLTarget.Origin>();
        private Target.Target tempTarget;

        //Constructor
        public TargetManager()
        {
            //TargetManagerScripts.GetTargetXML getTargetXML = new TargetManagerScripts.GetTargetXML();
        }

        /// <summary>
        /// Method which create new Targets and add them to the currentTargets
        /// </summary>
        /// <param name="type">Special Type</param>
        /// <param name="nbr">Number of specials types</param>
        private void Create()
        {
            Debug.Log("StartCreate");
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
            Debug.Log("EndCreate");
        }
        /// <summary>
        /// Method which change the values of type and nbr by the current week
        /// </summary>
        public void NewWeek()
        {
            //TODO Change types and number by week
            Create();
        }
    }
}