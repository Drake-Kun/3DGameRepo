using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInformation : MonoBehaviour {

    //Player level related stats
    public int playerLevel;
    public string playerName;
    public int currentEXP;
    public int neededEXP;

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

    void Start()
    {
        playerLevel = 1;
        currentEXP = 0;
        neededEXP = 10;
        healthPointsCurrent = healthPointsMax;
        techPointsCurrent = techPointsMax;
    }

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
            Destroy(gameObject);
        }

        if (currentEXP >= neededEXP)
        {
            currentEXP -= neededEXP;
            playerLevel += 1;
            neededEXP = (neededEXP + 5) * 2;
        }

        if (healthPointsCurrent <= 0)
        {
            fallen = true;
        }
    }
}
