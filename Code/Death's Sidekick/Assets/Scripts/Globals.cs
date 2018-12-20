﻿using UnityEngine;

namespace Assets.Scripts
{
    /// <summary>
    /// Class which contains the globals objects and variables
    /// </summary>
    public static class Globals
    {
        //TODO Create Globals at the beginning of the Game
        //Variables
        public static int week = 1;
        public static bool soulCrystal = false;
        public static bool summonCrystal = false;
        public static int resolution = 1290;

        //Objects
        public static Managers.EventManager eventManager = new Managers.EventManager();
        public static Managers.TargetManager targetManager = new Managers.TargetManager();
        public static Managers.ScreenManager screenManager = new Managers.ScreenManager();
        public static Managers.PlayerManager playerManager = new Managers.PlayerManager();
    }
}
