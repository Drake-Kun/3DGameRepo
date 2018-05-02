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
        player1Level = 1;
        player1CurrentEXP = 0;
        player1NeededEXP = 10;
    }
}
