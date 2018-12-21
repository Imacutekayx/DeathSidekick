using Assets.Scripts.Managers;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    /// <summary>
    /// Class which manage all the actions between the user and the screen
    /// </summary>
    public class ScreenManager
    {
        //Objects
        public Camera mainCamera = Camera.current;
        public Canvas canvas = new Canvas();
        private ScreenManagerScripts.TargetScreenManager targetScreen = new ScreenManagerScripts.TargetScreenManager();
        private Sprite other = Sprite.Create(new Texture2D(100, 100), new Rect(0,0,100,100), new Vector2(0,0));

        //Constructor
        public ScreenManager()
        {
            
        }

        /// <summary>
        /// Method which call the targetScreen and ask it to show all the current targets
        /// </summary>
        public void ShowTarget()
        {
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