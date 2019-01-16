using UnityEngine;

namespace Assets.Scripts.Target.TargetRandom
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
            //TODO -16
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
            //Basic calculate
            if (target.sex)
            {
                if(target.age > 40)
                {
                    target.speed = Random.Range(30, 61);
                }
                else if(target.age > 28)
                {
                    target.speed = Random.Range(40, 76);
                }
                else if(target.age > 18)
                {
                    target.speed = Random.Range(45, 91);
                }
                else if(target.age > 15)
                {
                    target.speed = Random.Range(40, 81);
                }
            }
            else
            {
                if (target.age > 40)
                {
                    target.speed = Random.Range(25, 61);
                }
                else if (target.age > 28)
                {
                    target.speed = Random.Range(35, 61);
                }
                else if (target.age > 18)
                {
                    target.speed = Random.Range(45, 81);
                }
                else if (target.age > 15)
                {
                    target.speed = Random.Range(40, 76);
                }
            }

            //Random by training
            target.speed = RandomAll(target.speed);
        }

        /// <summary>
        /// Choose the strength randomly
        /// </summary>
        private void RandomStrength()
        {
            //Basic
            if (target.sex)
            {
                if(target.weight < 66)
                {
                    target.strength = Random.Range(15, 30);
                }
                else if (target.weight < 86)
                {
                    target.strength = Random.Range(30, 45);
                }
                else if (target.weight < 106)
                {
                    target.strength = Random.Range(45, 60);
                }
                else if (target.weight < 126)
                {
                    target.strength = Random.Range(60, 75);
                }
                else
                {
                    target.strength = Random.Range(75, 90);
                }
            }
            else
            {
                if (target.weight < 56)
                {
                    target.strength = Random.Range(10, 25);
                }
                else if (target.weight < 76)
                {
                    target.strength = Random.Range(25, 40);
                }
                else if (target.weight < 96)
                {
                    target.strength = Random.Range(40, 55);
                }
                else if (target.weight < 116)
                {
                    target.strength = Random.Range(55, 70);
                }
                else
                {
                    target.strength = Random.Range(70, 85);
                }
            }

            //Random by training
            target.strength = RandomAll(target.strength);
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

        /// <summary>
        /// Method which add a random level of training to the target
        /// </summary>
        /// <param name="basic"></param>
        /// <returns></returns>
        private int RandomAll(int basic)
        {
            //Random
            tempRnd = Random.Range(0, 114);
            if (tempRnd < 2)
            {
                basic -= 35;
            }
            else if (tempRnd < 10)
            {
                basic -= 30;
            }
            else if (tempRnd < 14)
            {
                basic -= 25;
            }
            else if (tempRnd < 22)
            {
                basic -= 20;
            }
            else if (tempRnd < 28)
            {
                basic -= 15;
            }
            else if (tempRnd < 38)
            {
                basic -= 10;
            }
            else if (tempRnd < 52)
            {
                basic -= 5;
            }
            else if (tempRnd < 88) { }
            else if (tempRnd < 95)
            {
                basic += 5;
            }
            else if (tempRnd < 100)
            {
                basic += 10;
            }
            else if (tempRnd < 103)
            {
                basic += 15;
            }
            else if (tempRnd < 107)
            {
                basic += 20;
            }
            else if (tempRnd < 109)
            {
                basic += 25;
            }
            else if (tempRnd < 113)
            {
                basic += 30;
            }
            else
            {
                basic += 35;
            }
            
            //Difficulty
            basic += Globals.week;

            //Fix of bad Randoms
            if (basic > 100)
            {
                basic = 100;
            }
            else if (basic < 1)
            {
                basic = 1;
            }

            return basic;
        }
    }
}
