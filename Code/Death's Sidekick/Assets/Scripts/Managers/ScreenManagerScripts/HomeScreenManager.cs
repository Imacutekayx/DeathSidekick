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
        public int currentItem = 0;
        public string actionType;
        public bool sleeped = false;
        public bool tired = false;

        /// <summary>
        /// Method which create the objects used to trigger the screen
        /// </summary>
        public void Initialise(Transform canvasTransform)
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
            work.transform.SetParent(canvasTransform, false);

            //Train
            GameObject train = new GameObject
            {
                name = "Train"
            };
            tempBox = train.AddComponent<BoxCollider2D>();
            tempBox.size = new Vector2(width / 8 * 3, height / 9 * 4);
            tempBox.transform.position = new Vector2(-width + width / 16 * 3, -height + height / 9 * 2);
            train.AddComponent<ScreenManagerScripts.HomeScreenScripts.ActionTrigger>();
            train.transform.SetParent(canvasTransform, false);

            //Infos
            GameObject infos = new GameObject
            {
                name = "Infos"
            };
            tempBox = infos.AddComponent<BoxCollider2D>();
            tempBox.size = new Vector2(width / 8 * 5, height / 3 * 2);
            tempBox.transform.position = new Vector2(-width / 8 + width / 16 * 5, height / 9 + height / 3);
            infos.AddComponent<ScreenManagerScripts.HomeScreenScripts.ActionTrigger>();
            infos.transform.SetParent(canvasTransform, false);

            //Sleep
            GameObject sleep = new GameObject
            {
                name = "Sleep"
            };
            tempBox = sleep.AddComponent<BoxCollider2D>();
            tempBox.size = new Vector2(width / 8 * 7, height / 3 * 2);
            tempBox.transform.position = new Vector2(-width / 2 + width / 16 * 7, -height + height / 3);
            sleep.AddComponent<ScreenManagerScripts.HomeScreenScripts.ActionTrigger>();
            sleep.transform.SetParent(canvasTransform, false);

            //Market
            GameObject market = new GameObject
            {
                name = "Market"
            };
            tempBox = market.AddComponent<BoxCollider2D>();
            tempBox.size = new Vector2(width / 4, height / 9 * 4);
            tempBox.transform.position = new Vector2(width / 4 * 3, height / 9);
            market.AddComponent<ScreenManagerScripts.HomeScreenScripts.ActionTrigger>();
            market.transform.SetParent(canvasTransform, false);

            //Bag
            GameObject bag = new GameObject
            {
                name = "Bag"
            };
            tempBox = bag.AddComponent<BoxCollider2D>();
            tempBox.size = new Vector2(width / 2, height / 9 * 7);
            tempBox.transform.position = new Vector2(width - width / 4, -height + height / 18 * 7);
            bag.AddComponent<ScreenManagerScripts.HomeScreenScripts.ActionTrigger>();
            bag.transform.SetParent(canvasTransform, false);

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
                summon.transform.SetParent(canvasTransform, false);
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
            time.transform.SetParent(canvasTransform, false);

            Globals.screenManager.secCanvas.transform.SetAsLastSibling();
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
        public void ShowMarket(Transform secCanvasTransform)
        {
            actionType = "market";
            List<Player.XMLPlayer.Item> market = Globals.playerManager.ShowBuyable();
            
            //Back
            GameObject back = new GameObject();
            Image tempImage = back.AddComponent<Image>();
            tempImage.color = new Color(0.75f, 0.75f, 0.75f);
            tempImage.rectTransform.sizeDelta = new Vector2(width * 2, height * 2);
            back.transform.SetParent(secCanvasTransform, false);

            //Back Items
            GameObject backItem = new GameObject();
            tempImage = backItem.AddComponent<Image>();
            tempImage.color = Color.gray;
            tempImage.rectTransform.sizeDelta = new Vector2(width, height * 2);
            backItem.transform.SetParent(secCanvasTransform, false);

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
            pageMark.transform.SetParent(secCanvasTransform, false);

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
            pageHist.transform.SetParent(secCanvasTransform, false);

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
            close.transform.SetParent(secCanvasTransform, false);

            //Skin
            GameObject skin = new GameObject
            {
                name = "Skin"
            };
            tempImage = skin.AddComponent<Image>();
            tempImage.rectTransform.sizeDelta = new Vector2(width / 8 * 2, height / 9 * 4);
            tempImage.rectTransform.position = new Vector2(width / 4 * 3, height / 3);
            skin.transform.SetParent(secCanvasTransform, false);

            //Name
            GameObject name = new GameObject
            {
                name = "Name"
            };
            Text tempText = name.AddComponent<Text>();
            tempText.rectTransform.sizeDelta = new Vector2(width / 8 * 2, height / 9 * 2);
            tempText.rectTransform.position = new Vector2(width / 4 * 3, 0);
            Globals.screenManager.TextProperties(tempText);
            tempText.alignment = TextAnchor.MiddleCenter;
            tempText.text = "Death";
            name.transform.SetParent(secCanvasTransform, false);

            //Gold
            GameObject gold = new GameObject
            {
                name = "Gold"
            };
            tempText = gold.AddComponent<Text>();
            tempText.rectTransform.sizeDelta = new Vector2(width / 8, height / 9 * 2);
            tempText.rectTransform.position = new Vector2(width / 16 * 11, -height / 3 * 2);
            Globals.screenManager.TextProperties(tempText);
            tempText.alignment = TextAnchor.MiddleCenter;
            tempText.text = Convert.ToString(Globals.playerManager.Money());
            gold.transform.SetParent(secCanvasTransform, false);

            //GoldSkin
            GameObject goldSkin = new GameObject
            {
                name = "GoldSkin"
            };
            tempImage = goldSkin.AddComponent<Image>();
            tempImage.rectTransform.sizeDelta = new Vector2(width / 8, height / 9 * 2);
            tempImage.rectTransform.position = new Vector2(width / 16 * 13, -height / 3 * 2);
            goldSkin.transform.SetParent(secCanvasTransform, false);

            //Items
            for (int i = 0; i < 4; ++i)
            {
                //Skin
                GameObject skinItem = new GameObject
                {
                    name = "skinItem" + i
                };
                tempImage = skinItem.AddComponent<Image>();
                tempImage.rectTransform.sizeDelta = new Vector2(width / 8, height / 9 * 2);
                tempImage.rectTransform.position = new Vector2(i == 0 || i == 2 ? -width / 4 : width / 4, i == 0 || i == 1 ? height / 3 * 2 : -height / 9 * 2);
                tempBox = skinItem.AddComponent<BoxCollider2D>();
                tempBox.size = tempImage.rectTransform.sizeDelta;
                tempBox.transform.position = tempImage.rectTransform.position;
                skinItem.AddComponent<ScreenManagerScripts.HomeScreenScripts.BtnScript>();
                skinItem.transform.SetParent(secCanvasTransform, false);

                //Name
                GameObject nameItem = new GameObject
                {
                    name = "nameItem" + i
                };
                tempText = nameItem.AddComponent<Text>();
                tempText.rectTransform.sizeDelta = new Vector2(width / 4, height / 9 * 2);
                tempText.rectTransform.position = new Vector2(i == 0 || i == 2 ? -width / 4 : width / 4, i == 0 || i == 1 ? height / 9 * 4 : -height / 9 * 4);
                Globals.screenManager.TextProperties(tempText);
                tempText.alignment = TextAnchor.MiddleCenter;
                nameItem.transform.SetParent(secCanvasTransform, false);

                //Price
                GameObject priceItem = new GameObject
                {
                    name = "priceItem" + i
                };
                tempText = priceItem.AddComponent<Text>();
                tempText.rectTransform.sizeDelta = new Vector2(width / 4, height / 9 * 2);
                tempText.rectTransform.position = new Vector2(i == 0 || i == 2 ? -width / 4 : width / 4, i == 0 || i == 1 ? height / 9 * 2 : -height / 3 * 2);
                Globals.screenManager.TextProperties(tempText);
                tempText.alignment = TextAnchor.MiddleCenter;
                priceItem.transform.SetParent(secCanvasTransform, false);
            }

            LoadMarket(Globals.playerManager.lstBuyable);
        }

        /// <summary>
        /// Method which load the items in the market canvas
        /// </summary>
        /// <param name="valueAdd">value to add to the currentItem</param>
        public void LoadMarket(List<Player.XMLPlayer.Item> market, bool changePage = false, bool isMarket = true, int valueAdd = 0)
        {
            Debug.Log(market.Count);

            if (changePage)
            {
                currentItem = 0;
            }

            //Variables
            int currentObject = 0;

            //Load value
            currentItem += valueAdd;
            for (int i = market.Count - currentItem; i > Globals.playerManager.lstBuyable.Count - currentItem - 4; --i)
            {
                if(i > 0)
                {
                    //Skin
                    GameObject skinItem = Globals.screenManager.secCanvas.transform.Find("skinItem" + currentObject).gameObject;
                    skinItem.GetComponent<ScreenManagerScripts.HomeScreenScripts.BtnScript>().id = i - 1;
                    skinItem.SetActive(true);

                    //Name
                    GameObject nameItem = Globals.screenManager.secCanvas.transform.Find("nameItem" + currentObject).gameObject;
                    nameItem.GetComponent<Text>().text = market[i - 1].name;
                    nameItem.SetActive(true);

                    //Price
                    GameObject priceItem = Globals.screenManager.secCanvas.transform.Find("priceItem" + currentObject).gameObject;
                    priceItem.GetComponent<Text>().text = isMarket ? Convert.ToString(market[i - 1].price) : Convert.ToString(market[i - 1].days);
                    priceItem.SetActive(true);
                }
                else
                {
                    Globals.screenManager.secCanvas.transform.Find("skinItem" + currentObject).gameObject.SetActive(false);
                    Globals.screenManager.secCanvas.transform.Find("nameItem" + currentObject).gameObject.SetActive(false);
                    Globals.screenManager.secCanvas.transform.Find("priceItem" + currentObject).gameObject.SetActive(false);
                }
                ++currentObject;
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