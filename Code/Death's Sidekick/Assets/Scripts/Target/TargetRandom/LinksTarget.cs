using UnityEngine;

namespace Assets.Scripts.Target.TargetRandom
{
    /// <summary>
    /// Class creating the target's links
    /// </summary>
    class LinksTarget
    {
        //Objects
        Target target;

        //Variables
        int tempRnd;

        /// <summary>
        /// Basic constructor of the class which will launch the other random methods
        /// </summary>
        /// <param name="linkedTarget">The target we want to create</param>
        public LinksTarget(Target linkedTarget)
        {
            target = linkedTarget;
            RandomLinks();
        }

        /// <summary>
        /// Create a relation between the target and an Other
        /// </summary>
        /// <param name="type">Type of the relation</param>
        public void CreateRelation(byte type)
        {
            Other other = new Other(target, type);
            target.AddLink(other.link);
        }
        
        /// <summary>
        /// Choose the types of relation the target will have
        /// </summary>
        private void RandomLinks()
        {
            //0-Friends
            tempRnd = Random.Range(1, 201);
            if (tempRnd < 101)
            {
                if ((target.age > 40 && tempRnd < 22) ||
                    (target.age > 28 && tempRnd < 38) ||
                    (target.age > 18 && tempRnd < 47) ||
                    (target.age > 15 && tempRnd < 88) ||
                    (target.age > 10 && tempRnd < 69) ||
                    tempRnd < 24)
                {
                    for (int x = 0; x < NumberFriends(); ++x)
                    {
                        CreateRelation(0);
                    }
                }
            }

            //1-BestFriend
            tempRnd = Random.Range(1, 201);
            if (tempRnd < 101)
            {
                if ((target.age > 40 && tempRnd < 13) ||
                    (target.age > 28 && tempRnd < 29) ||
                    (target.age > 18 && tempRnd < 44) ||
                    (target.age > 15 && tempRnd < 56) ||
                    (target.age > 10 && tempRnd < 69) ||
                    tempRnd < 43)
                {
                    CreateRelation(1);
                }
            }

            //2-Family
            tempRnd = Random.Range(1, 201);
            if (tempRnd < 101)
            {
                if ((target.age > 40 && tempRnd < 13) ||
                    (target.age > 28 && tempRnd < 29) ||
                    (target.age > 18 && tempRnd < 44) ||
                    (target.age > 15 && tempRnd < 56) ||
                    (target.age > 10 && tempRnd < 69) ||
                    tempRnd < 43)
                {
                    for (int x = 0; x < NumberFamily(); ++x)
                    {
                        CreateRelation(2);
                    }
                }
            }

            //4-Couple
            tempRnd = Random.Range(1, 201);
            if (tempRnd < 101)
            {
                if ((target.age > 40 && tempRnd < 85) ||
                    (target.age > 28 && tempRnd < 63) ||
                    (target.age > 18 && tempRnd < 69) ||
                    (target.age > 15 && tempRnd < 33))
                {
                    CreateRelation(4);
                    target.inCouple = true;
                }
            }

            //3-Love
            tempRnd = Random.Range(1, 201);
            if (target.inCouple)
            {
                tempRnd = Random.Range(1, 600);
            }
            if (tempRnd < 101)
            {
                if ((target.age > 40 && tempRnd < 17) ||
                    (target.age > 28 && tempRnd < 23) ||
                    (target.age > 18 && tempRnd < 39) ||
                    (target.age > 15 && tempRnd < 53) ||
                    (target.age > 10 && tempRnd < 11) ||
                    tempRnd < 4)
                {
                    CreateRelation(3);
                }
            }
        }

