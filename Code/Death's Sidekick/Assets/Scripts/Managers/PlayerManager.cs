using System.Collections.Generic;

namespace Assets.Scripts.Managers
{
    /// <summary>
    /// Class which will manage all actions or variables related to the Player
    /// </summary>
    public class PlayerManager
    {
        //Objects
        private Player.Player player = new Player.Player();
        private List<Player.Object> lstBuyable = new List<Player.Object>();
        private List<Player.Power> lstPowersLocked = new List<Player.Power>();

        //Constructor
        public PlayerManager()
        {
            //TODO Add each object not bought from XML to lstBuyable && Add each object bought from XML to Player.bag
            //TODO Add each power locked from XML to lstPowersLocked && Add each power unlocked from XML to Player.powers
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
            foreach(Player.Object obj in lstBuyable)
            {
                if(obj.name == Name)
                {
                    player.AddToBag(obj);
                    lstBuyable.Remove(obj);
                }
            }
        }

        /// <summary>
        /// Use an object of the bag
        /// </summary>
        /// <param name="Name">Name of the object</param>
        public void UseObject(string Name)
        {
            List<Player.Object> currentBag = player.ShowBag();
            foreach(Player.Object obj in currentBag)
            {
                if(obj.name == Name)
                {
                    //TODO Use an object and add the Effect to the Player
                    player.UsedObject(obj);
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
            foreach(Player.Power pow in lstPowersLocked)
            {
                if(pow.name == Name)
                {
                    player.Unlock(pow);
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
            List<Player.Power> currentPowers = player.ShowPowers();
            foreach(Player.Power pow in currentPowers)
            {
                if(pow.name == Name)
                {
                    //TODO Use a power and add the Effect to the Player
                    player.UsedPower(pow);
                }
            }
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
