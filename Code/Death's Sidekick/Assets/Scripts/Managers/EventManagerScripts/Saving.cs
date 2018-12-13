using System;
using System.Xml;
using System.Xml.Linq;

namespace Assets.Scripts.Managers.EventManagerScripts
{
    /// <summary>
    /// Class which manage all related to saving
    /// </summary>
    class Saving
    {
        /// <summary>
        /// Save the current stat to an XML
        /// </summary>
        public void Save()
        {
            //TODO Save informations in binary files
            //Creation of Doc
            new XDocument(
                new XElement("Save",
                //GLOBALS
                new XElement("Week", Globals.week.ToString("D")),
                new XElement("SummonCrystal", Globals.summonCrystal.ToString()),
                //TODO Player
                //PlayerXML
                new XElement("Items", SaveItems()),
                new XElement("Powers", SavePowers()),
                new XElement("Summons", SaveSummons())
                )
            )
            .Save("../../../XML/Save/Save.xml");
        }

        /// <summary>
        /// Load the current save of the game
        /// </summary>
        public void Load()
        {
            //Open XML
            var xmldoc = new XmlDocument();
            xmldoc.Load("../../../XML/Save/Save.XML");

            //Get informations
            XmlNodeList saves = xmldoc.GetElementsByTagName("Save");
            XmlNode save = saves[0];

            //GLOBALS
            Globals.week = Convert.ToInt32(save.SelectSingleNode("Week").InnerText);
            if(save.SelectSingleNode("SummonCrystal").InnerText == "True")
            {
                Globals.summonCrystal = true;
            }

            //PlayerXML
            LoadItems(save.SelectSingleNode("Items").InnerText);
            LoadPowers(save.SelectSingleNode("Powers").InnerText);
            LoadSummons(save.SelectSingleNode("Summons").InnerText);
        }

        /// <summary>
        /// Method which save the current objects in the bag
        /// </summary>
        /// <returns>String of all the inbag items with their attributes</returns>
        private string SaveItems()
        {
            //Variables
            bool bolFirst = false;
            string strSave = "";

            foreach(Player.XMLPlayer.Item item in Globals.playerManager.ShowBag())
            {
                if (!bolFirst)
                {
                    strSave += ";";
                }
                else
                {
                    bolFirst = false;
                }
                strSave += item.name + "," + item.used.ToString();
            }
            return strSave;
        }

        /// <summary>
        /// Method which save the current powers unlocked
        /// </summary>
        /// <returns>String of all the unlocked powers with their attributes</returns>
        private string SavePowers()
        {
            //Variables
            bool bolFirst = false;
            string strSave = "";

            foreach (Player.XMLPlayer.Power power in Globals.playerManager.ShowPowers())
            {
                if (!bolFirst)
                {
                    strSave += ";";
                }
                else
                {
                    bolFirst = false;
                }
                strSave += power.name + "," + power.actualWaitTime.ToString("D");
            }
            return strSave;
        }

        /// <summary>
        /// Method which save the current summons unlocked
        /// </summary>
        /// <returns>String of all the unlocked summons with their attributes</returns>
        private string SaveSummons()
        {
            //Variables
            bool bolFirst = false;
            string strSave = "";

            foreach (Player.XMLPlayer.Summon summon in Globals.playerManager.lstSummons)
            {
                if(summon.nbrInvoked != 0)
                {
                    if (!bolFirst)
                    {
                        strSave += ";";
                    }
                    else
                    {
                        bolFirst = false;
                    }
                    strSave += summon.name + "," + summon.nbrInvoked.ToString("D");
                }
            }
            return strSave;
        }

        /// <summary>
        /// Method which add the items in the XML to the playerBag and tell if they are used
        /// </summary>
        /// <param name="items">String which contains the items' informations</param>
        private void LoadItems(string items)
        {
            //Variables
            string[] arrayItem;
            string[] arrayItems = items.Split(';');

            foreach(string item in arrayItems)
            {
                arrayItem = item.Split(',');
                foreach(Player.XMLPlayer.Item buyable in Globals.playerManager.lstBuyable)
                {
                    if(buyable.name == arrayItem[0])
                    {
                        Globals.playerManager.AddToPlayerBag(buyable.name);
                        if(arrayItem[1] == "True")
                        {
                            buyable.used = true;
                        }
                        continue;
                    }
                }
            }
        }

        /// <summary>
        /// Method which add the powers in the XML to the playerPowers and tell if they are usable
        /// </summary>
        /// <param name="powers">String which contains the powers' informations</param>
        private void LoadPowers(string powers)
        {
            //Variables
            string[] arrayPower;
            string[] arrayPowers = powers.Split(';');

            foreach (string power in arrayPowers)
            {
                arrayPower = power.Split(',');
                foreach (Player.XMLPlayer.Power lockedPower in Globals.playerManager.lstPowersLocked)
                {
                    if (lockedPower.name == arrayPower[0])
                    {
                        Globals.playerManager.UnlockPower(lockedPower.name);
                        if (Convert.ToInt32(arrayPower[1]) == lockedPower.waitTime)
                        {
                            lockedPower.actualWaitTime = Convert.ToInt32(arrayPower[1]);
                        }
                        continue;
                    }
                }
            }
        }

        /// <summary>
        /// Method which analyse the summons in the XML and tell if they has already been used
        /// </summary>
        /// <param name="summons">String which contains the summons' informations</param>
        private void LoadSummons(string summons)
        {
            //Variables
            string[] arraySummon;
            string[] arraySummons = summons.Split(';');

            foreach (string summon in arraySummons)
            {
                arraySummon = summon.Split(',');
                foreach (Player.XMLPlayer.Summon invokable in Globals.playerManager.lstSummons)
                {
                    if (invokable.name == arraySummon[0])
                    {
                        invokable.nbrInvoked = Convert.ToInt32(arraySummon[1]);
                        continue;
                    }
                }
            }
        }
    }
}
