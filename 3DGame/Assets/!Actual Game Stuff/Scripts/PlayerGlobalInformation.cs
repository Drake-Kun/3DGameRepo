using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGlobalInformation : MonoBehaviour {



    //Player1 level and stats
    public int player1Level;
    public string player1Name;
    public int player1CurrentEXP;
    public int player1NeededEXP;
    
    public int player1HealthPointsMax;
    public int Player1HealthPointsCurrent;
    public int player1TechPointsMax;
    public int player1TechPointsCurrent;
    public int player1PhysicalDamage;
    public int player1PhysicalResist;
    public int player1TechDamage;
    public int player1TechResist;

    //Player2 level and stats
    public int player2Level;
    public string player2Name;
    public int player2CurrentEXP;
    public int player2NeededEXP;

    public int player2HealthPointsMax;
    public int Player2HealthPointsCurrent;
    public int player2TechPointsMax;
    public int player2TechPointsCurrent;
    public int player2PhysicalDamage;
    public int player2PhysicalResist;
    public int player2TechDamage;
    public int player2TechResist;

    //Player3 level and stats
    public int player3Level;
    public string player3Name;
    public int player3CurrentEXP;
    public int player3NeededEXP;

    public int player3HealthPointsMax;
    public int Player3HealthPointsCurrent;
    public int player3TechPointsMax;
    public int player3TechPointsCurrent;
    public int player3PhysicalDamage;
    public int player3PhysicalResist;
    public int player3TechDamage;
    public int player3TechResist;

    //Player4 level and stats
    public int player4Level;
    public string player4Name;
    public int player4CurrentEXP;
    public int player4NeededEXP;

    public int player4HealthPointsMax;
    public int Player4HealthPointsCurrent;
    public int player4TechPointsMax;
    public int player4TechPointsCurrent;
    public int player4PhysicalDamage;
    public int player4PhysicalResist;
    public int player4TechDamage;
    public int player4TechResist;

    void Start()
    {

        // START PLAYER1 STATS
        player1Level = 1;
        player1CurrentEXP = 0;
        player1NeededEXP = 10;

        player1HealthPointsMax = 30;
        Player1HealthPointsCurrent = player1HealthPointsMax;
        player1TechPointsMax = 10;
        player1PhysicalDamage = 6;
        player1PhysicalResist = 6;
        player1TechDamage = 4;
        player1TechResist = 4;


        // START PLAYER2 STATS
        player2Level = 1;
        player2CurrentEXP = 0;
        player2NeededEXP = 10;

        player2HealthPointsMax = 27;
        Player2HealthPointsCurrent = player2HealthPointsMax;
        player2TechPointsMax = 12;
        player2PhysicalDamage = 8;
        player2PhysicalResist = 4;
        player2TechDamage = 5;
        player2TechResist = 3;


        // START PLAYER3 STATS
        player3Level = 1;
        player3CurrentEXP = 0;
        player3NeededEXP = 10;

        player3HealthPointsMax = 25;
        Player3HealthPointsCurrent = player3HealthPointsMax;
        player3TechPointsMax = 15;
        player3PhysicalDamage = 2;
        player3PhysicalResist = 4;
        player3TechDamage = 8;
        player3TechResist = 6;


        // START PLAYER4 STATS
        player4Level = 1;
        player4CurrentEXP = 0;
        player4NeededEXP = 10;

        player4HealthPointsMax = 27;
        Player4HealthPointsCurrent = player4HealthPointsMax;
        player4TechPointsMax = 13;
        player4PhysicalDamage = 5;
        player4PhysicalResist = 5;
        player4TechDamage = 5;
        player4TechResist = 5;
    }

    void Update()
    {
        if (player1CurrentEXP >= player1NeededEXP)
        {
            player1Level += 1;
            player1CurrentEXP -= player1NeededEXP;
            player1NeededEXP = (player1NeededEXP + 5) * 2;

            if (player1Level < 5)
            {
                player1HealthPointsMax += 3;
                player1TechPointsMax += 2;
                player1PhysicalDamage += 2;
                player1PhysicalResist += 2;
                player1TechDamage += 1;
                player1TechResist += 1;
            }

            else if (player1Level >= 5 && player1Level < 10)
            {
                player1HealthPointsMax += 5;
                player1TechPointsMax += 3;
                player1PhysicalDamage += 3;
                player1PhysicalResist += 2;
                player1TechDamage += 1;
                player1TechResist += 2;
            }
        }

        if (player2CurrentEXP >= player2NeededEXP)
        {
            player2Level += 1;
            player2CurrentEXP -= player2NeededEXP;
            player2NeededEXP = (player2NeededEXP + 5) * 2;

            if (player2Level < 5)
            {
                player2HealthPointsMax += 2;
                player2TechPointsMax += 3;
                player2PhysicalDamage += 3;
                player2PhysicalResist += 1;
                player2TechDamage += 2;
                player2TechResist += 1;
            }

            else if (player2Level >= 5 && player2Level < 10)
            {
                player2HealthPointsMax += 4;
                player2TechPointsMax += 3;
                player2PhysicalDamage += 4;
                player2PhysicalResist += 2;
                player2TechDamage += 3;
                player2TechResist += 1;
            }
        }

        if (player3CurrentEXP >= player3NeededEXP)
        {
            player3Level += 1;
            player3CurrentEXP -= player3NeededEXP;
            player3NeededEXP = (player3NeededEXP + 5) * 2;

            if (player3Level < 5)
            {
                player3HealthPointsMax += 2;
                player3TechPointsMax += 3;
                player3PhysicalDamage += 1;
                player3PhysicalResist += 1;
                player3TechDamage += 3;
                player3TechResist += 2;
            }

            else if (player3Level >= 5 && player3Level < 10)
            {
                player3HealthPointsMax += 3;
                player3TechPointsMax += 5;
                player3PhysicalDamage += 1;
                player3PhysicalResist += 2;
                player3TechDamage += 5;
                player3TechResist += 3;
            }
        }

        if (player4CurrentEXP >= player4NeededEXP)
        {
            player4Level += 1;
            player4CurrentEXP -= player4NeededEXP;
            player4NeededEXP = (player4NeededEXP + 5) * 2;

            if (player4Level < 5)
            {
                player4HealthPointsMax += 2;
                player4TechPointsMax += 3;
                player4PhysicalDamage += 1;
                player4PhysicalResist += 2;
                player4TechDamage += 2;
                player4TechResist += 2;
            }

            else if (player4Level >= 5 && player4Level < 10)
            {
                player4HealthPointsMax += 3;
                player4TechPointsMax += 4;
                player4PhysicalDamage += 2;
                player4PhysicalResist += 3;
                player4TechDamage += 4;
                player4TechResist += 3;
            }
        }
    }

    public void EnterBattle()
    {

        // Give player1 their stats
        GameObject.Find("FriendlyUnit1").GetComponent<PlayerInformation>().healthPointsMax = player1HealthPointsMax;
        GameObject.Find("FriendlyUnit1").GetComponent<PlayerInformation>().healthPointsCurrent = Player1HealthPointsCurrent;
        GameObject.Find("FriendlyUnit1").GetComponent<PlayerInformation>().techPointsMax = player1TechPointsMax;
        GameObject.Find("FriendlyUnit1").GetComponent<PlayerInformation>().techPointsCurrent = player1TechPointsCurrent;
        GameObject.Find("FriendlyUnit1").GetComponent<PlayerInformation>().physicalDamage = player1PhysicalDamage;
        GameObject.Find("FriendlyUnit1").GetComponent<PlayerInformation>().physicalResist = player1PhysicalResist; 
        GameObject.Find("FriendlyUnit1").GetComponent<PlayerInformation>().techDamage = player1TechDamage;
        GameObject.Find("FriendlyUnit1").GetComponent<PlayerInformation>().techResist = player1TechResist;


        // Give player2 their stats
        GameObject.Find("FriendlyUnit2").GetComponent<PlayerInformation>().healthPointsMax = player2HealthPointsMax;
        GameObject.Find("FriendlyUnit2").GetComponent<PlayerInformation>().healthPointsCurrent = Player2HealthPointsCurrent;
        GameObject.Find("FriendlyUnit2").GetComponent<PlayerInformation>().techPointsMax = player2TechPointsMax;
        GameObject.Find("FriendlyUnit2").GetComponent<PlayerInformation>().techPointsCurrent = player2TechPointsCurrent;
        GameObject.Find("FriendlyUnit2").GetComponent<PlayerInformation>().physicalDamage = player2PhysicalDamage;
        GameObject.Find("FriendlyUnit2").GetComponent<PlayerInformation>().physicalResist = player2PhysicalResist;
        GameObject.Find("FriendlyUnit2").GetComponent<PlayerInformation>().techDamage = player2TechDamage;
        GameObject.Find("FriendlyUnit2").GetComponent<PlayerInformation>().techResist = player2TechResist;


        // Give player3 their stats
        GameObject.Find("FriendlyUnit3").GetComponent<PlayerInformation>().healthPointsMax = player3HealthPointsMax;
        GameObject.Find("FriendlyUnit3").GetComponent<PlayerInformation>().healthPointsCurrent = Player3HealthPointsCurrent;
        GameObject.Find("FriendlyUnit3").GetComponent<PlayerInformation>().techPointsMax = player3TechPointsMax;
        GameObject.Find("FriendlyUnit3").GetComponent<PlayerInformation>().techPointsCurrent = player3TechPointsCurrent;
        GameObject.Find("FriendlyUnit3").GetComponent<PlayerInformation>().physicalDamage = player3PhysicalDamage;
        GameObject.Find("FriendlyUnit3").GetComponent<PlayerInformation>().physicalResist = player3PhysicalResist;
        GameObject.Find("FriendlyUnit3").GetComponent<PlayerInformation>().techDamage = player3TechDamage;
        GameObject.Find("FriendlyUnit3").GetComponent<PlayerInformation>().techResist = player3TechResist;


        // Give player4 their stats
        GameObject.Find("FriendlyUnit4").GetComponent<PlayerInformation>().healthPointsMax = player4HealthPointsMax;
        GameObject.Find("FriendlyUnit4").GetComponent<PlayerInformation>().healthPointsCurrent = Player4HealthPointsCurrent;
        GameObject.Find("FriendlyUnit4").GetComponent<PlayerInformation>().techPointsMax = player4TechPointsMax;
        GameObject.Find("FriendlyUnit4").GetComponent<PlayerInformation>().techPointsCurrent = player4TechPointsCurrent;
        GameObject.Find("FriendlyUnit4").GetComponent<PlayerInformation>().physicalDamage = player4PhysicalDamage;
        GameObject.Find("FriendlyUnit4").GetComponent<PlayerInformation>().physicalResist = player4PhysicalResist;
        GameObject.Find("FriendlyUnit4").GetComponent<PlayerInformation>().techDamage = player4TechDamage;
        GameObject.Find("FriendlyUnit4").GetComponent<PlayerInformation>().techResist = player4TechResist;
    }

}
