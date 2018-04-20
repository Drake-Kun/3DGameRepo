using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInformation : MonoBehaviour {

    public int playerLevel;
    public int currentEXP;
    public int neededEXP;

    public int healthPointsMax = 30;
    public int healthPointsCurrent;
    public int techPointsMax = 20;
    public int techPointsCurrent;
    public int physicalDamage = 5;
    public int physicalResist = 2;
    public int techDamage = 2;
    public int techResist = 2;

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
    }
}
