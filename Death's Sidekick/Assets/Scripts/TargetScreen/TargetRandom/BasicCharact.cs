using UnityEngine;

namespace Assets.Scripts.TargetScreen.TargetRandom
{
    //Class creating the target's basic characteristics
    class BasicCharact
    {
        //Objects
        Target target;

        //Variables
        int tempRnd;

        /// <summary>
        /// Basic constructor of the class which will launch the other random methods
        /// </summary>
        /// <param name="linkedTarget">The target we want to create</param>
        public BasicCharact(Target linkedTarget)
        {
            target = linkedTarget;
            //TODO Random Name
            RandomAgeSex();
            //Random < 15
            RandomHeight();
            RandomWeight();
        }

        /// <summary>
        /// Choose the age randomly
        /// </summary>
        /// <param name="target">The target we are creating</param>
        private void RandomAgeSex()
        {
            target.age = Random.Range(4, 56);
            tempRnd = Random.Range(0, 1);
            target.sex = (tempRnd == 0);
        }

        /// <summary>
        /// Choose the height randomly
        /// </summary>
        /// <param name="target">The target we are creating</param>
        private void RandomHeight()
        {
            tempRnd = Random.Range(1, 34);
            if (tempRnd == 1)
            {
                target.height = Random.Range(145, 155);
            }
            else if (tempRnd < 4)
            {
                target.height = Random.Range(156, 160);
            }
            else if (tempRnd < 6)
            {
                target.height = Random.Range(161, 165);
            }
            else if (tempRnd < 10)
            {
                target.height = Random.Range(166, 170);
            }
            else if (tempRnd < 16)
            {
                target.height = Random.Range(171, 175);
            }
            else if (tempRnd < 24)
            {
                target.height = Random.Range(176, 180);
            }
            else if (tempRnd < 30)
            {
                target.height = Random.Range(181, 185);
            }
            else if (tempRnd < 34)
            {
                target.height = Random.Range(186, 190);
            }
            else
            {
                target.height = Random.Range(191, 200);
            }

            //If female
            if (!target.sex)
            {
                target.height -= 10;
            }
        }

        /// <summary>
        /// Choose the weight randomly
        /// </summary>
        /// <param name="target">The target we are creating</param>
        private void RandomWeight()
        {
            //If male
            if (target.sex)
            {
                if (target.height < 156)
                {
                    target.weight = Random.Range(53, 64);
                }
                else if (target.height < 161)
                {
                    target.weight = Random.Range(55, 68);
                }
                else if (target.height < 166)
                {
                    target.weight = Random.Range(57, 72);
                }
                else if (target.height < 171)
                {
                    target.weight = Random.Range(59, 75);
                }
                else if (target.height < 176)
                {
                    target.weight = Random.Range(61, 79);
                }
                else if (target.height < 181)
                {
                    target.weight = Random.Range(63, 83);
                }
                else if (target.height < 186)
                {
                    target.weight = Random.Range(65, 87);
                }
                else if (target.height < 191)
                {
                    target.weight = Random.Range(68, 91);
                }
                else
                {
                    target.weight = Random.Range(71, 95);
                }
            }
            else
            {
                if (target.height < 146)
                {
                    target.weight = Random.Range(43, 57);
                }
                else if (target.height < 151)
                {
                    target.weight = Random.Range(45, 60);
                }
                else if (target.height < 156)
                {
                    target.weight = Random.Range(45, 63);
                }
                else if (target.height < 161)
                {
                    target.weight = Random.Range(47, 67);
                }
                else if (target.height < 166)
                {
                    target.weight = Random.Range(50, 70);
                }
                else if (target.height < 171)
                {
                    target.weight = Random.Range(53, 74);
                }
                else if (target.height < 176)
                {
                    target.weight = Random.Range(55, 77);
                }
                else if (target.height < 181)
                {
                    target.weight = Random.Range(58, 80);
                }
                else
                {
                    target.weight = Random.Range(61, 83);
                }
            }

            //Add a little more random
            tempRnd = Random.Range(1, 14);
            if (tempRnd == 1)
            {
                target.weight -= Random.Range(11, 20);
            }
            else if (tempRnd < 4)
            {
                target.weight -= Random.Range(1, 10);
            }
            else if (tempRnd < 12) { }
            else if (tempRnd < 14)
            {
                target.weight += Random.Range(1, 10);
            }
            else
            {
                target.weight += Random.Range(11, 20);
            }
            if (target.age > 40)
            {
                target.weight += Random.Range(6, 15);
            }
        }
    }
}
