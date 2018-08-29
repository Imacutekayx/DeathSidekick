using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target{

    //Objects
    private List<Link> links;

    //Variables
    private bool isScenario;
    private string name;
    private string lastName;
    //TODO add caracts && skin

    //Constructor
    public Target(bool isScenario, string name, string lastName)
    {
        this.isScenario = isScenario;
        this.name = name;
        this.lastName = lastName;
    }

    /// <summary>
    /// Get the list of links of this target
    /// </summary>
    /// <returns>List of the links</returns>
    public List<Link> GetLinks()
    {
        return this.links;
    }

    /// <summary>
    /// Create a relation between the target and an Other
    /// </summary>
    /// <param name="type">Type of the relation</param>
    public void CreateRelation(byte type)
    {
        Other other = new Other(this, type);
        links.Add(other.link);
    }
}
