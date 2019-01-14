using Assets.Scripts.Managers;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Managers
{
    /// <summary>
    /// Class which manage all the actions between the user and the screen
    /// </summary>
    public class ScreenManager
    {
        //Objects
        public Camera mainCamera = Camera.current;
        public Canvas canvas;
        public GameObject secCanvas;
        public Image background;
        private string currentScreen;
        private ScreenManagerScripts.TargetScreenManager targetScreen = new ScreenManagerScripts.TargetScreenManager();
        private Sprite other = Sprite.Create(new Texture2D(100, 100), new Rect(0,0,100,100), new Vector2(0,0));
        //TODO Add images for each button and skin

        //Constructor
        public ScreenManager()
        {
        }

        /// <summary>
        /// Method which show a new screen depending of the name in parameter
        /// </summary>
        /// <param name="name">Name of the new screen</param>
        public void NewScreen(string name)
        {
            currentScreen = name;
            switch (name)
            {
                case "targetScreen":
                    ShowTargets();
                    break;
            }
        }

        /// <summary>
        /// Show content of the current screen depending of the action
        /// </summary>
        /// <param name="action">Kind of content to show</param>
        /// <param name="idContent">Id of the content</param>
        /// <param name="valueContent">Value applied to the content</param>
        public void ShowContent(string action, string idContent = "", bool valueContent = true)
        {
            switch (currentScreen)
            {
                case "targetScreen":
                    ShowTargetContent(action, Convert.ToInt32(idContent), valueContent);
                    break;
            }
        }

        /// <summary>
        /// Method which call the targetScreen and ask it to show all the current targets
        /// </summary>
        private void ShowTargets()
        {
            float width = Globals.resolution;
            float height = Globals.resolution / 16 * 9;

            background.rectTransform.sizeDelta = new Vector2(0,0);

            //Set secCanvas properties
            secCanvas = canvas.gameObject.transform.Find("SecCanvas").gameObject;
            secCanvas.GetComponent<Canvas>().renderMode = RenderMode.WorldSpace;
            secCanvas.GetComponent<RectTransform>().sizeDelta = new Vector2(-(Globals.resolution), 0);

            //TODO Finish adding objects
            //AddObjectsInCanvas
            GameObject skin = new GameObject();
            Image tempImage = skin.AddComponent<Image>();
            tempImage.rectTransform.sizeDelta = new Vector2();

            targetScreen.ShowTargets(other);
        }

        /// <summary>
        /// Show content of the targetScreen depending of the action
        /// </summary>
        /// <param name="action">Action to do with the content of the screen</param>
        /// <param name="id">Id of the content</param>
        /// <param name="value">Value applied to the content</param>
        private void ShowTargetContent(string action, int id, bool value)
        {
            switch (action)
            {
                case "Infos":
                    targetScreen.ShowTargetInfos(id, secCanvas.GetComponent<Canvas>());
                    break;

                case "Links":
                    targetScreen.ShowLinks(id, value);
                    break;
            }
        }
    }
}