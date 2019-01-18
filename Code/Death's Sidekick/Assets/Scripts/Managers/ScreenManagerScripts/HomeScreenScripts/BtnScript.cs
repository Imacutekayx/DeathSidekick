using System;
using UnityEngine;

namespace Assets.Scripts.Managers.ScreenManagerScripts.HomeScreenScripts
{
    /// <summary>
    /// Script which manage the events of the buttons on the homeScreen
    /// </summary>
    public class BtnScript : MonoBehaviour
    {
        /// <summary>
        /// Event which triggers when the user click on the button
        /// </summary>
        void OnMouseDown()
        {
            switch (this.name)
            {
                case "Speed":
                case "Strength":
                case "Stamina":
                    Globals.playerManager.IncrementStat(5, this.name);
                    Globals.screenManager.ShowContent("Update");
                    break;

                //TODO Change page
                case "PageMark":
                    break;

                case "PageHist":
                    break;

                case "Close":
                    Globals.screenManager.secCanvas.SetActive(false);
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
                    Globals.screenManager.ShowContent("Scroll", "", true, Input.GetAxis("Mouse ScrollWheel"));
                }
            }
        }
    }
}