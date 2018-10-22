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
        private List<Object> bag = new List<Object>();
        private List<Power> powers = new List<Power>();

        //Constructor
        public Player()
        {
            //TODO Randomize skin
        }

        /// <summary>
        /// Add an item to the bag
        /// </summary>
        /// <param name="obj">Item to add</param>
        public void AddToBag(Object obj)
        {
            bag.Add(obj);
        }

        /// <summary>
        /// Return the current bag
        /// </summary>
        /// <returns>Bag</returns>
        public List<Object> ShowBag()
        {
            return bag;
        }

        /// <summary>
        /// Put the used variable of an object to true
        /// </summary>
        /// <param name="obj"></param>
        public void UsedObject(Object obj)
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
        public Object RemoveFromBag(string Name)
        {
            foreach(Object obj in bag)
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
        public void Unlock(Power pow)
        {
            powers.Add(pow);
        }

        /// <summary>
        /// Return the current powers
        /// </summary>
        /// <returns>Powers</returns>
        public List<Power> ShowPowers()
        {
            return powers;
        }

        /// <summary>
        /// Put the actualWaitTime of the power used to 0
        /// </summary>
        /// <param name="pow">Power used</param>
        public void UsedPower(Power pow)
        {
            pow.actualWaitTime = 0;
        }

        /// <summary>
        /// Increment the actualWaitTime of currently blocked powers
        /// </summary>
        public void NewWeek()
        {
            foreach(Power pow in powers)
            {
                if(pow.actualWaitTime != pow.waitTime)
                {
                    ++pow.actualWaitTime;
                }
            }
        }
    }
}
