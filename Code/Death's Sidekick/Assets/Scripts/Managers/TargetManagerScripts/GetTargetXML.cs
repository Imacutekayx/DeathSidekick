using Assets.Scripts.Target.XMLTarget;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Xml;
using UnityEngine;

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
            //TODO Fix path XML and reactive random Target
            //GetJobs();
            //GetFornames();
            //GetLastnames();
            //GetOrigins();
        }

        /// <summary>
        /// Method which get the informations from Jobs.XML and put them in targetManager.jobs
        /// </summary>
        private void GetJobs()
        {
            //Objects
            List<Job> lstJobs = new List<Job>();

            //Open XML
            var xmldoc = new XmlDocument();
            xmldoc.Load("C:/Users/briandgr/Desktop/ProjectSidekick/Code/Death's Sidekick/Assets/XML/Target/Jobs.XML");

            //Get informations
            XmlNodeList jobs = xmldoc.GetElementsByTagName("Job");
            foreach (XmlNode job in jobs)
            {
                lstJobs.Add(new Job(Normalize(job.SelectSingleNode("Name").InnerText), Normalize(job.SelectSingleNode("Place").InnerText), 
                    Normalize(job.SelectSingleNode("HourBeginning").InnerText), Normalize(job.SelectSingleNode("HourFinishing").InnerText)));
            }

            //Return lastnames
            foreach (Job job in lstJobs)
            {
                Globals.targetManager.jobs.Add(job);
            }
            lstJobs.Clear();
        }

        /// <summary>
        /// Method which get the informations from Lastnames.XML and put them in targetManager.fornames
        /// </summary>
        private void GetFornames()
        {
            //Objects
            List<Forname> lstFornames = new List<Forname>();
            Forname tempForname;

            //Open XML
            var xmldoc = new XmlDocument();
            xmldoc.Load("C:/Users/briandgr/Desktop/ProjectSidekick/Code/Death's Sidekick/Assets/XML/Target/Fornames.XML");

            //Get informations
            XmlNodeList fornames = xmldoc.GetElementsByTagName("Forname");
            foreach (XmlNode forname in fornames)
            {
                tempForname = new Forname(true, Normalize(forname.SelectSingleNode("Name").InnerText), Normalize(forname.SelectSingleNode("Origin").InnerText));
                if (Normalize(forname.SelectSingleNode("Sex").InnerText) == "Female")
                {
                    tempForname.sex = false;
                }
                lstFornames.Add(tempForname);
            }
            //Return fornames
            foreach (Forname forname in lstFornames)
            {
                Globals.targetManager.fornames.Add(forname);
            }
            lstFornames.Clear();
        }

        /// <summary>
        /// Method which get the informations from Lastnames.XML and put them in targetManager.lastnames
        /// </summary>
        private void GetLastnames()
        {
            //Objects
            List<Lastname> lstLastnames = new List<Lastname>();

            //Open XML
            var xmldoc = new XmlDocument();
            xmldoc.Load("C:/Users/briandgr/Desktop/ProjectSidekick/Code/Death's Sidekick/Assets/XML/Target/Lastnames.XML");

            //Get informations
            XmlNodeList lastnames = xmldoc.GetElementsByTagName("Lastname");
            foreach (XmlNode lastname in lastnames)
            {
                lstLastnames.Add(new Lastname(Normalize(lastname.SelectSingleNode("Name").InnerText), Normalize(lastname.SelectSingleNode("Origin").InnerText)));
            }

            //Return lastnames
            foreach (Lastname lastname in lstLastnames)
            {
                Globals.targetManager.lastnames.Add(lastname);
            }
            lstLastnames.Clear();
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
                        lstCountry.Add(new Country(Normalize(country.SelectSingleNode("CName").InnerText), Convert.ToInt32(country.SelectSingleNode("CNbr").InnerText)));
                    }
                    lstArea.Add(new Area(Normalize(area.SelectSingleNode("AName").InnerText), Convert.ToInt32(area.SelectSingleNode("ANbr").InnerText), lstCountry));
                    lstCountry.Clear();
                }
                lstOrigin.Add(new Origin(Normalize(origin.SelectSingleNode("Name").InnerText), Convert.ToInt32(origin.SelectSingleNode("Nbr").InnerText), lstArea));
                lstArea.Clear();
            }

            //Return origins
            foreach(Origin origin in lstOrigin)
            {
                Globals.targetManager.origins.Add(origin);
            }
            lstOrigin.Clear();
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
            for(int i = 0; i < strBase.Length; ++i)
            {
                chaCheck = Convert.ToChar(strBase.Substring(0, 1));
                if (Char.IsUpper(chaCheck)){
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
