namespace Assets.Scripts.Player.XMLPlayer
{
    /// <summary>
    /// Class which contains an object's information
    /// </summary>
    public class Item
    {
        //Variables
        public string name;
        public double price;
        public string typeEffect;
        public int valueEffect;
        public bool used;
        public bool inBag;

        //Constructor
        public Item(string Name, double Price, string TypeEffect, int ValueEffect, bool Used, bool InBag)
        {
            name = Name;
            price = Price;
            typeEffect = TypeEffect;
            valueEffect = ValueEffect;
            used = Used;
            inBag = InBag;
        }
    }
}
