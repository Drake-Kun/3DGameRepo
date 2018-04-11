using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat: MonoBehaviour {

    public GameObject knightTargetUnit;
    public GameObject archerTargetUnit;
    public GameObject healerTargetUnit;
    public GameObject mageTargetUnit;

    // Knight stats relevant to battle
    public bool knightMagicDamage;
    public int knightMagicDamageValue;
    public bool knightPhysicalDamage;
    public int knightPhysicalDamageValue;

    // Archer stats relevant to battle
    public bool archerMagicDamage;
    public int archerMagicDamageValue;
    public bool archerPhysicalDamage;
    public int archerPhysicalDamageValue;

    // Healer stats relevant to battle
    public bool healerMagicDamage;
    public int healerMagicDamageValue;
    public bool healerPhysicalDamage;
    public int healerPhysicalDamageValue;

    // Mage stats relevant to battle
    public bool mageMagicDamage;
    public int mageMagicDamageValue;
    public bool magePhysicalDamage;
    public int magePhysicalDamageValue;

    // Attacks relevant to all units
    public bool useBasicAttack = false;
    public bool useGuard = false;

    // Attacks relevant to the knight
    public bool useTaunt = false;
    public bool useDouble_edge = false;

    // Attacks relevant to the archer
    public bool useTag = false;
    public bool useSnare = false;

    // Are we doing magic damage?
    public bool magicDamage;

    void Start()
    {
    
    }

    void knightAttack()
    {
        int damageDone = 1;



        if (magicDamage == false)
        {
            damageDone = knightPhysicalDamageValue - knightTargetUnit.GetComponent<EnemyCombatScript>().armorValue;
            if (damageDone <= 0)
            {
                damageDone = 1;
            }
        }

        if (magicDamage == true)
        {
            damageDone = knightMagicDamageValue - knightTargetUnit.GetComponent<EnemyCombatScript>().resistValue;
            if (damageDone <= 0)
            {
                damageDone = 1;
            }
        }

        knightTargetUnit.GetComponent<EnemyCombatScript>().healthPoints -= damageDone;
    }

    void archerAttack()
    {

    }

    void healerAttack()
    {

    }

    void mageAttack()
    {

    }
}
