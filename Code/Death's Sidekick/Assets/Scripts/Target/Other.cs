using UnityEngine;

/// <summary>
/// Class object Other which is linked to a Target by a Link
/// </summary>
public class Other : MonoBehaviour {

    //Objects
    public Link link;

    //Constructor
    public Other(Target target, byte relation)
    {
        link = new Link(target, this, relation);
    }
}
