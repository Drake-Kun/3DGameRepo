using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitInformation : MonoBehaviour {

    public int unitLevel;

    // How many experience points do we have?
    public int unitExp;

    // How many experience points do we need to level up?
    public int levelExp;

    // An int that lets is know how much exp we have left to level up.
    // We will use this int when displaying in menus how much exp a unit needs to level up.
    public int levelExpLeft;

    // Kind of obvious, but these are our stats! :D
    public int healthPointsMax;
    public int healthPoints;
    public int physicalDamage;
    public int magicDamage;
    public int physicalResist;
    public int magicResist;
    public int unitSpeed;

    // This is how much our units individual stats will increase by every time they level up.
    public int healthPointsMaxPlus;
    public int physicalDamagePlus;
    public int magicDamagePlus;
    public int physicalResistPlus;
    public int magicResistPlus;
    public int unitSpeedPlus;

    // Is this unit fallen (basically dead)?
    public bool fallen;

    // Is this unit one of the player's?
    public bool playerUnit;

    // Given to enemy units: How much experience points does this unit give the player on death?
    public int expGiven;

    // Have we distributed exp to the player's units?
    public bool expDistributed;
    
    void Start () {

        // If this is a unit owned by the player, initialize stats such as level, exp, and exp needed to level up.
        if (playerUnit == true)
        {
            unitLevel = 1;
            unitExp = 0;
            levelExp = 100;
        }


	}
	
	void Update () {

        // Checks to see if we're an enemy unit, and if we're dead, and if we've already distributed exp for our shameful death.
        if (playerUnit == false && fallen == true && expDistributed == false)
        {
            // Checks to see if the apprpriate units are alive to recieve exp. Fallen units don't DESERVE exp. 
            if (GameObject.Find("UnitInformationKnight").GetComponent<UnitInformation>().fallen == false)
            {
                GameObject.Find("UnitInformationKnight").GetComponent<UnitInformation>().unitExp += expGiven;
            }

            if (GameObject.Find("UnitInformationArcher").GetComponent<UnitInformation>().fallen == false)
            {
                GameObject.Find("UnitInformationArcher").GetComponent<UnitInformation>().unitExp += expGiven;
            }

            if (GameObject.Find("UnitInformationHealer").GetComponent<UnitInformation>().fallen == false)
            {
                GameObject.Find("UnitInformationHealer").GetComponent<UnitInformation>().unitExp += expGiven;
            }

            if (GameObject.Find("UnitInformationMage").GetComponent<UnitInformation>().fallen == false)
            {
                GameObject.Find("UnitInformationMage").GetComponent<UnitInformation>().unitExp += expGiven;
            }

            // Okay, we've distributed exp
            expDistributed = true;
        }

        // Checks to see if we've run out of health points, and are therefore dead.
        if (healthPoints <= 0)
        {
            // Sets health points to 0 so we don't have negative values.
            healthPoints = 0;
            // We ded.
            fallen = true;
        }

        // If we aren't dead, we aren't dead.
        else
        {
            // We live!
            fallen = false;
        }

        // This calculates how much exp we have left to level up
        levelExpLeft = levelExp - unitExp;

        // Checks to see if we have enough exp to level up
        if (unitExp >= levelExp)
        {
            // If we had enough to level up, level up and add stats to the unit
            levelExp += 1;
            healthPointsMax += healthPointsMaxPlus;
            healthPoints += healthPointsMaxPlus;
            physicalDamage += physicalDamagePlus;
            magicDamage += magicDamagePlus;
            physicalResist += physicalResistPlus;
            magicResist += magicResist;
            unitSpeed += unitSpeedPlus;

            // Adjust levelExp so that we need more exp to level up again
            levelExp *= 2;
        }


	}
}
