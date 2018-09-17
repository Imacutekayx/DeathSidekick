namespace Assets.Scripts.TargetScreen.TargetRandom
{
    /// <summary>
    /// Class creating the target's special characteristics
    /// </summary>
    class SpaceCharact
    {
        //Objects
        Target target;

        //Variables
        int tempRnd;

        /// <summary>
        /// Basic constructor of the class which will launch the other random methods
        /// </summary>
        /// <param name="linkedTarget">The target we want to create</param>
        public SpaceCharact(Target linkedTarget)
        {
            target = linkedTarget;
        }

        private void RandomSpeed()
        {
            //Fix of bad Randoms
            if(target.speed > 100)
            {
                target.speed = 100;
            }
            else if(target.speed < 0)
            {
                target.speed = 0;
            }
        }

        private void RandomStrength()
        {

        }
    }
}
