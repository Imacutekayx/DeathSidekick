using UnityEngine;

/// <summary>
/// Object Other
/// </summary>
public class Other : MonoBehaviour {

    //Objects
    public Link link;

    public Other(Target target, byte relation)
    {
        link = new Link(target, this, relation);
    }
}
