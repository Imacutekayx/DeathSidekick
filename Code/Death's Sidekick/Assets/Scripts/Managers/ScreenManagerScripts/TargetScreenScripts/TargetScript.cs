using System;
using UnityEngine;

namespace Assets.Scripts.Managers.ScreenManagerScripts.TargetScreenScripts
{
    /// <summary>
    /// Script which will observe the events of a target
    /// </summary>
    public class TargetScript : MonoBehaviour
    {
        /// <summary>
        /// Show the links of a target when the mouse enter it
        /// </summary>
        void OnMouseEnter()
        {
            if (!Globals.screenManager.secCanvas.activeSelf)
            {
                Assets.Scripts.Globals.screenManager.ShowContent("Links", this.name, true);
            }
        }

        /// <summary>
        /// Hide the links of a target when the mouse exit it
        /// </summary>
        void OnMouseExit()
        {
            Assets.Scripts.Globals.screenManager.ShowContent("Links", this.name, false);
        }

        /// <summary>
        /// Show a new screen with the informations of a target
        /// </summary>
        void OnMouseDown()
        {
            if (!Globals.screenManager.secCanvas.activeSelf)
            {
                OnMouseExit();
                Globals.screenManager.secCanvas.transform.Find("Kill").GetComponent<KillBtn>().id = Convert.ToInt32(this.name);
                Assets.Scripts.Globals.screenManager.ShowContent("Infos", this.name);
            }
        }
    }
}