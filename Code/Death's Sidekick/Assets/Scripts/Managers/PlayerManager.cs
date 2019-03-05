using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    /// <summary>
    /// Class which will manage all actions or variables related to the Player
    /// </summary>
    public class PlayerManager
    {
        //Objects
        private Player.Player player = new Player.Player();
        public List<Player.XMLPlayer.Item> lstBuyable = new List<Player.XMLPlayer.Item> { new Player.XMLPlayer.Item("Knife", 1, 50, false, 3), new Player.XMLPlayer.Item("Gun", 1, 250, false, 3),
            new Player.XMLPlayer.Item("Sword", 1, 150, false, 3), new Player.XMLPlayer.Item("AK47", 1, 10, false, 3),new Player.XMLPlayer.Item("Kamehameha", 1, 5000, false, 3),
            new Player.XMLPlayer.Item("Jsp", 1, 9999.95, false, 3), new Player.XMLPlayer.Item("Item", 1, 0, false, 3), new Player.XMLPlayer.Item("Imet", 1, 15, false, 3)};
        public List<Player.XMLPlayer.Item> lstItems = new List<Player.XMLPlayer.Item>();
        public List<Player.XMLPlayer.Item> lstWait = new List<Player.XMLPlayer.Item>();
        public List<Player.XMLPlayer.Power> lstPowersLocked = new List<Player.XMLPlayer.Power>();
        public List<Player.XMLPlayer.Summon> lstSummons = new List<Player.XMLPlayer.Summon>();

        //Constructor
        public PlayerManager()
        {
            PlayerManagerScripts.GetPlayerXML getPlayerXML = new PlayerManagerScripts.GetPlayerXML();
        }

        /// <summary>
        /// Show the buyable objects
        /// </summary>
        public List<Player.XMLPlayer.Item> ShowBuyable()
        {
            return lstBuyable;
        }

        /// <summary>
        /// Show the current bag of the Player
        /// </summary>
        public List<Player.XMLPlayer.Item> ShowBag()
        {
            return player.ShowBag();
        }

        /// <summary>
        /// Add an item to the Player's bag
        /// </summary>
        /// <param name="Name">Name of the item</param>
        public void AddToPlayerBag(string Name)
        {
            foreach(Player.XMLPlayer.Item obj in lstWait)
            {
                if(obj.name == Name)
                {
                    player.AddToBag(obj);
                    lstWait.Remove(obj);
                    return;
                }
            }
        }

        /// <summary>
        /// Use an object of the bag
        /// </summary>
        /// <param name="Name">Name of the object</param>
        public void UseObject(string Name)
        {
            List<Player.XMLPlayer.Item> currentBag = player.ShowBag();
            foreach(Player.XMLPlayer.Item obj in currentBag)
            {
                if(obj.name == Name)
                {
                    //TODO Use an object and add the Effect to the Player
                    player.UsedObject(obj);
                    obj.used = true;
                }
            }
        }

        /// <summary>
        /// Remove an item from the Player's bag
        /// </summary>
        /// <param name="Name">Name of the item</param>
        public void RemoveFromPlayerBag(string Name)
        {
            lstBuyable.Add(player.RemoveFromBag(Name));
        }

        /// <summary>
        /// Method which make all the changes between two days for the player
        /// </summary>
        public void DayPassed()
        {
            List<Player.XMLPlayer.Item> tempList = new List<Player.XMLPlayer.Item>(lstWait);
            foreach(Player.XMLPlayer.Item item in tempList)
            {
                --item.days;
                if (item.days == 0)
                {
                    AddToPlayerBag(item.name);
                }
            }
        }

        /// <summary>
        /// Check change for the new week
        /// </summary>
        public void NewWeek()
        {
            UnlockPower();
            UnlockItem();
        }

        /// <summary>
        /// Unlock a power for the Player
        /// </summary>
        private void UnlockPower()
        {
            foreach(Player.XMLPlayer.Power pow in lstPowersLocked)
            {
                if(pow.week <= Globals.week)
                {
                    player.Unlock(pow);
                    lstPowersLocked.Remove(pow);
                    pow.actualWaitTime = pow.waitTime;
                }
            }
        }

        /// <summary>
        /// Put an item in the market
        /// </summary>
        private void UnlockItem()
        {
            foreach (Player.XMLPlayer.Item item in lstItems)
            {
                if (item.week <= Globals.week)
                {
                    lstBuyable.Add(item);
                    lstItems.Remove(item);
                }
            }
        }

        /// <summary>
        /// Show the current powers of the Player
        /// </summary>
        public List<Player.XMLPlayer.Power> ShowPowers()
        {
            return player.ShowPowers();
        }

        /// <summary>
        /// Use a power
        /// </summary>
        /// <param name="Name"></param>
        public void UsePower(string Name)
        {
            List<Player.XMLPlayer.Power> currentPowers = player.ShowPowers();
            foreach(Player.XMLPlayer.Power pow in currentPowers)
            {
                if(pow.name == Name)
                {
                    //TODO Use a power and add the Effect to the Player
                    player.UsedPower(pow);
                }
            }
        }

        /// <summary>
        /// Invoke a Summon
        /// </summary>
        public void Summon()
        {
            Player.XMLPlayer.Summon summon = lstSummons[Random.Range(0, lstSummons.Count)];
            ++summon.nbrInvoked;
            summon.Invoke();
        }

        /// <summary>
        /// Increment stat of the player
        /// </summary>
        /// <param name="name">Stat to train</param>
        public void IncrementStat(int value, string name = "")
        {
            if(name == "")
            {
                player.IncrementAll(value);
            }
            else
            {
                player.IncrementStat(name, value);
            }
        }

        /// <summary>
        /// Method which add the double in parameter to the current money of the player
        /// </summary>
        /// <param name="moneyToAdd">Money to add</param>
        /// <returns>Current money</returns>
        public double Money(double moneyToAdd = 0)
        {
            return player.money += moneyToAdd;
        }

        /// <summary>
        /// Method which add a status to the player and change stats
        /// </summary>
        /// <param name="name">Name of the status</param>
        /// <param name="value">Enter or exit the status</param>
        public void Status(string name, bool value)
        {
            switch (name)
            {
                case "Tired":
                    player.IncrementAll(value ? -10 : 10);
                    break;
            }
        }

        /// <summary>
        /// Add a new week
        /// </summary>
        public void NewSoul()
        {
            player.NewSoul();
        }
    }
}
