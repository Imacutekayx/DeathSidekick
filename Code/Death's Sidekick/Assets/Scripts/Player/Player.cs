using System.Collections.Generic;

namespace Assets.Scripts.Player
{
    /// <summary>
    /// Class which has the Player's informations
    /// </summary>
    class Player
    {
        //Variables
        private int strength = 25;
        private int speed = 25;
        private int stamina = 25;
        private double money;

        //Skin
        //TODO Skin
        public bool skin;

        //Objects
        private List<XMLPlayer.Object> bag = new List<XMLPlayer.Object>();
        private List<XMLPlayer.Power> powers = new List<XMLPlayer.Power>();

        //Constructor
        public Player()
        {
            //TODO Randomize skin
        }

        /// <summary>
        /// Add an item to the bag
        /// </summary>
        /// <param name="obj">Item to add</param>
        public void AddToBag(XMLPlayer.Object obj)
        {
            bag.Add(obj);
        }

        /// <summary>
        /// Return the current bag
        /// </summary>
        /// <returns>Bag</returns>
        public List<XMLPlayer.Object> ShowBag()
        {
            return bag;
        }

        /// <summary>
        /// Put the used variable of an object to true
        /// </summary>
        /// <param name="obj"></param>
        public void UsedObject(XMLPlayer.Object obj)
        {
            if (!obj.used)
            {
                obj.used = true;
            }
        }

        /// <summary>
        /// Remove an item from the bag
        /// </summary>
        /// <param name="Name">Name of the object</param>
        /// <returns>Object removed</returns>
        public XMLPlayer.Object RemoveFromBag(string Name)
        {
            foreach(XMLPlayer.Object obj in bag)
            {
                if(obj.name == Name)
                {
                    obj.used = false;
                    bag.Remove(obj);
                    return obj;
                }
            }
            return null;
        }

        /// <summary>
        /// Unlock a power
        /// </summary>
        /// <param name="obj">Power to unlock</param>
        public void Unlock(XMLPlayer.Power pow)
        {
            powers.Add(pow);
        }

        /// <summary>
        /// Return the current powers
        /// </summary>
        /// <returns>Powers</returns>
        public List<XMLPlayer.Power> ShowPowers()
        {
            return powers;
        }

        /// <summary>
        /// Put the actualWaitTime of the power used to 0
        /// </summary>
        /// <param name="pow">Power used</param>
        public void UsedPower(XMLPlayer.Power pow)
        {
            pow.actualWaitTime = 0;
        }

        /// <summary>
        /// Increment stat of the Player
        /// </summary>
        /// <param name="name">Stat to train</param>
        public void IncrementStat(string name)
        {
            switch (name)
            {
                //TODO Increment stat
                case "strength":
                    break;

                case "speed":
                    break;

                case "stamina":
                    break;
            }
        }

        /// <summary>
        /// Increment the actualWaitTime of currently blocked powers
        /// </summary>
        public void NewWeek()
        {
            foreach(XMLPlayer.Power pow in powers)
            {
                if(pow.actualWaitTime != pow.waitTime)
                {
                    ++pow.actualWaitTime;
                }
            }
        }
    }
}
