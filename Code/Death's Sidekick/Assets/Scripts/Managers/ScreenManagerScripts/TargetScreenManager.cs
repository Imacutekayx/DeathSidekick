﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts;
using System;

namespace Assets.Scripts.Managers.ScreenManagerScripts
{
    /// <summary>
    /// Class which manage all related to the target's screen
    /// </summary>
    public class TargetScreenManager
    {

        //Variables
        private int width;
        private int height;

        //Object
        private List<GameObject> lstTargets = new List<GameObject>();
        private List<List<GameObject>> lstOthers = new List<List<GameObject>>();
        private List<List<GameObject>> lstLinks = new List<List<GameObject>>();

        //Constructor
        public TargetScreenManager()
        {
            width = Globals.resolution;
            height = width / 16 * 9;
        }

        /// <summary>
        /// Method which show the current targets
        /// </summary>
        public void ShowTargets(Sprite other)
        {
            //Variables
            int c;
            int a;
            float x = 0;
            float y = 0;

            //Objects
            List<byte> cases = new List<byte> { 0, 1, 2, 3, 4, 5 };
            List<GameObject> tempLstOther = new List<GameObject>();
            List<GameObject> tempLstLinks = new List<GameObject>();
            Assets.Scripts.Target.Target target;
            Image tempImage;

            lstTargets.Clear();
            lstOthers.Clear();
            lstLinks.Clear();

            //Foreach target
            for (int i = 0; i < Globals.targetManager.currentTargets.Count; ++i)
            {
                //Creation of the Image
                target = Globals.targetManager.currentTargets[i];
                lstTargets.Add(new GameObject());
                lstTargets[i].AddComponent<Image>();
                lstTargets[i].name = Convert.ToString(i);
                tempImage = lstTargets[i].GetComponent<Image>();
                tempImage.sprite = target.skin;
                
                //Calculation of the position of the Image
                a = UnityEngine.Random.Range(0, cases.Count);
                c = cases[a];
                cases.Remove(cases[a]);
                CalculatePosition(tempImage, c);

                //Foreach link of the target
                int j = 0;
                foreach (Assets.Scripts.Target.Link link in target.GetLinks())
                {
                    tempLstOther.Add(new GameObject());
                    tempLstOther[j].AddComponent<Image>();
                    tempLstOther[j].GetComponent<Image>().sprite = other;
                    tempLstLinks.Add(new GameObject());
                    tempLstLinks[j].AddComponent<LineRenderer>();
                    ++j;
                }
                lstOthers.Add(new List<GameObject>());
                foreach(GameObject gb in tempLstOther)
                {
                    lstOthers[i].Add(gb);
                }
                lstLinks.Add(new List<GameObject>());
                foreach(GameObject gb in tempLstLinks)
                {
                    lstLinks[i].Add(gb);
                }
                tempLstOther.Clear();
                tempLstLinks.Clear();
                ShowOther(i);
                
                //Add components to trigger events
                lstTargets[i].AddComponent<BoxCollider2D>();
                lstTargets[i].GetComponent<BoxCollider2D>().size = lstTargets[i].GetComponent<Image>().rectTransform.sizeDelta;
                lstTargets[i].AddComponent<ScreenManagerScripts.TargetScript>();
                lstTargets[i].GetComponent<ScreenManagerScripts.TargetScript>().enabled = true;

                lstTargets[i].SetActive(true);
            }
            for(int i = 0; i < Globals.targetManager.currentTargets.Count; ++i)
            {
                lstTargets[i].transform.SetParent(Globals.screenManager.canvas.transform, false);
            }
        }

