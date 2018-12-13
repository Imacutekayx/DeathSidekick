namespace Assets.Scripts.Managers
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
        public static EventManager eventManager = new EventManager();
        public static TargetManager targetManager = new TargetManager();
        public static ScreenManager screenManager = new ScreenManager();
        public static PlayerManager playerManager = new PlayerManager();
    }
}
