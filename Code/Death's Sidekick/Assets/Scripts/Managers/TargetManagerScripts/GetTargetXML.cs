using Assets.Scripts.Target.XMLTarget;
using System;
using System.Collections.Generic;
using System.Xml;

namespace Assets.Scripts.Managers.TargetManagerScripts
{
    /// <summary>
    /// Class which get the informations of all the XML related to the targets and give them to the targetManager
    /// </summary>
    class GetTargetXML
    {
        //Constructor of the class
        public GetTargetXML()
        {
            //TODO Add Jobs from XML to jobs
            //TODO Add Fornames from XML to fornames
            //TODO Add Lastnames from XML to lastnames
            GetOrigins();
        }

        /// <summary>
        /// Method which get the informations from Origins.XML and put them in targetManager.origins
        /// </summary>
        private void GetOrigins()
        {
            //Objects
            List<Origin> lstOrigin = new List<Origin>();
            List<Area> lstArea = new List<Area>();
            List<Country> lstCountry = new List<Country>();

            //Open XML
            var xmldoc = new XmlDocument();
            xmldoc.Load("C:/Users/briandgr/Desktop/ProjectSidekick/Code/Death's Sidekick/Assets/XML/Target/Origins.XML");

            //Get informations
            XmlNodeList origins = xmldoc.GetElementsByTagName("Origin");
            foreach (XmlNode origin in origins)
            {
                foreach (XmlNode area in origin.SelectNodes("Area"))
                {
                    foreach (XmlNode country in area.SelectNodes("Country"))
                    {
                        lstCountry.Add(new Country(country.SelectSingleNode("CName").InnerText, Convert.ToInt32(country.SelectSingleNode("CNbr").InnerText)));
                    }
                    lstArea.Add(new Area(area.SelectSingleNode("AName").InnerText, Convert.ToInt32(area.SelectSingleNode("ANbr").InnerText), lstCountry));
                    lstCountry.Clear();
                }
                lstOrigin.Add(new Origin(origin.SelectSingleNode("Name").InnerText, Convert.ToInt32(origin.SelectSingleNode("Nbr").InnerText), lstArea));
                lstArea.Clear();
            }

            //Return origins
            foreach(Origin origin in lstOrigin)
            {
                Globals.targetManager.origins.Add(origin);
            }
            lstOrigin.Clear();
        }
    }
}