        /// <summary>
        /// Choose the number of friends the target will have
        /// </summary>
        /// <returns>Return the number of friends</returns>
        private int NumberFriends()
        {
            tempRnd = Random.Range(1, 101);

            if (target.age > 40)
            {
                if (tempRnd < 40)
                {
                    return 1;
                }
                if (tempRnd < 73)
                {
                    return 2;
                }
                if (tempRnd < 92)
                {
                    return 3;
                }
                return 4;
            }
            if (target.age > 28)
            {
                if (tempRnd < 39)
                {
                    return 1;
                }
                if (tempRnd < 62)
                {
                    return 2;
                }
                if (tempRnd < 81)
                {
                    return 3;
                }
                if (tempRnd < 92)
                {
                    return 4;
                }
                return 5;
            }
            if (target.age > 18)
            {
                if (tempRnd < 16)
                {
                    return 1;
                }
                if (tempRnd < 54)
                {
                    return 2;
                }
                if (tempRnd < 78)
                {
                    return 3;
                }
                if (tempRnd < 89)
                {
                    return 4;
                }
                return 5;
            }
            if (target.age > 15)
            {
                if (tempRnd < 7)
                {
                    return 1;
                }
                if (tempRnd < 23)
                {
                    return 2;
                }
                if (tempRnd < 47)
                {
                    return 3;
                }
                if (tempRnd < 73)
                {
                    return 4;
                }
                return 5;
            }
            if (target.age > 10)
            {
                if (tempRnd < 21)
                {
                    return 1;
                }
                if (tempRnd < 43)
                {
                    return 2;
                }
                if (tempRnd < 77)
                {
                    return 3;
                }
                if (tempRnd < 88)
                {
                    return 4;
                }
                return 5;
            }
            if (tempRnd < 45)
            {
                return 1;
            }
            if (tempRnd < 83)
            {
                return 2;
            }
            return 3;
        }

        /// <summary>
        /// Choose the number of member of his family the target will have
        /// </summary>
        /// <returns>The number of members of the target's family</returns>
        private int NumberFamily()
        {
            tempRnd = Random.Range(1, 101);

            if (target.age > 40)
            {
                if (tempRnd < 38)
                {
                    return 1;
                }
                if (tempRnd < 67)
                {
                    return 2;
                }
                if (tempRnd < 84)
                {
                    return 3;
                }
                return 4;
            }
            if (target.age > 28)
            {
                if (tempRnd < 24)
                {
                    return 1;
                }
                if (tempRnd < 48)
                {
                    return 2;
                }
                if (tempRnd < 87)
                {
                    return 3;
                }
                return 4;
            }
            if (target.age > 18)
            {
                if (tempRnd < 83)
                {
                    return 1;
                }
                if (tempRnd < 97)
                {
                    return 2;
                }
                return 3;
            }
            if (target.age > 15)
            {
                if (tempRnd < 34)
                {
                    return 1;
                }
                if (tempRnd < 73)
                {
                    return 2;
                }
                if (tempRnd < 92)
                {
                    return 3;
                }
                return 4;
            }
            if (target.age > 10)
            {
                if (tempRnd < 29)
                {
                    return 1;
                }
                if (tempRnd < 67)
                {
                    return 2;
                }
                if (tempRnd < 90)
                {
                    return 3;
                }
                return 4;
            }
            if (tempRnd < 24)
            {
                return 1;
            }
            if (tempRnd < 62)
            {
                return 2;
            }
            if (tempRnd < 91)
            {
                return 3;
            }
            return 4;
        }

        /// <summary>
        /// Choose the number of loving people the target will have (both sides)
        /// </summary>
        /// <returns>Return the number of people concerned by love</returns>
        private int NumberLove()
        {
            tempRnd = Random.Range(1, 101);

            if (target.age > 40)
            {
                if (tempRnd < 64)
                {
                    return 1;
                }
                if (tempRnd < 98)
                {
                    return 2;
                }
                return 3;
            }
            if (target.age > 28)
            {
                if (tempRnd < 53)
                {
                    return 1;
                }
                if (tempRnd < 92)
                {
                    return 2;
                }
                return 3;
            }
            if (target.age > 18)
            {
                if (tempRnd < 43)
                {
                    return 1;
                }
                if (tempRnd < 81)
                {
                    return 2;
                }
                return 3;
            }
            if (target.age > 15)
            {
                if (tempRnd < 34)
                {
                    return 1;
                }
                if (tempRnd < 67)
                {
                    return 2;
                }
                return 3;
            }
            if (target.age > 10)
            {
                if (tempRnd < 96)
                {
                    return 1;
                }
                return 2;
            }
            if (tempRnd < 99)
            {
                return 1;
            }
            return 2;
        }
    }
}
