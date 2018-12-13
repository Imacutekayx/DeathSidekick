using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.Managers;
using System;

/// <summary>
/// Class which manage all related to the target's screen
/// </summary>
public class TargetScreenManager : MonoBehaviour {

    //Variables
    private int width;
    private int height;

    //Object
    public List<Image> lstTargets;

    //Constructor
	public TargetScreenManager()
    {
        width = Globals.resolution;
        height = width / 16 * 9;
    }

    /// <summary>
    /// Method which show the current targets
    /// </summary>
    public void ShowTarget()
    {
        //Variables
        int c;

        //Objects
        List<byte> cases = new List<byte> { 0, 1, 2, 3, 4, 5 };
        Assets.Scripts.Target.Target target;

        lstTargets.Clear();

        for(int i = 0; i < Globals.targetManager.currentTargets.Count; ++i)
        {
            target = Globals.targetManager.currentTargets[i];
            lstTargets[i].sprite = target.skin;
            c = UnityEngine.Random.Range(0, cases.Count - 1);
            //TODO Change size l2 and l3
            switch (c)
            {
                case 0:
                case 1:
                    lstTargets[i].rectTransform.sizeDelta = new Vector2(width / 16, height / 18 * 3);
                    break;

                case 2:
                case 3:
                    lstTargets[i].rectTransform.sizeDelta = new Vector2(width / 16, height / 18 * 3);
                    break;

                case 4:
                case 5:
                    lstTargets[i].rectTransform.sizeDelta = new Vector2(width / 16, height / 18 * 3);
                    break;
            }
        }
    }
}
