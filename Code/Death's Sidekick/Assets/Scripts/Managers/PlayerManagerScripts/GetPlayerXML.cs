using Assets.Scripts.Player.XMLPlayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

namespace Assets.Scripts.Managers.PlayerManagerScripts
{
    class GetPlayerXML
    {
        //Constructor of the class
        public GetPlayerXML()
        {
            //GetItems();
            //GetPowers();
            //GetSummons();
        }

        /// <summary>
        /// Method which get the informations from Items.XML and put them in playerManager.lstBuyable
        /// </summary>
        private void GetItems()
        {
            //Objects
            List<Item> lstItem = new List<Item>();

            //Open XML
            var xmldoc = new XmlDocument();
            xmldoc.Load("../../../XML/Player/Items.XML");

            //Get informations
            XmlNodeList items = xmldoc.GetElementsByTagName("Item");
            foreach (XmlNode item in items)
            {
                lstItem.Add(new Item(Normalize(item.SelectSingleNode("Name").InnerText), Convert.ToInt32(item.SelectSingleNode("Week").InnerText), Convert.ToDouble(item.SelectSingleNode("Price").InnerText), false, 3));
            }

            //Return lstBuyable
            foreach (Item item in lstItem)
            {
                Globals.playerManager.lstItems.Add(item);
            }
            lstItem.Clear();
        }

        /// <summary>
        /// Method which get the informations from Powers.XML and put them in playerManager.lstPowers
        /// </summary>
        private void GetPowers()
        {
            //Objects
            List<Power> lstPowers = new List<Power>();

            //Open XML
            var xmldoc = new XmlDocument();
            xmldoc.Load("../../../XML/Player/Powers.XML");

            //Get informations
            XmlNodeList powers = xmldoc.GetElementsByTagName("Power");
            foreach (XmlNode power in powers)
            {
                lstPowers.Add(new Power(Normalize(power.SelectSingleNode("Name").InnerText), Convert.ToInt32(power.SelectSingleNode("Week").InnerText), Convert.ToInt32(power.SelectSingleNode("WaitTime").InnerText), 0));
            }

            //Return lstPowers
            foreach (Power power in lstPowers)
            {
                Globals.playerManager.lstPowersLocked.Add(power);
            }
            lstPowers.Clear();
        }

        /// <summary>
        /// Method which get the informations from Summons.XML and put them in playerManager.lstSummons
        /// </summary>
        private void GetSummons()
        {
            //Objects
            List<Summon> lstSummons = new List<Summon>();

            //Open XML
            var xmldoc = new XmlDocument();
            xmldoc.Load("../../../XML/Player/Summons.XML");

            //Get informations
            XmlNodeList summons = xmldoc.GetElementsByTagName("Summon");
            foreach (XmlNode summon in summons)
            {
                lstSummons.Add(new Summon(Normalize(summon.SelectSingleNode("Name").InnerText), Normalize(summon.SelectSingleNode("Function").InnerText),
                    Normalize(summon.SelectSingleNode("Effect").InnerText), 0));
            }

            //Return lstPowers
            foreach (Summon summon in lstSummons)
            {
                Globals.playerManager.lstSummons.Add(summon);
            }
            lstSummons.Clear();
        }

        /// <summary>
        /// Method which normalize string
        /// </summary>
        /// <param name="strBase">String to normalize</param>
        /// <returns>Normalized string</returns>
        private string Normalize(string strBase)
        {
            //Variables
            string strChecked = "";
            char chaCheck;
            bool bolFirst = true;

            //Delete special chars and spaces
            strBase = Regex.Replace(strBase, @"\n", "");
            strBase = Regex.Replace(strBase, @"\r", "");
            strBase = Regex.Replace(strBase, @"\t", "");
            strBase = Regex.Replace(strBase, " ", "");

            //Check maj
            for (int i = 0; i < strBase.Length; ++i)
            {
                chaCheck = Convert.ToChar(strBase.Substring(0, 1));
                if (Char.IsUpper(chaCheck))
                {
                    if (bolFirst)
                    {
                        bolFirst = false;
                    }
                    else
                    {
                        strChecked += " ";
                    }
                }
                strChecked += chaCheck;
            }

            return strChecked;
        }
    }
}
