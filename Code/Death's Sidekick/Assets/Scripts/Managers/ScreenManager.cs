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
        //Variables
        //TargetScreen
        private static float width = Globals.resolution;
        private static float height = Globals.resolution / 16 * 9;
        private static float contentWidth = width / 8 * 3;
        private static float imageHeight = height / 9 * 7;
        private static float textHeight = imageHeight / 6;
        private static float xPosition = width / 16 + width / 16 * 3;

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
            background.rectTransform.sizeDelta = new Vector2(0,0);

            //Set secCanvas properties
            secCanvas = canvas.gameObject.transform.Find("SecCanvas").gameObject;
            secCanvas.GetComponent<Canvas>().renderMode = RenderMode.WorldSpace;
            secCanvas.GetComponent<RectTransform>().sizeDelta = new Vector2(-(Globals.resolution), 0);

            //TODO Finish adding objects
            //AddObjectsInCanvas
            //Back
            GameObject back = new GameObject();
            back.name = "Back";
            Image tempImage = back.AddComponent<Image>();
            tempImage.rectTransform.sizeDelta = new Vector2(width, height * 2);
            tempImage.color = new Color(0.75f, 0.75f, 0.75f);
            back.transform.SetParent(secCanvas.transform, false);

            //Skin
            GameObject skin = new GameObject();
            skin.name = "Skin";
            tempImage = skin.AddComponent<Image>();
            tempImage.rectTransform.sizeDelta = new Vector2(contentWidth, imageHeight);
            tempImage.rectTransform.position = new Vector2(xPosition - width / 2, height / 9 + imageHeight/2);
            skin.transform.SetParent(secCanvas.transform, false);

            //Name
            GameObject name = new GameObject();
            name.name = "Name";
            PositionText(name.AddComponent<Text>(), false, 11);
            name.GetComponent<Text>().text = name.name;
            name.transform.SetParent(secCanvas.transform, false);

            //Origin
            GameObject origin = new GameObject();
            origin.name = "Origin";
            PositionText(origin.AddComponent<Text>(), false, 9);
            origin.GetComponent<Text>().text = origin.name;
            origin.transform.SetParent(secCanvas.transform, false);

            //Age
            GameObject age = new GameObject();
            age.name = "Age";
            PositionText(age.AddComponent<Text>(), false, 7);
            age.GetComponent<Text>().text = age.name;
            age.transform.SetParent(secCanvas.transform, false);

            //Sex
            GameObject sex = new GameObject();
            sex.name = "Sex";
            PositionText(sex.AddComponent<Text>(), false, 5);
            sex.GetComponent<Text>().text = sex.name;
            sex.transform.SetParent(secCanvas.transform, false);

            //Height
            GameObject targetHeight = new GameObject();
            targetHeight.name = "Height";
            PositionText(targetHeight.AddComponent<Text>(), false, 3);
            targetHeight.GetComponent<Text>().text = targetHeight.name;
            targetHeight.transform.SetParent(secCanvas.transform, false);

            //Weight
            GameObject targetWeight = new GameObject();
            targetWeight.name = "Weight";
            PositionText(targetWeight.AddComponent<Text>(), false, 1);
            targetWeight.GetComponent<Text>().text = targetWeight.name;
            targetWeight.transform.SetParent(secCanvas.transform, false);

            //Map
            GameObject map = new GameObject();
            map.name = "Map";
            tempImage = map.AddComponent<Image>();
            tempImage.rectTransform.sizeDelta = new Vector2(contentWidth, imageHeight);
            tempImage.rectTransform.position = new Vector2(xPosition, -imageHeight/2);
            map.transform.SetParent(secCanvas.transform, false);

            //Speed
            GameObject speed = new GameObject();
            speed.name = "Speed";
            PositionText(speed.AddComponent<Text>(), true, 11);
            speed.GetComponent<Text>().text = speed.name;
            speed.transform.SetParent(secCanvas.transform, false);

            //Strength
            GameObject strength = new GameObject();
            strength.name = "Strength";
            PositionText(strength.AddComponent<Text>(), true, 9);
            strength.GetComponent<Text>().text = strength.name;
            strength.transform.SetParent(secCanvas.transform, false);

            //Stamina
            GameObject stamina = new GameObject();
            stamina.name = "Stamina";
            PositionText(stamina.AddComponent<Text>(), true, 7);
            stamina.GetComponent<Text>().text = stamina.name;
            stamina.transform.SetParent(secCanvas.transform, false);

            //Reflex
            GameObject reflex = new GameObject();
            reflex.name = "Reflex";
            PositionText(reflex.AddComponent<Text>(), true, 5);
            reflex.GetComponent<Text>().text = reflex.name;
            reflex.transform.SetParent(secCanvas.transform, false);

            //IQ
            GameObject iq = new GameObject();
            iq.name = "IQ";
            PositionText(iq.AddComponent<Text>(), true, 3);
            iq.GetComponent<Text>().text = iq.name;
            iq.transform.SetParent(secCanvas.transform, false);

            //Anxiety
            GameObject anxiety = new GameObject();
            anxiety.name = "Anxiety";
            PositionText(anxiety.AddComponent<Text>(), true, 1);
            anxiety.GetComponent<Text>().text = anxiety.name;
            anxiety.transform.SetParent(secCanvas.transform, false);

            //Quit
            GameObject quit = new GameObject();
            quit.name = "Quit";
            tempImage = quit.AddComponent<Image>();
            tempImage.rectTransform.sizeDelta = new Vector2(contentWidth / 2, textHeight);
            tempImage.rectTransform.position = new Vector2(width / 4 - width / 2, height / 9 - height);
            quit.AddComponent<BoxCollider2D>();
            quit.GetComponent<BoxCollider2D>().size = tempImage.rectTransform.sizeDelta;
            quit.transform.SetParent(secCanvas.transform, false);
            quit.AddComponent<ScreenManagerScripts.TargetScreenScripts.QuitBtn>();

            //Kill
            GameObject kill = new GameObject();
            kill.name = "Kill";
            tempImage = kill.AddComponent<Image>();
            tempImage.rectTransform.sizeDelta = new Vector2(contentWidth / 2, textHeight);
            tempImage.rectTransform.position = new Vector2(width / 4, height / 9 - height);
            kill.AddComponent<BoxCollider2D>();
            kill.GetComponent<BoxCollider2D>().size = tempImage.rectTransform.sizeDelta;
            kill.transform.SetParent(secCanvas.transform, false);
            kill.AddComponent<ScreenManagerScripts.TargetScreenScripts.KillBtn>();

            targetScreen.ShowTargets(other);
        }

        /// <summary>
        /// Method which position a text dynamically
        /// </summary>
        /// <param name="tempText">Text to change</param>
        /// <param name="minus">If the text is in the left bottom of the canvas</param>
        /// <param name="nbr">position of the text next to the image</param>
        private void PositionText(Text tempText, bool minus, int nbr)
        {
            float addingX = 0;
            float addingY = 0;
            if (minus)
            {
                addingX = width / 2;
                addingY = height / 9 * 8;
            }
            //TODO Make default font arial
            tempText.resizeTextForBestFit = true;
            tempText.color = Color.black;
            tempText.rectTransform.sizeDelta = new Vector2(contentWidth, textHeight);
            tempText.rectTransform.position = new Vector2(xPosition - addingX, height / 9 + textHeight / 2 * nbr - addingY);
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
                    targetScreen.ShowTargetInfos(id, secCanvas);
                    break;

                case "Links":
                    targetScreen.ShowLinks(id, value);
                    break;
            }
        }
    }
}