﻿using System;
using UnityEngine;

namespace Assets.Scripts.Managers.ScreenManagerScripts
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
            Assets.Scripts.Globals.screenManager.ShowLinksTargets(Convert.ToInt32(this.name), true);
        }

        /// <summary>
        /// Hide the links of a target when the mouse exit it
        /// </summary>
        void OnMouseExit()
        {
            Assets.Scripts.Globals.screenManager.ShowLinksTargets(Convert.ToInt32(this.name), false);
        }

        /// <summary>
        /// Show a new screen with the informations of a target
        /// </summary>
        void OnMouseDown()
        {
            //TODO Screen with personnal infos of the target
        }
    }
}