using UnityEngine;

/// <summary>
/// Class object Link which describe a link between a Target and an Other
/// </summary>
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
