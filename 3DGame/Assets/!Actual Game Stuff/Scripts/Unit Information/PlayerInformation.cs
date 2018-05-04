using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInformation : MonoBehaviour {

    public string playerName;

    //Player stats
    public int healthPointsMax;
    public int healthPointsCurrent;
    public int techPointsMax;
    public int techPointsCurrent;
    public int physicalDamage;
    public int physicalResist;
    public int techDamage;
    public int techResist;

    //Is the player poisoned?
    public bool poisoned;
    public int poisonTimer;

    public bool fallen = false;

    void Update()
    {
        if (healthPointsCurrent >= healthPointsMax)
        {
            healthPointsCurrent = healthPointsMax;
        }

        if (techPointsCurrent >= techPointsMax)
        {
            techPointsCurrent = techPointsMax;
        }

        if (healthPointsCurrent <= 0)
        {
            fallen = true;
        }

        else
        {
            fallen = false;
        }

        if (healthPointsCurrent <= 0)
        {
            fallen = true;
        }
    }
}
