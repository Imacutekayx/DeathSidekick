using Assets.Scripts.TargetScreen.TargetRandom;
using System.Collections.Generic;

public class Target{

    //Objects
    private List<Link> links;

    //Variables
    public bool inCouple = false;
    private bool isScenario;
    private int tempRnd;

    //Basic characteristics
    public string name;
    public string lastName;
    public int age;
    public bool sex;   //0 == Male / 1 == Female
    public int height;
    public int weight;

    //Special characteristics
    public int speed;
    public int strength;
    public int stamina;
    public int reflex;
    public int iq;
    public int anxiety;

    //Constructor
    public Target(bool isScenario, string type = "base")
    {
        //TODO Add types
        this.isScenario = isScenario;

        //Create Basic characteristics
        BasicCharact basic = new BasicCharact(this);

        //Create Special characteristics
        SpaceCharact space = new SpaceCharact(this);

        //Create Links
        LinksTarget link = new LinksTarget(this);
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
    /// Add a link to the list of the target
    /// </summary>
    /// <param name="link">The link we want to add</param>
    public void AddLink(Link link)
    {
        links.Add(link);
    }
}
