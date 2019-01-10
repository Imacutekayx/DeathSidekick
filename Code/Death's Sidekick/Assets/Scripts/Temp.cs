using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class Temp : MonoBehaviour
    {
        public Camera main;
        public Canvas canvas;
        public Image img;

        // Use this for initialization
        void Start()
        {
            main.orthographicSize = Globals.resolution / main.aspect;
            canvas.GetComponent<CanvasScaler>().referenceResolution = new Vector2(Globals.resolution*2, Globals.resolution / 8 * 9);
            Globals.screenManager.canvas = canvas;
            Globals.screenManager.background = img;
            Globals.eventManager.CreateNewWeek();
            Globals.screenManager.ShowTarget();
        }
    }
}