using System;
using UnityEngine;
using Random = UnityEngine.Random;

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
            target = linkedTarget;
            RandomSpeed();
            RandomStrength();
            RandomStamina();
            RandomReflex();
            RandomIntellect();
        }

        /// <summary>
        /// Choose the speed randomly
        /// </summary>
        private void RandomSpeed()
        {
            //Basic calculate
            if(target.age > 15)
            {
                if (target.sex)
                {
                    if (target.age > 40)
                    {
                        target.speed = Random.Range(30, 61);
                    }
                    else if (target.age > 28)
                    {
                        target.speed = Random.Range(40, 76);
                    }
                    else if (target.age > 18)
                    {
                        target.speed = Random.Range(45, 91);
                    }
                    else
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
                    else
                    {
                        target.speed = Random.Range(40, 76);
                    }
                }

                //Random by training
                target.speed = RandomAll(target.speed);
            }
            else
            {
                //Basic
                target.speed = Random.Range(40, 76);
                target.speed = Convert.ToInt32(Convert.ToDouble(target.speed) / 10 * (10 -(Math.Abs(15 - target.age))));

                //Random
                target.speed = RandomChild(target.speed);
            }
        }

        /// <summary>
        /// Choose the strength randomly
        /// </summary>
        private void RandomStrength()
        {
            //Basic
            if(target.age > 15)
            {
                if (target.sex)
                {
                    if (target.weight < 66)
                    {
                        target.strength = Random.Range(20, 36);
                    }
                    else if (target.weight < 86)
                    {
                        target.strength = Random.Range(35, 51);
                    }
                    else if (target.weight < 106)
                    {
                        target.strength = Random.Range(50, 66);
                    }
                    else if (target.weight < 126)
                    {
                        target.strength = Random.Range(65, 81);
                    }
                    else
                    {
                        target.strength = Random.Range(80, 96);
                    }
                }
                else
                {
                    if (target.weight < 56)
                    {
                        target.strength = Random.Range(15, 31);
                    }
                    else if (target.weight < 76)
                    {
                        target.strength = Random.Range(30, 46);
                    }
                    else if (target.weight < 96)
                    {
                        target.strength = Random.Range(45, 61);
                    }
                    else if (target.weight < 116)
                    {
                        target.strength = Random.Range(60, 76);
                    }
                    else
                    {
                        target.strength = Random.Range(75, 91);
                    }
                }
                
                //Random by training
                target.strength = RandomAll(target.strength);
            }
            else
            {
                //Basic
                target.strength = Random.Range(30, 51);
                target.strength = Convert.ToInt32(Convert.ToDouble(target.strength) / 10 * (10 - (Math.Abs(15 - target.age))));

                //Random
                target.strength = RandomChild(target.strength, 2);
            }
        }

        /// <summary>
        /// Choose the stamina randomly
        /// </summary>
        private void RandomStamina()
        {
            //Basic
            if(target.age > 15)
            {
                if (target.sex)
                {
                    if (target.age > 40)
                    {
                        target.stamina = Random.Range(35, 56);
                    }
                    else if (target.age > 28)
                    {
                        target.stamina = Random.Range(45, 66);
                    }
                    else if (target.age > 18)
                    {
                        target.stamina = Random.Range(55, 76);
                    }
                    else
                    {
                        target.stamina = Random.Range(35, 76);
                    }
                }
                else
                {
                    if (target.age > 40)
                    {
                        target.stamina = Random.Range(25, 46);
                    }
                    else if (target.age > 28)
                    {
                        target.stamina = Random.Range(35, 51);
                    }
                    else if (target.age > 18)
                    {
                        target.stamina = Random.Range(40, 61);
                    }
                    else
                    {
                        target.stamina = Random.Range(25, 61);
                    }
                }
                
                //Random by training
                target.stamina = RandomAll(target.stamina);
            }
            else
            {
                //Basic
                target.stamina = Random.Range(45, 76);
                target.stamina = Convert.ToInt32(Convert.ToDouble(target.stamina) / 10 * (10 - (Math.Abs(15 - target.age))));

                //Random
                target.stamina = RandomChild(target.stamina);
            }
        }

        /// <summary>
        /// Choose the reflex randomly
        /// </summary>
        private void RandomReflex()
        {
            //Basic
            int influence = 1;
            target.reflex = Random.Range(50, 86);
            if(target.age < 16)
            {
                influence = 3;
            }
            target.reflex = Convert.ToInt16(Convert.ToDouble(target.reflex) / 100 * (100 - (Math.Abs(24 - target.age) * influence)));

            //Random
            target.reflex = RandomChild(target.reflex);
        }

        /// <summary>
        /// Choose the Intellect randomly
        /// </summary>
        private void RandomIntellect()
        {
            //Basic
            tempRnd = Random.Range(0, 150);
            if(tempRnd < 5)
            {
                target.intellect = Random.Range(10, 21);
            }
            else if(tempRnd < 20)
            {
                target.intellect = Random.Range(20, 31);
            }
            else if (tempRnd < 50)
            {
                target.intellect = Random.Range(30, 41);
            }
            else if (tempRnd < 100)
            {
                target.intellect = Random.Range(40, 61);
            }
            else if (tempRnd < 130)
            {
                target.intellect = Random.Range(60, 71);
            }
            else if (tempRnd < 145)
            {
                target.intellect = Random.Range(70, 81);
            }
            else
            {
                target.intellect = Random.Range(80, 91);
            }

            //Child
            if(target.age < 12)
            {
                target.intellect = Convert.ToInt32(Convert.ToDouble(target.intellect) / 10 * (10 - (11 - target.age)));
            }

            //Random
            target.intellect = RandomChild(target.intellect, 2);
        }

        /// <summary>
        /// Method which add a random level of training to the target
        /// </summary>
        /// <param name="basic"></param>
        /// <returns>Final level</returns>
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

        /// <summary>
        /// Method which add a random level used to children and reflex
        /// </summary>
        /// <param name="basic">Basic level</param>
        /// <returns>Final level</returns>
        private int RandomChild(int basic, int influence = 1)
        {
            //Add more random
            tempRnd = Random.Range(0, 9);
            if (tempRnd < 1)
            {
                basic -= (20 / influence);
            }
            else if (tempRnd < 3)
            {
                basic -= (10 / influence);
            }
            else if (tempRnd < 6) { }
            else if (tempRnd < 8)
            {
                basic += (10 / influence);
            }
            else
            {
                basic += (20 / influence);
            }

            //Difficulty
            basic += Globals.week / 2;

            //Fix
            if (basic < 1)
            {
                basic = 1;
            }
            else if (basic > 100)
            {
                basic = 100;
            }

            return basic;
        }
    }
}
