using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target{

    //Objects
    private List<Link> links;

    //Variables
    private bool isScenario;
    private bool inCouple = false;
    private int tempRnd;

    //Basic characteristics
    private string name;
    private string lastName;
    private int age;
    private bool sex;   //0 == Male / 1 == Female
    private int height;
    private int weight;

    //Special characteristics
    private int speed;
    private int strength;
    private int stamina;
    private int reflex;
    private int iq;
    private int anxiety;

    //Constructor
    public Target(bool isScenario, byte type = base)
    {
        //TODO Add types
        this.isScenario = isScenario;

        //Create Basic characteristics
        //TODO Random name
        RandomAgeSex();
        RandomHeight();
        RandomWeight();

        //Create Special characteristics
        //TODO Create Special

        //Create Links
        RandomLinks();
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
    /// Create a relation between the target and an Other
    /// </summary>
    /// <param name="type">Type of the relation</param>
    public void CreateRelation(byte type)
    {
        Other other = new Other(this, type);
        links.Add(other.link);
    }

    //TODO Coms
    private void RandomAgeSex(){
        age = random.Range(4, 56);
        sex = random.Range(0, 1);
    }

    private void RandomHeight(){
        tempRnd = random.Range(1, 34);
        if(tempRnd == 1){
            height = random.Range(145, 155);
        }
        else if(tempRnd < 4){
            height = random.Range(156, 160);
        }
        else if(tempRnd < 6){
            height = random.Range(161, 165);
        }
        else if(tempRnd < 10){
            height = random.Range(166, 170);
        }
        else if(tempRnd < 16){
            height = random.Range(171, 175);
        }
        else if(tempRnd < 24){
            height = random.Range(176, 180);
        }
        else if(tempRnd < 30){
            height = random.Range(181, 185);
        }
        else if(tempRnd < 34){
            height = random.Range(186, 190);
        }
        else{
            height = random.Range(191, 200)
        }

        //If female
        if(!sex){
            height -= 10;
        }
    }

    private void RandomWeight(){
        //If male
        if(sex){
            if(height < 156){
                weight = random.Range(53, 64);
            }
            else if(height < 161){
                weight = random.Range(55, 68);
            }
            else if(height < 166){
                weight = random.Range(57, 72);
            }
            else if(height < 171){
                weight = random.Range(59, 75);
            }
            else if(height < 176){
                weight = random.Range(61, 79);
            }
            else if(height < 181){
                weight = random.Range(63, 83);
            }
            else if(height < 186){
                weight = random.Range(65, 87);
            }
            else if(height < 191){
                weight = random.Range(68, 91);
            }
            else{
                weight = random.Range(71, 95);
            }
        }
        else{
            if(height < 146){
                weight = random.Range(43, 57);
            }
            else if(height < 151){
                weight = random.Range(45, 60);
            }
            else if(height < 156){
                weight = random.Range(45, 63);
            }
            else if(height < 161){
                weight = random.Range(47, 67);
            }
            else if(height < 166){
                weight = random.Range(50, 70);
            }
            else if(height < 171){
                weight = random.Range(53, 74);
            }
            else if(height < 176){
                weight = random.Range(55, 77);
            }
            else if(height < 181){
                weight = random.Range(58, 80);
            }
            else{
                weight = random.Range(61, 83);
            }
        }

        tempRnd = random.Range(1, 14);
        if(tempRnd == 1){
            weight -= random.Range(11, 20);
        }
        else if(tempRnd < 4){
            weight -= random.Range(1, 10);
        }
        else if(tempRnd < 12){}
        else if(tempRnd < 14){
            weight += random.Range(1, 10);
        }
        else{
            weight += random.Range(11, 20);
        }
        if(age > 40){
            weight += random.Range(6, 15);
        }
    }

    private void RandomLinks(){
        //0-Friends
        tempRnd = random.Range(1, 200);
        if(tempRnd < 101){
            if((age > 40 && tempRnd < 22) ||
                (age > 28 && tempRnd < 38) ||
                (age > 18 && tempRnd < 47) ||
                (age > 15 && tempRnd < 88) ||
                (age > 10 && tempRnd < 69) ||
                tempRnd < 24){
                    for(int x = 0; x < NumberFriends(); ++x){
                        CreateRelation(0);
                    }
            }
        }

        //1-BestFriend
        tempRnd = random.Range(1, 200);
        if(tempRnd < 101){
            if((age > 40 && tempRnd < 13) ||
                (age > 28 && tempRnd < 29) ||
                (age > 18 && tempRnd < 44) ||
                (age > 15 && tempRnd < 56) ||
                (age > 10 && tempRnd < 69) ||
                tempRnd < 43){
                    CreateRelation(1);
                }
        }

        //2-Family
        tempRnd = random.Range(1, 200);
        if(tempRnd < 101){
            if((age > 40 && tempRnd < 13) ||
                (age > 28 && tempRnd < 29) ||
                (age > 18 && tempRnd < 44) ||
                (age > 15 && tempRnd < 56) ||
                (age > 10 && tempRnd < 69) ||
                tempRnd < 43){
                    for(x = 0; x < NumberFamily(); ++x){
                        CreateRelation(2);
                    }
            }
        }

        //4-Couple
        tempRnd = random.Range(1, 200);
        if(tempRnd < 101){
            if((age > 40 && tempRnd < 85) ||
                (age > 28 && tempRnd < 63) ||
                (age > 18 && tempRnd < 69) ||
                (age > 15 && tempRnd < 33){
                    CreateRelation(4);
                    inCouple = true;
                }
        }

        //3-Love
        tempRnd = random.Range(1, 200);
        if(inCouple){
            tempRnd = random.Range(1, 600);
        }
        if(tempRnd < 101){
            if((age > 40 && tempRnd < 17) ||
                (age > 28 && tempRnd < 23) ||
                (age > 18 && tempRnd < 39) ||
                (age > 15 && tempRnd < 53) ||
                (age > 10 && tempRnd < 11) ||
                tempRnd < 4){
                CreateRelation(3);
            }
        }
    }

    private int NumberFriends(){
        tempRnd = random.Range(1, 100);

        if(age > 40){
            if(tempRnd < 40){
                return 1;
            }
            if(tempRnd < 73){
                return 2;
            }
            if(tempRnd < 92){
                return 3;
            }
            return 4;
        }
        if(age > 28){
            if(tempRnd < 39){
                return 1;
            }
            if(tempRnd < 62){
                return 2;
            }
            if(tempRnd < 81){
                return 3;
            }
            if(tempRnd < 92){
                return 4;
            }
            return 5;
        }
        if(age > 18){
            if(tempRnd < 16){
                return 1;
            }
            if(tempRnd < 54){
                return 2;
            }
            if(tempRnd < 78){
                return 3;
            }
            if(tempRnd < 89){
                return 4;
            }
            return 5;
        }
        if(age > 15){
            if(tempRnd < 7){
                retunr 1;
            }
            if(tempRnd < 23){
                return 2;
            }
            if(tempRnd < 47){
                return 3;
            }
            if(tempRnd < 73){
                return 4;
            }
            return 5;
        }
        if(age > 10){
            if(tempRnd < 21){
                return 1;
            }
            if(tempRnd < 43){
                return 2;
            }
            if(tempRnd < 77){
                return 3;
            }
            if(tempRnd < 88){
                return 4;
            }
            return 5;
        }
        if(tempRnd < 45){
            return 1;
        }
        if(tempRnd < 83){
            return 2;
        }
        return 3;
    }

    private int NumberFamily(){
        tempRnd = random.Range(1, 100);

        if(age > 40){
            if(tempRnd < 38){
                return 1;
            }
            if(tempRnd < 67){
                return 2;
            }
            if(tempRnd < 84){
                return 3;
            }
            return 4;
        }
        if(age > 28){
            if(tempRnd < 24){
                return 1;
            }
            if(tempRnd < 48){
                return 2;
            }
            if(tempRnd < 87){
                return 3;
            }
            return 4;
        }
        if(age > 18){
            if(tempRnd < 83){
                return 1;
            }
            if(tempRnd < 97){
                return 2;
            }
            return 3;
        }
        if(age > 15){
            if(tempRnd < 34){
                retunr 1;
            }
            if(tempRnd < 73){
                return 2;
            }
            if(tempRnd < 92){
                return 3;
            }
            return 4;
        }
        if(age > 10){
            if(tempRnd < 29){
                return 1;
            }
            if(tempRnd < 67){
                return 2;
            }
            if(tempRnd < 90){
                return 3;
            }
            return 4;
        }
        if(tempRnd < 24){
            return 1;
        }
        if(tempRnd < 62){
            return 2;
        }
        if(tempRnd < 91){
            return 3;
        }
        return 4;
    }

    private int NumberLove(){
        tempRnd = random.Range(1, 100);

        if(age > 40){
            if(tempRnd < 64){
                return 1;
            }
            if(tempRnd < 98){
                return 2;
            }
            return 3;
        }
        if(age > 28){
            if(tempRnd < 53){
                return 1;
            }
            if(tempRnd < 92){
                return 2;
            }
            return 3;
        }
        if(age > 18){
            if(tempRnd < 43){
                return 1;
            }
            if(tempRnd < 81){
                return 2;
            }
            return 3;
        }
        if(age > 15){
            if(tempRnd < 34){
                return 1;
            }
            if(tempRnd < 67){
                return 2;
            }
            return 3;
        }
        if(age > 10){
            if(tempRnd < 96){
                return 1;
            }
            return 2;
        }
        if(tempRnd < 99){
            return 1;
        }
        return 2;
    }
}
