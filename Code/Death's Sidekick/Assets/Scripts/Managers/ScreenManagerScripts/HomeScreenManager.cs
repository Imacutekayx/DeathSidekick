using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Managers.ScreenManagerScripts
{
    /// <summary>
    /// Class which manage all related to the target's screen
    /// </summary>
    public class HomeScreenManager
    {
        //Variables
        private static readonly float width = ScreenManager.width;
        private static readonly float height = ScreenManager.height;
        public bool sleeped = false;
        public bool tired = false;

        /// <summary>
        /// Method which create the objects used to trigger the screen
        /// </summary>
        public void Initialise()
        {
            GameObject work = new GameObject
            {
                name = "Work"
            };
            BoxCollider2D tempBox = work.AddComponent<BoxCollider2D>();
            tempBox.size = new Vector2(width / 16 * 6, height / 9 * 8);
            tempBox.transform.position = new Vector2(width / 16 * 3 + width / 32 * 6 - width, height - height / 9 * 3 - height / 18 * 8);
            work.AddComponent<ScreenManagerScripts.HomeScreenScripts.ActionTrigger>();
            work.transform.SetParent(Globals.screenManager.canvas.transform, false);

            //Checker
            Image tempImage = work.AddComponent<Image>();
            tempImage.rectTransform.sizeDelta = tempBox.size;
            tempImage.rectTransform.position = tempBox.transform.position;

            //TODO Finish gameObjects
        }
    }
}