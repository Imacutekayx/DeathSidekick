using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Managers.ScreenManagerScripts.HomeScreenScripts
{
    /// <summary>
    /// Script which manage the events of the buttons on the homeScreen
    /// </summary>
    public class BtnScript : MonoBehaviour
    {
        //Variable
        public int id;
       
        /// <summary>
        /// Event which triggers when the user click on the button
        /// </summary>
        void OnMouseDown()
        {
            if (this.name.Contains("skinItem"))
            {
                Globals.screenManager.ShowContent("Buy", "", false, id);
            }
            else if (this.name.Contains("drop"))
            {
                Globals.screenManager.ShowContent("Drop", "", false, id);
            }
            else
            {
                switch (this.name)
                {
                    case "Speed":
                    case "Strength":
                    case "Stamina":
                        Globals.playerManager.IncrementStat(5, this.name);
                        Globals.screenManager.ShowContent("Update");
                        break;

                    case "PageMark":
                    case "PageHist":
                        Globals.screenManager.secCanvas.transform.Find(this.name == "PageMark" ? "PageHist" : "PageMark").gameObject.AddComponent<ScreenManagerScripts.HomeScreenScripts.BtnScript>();
                        Globals.screenManager.secCanvas.transform.Find(this.name == "PageMark" ? "PageHist" : "PageMark").gameObject.GetComponent<Image>().color = Color.cyan;
                        this.GetComponent<Image>().color = Color.gray;
                        Globals.screenManager.ShowContent("LoadMarket", this.name == "PageHist" ? "History" : "");
                        Destroy(this.GetComponent<ScreenManagerScripts.HomeScreenScripts.BtnScript>());
                        break;

                    case "Close":
                        Globals.screenManager.secCanvas.SetActive(false);
                        //TODO Fix why clear is required here
                        Globals.screenManager.ClearSecCanvas();
                        break;
                }
            }
        }

        /// <summary>
        /// Event which triggers every frame
        /// </summary>
        void Update()
        {
            if (this.name == "Scroller")
            {
                if (Input.GetAxis("Mouse ScrollWheel") != 0f) // Up
                {
                    Globals.screenManager.ShowContent("Scroll", "", true, Input.GetAxis("Mouse ScrollWheel"));
                }
            }
        }
    }
}