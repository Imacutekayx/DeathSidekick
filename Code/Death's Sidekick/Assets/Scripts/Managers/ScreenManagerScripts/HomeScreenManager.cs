using System;
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
        public string actionType;
        public bool sleeped = false;
        public bool tired = false;

        /// <summary>
        /// Method which create the objects used to trigger the screen
        /// </summary>
        public void Initialise()
        {
            //Work
            GameObject work = new GameObject
            {
                name = "Work"
            };
            BoxCollider2D tempBox = work.AddComponent<BoxCollider2D>();
            tempBox.size = new Vector2(width / 16 * 6, height / 9 * 8);
            tempBox.transform.position = new Vector2(width / 16 * 3 + width / 32 * 6 - width, height - height / 9 * 3 - height / 18 * 8);
            work.AddComponent<ScreenManagerScripts.HomeScreenScripts.ActionTrigger>();
            work.transform.SetParent(Globals.screenManager.canvas.transform, false);

            //Train
            GameObject train = new GameObject
            {
                name = "Train"
            };
            tempBox = train.AddComponent<BoxCollider2D>();
            tempBox.size = new Vector2(width / 8 * 3, height / 9 * 4);
            tempBox.transform.position = new Vector2(-width + width / 16 * 3, -height + height / 9 * 2);
            train.AddComponent<ScreenManagerScripts.HomeScreenScripts.ActionTrigger>();
            train.transform.SetParent(Globals.screenManager.canvas.transform, false);

            //Infos
            GameObject infos = new GameObject
            {
                name = "Infos"
            };
            tempBox = infos.AddComponent<BoxCollider2D>();
            tempBox.size = new Vector2(width / 8 * 5, height / 3 * 2);
            tempBox.transform.position = new Vector2(-width / 8 + width / 16 * 5, height / 9 + height / 3);
            infos.AddComponent<ScreenManagerScripts.HomeScreenScripts.ActionTrigger>();
            infos.transform.SetParent(Globals.screenManager.canvas.transform, false);

            //Sleep
            GameObject sleep = new GameObject
            {
                name = "Sleep"
            };
            tempBox = sleep.AddComponent<BoxCollider2D>();
            tempBox.size = new Vector2(width / 8 * 7, height / 3 * 2);
            tempBox.transform.position = new Vector2(-width / 2 + width / 16 * 7, -height + height / 3);
            sleep.AddComponent<ScreenManagerScripts.HomeScreenScripts.ActionTrigger>();
            sleep.transform.SetParent(Globals.screenManager.canvas.transform, false);

            //Market
            GameObject market = new GameObject
            {
                name = "Market"
            };
            tempBox = market.AddComponent<BoxCollider2D>();
            tempBox.size = new Vector2(width / 4, height / 9 * 4);
            tempBox.transform.position = new Vector2(width / 4 * 3, height / 9);
            market.AddComponent<ScreenManagerScripts.HomeScreenScripts.ActionTrigger>();
            market.transform.SetParent(Globals.screenManager.canvas.transform, false);

            //Bag
            GameObject bag = new GameObject
            {
                name = "Bag"
            };
            tempBox = bag.AddComponent<BoxCollider2D>();
            tempBox.size = new Vector2(width / 2, height / 9 * 7);
            tempBox.transform.position = new Vector2(width - width / 4, -height + height / 18 * 7);
            bag.AddComponent<ScreenManagerScripts.HomeScreenScripts.ActionTrigger>();
            bag.transform.SetParent(Globals.screenManager.canvas.transform, false);

            //Summon
            if (Globals.week > 10)
            {
                GameObject summon = new GameObject
                {
                    name = "Summon"
                };
                tempBox = summon.AddComponent<BoxCollider2D>();
                tempBox.size = new Vector2(width / 16, height / 9);
                tempBox.transform.position = new Vector2(width / 2 + width / 32, -height / 9 * 2 + height / 18);
                summon.AddComponent<ScreenManagerScripts.HomeScreenScripts.ActionTrigger>();
                summon.transform.SetParent(Globals.screenManager.canvas.transform, false);
            }

            //Time
            GameObject time = new GameObject
            {
                name = "Time"
            };
            Text tempText = time.AddComponent<Text>();
            tempText.rectTransform.sizeDelta = new Vector2(width / 16*9, height / 9);
            tempText.transform.position = new Vector2(width - width / 32*9, height - height / 18);
            Globals.screenManager.TextProperties(tempText);
            time.transform.SetParent(Globals.screenManager.canvas.transform, false);

            UpdateTime();
        }

        /// <summary>
        /// Method which update the time showed on the screen
        /// </summary>
        public void UpdateTime()
        {
            string text = "";

            //Day
            switch (Globals.day)
            {
                case 1:
                    text = "Monday ";
                    break;

                case 2:
                    text = "Tuesday ";
                    break;

                case 3:
                    text = "Wednesday ";
                    break;

                case 4:
                    text = "Thursday ";
                    break;

                case 5:
                    text = "Friday ";
                    break;

                case 6:
                    text = "Saturday ";
                    break;

                case 7:
                    text = "Sunday ";
                    break;
            }

            //Time
            switch (Globals.partOfDay)
            {
                case 0:
                    text += "morning";
                    break;

                case 1:
                    text += "afternoon";
                    break;

                case 2:
                    text += "night";
                    break;
            }

            Globals.screenManager.canvas.transform.Find("Time").GetComponent<Text>().text = text;
        }

        /// <summary>
        /// Method which create the buttons to choose which stat the user wants to train
        /// </summary>
        public void ShowTrain()
        {
            actionType = "Train";

            //Speed
            GameObject speed = new GameObject
            {
                name = "Speed"
            };
            Image tempImage = speed.AddComponent<Image>();
            tempImage.rectTransform.sizeDelta = new Vector2(width / 8 * 3, height / 9);
            tempImage.rectTransform.position = new Vector2(-width + width / 16 * 3, -height / 9 * 5 + height / 18 * 5);
            tempImage.color = Color.blue;
            BoxCollider2D tempBox = speed.AddComponent<BoxCollider2D>();
            tempBox.size = tempImage.rectTransform.sizeDelta;
            tempBox.transform.position = tempImage.rectTransform.position;
            speed.AddComponent<ScreenManagerScripts.HomeScreenScripts.BtnScript>();
            speed.transform.SetParent(Globals.screenManager.canvas.transform, false);

            //Strength
            GameObject strength = new GameObject
            {
                name = "Strength"
            };
            tempImage = strength.AddComponent<Image>();
            tempImage.rectTransform.sizeDelta = new Vector2(width / 8 * 3, height / 9);
            tempImage.rectTransform.position = new Vector2(-width + width / 16 * 3, -height / 9 * 5 + height / 18 * 3);
            tempImage.color = Color.red;
            tempBox = strength.AddComponent<BoxCollider2D>();
            tempBox.size = tempImage.rectTransform.sizeDelta;
            tempBox.transform.position = tempImage.rectTransform.position;
            strength.AddComponent<ScreenManagerScripts.HomeScreenScripts.BtnScript>();
            strength.transform.SetParent(Globals.screenManager.canvas.transform, false);

            //Stamina
            GameObject stamina = new GameObject
            {
                name = "Stamina"
            };
            tempImage = stamina.AddComponent<Image>();
            tempImage.rectTransform.sizeDelta = new Vector2(width / 8 * 3, height / 9);
            tempImage.rectTransform.position = new Vector2(-width + width / 16 * 3, -height / 9 * 5 + height / 18);
            tempImage.color = Color.yellow;
            tempBox = stamina.AddComponent<BoxCollider2D>();
            tempBox.size = tempImage.rectTransform.sizeDelta;
            tempBox.transform.position = tempImage.rectTransform.position;
            stamina.AddComponent<ScreenManagerScripts.HomeScreenScripts.BtnScript>();
            stamina.transform.SetParent(Globals.screenManager.canvas.transform, false);
        }

        /// <summary>
        /// Method which create the buttons to choose which kind of informations the user wants to learn about the target
        /// </summary>
        public void ShowInfos()
        {

        }

        /// <summary>
        /// Method which show the market and the items buyables
        /// </summary>
        public void ShowMarket()
        {
            actionType = "market";
            List<Player.XMLPlayer.Item> market = Globals.playerManager.ShowBuyable();

            //Back
            GameObject back = new GameObject();
            Image tempImage = back.AddComponent<Image>();
            tempImage.color = Color.gray;
            tempImage.rectTransform.sizeDelta = new Vector2(width, height * 2);
            back.transform.SetParent(Globals.screenManager.secCanvas.transform, false);

            //Market
            GameObject pageMark = new GameObject
            {
                name = "PageMark"
            };
            tempImage = pageMark.AddComponent<Image>();
            tempImage.rectTransform.sizeDelta = new Vector2(width / 2, height);
            tempImage.rectTransform.position = new Vector2(-width / 4 * 3, height / 2);
            BoxCollider2D tempBox = pageMark.AddComponent<BoxCollider2D>();
            tempBox.size = tempImage.rectTransform.sizeDelta;
            tempBox.transform.position = tempImage.rectTransform.position;
            pageMark.AddComponent<ScreenManagerScripts.HomeScreenScripts.BtnScript>();
            pageMark.transform.SetParent(Globals.screenManager.secCanvas.transform, false);

            //History
            GameObject pageHist = new GameObject
            {
                name = "PageHist"
            };
            tempImage = pageHist.AddComponent<Image>();
            tempImage.rectTransform.sizeDelta = new Vector2(width / 2, height);
            tempImage.rectTransform.position = new Vector2(-width / 4 * 3, -height / 2);
            tempBox = pageHist.AddComponent<BoxCollider2D>();
            tempBox.size = tempImage.rectTransform.sizeDelta;
            tempBox.transform.position = tempImage.rectTransform.position;
            pageHist.AddComponent<ScreenManagerScripts.HomeScreenScripts.BtnScript>();
            pageHist.transform.SetParent(Globals.screenManager.secCanvas.transform, false);

            //Close
            GameObject close = new GameObject
            {
                name = "Close"
            };
            tempImage = close.AddComponent<Image>();
            tempImage.rectTransform.sizeDelta = new Vector2(width / 8, height / 9 * 2);
            tempImage.rectTransform.position = new Vector2(width / 16 * 15, height / 9 * 8);
            tempBox = close.AddComponent<BoxCollider2D>();
            tempBox.size = tempImage.rectTransform.sizeDelta;
            tempBox.transform.position = tempImage.rectTransform.position;
            close.AddComponent<ScreenManagerScripts.HomeScreenScripts.BtnScript>();
            close.transform.SetParent(Globals.screenManager.secCanvas.transform, false);

            //Skin
            GameObject skin = new GameObject
            {
                name = "Skin"
            };
            tempImage = skin.AddComponent<Image>();
            tempImage.rectTransform.sizeDelta = new Vector2(width / 8 * 2, height / 9 * 4);
            tempImage.rectTransform.position = new Vector2(width / 4 * 3, height / 3);
            skin.transform.SetParent(Globals.screenManager.secCanvas.transform, false);

            //Name
            GameObject name = new GameObject
            {
                name = "Name"
            };
            Text tempText = name.AddComponent<Text>();
            tempText.rectTransform.sizeDelta = new Vector2(width / 8 * 2, height / 9 * 2);
            tempText.rectTransform.position = new Vector2(width / 4 * 3, 0);
            Globals.screenManager.TextProperties(tempText);
            tempText.text = "Death";
            name.transform.SetParent(Globals.screenManager.secCanvas.transform, false);

            //Gold
            GameObject gold = new GameObject
            {
                name = "Gold"
            };
            tempText = gold.AddComponent<Text>();
            tempText.rectTransform.sizeDelta = new Vector2(width / 8, height / 9 * 2);
            tempText.rectTransform.position = new Vector2(width / 16 * 11, -height / 3 * 2);
            Globals.screenManager.TextProperties(tempText);
            tempText.text = Convert.ToString(Globals.playerManager.Money());
            gold.transform.SetParent(Globals.screenManager.secCanvas.transform, false);

            //GoldSkin
            GameObject goldSkin = new GameObject
            {
                name = "GoldSkin"
            };
            tempImage = goldSkin.AddComponent<Image>();
            tempImage.rectTransform.sizeDelta = new Vector2(width / 8, height / 9 * 2);
            tempImage.rectTransform.position = new Vector2(width / 16 * 13, -height / 3 * 2);
            goldSkin.transform.SetParent(Globals.screenManager.secCanvas.transform, false);

            //Items
            for (int i = 0; i < 4; ++i)
            {

            }
        }

        /// <summary>
        /// Method which show the bag of the player and his items
        /// </summary>
        public void ShowBag()
        {

        }
        
        /// <summary>
        /// Method which put the items down
        /// </summary>
        public void ItemUp()
        {

        }

        /// <summary>
        /// Method which put the items down
        /// </summary>
        public void ItemDown()
        {

        }
    }
}