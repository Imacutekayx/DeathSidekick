using UnityEngine;

namespace Assets.Scripts.Managers.ScreenManagerScripts.TargetScreenScripts
{
    /// <summary>
    /// Class which manage the events of the buttons
    /// </summary>
    public class BtnTarget : MonoBehaviour
    {
        public int id;

        /// <summary>
        /// Event that trigger when the user click on the btn
        /// </summary>
        void OnMouseDown()
        {
            switch (this.name)
            {
                case "Kill":
                    Globals.targetManager.target = Globals.targetManager.currentTargets[id];
                    Globals.screenManager.NewScreen("homeScreen");
                    break;

                case "Skip":
                    Globals.targetManager.target = null;
                    Globals.screenManager.NewScreen("homeScreen");
                    break;

                case "Quit":
                    Globals.screenManager.secCanvas.SetActive(false);
                    break;
            }
        }
    }
}