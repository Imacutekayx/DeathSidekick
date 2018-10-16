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
            RandomSpeed();
            RandomStrength();
            RandomStamina();
            RandomReflex();
            RandomIQ();
        }

        /// <summary>
        /// Choose the speed randomly
        /// </summary>
        private void RandomSpeed()
        {
            //TODO Calculate Speed
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

        /// <summary>
        /// Choose the strength randomly
        /// </summary>
        private void RandomStrength()
        {
            //TODO Calculate Strength
        }

        /// <summary>
        /// Choose the stamina randomly
        /// </summary>
        private void RandomStamina()
        {
            //TODO Calculate Stamina
        }

        /// <summary>
        /// Choose the reflex randomly
        /// </summary>
        private void RandomReflex()
        {
            //TODO Calculate Reflex
        }

        /// <summary>
        /// Choose the IQ randomly
        /// </summary>
        private void RandomIQ()
        {
            //TODO Calculate IQ
        }
    }
}
