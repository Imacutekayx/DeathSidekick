using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Player
{
    /// <summary>
    /// Class which has the Player's informations
    /// </summary>
    class Player
    {
        //Variables
        public int strength = 25;
        public int speed = 25;
        public int stamina = 25;
        private double money;

        //Skin
        public Sprite skin;

        //Objects
        private List<XMLPlayer.Item> bag = new List<XMLPlayer.Item>();
        private List<XMLPlayer.Power> powers = new List<XMLPlayer.Power>();

        /// <summary>
        /// Add an item to the bag
        /// </summary>
        /// <param name="obj">Item to add</param>
        public void AddToBag(XMLPlayer.Item obj)
        {
            bag.Add(obj);
        }

        /// <summary>
        /// Return the current bag
        /// </summary>
        /// <returns>Bag</returns>
        public List<XMLPlayer.Item> ShowBag()
        {
            return bag;
        }

        /// <summary>
        /// Put the used variable of an object to true
        /// </summary>
        /// <param name="obj"></param>
        public void UsedObject(XMLPlayer.Item obj)
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
        public XMLPlayer.Item RemoveFromBag(string Name)
        {
            foreach(XMLPlayer.Item obj in bag)
            {
                if(obj.name == Name)
                {
                    obj.used = false;
                    bag.Remove(obj);
                    obj.inBag = false;
                    obj.used = false;
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
                //TODO Up stat
                case "strength":
                    break;

                case "speed":
                    break;

                case "stamina":
                    break;
            }

            CheckStats();
        }

        /// <summary>
        /// Method which add a certain amout of level to all the stats
        /// </summary>
        /// <param name="value">Value to add</param>
        public void IncrementAll(int value)
        {
            strength += value;
            speed += value;
            stamina += value;

            CheckStats();
        }

        /// <summary>
        /// Method which check all stats to verify the limits
        /// </summary>
        private void CheckStats()
        {
            if(strength < 1)
            {
                strength = 1;
            }
            else if(strength > 100)
            {
                strength = 100;
            }

            if (speed < 1)
            {
                speed = 1;
            }
            else if (speed > 100)
            {
                speed = 100;
            }

            if (stamina < 1)
            {
                stamina = 1;
            }
            else if (stamina > 100)
            {
                stamina = 100;
            }
        }

        /// <summary>
        /// Increment the actualWaitTime of currently blocked powers
        /// </summary>
        public void NewSoul()
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
