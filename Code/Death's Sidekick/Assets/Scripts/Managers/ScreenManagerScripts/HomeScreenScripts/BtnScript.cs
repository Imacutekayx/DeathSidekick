using System;
using UnityEngine;

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
            switch (this.name)
            {
                case "Speed":
                case "Strength":
                case "Stamina":
                    Globals.playerManager.IncrementStat(5, this.name);
                    Globals.screenManager.ShowContent("Update");
                    break;
                    
                case "PageMark":
                    Debug.Log("Market");
                    Globals.screenManager.secCanvas.transform.Find("PageHist").gameObject.AddComponent<ScreenManagerScripts.HomeScreenScripts.BtnScript>();
                    Globals.screenManager.ShowContent("LoadMarket");
                    Destroy(this.GetComponent<ScreenManagerScripts.HomeScreenScripts.BtnScript>());
                    break;

                case "PageHist":
                    Debug.Log("History");
                    Globals.screenManager.secCanvas.transform.Find("PageMark").gameObject.AddComponent<ScreenManagerScripts.HomeScreenScripts.BtnScript>();
                    Globals.screenManager.ShowContent("LoadMarket", "History");
                    Destroy(this.GetComponent<ScreenManagerScripts.HomeScreenScripts.BtnScript>());
                    break;

                case "Close":
                    Globals.screenManager.secCanvas.SetActive(false);
                    //TODO Fix why clear is required here
                    Globals.screenManager.ClearSecCanvas();
                    break;
            }
        }

        /// <summary>
        /// Event which triggers every frame
        /// </summary>
        void Update()
        {
            if (this.name == "market" || this.name == "bag")
            {
                if (Input.GetAxis("Mouse ScrollWheel") != 0f) // Up
                {
                    Debug.Log("Scroll");
                    Globals.screenManager.ShowContent("Scroll", "", true, Input.GetAxis("Mouse ScrollWheel"));
                }
            }
        }
    }
}