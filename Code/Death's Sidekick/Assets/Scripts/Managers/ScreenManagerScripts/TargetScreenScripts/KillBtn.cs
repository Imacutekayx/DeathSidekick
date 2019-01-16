using UnityEngine;

namespace Assets.Scripts.Managers.ScreenManagerScripts.TargetScreenScripts
{
    /// <summary>
    /// Class which manage the events of the kill btn on the targetScreen
    /// </summary>
    public class KillBtn : MonoBehaviour
    {
        //Variables
        public int id;

        /// <summary>
        /// Event triggered qhen the user click on the GameObject and which choose the designed target as the current target
        /// </summary>
        void OnMouseDown()
        {
            Globals.targetManager.target = Globals.targetManager.currentTargets[id];
            //TODO Next Screen
        }
    }
}