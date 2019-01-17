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
        //Globals
        public static readonly float width = Globals.resolution;
        public static readonly float height = Globals.resolution / 16 * 9;

        //Objects
        public Camera mainCamera = Camera.current;
        public Canvas canvas;
        public GameObject secCanvas;
        public Image background;
        private string currentScreen;
        private ScreenManagerScripts.TargetScreenManager targetScreen = new ScreenManagerScripts.TargetScreenManager();
        private ScreenManagerScripts.HomeScreenManager homeScreen = new ScreenManagerScripts.HomeScreenManager();
        private readonly Sprite other = Sprite.Create(new Texture2D(100, 100), new Rect(0,0,100,100), new Vector2(0,0));
        //TODO Add images for each button and skins algos and sprites

        /// <summary>
        /// Method which show a new screen depending of the name in parameter
        /// </summary>
        /// <param name="name">Name of the new screen</param>
        public void NewScreen(string name)
        {
            //Clean the canvas
            foreach(Transform child in canvas.transform)
            {
                if(child.name != "SecCanvas" && child.name != "Background")
                {
                    GameObject.Destroy(child.gameObject);
                }
            }
            secCanvas.SetActive(false);
            foreach (Transform child in secCanvas.transform)
            {
                GameObject.Destroy(child.gameObject);
            }

            //Change screen
            currentScreen = name;
            switch (name)
            {
                case "targetScreen":
                    ShowTargets();
                    break;

                case "homeScreen":
                    ShowHome();
                    break;
            }
        }

        /// <summary>
        /// Show content of the current screen depending of the action
        /// </summary>
        /// <param name="action">Kind of content to show</param>
        /// <param name="idContent">Id of the content</param>
        /// <param name="valueContent">Value applied to the content</param>
        public void ShowContent(string action, string Content = "", bool valueContent = true)
        {
            switch (currentScreen)
            {
                case "targetScreen":
                    ShowTargetContent(action, Convert.ToInt32(Content), valueContent);
                    break;

                case "homeScreen":
                    ShowHomeContent(action, Content);
                    break;
            }
        }

        /// <summary>
        /// Method which call the targetScreen and ask it to show all the current targets
        /// </summary>
        private void ShowTargets()
        {
            //Set canvas properties
            secCanvas.GetComponent<RectTransform>().sizeDelta = new Vector2(-(Globals.resolution), 0);

            //AddObjectsInCanvas
            //Back
            GameObject back = new GameObject
            {
                name = "Back"
            };
            Image tempImage = back.AddComponent<Image>();
            tempImage.rectTransform.sizeDelta = new Vector2(width, height * 2);
            tempImage.color = new Color(0.75f, 0.75f, 0.75f);
            back.transform.SetParent(secCanvas.transform, false);

            //Skin
            GameObject skin = new GameObject
            {
                name = "Skin"
            };
            tempImage = skin.AddComponent<Image>();
            tempImage.rectTransform.sizeDelta = new Vector2(targetScreen.contentWidth, ScreenManagerScripts.TargetScreenManager.imageHeight);
            tempImage.rectTransform.position = new Vector2(targetScreen.xPosition - width / 2, height / 9 + ScreenManagerScripts.TargetScreenManager.imageHeight /2);
            skin.transform.SetParent(secCanvas.transform, false);

            //Name
            GameObject name = new GameObject
            {
                name = "Name"
            };
            targetScreen.PositionTargetText(name.AddComponent<Text>(), false, 11);
            TextProperties(name.GetComponent<Text>());
            name.GetComponent<Text>().text = name.name;
            name.transform.SetParent(secCanvas.transform, false);

            //Origin
            GameObject origin = new GameObject
            {
                name = "Origin"
            };
            targetScreen.PositionTargetText(origin.AddComponent<Text>(), false, 9);
            TextProperties(origin.GetComponent<Text>());
            origin.GetComponent<Text>().text = origin.name;
            origin.transform.SetParent(secCanvas.transform, false);

            //Age
            GameObject age = new GameObject
            {
                name = "Age"
            };
            targetScreen.PositionTargetText(age.AddComponent<Text>(), false, 7);
            TextProperties(age.GetComponent<Text>());
            age.GetComponent<Text>().text = age.name;
            age.transform.SetParent(secCanvas.transform, false);

            //Sex
            GameObject sex = new GameObject
            {
                name = "Sex"
            };
            targetScreen.PositionTargetText(sex.AddComponent<Text>(), false, 5);
            TextProperties(sex.GetComponent<Text>());
            sex.GetComponent<Text>().text = sex.name;
            sex.transform.SetParent(secCanvas.transform, false);

            //Height
            GameObject targetHeight = new GameObject
            {
                name = "Height"
            };
            targetScreen.PositionTargetText(targetHeight.AddComponent<Text>(), false, 3);
            TextProperties(targetHeight.GetComponent<Text>());
            targetHeight.GetComponent<Text>().text = targetHeight.name;
            targetHeight.transform.SetParent(secCanvas.transform, false);

            //Weight
            GameObject targetWeight = new GameObject
            {
                name = "Weight"
            };
            targetScreen.PositionTargetText(targetWeight.AddComponent<Text>(), false, 1);
            TextProperties(targetWeight.GetComponent<Text>());
            targetWeight.GetComponent<Text>().text = targetWeight.name;
            targetWeight.transform.SetParent(secCanvas.transform, false);

            //Map
            GameObject map = new GameObject
            {
                name = "Map"
            };
            tempImage = map.AddComponent<Image>();
            tempImage.rectTransform.sizeDelta = new Vector2(targetScreen.contentWidth, ScreenManagerScripts.TargetScreenManager.imageHeight);
            tempImage.rectTransform.position = new Vector2(targetScreen.xPosition, -ScreenManagerScripts.TargetScreenManager.imageHeight /2);
            map.transform.SetParent(secCanvas.transform, false);

            //Speed
            GameObject speed = new GameObject
            {
                name = "Speed"
            };
            targetScreen.PositionTargetText(speed.AddComponent<Text>(), true, 11);
            TextProperties(speed.GetComponent<Text>());
            speed.GetComponent<Text>().text = speed.name;
            speed.transform.SetParent(secCanvas.transform, false);

            //Strength
            GameObject strength = new GameObject
            {
                name = "Strength"
            };
            targetScreen.PositionTargetText(strength.AddComponent<Text>(), true, 9);
            TextProperties(strength.GetComponent<Text>());
            strength.GetComponent<Text>().text = strength.name;
            strength.transform.SetParent(secCanvas.transform, false);

            //Stamina
            GameObject stamina = new GameObject
            {
                name = "Stamina"
            };
            targetScreen.PositionTargetText(stamina.AddComponent<Text>(), true, 7);
            TextProperties(stamina.GetComponent<Text>());
            stamina.GetComponent<Text>().text = stamina.name;
            stamina.transform.SetParent(secCanvas.transform, false);

            //Reflex
            GameObject reflex = new GameObject
            {
                name = "Reflex"
            };
            targetScreen.PositionTargetText(reflex.AddComponent<Text>(), true, 5);
            TextProperties(reflex.GetComponent<Text>());
            reflex.GetComponent<Text>().text = reflex.name;
            reflex.transform.SetParent(secCanvas.transform, false);

            //Intellect
            GameObject intellect = new GameObject
            {
                name = "Intellect"
            };
            targetScreen.PositionTargetText(intellect.AddComponent<Text>(), true, 3);
            TextProperties(intellect.GetComponent<Text>());
            intellect.GetComponent<Text>().text = intellect.name;
            intellect.transform.SetParent(secCanvas.transform, false);

            //Anxiety
            GameObject anxiety = new GameObject
            {
                name = "Anxiety"
            };
            targetScreen.PositionTargetText(anxiety.AddComponent<Text>(), true, 1);
            TextProperties(anxiety.GetComponent<Text>());
            anxiety.GetComponent<Text>().text = anxiety.name;
            anxiety.transform.SetParent(secCanvas.transform, false);

            //Quit
            GameObject quit = new GameObject
            {
                name = "Quit"
            };
            tempImage = quit.AddComponent<Image>();
            tempImage.rectTransform.sizeDelta = new Vector2(targetScreen.contentWidth / 2, targetScreen.textHeight);
            tempImage.rectTransform.position = new Vector2(width / 4 - width / 2, height / 9 - height);
            quit.AddComponent<BoxCollider2D>();
            quit.GetComponent<BoxCollider2D>().size = tempImage.rectTransform.sizeDelta;
            quit.transform.SetParent(secCanvas.transform, false);
            quit.AddComponent<ScreenManagerScripts.TargetScreenScripts.BtnTarget>();

            //Kill
            GameObject kill = new GameObject
            {
                name = "Kill"
            };
            tempImage = kill.AddComponent<Image>();
            tempImage.rectTransform.sizeDelta = new Vector2(targetScreen.contentWidth / 2, targetScreen.textHeight);
            tempImage.rectTransform.position = new Vector2(width / 4, height / 9 - height);
            kill.AddComponent<BoxCollider2D>();
            kill.GetComponent<BoxCollider2D>().size = tempImage.rectTransform.sizeDelta;
            kill.transform.SetParent(secCanvas.transform, false);
            kill.AddComponent<ScreenManagerScripts.TargetScreenScripts.BtnTarget>();

            targetScreen.ShowTargets(other);
        }

        /// <summary>
        /// Method which call the homeScreen and show the house of the player
        /// </summary>
        private void ShowHome()
        {
            homeScreen.Initialise();
            ShowContent("Update");
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

        /// <summary>
        /// Show content of the homeScreen depending of the action
        /// </summary>
        /// <param name="action">Action to do with the content of the screen</param>
        /// <param name="nameContent">name of the content</param>
        private void ShowHomeContent(string action, string nameContent)
        {
            switch (action)
            {
                case "Work":
                    ShowContent("Update");
                    break;

                case "Train":
                    break;

                case "Infos":
                    break;

                case "Sleep":
                    homeScreen.sleeped = true;
                    if (homeScreen.tired)
                    {
                        Globals.playerManager.Status("Tired", false);
                        homeScreen.tired = false;
                    }
                    ShowContent("Update");
                    break;

                case "Buy":
                    break;

                case "Bag":
                    break;

                case "Update":
                    //Be called after each action and change value of date & pOfDay
                    if(Globals.day == 7 && Globals.partOfDay == 2)
                    {
                        Globals.eventManager.EndWeek();
                    }
                    else if(Globals.partOfDay == 2)
                    {
                        ++Globals.day;
                        Globals.partOfDay = 0;
                        if(!homeScreen.sleeped && !homeScreen.tired)
                        {
                            Globals.playerManager.Status("Tired", true);
                            homeScreen.tired = true;
                        }
                        homeScreen.sleeped = false;

                        //TODO Down stats
                    }
                    else
                    {
                        ++Globals.partOfDay;
                    }

                    //TODO Change value of time and day
                    break;

                case "Perso":
                    //Show Infos of perso (clicking him depending of his position[after some animation])
                    break;
            }
        }
        
        /// <summary>
        /// Method which set the basic properties of any Text component
        /// </summary>
        /// <param name="tempText">Text to set</param>
        private void TextProperties(Text tempText)
        {
            tempText.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
            tempText.resizeTextForBestFit = true;
            tempText.color = Color.black;
        }
    }
}