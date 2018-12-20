using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class Temp : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Debug.Log("Temp");
        Globals.eventManager.CreateNewWeek();
        Debug.Log("EventEnd");
        Globals.screenManager.ShowTarget();
	}
}
