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
        int a;
        float x = 0;
        float y = 0;

        //Objects
        List<byte> cases = new List<byte> { 0, 1, 2, 3, 4, 5 };
        Assets.Scripts.Target.Target target;

        lstTargets.Clear();

        //Foreach target
        for(int i = 0; i < Globals.targetManager.currentTargets.Count; ++i)
        {
            target = Globals.targetManager.currentTargets[i];
            lstTargets[i].sprite = target.skin;
            a = UnityEngine.Random.Range(0, cases.Count - 1);
            c = cases[a];
            cases.Remove(cases[a]);
            //TODO Change size l2 and l3
            switch (c)
            {
                case 0:
                case 1:
                    lstTargets[i].rectTransform.sizeDelta = new Vector2(width / 16, height / 18 * 3);
                    x = UnityEngine.Random.Range(width / 16, width / 16 * 5);
                    y = UnityEngine.Random.Range(height / 3 * 2 - height / 2, height / 18 * 15 - height / 2);
                    break;

                case 2:
                case 3:
                    lstTargets[i].rectTransform.sizeDelta = new Vector2(width / 64*3, height / 72 * 9);
                    x = UnityEngine.Random.Range(width / 16 * 2, width / 64 * 23);
                    y = UnityEngine.Random.Range(height / 18 * 7 - height / 2, height / 36 * 17 - height / 2);
                    break;

                case 4:
                case 5:
                    lstTargets[i].rectTransform.sizeDelta = new Vector2(width / 48*2, height / 54 * 6);
                    x = UnityEngine.Random.Range(width / 16 * 3, width / 32 * 13);
                    y = UnityEngine.Random.Range(height / 18 * 3 - height / 2, height / 18 * 5 - height / 2);
                    break;
            }
            if(c == 0 || c == 2 || c == 4)
            {
                x -= width / 2;
            }
            lstTargets[i].rectTransform.position = new Vector3(x, y);
            //TODO Priority of the targets
            //Foreach link of the target
            foreach(Assets.Scripts.Target.Link link in target.GetLinks())
            {
                //TODO Other and link
            }
        }
    }
}
