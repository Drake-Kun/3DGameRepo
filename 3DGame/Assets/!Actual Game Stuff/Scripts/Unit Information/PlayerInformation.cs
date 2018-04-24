using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInformation : MonoBehaviour {

    public int playerLevel;
    public string playerName;
    public int currentEXP;
    public int neededEXP;

    public int healthPointsMax;
    public int healthPointsCurrent;
    public int techPointsMax;
    public int techPointsCurrent;
    public int physicalDamage;
    public int physicalResist;
    public int techDamage;
    public int techResist;

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
