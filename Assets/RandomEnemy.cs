using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEnemy : MonoBehaviour {

    int enemies = 8;

    string bonusOne = "SlimeGreen";
    string bonusTwo = "SlimeRed";
    string bonusThree = "SlimeBlue";
    string bonusFour = "GolemIron";
    string bonusFive = "GolemPlatinum";
    string bonusSix = "GolemDiamond";
    // Use this for initialization
    void Start ()
    {
        if (GameObject.FindGameObjectsWithTag("Exit").Length < 1)
        {
            Instantiate(Resources.Load("Ladder") as GameObject, transform);
        }
        else
        {
            int f = PlayerPrefs.GetInt("f");
            if(f < 3)
            {
                bonusOne = "Golem";
            }
            if (f < 4)
            {
                bonusTwo = "GolemCopper";
            }
            if (f < 7)
            {
                bonusThree = "GolemCopper";
            }
            if (f < 5)
            {
                bonusFour = "GolemCopper";
            }
            if (f < 8)
            {
                bonusFive = "SlimeGreen";
            }
            if (f < 10)
            {
                bonusSix = "SlimeGreen";
            }
            int r = Random.Range(0, enemies);
            switch (r)
            {
                case 0:
                    print("Golem");
                    Instantiate(Resources.Load("Golem") as GameObject, transform);
                    break;
                case 1:
                    Instantiate(Resources.Load("GolemCopper") as GameObject, transform);
                    break;
                case 2:
                    Instantiate(Resources.Load(bonusOne) as GameObject, transform);
                    break;
                case 3:
                    Instantiate(Resources.Load(bonusTwo) as GameObject, transform);
                    break;
                case 4:
                    Instantiate(Resources.Load(bonusThree) as GameObject, transform);
                    break;
                case 5:
                    Instantiate(Resources.Load(bonusFour) as GameObject, transform);
                    break;
                case 6:
                    Instantiate(Resources.Load(bonusFive) as GameObject, transform);
                    break;
                case 7:
                    Instantiate(Resources.Load(bonusSix) as GameObject, transform);
                    break;
            }
        }
	}
	
	
}
