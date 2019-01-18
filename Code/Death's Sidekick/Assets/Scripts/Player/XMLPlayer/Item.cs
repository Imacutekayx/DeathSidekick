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
        public bool used;
        public byte days;

        //Constructor
        public Item(string Name, double Price, bool Used, byte Days)
        {
            name = Name;
            price = Price;
            used = Used;
            days = Days;
        }
    }
}
