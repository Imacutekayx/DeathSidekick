using Assets.Scripts.Managers;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Target.TargetRandom
{
    /// <summary>
    /// Class creating the target's basic characteristics
    /// </summary>
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
            //RandomFromXML();
            RandomAgeSex();
            RandomHeight();
            RandomWeight();
        }

        /// <summary>
        /// Choose the name randomly
        /// </summary>
        private void RandomFromXML()
        {
            //Origin
            int tempTotal = 0;
            int result;
            int resultTotal = 0;
            //Origin
            foreach(XMLTarget.Origin origin in Globals.targetManager.origins)
            {
                tempTotal += origin.nbr;
            }
            result = Random.Range(0, tempTotal);
            foreach(XMLTarget.Origin origin in Globals.targetManager.origins)
            {
                resultTotal += origin.nbr;
                if(result <= resultTotal)
                {
                    //Area
                    tempTotal = 0;
                    resultTotal = 0;
                    foreach(XMLTarget.Area area in origin.lstArea)
                    {
                        tempTotal += area.nbr;
                    }
                    result = Random.Range(0, tempTotal);
                    foreach(XMLTarget.Area area in origin.lstArea)
                    {
                        resultTotal += area.nbr;
                        if(result <= resultTotal)
                        {
                            //Country
                            tempTotal = 0;
                            resultTotal = 0;
                            foreach(XMLTarget.Country country in area.lstCountries)
                            {
                                tempTotal += country.nbr;
                            }
                            result = Random.Range(0, tempTotal);
                            foreach(XMLTarget.Country country in area.lstCountries)
                            {
                                resultTotal += country.nbr;
                                if(result <= resultTotal)
                                {
                                    target.country = country.name;
                                    continue;
                                }
                            }
                            target.area = area.name;
                            continue;
                        }
                    }
                    target.origin = origin.name;
                    continue;
                }
            }

            //Lastname
            List<XMLTarget.Lastname> lastnames = new List<XMLTarget.Lastname>();
            foreach(XMLTarget.Lastname lastname in Globals.targetManager.lastnames)
            {
                if(lastname.origin == target.area)
                {
                    lastnames.Add(lastname);
                }
            }
            target.lastname = lastnames[Random.Range(0, lastnames.Count-1)];
            lastnames = null;

            //Forname
            List<XMLTarget.Forname> fornames = new List<XMLTarget.Forname>();
            foreach(XMLTarget.Forname forname in Globals.targetManager.fornames)
            {
                if(forname.origin == target.area && forname.sex == target.sex)
                {
                    fornames.Add(forname);
                }
            }
            target.forname = fornames[Random.Range(0, fornames.Count-1)];
            fornames = null;

            //Job
            target.job = Globals.targetManager.jobs[Random.Range(0, Globals.targetManager.jobs.Count-1)];
        }

        /// <summary>
        /// Choose the age randomly
        /// </summary>
        private void RandomAgeSex()
        {
            target.age = Random.Range(4, 57);
            if(target.age < 16)
            {
                target.age = Random.Range(4, 29);
            }
            if(target.age < 16)
            {
                //TODO Add School as job
            }
            else if(target.age < 26)
            {
                if(Random.Range(0, 4) != 3)
                {
                    //TODO Add Studies as job
                }
            }
            tempRnd = Random.Range(0, 2);
            target.sex = (tempRnd == 0);
        }

        /// <summary>
        /// Choose the height randomly
        /// </summary>
        private void RandomHeight()
        {
            //Check if adult
            if(target.age > 15)
            {
                tempRnd = Random.Range(1, 35);
                if (tempRnd == 1)
                {
                    target.height = Random.Range(145, 156);
                }
                else if (tempRnd < 4)
                {
                    target.height = Random.Range(156, 161);
                }
                else if (tempRnd < 6)
                {
                    target.height = Random.Range(161, 166);
                }
                else if (tempRnd < 10)
                {
                    target.height = Random.Range(166, 171);
                }
                else if (tempRnd < 16)
                {
                    target.height = Random.Range(171, 176);
                }
                else if (tempRnd < 24)
                {
                    target.height = Random.Range(176, 181);
                }
                else if (tempRnd < 30)
                {
                    target.height = Random.Range(181, 186);
                }
                else if (tempRnd < 34)
                {
                    target.height = Random.Range(186, 191);
                }
                else
                {
                    target.height = Random.Range(191, 201);
                }

                //If female
                if (!target.sex)
                {
                    target.height -= 10;
                }
            }
            else
            {
                switch (target.age)
                {
                    case 15:
                        target.height = Random.Range(150, 181);
                        break;

                    case 14:
                        target.height = Random.Range(145, 176);
                        break;

                    case 13:
                        target.height = Random.Range(140, 166);
                        break;

                    case 12:
                        target.height = Random.Range(135, 161);
                        break;

                    case 11:
                        target.height = Random.Range(130, 151);
                        break;

                    case 10:
                        target.height = Random.Range(125, 146);
                        break;

                    case 9:
                        target.height = Random.Range(120, 141);
                        break;

                    case 8:
                        target.height = Random.Range(115, 136);
                        break;

                    case 7:
                        target.height = Random.Range(110, 131);
                        break;

                    case 6:
                        target.height = Random.Range(105, 121);
                        break;

                    case 5:
                        target.height = Random.Range(100, 116);
                        break;

                    case 4:
                        target.height = Random.Range(95, 111);
                        break;
                }

                //Add some random
                tempRnd = Random.Range(0, 45);
                if(tempRnd == 0)
                {
                    target.height -= 30;
                }
                else if(tempRnd < 3)
                {
                    target.height -= 20;
                }
                else if(tempRnd < 7)
                {
                    target.height -= 10;
                }
                else if(tempRnd < 34){}
                else if(tempRnd < 40)
                {
                    target.height += 10;
                }
                else if(tempRnd < 43)
                {
                    target.height += 20;
                }
                else
                {
                    target.height += 30;
                }
            }
        }

        /// <summary>
        /// Choose the weight randomly
        /// </summary>
        private void RandomWeight()
        {
            if(target.age > 15)
            {
                //If male
                if (target.sex)
                {
                    if (target.height < 156)
                    {
                        target.weight = Random.Range(53, 65);
                    }
                    else if (target.height < 161)
                    {
                        target.weight = Random.Range(55, 69);
                    }
                    else if (target.height < 166)
                    {
                        target.weight = Random.Range(57, 73);
                    }
                    else if (target.height < 171)
                    {
                        target.weight = Random.Range(59, 76);
                    }
                    else if (target.height < 176)
                    {
                        target.weight = Random.Range(61, 80);
                    }
                    else if (target.height < 181)
                    {
                        target.weight = Random.Range(63, 84);
                    }
                    else if (target.height < 186)
                    {
                        target.weight = Random.Range(65, 88);
                    }
                    else if (target.height < 191)
                    {
                        target.weight = Random.Range(68, 92);
                    }
                    else
                    {
                        target.weight = Random.Range(71, 96);
                    }
                }
                else
                {
                    if (target.height < 146)
                    {
                        target.weight = Random.Range(43, 58);
                    }
                    else if (target.height < 151)
                    {
                        target.weight = Random.Range(45, 61);
                    }
                    else if (target.height < 156)
                    {
                        target.weight = Random.Range(45, 64);
                    }
                    else if (target.height < 161)
                    {
                        target.weight = Random.Range(47, 68);
                    }
                    else if (target.height < 166)
                    {
                        target.weight = Random.Range(50, 71);
                    }
                    else if (target.height < 171)
                    {
                        target.weight = Random.Range(53, 75);
                    }
                    else if (target.height < 176)
                    {
                        target.weight = Random.Range(55, 78);
                    }
                    else if (target.height < 181)
                    {
                        target.weight = Random.Range(58, 81);
                    }
                    else
                    {
                        target.weight = Random.Range(61, 84);
                    }
                }

                //Add a little more random
                tempRnd = Random.Range(1, 21);
                if (tempRnd == 1)
                {
                    target.weight -= Random.Range(11, 21);
                }
                else if (tempRnd < 4)
                {
                    target.weight -= Random.Range(1, 11);
                }
                else if (tempRnd < 16) { }
                else if (tempRnd < 19)
                {
                    target.weight += Random.Range(1, 11);
                }
                else
                {
                    target.weight += Random.Range(11, 21);
                }
                if (target.age > 40)
                {
                    target.weight += Random.Range(6, 16);
                }
            }
            else
            {
                switch (target.age)
                {
                    case 15:
                        target.weight = Random.Range(50, 76);
                        break;

                    case 14:
                        target.weight = Random.Range(37, 60);
                        break;

                    case 13:
                        target.weight = Random.Range(33, 51);
                        break;

                    case 12:
                        target.weight = Random.Range(30, 46);
                        break;

                    case 11:
                        target.weight = Random.Range(28, 41);
                        break;

                    case 10:
                        target.weight = Random.Range(25, 37);
                        break;

                    case 9:
                        target.weight = Random.Range(23, 33);
                        break;

                    case 8:
                        target.weight = Random.Range(21, 30);
                        break;

                    case 7:
                        target.weight = Random.Range(19, 26);
                        break;

                    case 6:
                        target.weight = Random.Range(18, 23);
                        break;

                    case 5:
                        target.weight = Random.Range(15, 21);
                        break;

                    case 4:
                        target.weight = Random.Range(14, 19);
                        break;
                }

                //Add a little more Random
                tempRnd = Random.Range(0, 15);
                if(tempRnd == 0)
                {
                    target.weight -= 5;
                }
                else if(tempRnd > 12)
                {
                    target.weight += 5;
                }
            }
        }
    }
}
