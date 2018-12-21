using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;
namespace Assets.Scripts
{
    public class Temp : MonoBehaviour
    {

        public Camera main;

        // Use this for initialization
        void Start()
        {
            main.orthographicSize = Globals.resolution / main.aspect;
            Globals.eventManager.CreateNewWeek();
            Globals.screenManager.ShowTarget();
        }
    }
}