        /// <summary>
        /// Method which draw the others of a specific target
        /// </summary>
        /// <param name="id">Id of the target linked to the others</param>
        private void ShowOther(int id)
        {
            //Objects
            Image tempImage;
            List<Assets.Scripts.Target.Link> lstTargetLinks = Globals.targetManager.currentTargets[id].GetLinks();

            //Variables
            int count = 0;

            //Foreach other
            foreach (GameObject other in lstOthers[id])
            {
                tempImage = other.GetComponent<Image>();

                int c = UnityEngine.Random.Range(0, 5);
                CalculatePosition(tempImage, c);
                other.SetActive(true);
                
                //Create Object Link
                LineRenderer line = lstLinks[id][count].GetComponent<LineRenderer>();
                line.transform.SetParent(Globals.screenManager.canvas.transform, false);

                //Choose color
                switch (lstTargetLinks[count].typeOfRelation)
                {
                    case 0:
                        {
                            line.startColor = new Color(1, 1, 1);
                            break;
                        }

                    case 1:
                        {
                            line.startColor = new Color(1, 0.5f, 0);
                            break;
                        }

                    case 2:
                        {
                            line.startColor = new Color(0, 0, 1);
                            break;
                        }

                    case 3:
                        {
                            line.startColor = new Color(1, 0.75f, 0.8f);
                            break;
                        }

                    case 4:
                        {
                            line.startColor = new Color(1, 0, 0);
                            break;
                        }

                    case 5:
                        {
                            line.startColor = new Color(0.5f, 0.5f, 0.5f);
                            break;
                        }
                }

                //TODO Fix bug lines not visble in gamemode
                //SetRectangle
                line.startWidth = 10;
                line.SetPosition(0, lstTargets[id].transform.position + new Vector3(0, 0, -10));
                line.SetPosition(1, other.transform.position + new Vector3(0, 0, -10));
                other.transform.SetParent(Globals.screenManager.canvas.transform, false);

                ++count;

                ShowLinks(id, false);
            }
        }

        /// <summary>
        /// Method which show the links between the target and others
        /// </summary>
        /// <param name="id">Id of the target in the lstTargets</param>
        public void ShowLinks(int id, bool value)
        {
            foreach (GameObject link in lstLinks[id])
            {
                link.SetActive(value);
            }
        }

        /// <summary>
        /// Method which calculate a dynamic position for the image send based on the case c
        /// </summary>
        /// <param name="tempImage">Image to position</param>
        /// <param name="c">Case of the object</param>
        private void CalculatePosition(Image tempImage, int c)
        {
            //Variables
            float x = 0;
            float y = 0;

            //Size and Y
            switch (c)
            {
                case 0:
                case 1:
                    tempImage.rectTransform.sizeDelta = new Vector2(width / 8, height / 3);
                    y = UnityEngine.Random.Range(height / 6, height / 3 * 2 - height / 6);
                    y -= height;
                    break;

                case 2:
                case 3:
                    tempImage.rectTransform.sizeDelta = new Vector2(width / 48 * 5, height / 18 * 5);
                    y = UnityEngine.Random.Range(height / 9 * 6 + height / 36 * 5, height / 9 * 11 - height / 36 * 5);
                    y -= height;
                    break;

                case 4:
                case 5:
                    tempImage.rectTransform.sizeDelta = new Vector2(width / 12, height / 9 * 2);
                    y = UnityEngine.Random.Range(height / 9 * 2 + height / 9, height / 3 * 2 - height / 9);
                    break;
            }
            //X
            switch (c)
            {
                case 0:
                    x = UnityEngine.Random.Range(width / 8 + width / 16, width / 4 * 3 - width / 16);
                    x -= width;
                    break;

                case 1:
                    x = UnityEngine.Random.Range(width / 4 + width / 16, width / 8 * 7 - width / 16);
                    break;

                case 2:
                    x = UnityEngine.Random.Range(width / 4 + width / 96 * 5, width / 24 * 19 - width / 96 * 5);
                    x -= width;
                    break;

                case 3:
                    x = UnityEngine.Random.Range(width / 24 * 4 + width / 96 * 5, width / 4 * 3 - width / 96 * 5);
                    break;

                case 4:
                    x = UnityEngine.Random.Range(width / 8 * 3 + width / 24, width / 8 * 7 - width / 24);
                    x -= width;
                    break;

                case 5:
                    x = UnityEngine.Random.Range(width / 8 + width / 24, width / 8 * 5 - width / 24);
                    break;
            }
            tempImage.rectTransform.position = new Vector2(x, y);
        }
    }
}