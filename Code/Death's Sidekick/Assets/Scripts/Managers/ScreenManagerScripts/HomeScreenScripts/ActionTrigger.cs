using UnityEngine;

namespace Assets.Scripts.Managers.ScreenManagerScripts.HomeScreenScripts
{
    /// <summary>
    /// Class which manage the events linked to the action of the homeScreen
    /// </summary>
    public class ActionTrigger : MonoBehaviour
    {
        /// <summary>
        /// Event which triggers when the user click on the object
        /// </summary>
        void OnMouseDown()
        {
            Globals.screenManager.ShowContent(this.name);
        }
    }
}