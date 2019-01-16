using UnityEngine;

namespace Assets.Scripts.Managers.ScreenManagerScripts.TargetScreenScripts
{
    /// <summary>
    /// Class managing the events of the quit btn on the targetScreen
    /// </summary>
    public class QuitBtn : MonoBehaviour
    {
        /// <summary>
        /// Event triggered qhen the user click on the GameObject and which hide the secCanvas
        /// </summary>
        void OnMouseDown()
        {
            Globals.screenManager.secCanvas.SetActive(false);
        }
    }
}