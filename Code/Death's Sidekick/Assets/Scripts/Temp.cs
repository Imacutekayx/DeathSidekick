using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    /// <summary>
    /// Class which represents the beginning of the Game
    /// </summary>
    public class Temp : MonoBehaviour
    {
        //GameObjects
        public Camera main;
        public Canvas canvas;
        public Image back;

        // Use this for initialization
        void Start()
        {
            main.orthographicSize = Globals.resolution / main.aspect;
            canvas.GetComponent<CanvasScaler>().referenceResolution = new Vector2(Globals.resolution*2, Globals.resolution / 8 * 9);
            Globals.screenManager.canvas = canvas;
            Globals.screenManager.background = back;
            Globals.eventManager.CreateNewWeek();
        }
    }
}