namespace Assets.Scripts.Player.XMLPlayer
{
    /// <summary>
    /// Class which contains an object's information
    /// </summary>
    public class Object
    {
        //Variables
        public string name;
        public double price;
        public string typeEffect;
        public int valueEffect;
        public bool used;

        //Constructor
        public Object(string Name, double Price, string TypeEffect, int ValueEffect, bool Used)
        {
            name = Name;
            price = Price;
            typeEffect = TypeEffect;
            valueEffect = ValueEffect;
            used = Used;
        }
    }
}
