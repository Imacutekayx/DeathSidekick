namespace Assets.Scripts.Player.XMLPlayer
{
    /// <summary>
    /// Class which contains the informations of the summons
    /// </summary>
    public class Summon
    {
        //Variables
        public string name;
        public string function;
        public string effect;
        public int nbrInvoked;

        //Constructor
        public Summon(string Name, string Function, string Effect, int NbrInvoked)
        {
            name = Name;
            function = Function;
            effect = Effect;
            nbrInvoked = NbrInvoked;
        }

        /// <summary>
        /// Invoke the Summon
        /// </summary>
        public void Invoke()
        {
            //TODO Choose Scene
            if(nbrInvoked == 0)
            {

            }
            else if(nbrInvoked == 1)
            {

            }
            else
            {

            }
        }
    }
}
