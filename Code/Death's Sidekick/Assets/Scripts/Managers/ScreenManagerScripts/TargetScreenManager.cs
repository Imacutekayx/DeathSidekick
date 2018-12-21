using System.Collections;
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
        public void ShowTarget(Sprite other)
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


                //TODO Fix positions
                //Calculation of the position of the Image
                a = UnityEngine.Random.Range(0, cases.Count - 1);
                c = cases[a];
                cases.Remove(cases[a]);
                switch (c)
                {
                    case 0:
                    case 1:
                        tempImage.rectTransform.sizeDelta = new Vector2(width / 16, height / 18 * 3);
                        x = UnityEngine.Random.Range(width / 16, width / 16 * 5);
                        y = UnityEngine.Random.Range(height / 3 * 2 - height / 2, height / 18 * 15 - height / 2);
                        break;

                    case 2:
                    case 3:
                        tempImage.rectTransform.sizeDelta = new Vector2(width / 64 * 3, height / 72 * 9);
                        x = UnityEngine.Random.Range(width / 16 * 2, width / 64 * 23);
                        y = UnityEngine.Random.Range(height / 18 * 7 - height / 2, height / 36 * 17 - height / 2);
                        break;

                    case 4:
                    case 5:
                        tempImage.rectTransform.sizeDelta = new Vector2(width / 48 * 2, height / 54 * 6);
                        x = UnityEngine.Random.Range(width / 16 * 3, width / 32 * 13);
                        y = UnityEngine.Random.Range(height / 18 * 3 - height / 2, height / 18 * 5 - height / 2);
                        break;
                }
                if (c == 0 || c == 2 || c == 4)
                {
                    x -= width / 2;
                }
                tempImage.rectTransform.position = new Vector3(x, y, 2);
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

                //TODO Verify script
                lstTargets[i].AddComponent<ScreenManagerScripts.TargetScript>();

                lstTargets[i].SetActive(true);
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
            float x = 0;
            float y = 0;
            int count = 0;

            //Foreach other
            foreach (GameObject other in lstOthers[id])
            {
                tempImage = other.GetComponent<Image>();

                int c = UnityEngine.Random.Range(0, 5);
                switch (c)
                {
                    case 0:
                    case 1:
                        tempImage.rectTransform.sizeDelta = new Vector2(width / 16, height / 18 * 3);
                        x = UnityEngine.Random.Range(width / 16, width / 16 * 5);
                        y = UnityEngine.Random.Range(height / 3 * 2 - height / 2, height / 18 * 15 - height / 2);
                        break;

                    case 2:
                    case 3:
                        tempImage.rectTransform.sizeDelta = new Vector2(width / 64 * 3, height / 72 * 9);
                        x = UnityEngine.Random.Range(width / 16 * 2, width / 64 * 23);
                        y = UnityEngine.Random.Range(height / 18 * 7 - height / 2, height / 36 * 17 - height / 2);
                        break;

                    case 4:
                    case 5:
                        tempImage.rectTransform.sizeDelta = new Vector2(width / 48 * 2, height / 54 * 6);
                        x = UnityEngine.Random.Range(width / 16 * 3, width / 32 * 13);
                        y = UnityEngine.Random.Range(height / 18 * 3 - height / 2, height / 18 * 5 - height / 2);
                        break;
                }
                if (c == 0 || c == 2 || c == 4)
                {
                    x -= width / 2;
                }
                tempImage.rectTransform.position = new Vector3(x, y, 1);
                other.SetActive(true);

                //TODO Fix setting link color
                //Create Object Link
                LineRenderer line = lstLinks[id][count].GetComponent<LineRenderer>();
                
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

                //SetRectangle
                //TODO Fix line showed
                line.startWidth = 10;
                line.SetPosition(0, lstTargets[id].transform.position);
                line.SetPosition(1, other.transform.position);

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
    }
}