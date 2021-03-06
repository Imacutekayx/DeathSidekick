﻿using Assets.Scripts.Target.TargetRandom;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Target
{
    /// <summary>
    /// Class object Target which is a possible choice for the Player to kill and which has differents characteristics and Links with Others
    /// </summary>
    public class Target
    {
        //Objects
        private List<Link> links = new List<Link>();

        //Variables
        public bool inCouple = false;

        //Basic characteristics
        public XMLTarget.Forname forname;
        public XMLTarget.Lastname lastname;
        public int age;
        public bool sex;   //0 == Male / 1 == Female
        public int height;
        public int weight;
        public XMLTarget.Job job;
        public string origin;
        public string area;
        public string country;

        //Skin
        public Sprite skin;

        //Special characteristics
        public int speed;
        public int strength;
        public int stamina;
        public int reflex;
        public int intellect;
        public int anxiety;

        //TODO Add List status to target &| player

        //Constructor
        public Target(string type = "base")
        {
            //TODO Add types

            //Create Basic characteristics
            BasicCharact basic = new BasicCharact(this);

            //Create Special characteristics
            SpaceCharact space = new SpaceCharact(this);

            //Create Links
            LinksTarget link = new LinksTarget(this);

            //TODO Create Skin
        }

        /// <summary>
        /// Get the list of links of this target
        /// </summary>
        /// <returns>List of the links</returns>
        public List<Link> GetLinks()
        {
            return this.links;
        }

        /// <summary>
        /// Add a link to the list of the target
        /// </summary>
        /// <param name="link">The link we want to add</param>
        public void AddLink(Link link)
        {
            links.Add(link);
        }
    }
}