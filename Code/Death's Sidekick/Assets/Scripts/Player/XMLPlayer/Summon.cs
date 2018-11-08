namespace Assets.Scripts.Player.XMLPlayer
{
    /// <summary>
    /// Class which contains the informations of the summons
    /// </summary>
    public class Summon
    {
        //Variables
        string name;
        string function;
        string effect;
        int nbrInvoked;

        //Constructor
        public Summon(string Name, string Function, string Effect, string SkinFolder, int NbrInvoked)
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
