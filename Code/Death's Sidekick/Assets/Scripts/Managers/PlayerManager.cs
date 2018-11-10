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
        public List<Player.XMLPlayer.Item> lstBuyable = new List<Player.XMLPlayer.Item>();
        public List<Player.XMLPlayer.Power> lstPowersLocked = new List<Player.XMLPlayer.Power>();
        public List<Player.XMLPlayer.Summon> lstSummons = new List<Player.XMLPlayer.Summon>();

        //Constructor
        public PlayerManager()
        {
            PlayerManagerScripts.GetPlayerXML getPlayerXML = new PlayerManagerScripts.GetPlayerXML();
        }

        /// <summary>
        /// Method which add each XML Object where it belongs in a saved game
        /// </summary>
        public void ContinueSave()
        {
            PlayerManagerScripts.ContinueSavePlayer continueSavePlayer = new PlayerManagerScripts.ContinueSavePlayer(player);
        }

        /// <summary>
        /// Show the buyable objects
        /// </summary>
        public void ShowBuyable()
        {
            //TODO Show the market
        }

        /// <summary>
        /// Show the current bag of the Player
        /// </summary>
        public void ShowBag()
        {
            //TODO Show the bag of the Player
        }

        /// <summary>
        /// Add an item to the Player's bag
        /// </summary>
        /// <param name="Name">Name of the item</param>
        public void AddToPlayerBag(string Name)
        {
            foreach(Player.XMLPlayer.Item obj in lstBuyable)
            {
                if(obj.name == Name)
                {
                    player.AddToBag(obj);
                    lstBuyable.Remove(obj);
                    obj.inBag = true;
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
        /// Unlock a power for the Player
        /// </summary>
        /// <param name="Name">Name of the power</param>
        public void UnlockPower(string Name)
        {
            foreach(Player.XMLPlayer.Power pow in lstPowersLocked)
            {
                if(pow.name == Name)
                {
                    player.Unlock(pow);
                    pow.unlocked = true;
                    pow.actualWaitTime = pow.waitTime;
                }
            }
        }

        /// <summary>
        /// Show the current powers of the Player
        /// </summary>
        public void ShowPowers()
        {
            //TODO Show the powers of the Player
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
            Player.XMLPlayer.Summon summon = lstSummons[Random.Range(0, lstSummons.Count - 1)];
            ++summon.nbrInvoked;
            summon.Invoke();
        }

        /// <summary>
        /// Increment stat of the player
        /// </summary>
        /// <param name="name">Stat to train</param>
        public void IncrementStat(string name)
        {
            player.IncrementStat(name);
        }

        /// <summary>
        /// Add a new week
        /// </summary>
        public void NewWeek()
        {
            player.NewWeek();
        }
    }
}
