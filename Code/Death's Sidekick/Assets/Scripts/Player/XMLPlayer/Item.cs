namespace Assets.Scripts.Player.XMLPlayer
{
    /// <summary>
    /// Class which contains an object's information
    /// </summary>
    public class Item
    {
        //Variables
        public string name;
        public int week;
        public double price;
        public bool used;
        public byte days;

        //Constructor
        public Item(string Name, int Week, double Price, bool Used, byte Days)
        {
            name = Name;
            week = Week;
            price = Price;
            used = Used;
            days = Days;
        }
    }
}
