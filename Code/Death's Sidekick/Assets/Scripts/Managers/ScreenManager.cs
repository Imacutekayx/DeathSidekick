using Assets.Scripts.Managers;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    /// <summary>
    /// Class which manage all the actions between the user and the screen
    /// </summary>
    public class ScreenManager : MonoBehaviour
    {
        //Objects
        public Camera mainCamera;
        public Canvas canvas;
        public TargetScreenManager targetScreen = new TargetScreenManager();
        public Sprite other;

        //Constructor
        public ScreenManager()
        {
            mainCamera.orthographicSize = Globals.resolution / mainCamera.aspect;
        }

        /// <summary>
        /// Method which call the targetScreen and ask it to show all the current targets
        /// </summary>
        public void ShowTarget()
        {
            Debug.Log("StartShow");
            targetScreen.ShowTarget(other);
        }

        /// <summary>
        /// Method which show all the links between a target and others
        /// </summary>
        /// <param name="id">Id of the target</param>
        public void ShowLinksTargets(int id, bool value)
        {
            targetScreen.ShowLinks(id, value);
        }
    }
}