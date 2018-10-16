using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Link : MonoBehaviour {

    //Objects
    public Target target;
    public Other other;

    //Variables
    public byte typeOfRelation;

    //Constructor
    public Link (Target newTarget, Other newOther, byte newRelation)
    {
        target = newTarget;
        other = newOther;
        typeOfRelation = newRelation;
    }
}
