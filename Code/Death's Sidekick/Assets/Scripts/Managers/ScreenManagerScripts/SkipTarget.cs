using UnityEngine;

namespace Assets.Scripts.Managers.ScreenManagerScripts
{
    /// <summary>
    /// Script which give to the player the possibility to skip the choice of the target
    /// </summary>
    public class SkipTarget : MonoBehaviour
    {
        /// <summary>
        /// Event which skip the choice of target
        /// </summary>
        void OnMouseDown()
        {
            Globals.targetManager.target = null;
            //TODO Next Screen
        }
    }
}