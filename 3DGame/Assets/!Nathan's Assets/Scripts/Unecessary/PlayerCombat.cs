using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat: MonoBehaviour {

    public GameObject knightTargetUnit;
    public GameObject archerTargetUnit;
    public GameObject healerTargetUnit;
    public GameObject mageTargetUnit;

    // Knight stats relevant to battle
    public int healthPointsMax;
    public int healthPoints;
    public int physicalDamage;
    public int magicDamage;
    public int armorValue;
    public int resistValue;
    public string damageType;


    // Attacks relevant to all units
    public bool useBasicAttack = false;
    public bool useGuard = false;

    // Attacks relevant to the knight
    public bool useTaunt = false;
    public bool useDouble_edge = false;

    // Attacks relevant to the archer
    public bool useTag = false;
    public bool useSnare = false;

    // Attacks relevant to the healer
    public bool useHeal = false;
    public bool useDispel = false;

    // Attacks relevant to the mage
    public bool useFireball = false;
    public bool useFreeze = false;

    void Start()
    {
        // The knight is "FriendlyUnit1", so if we're "FriendlyUnit1" we will grab the knight's stats from "PlayerInformation"
        if (gameObject.name == "FriendlyUnit1")
        {
            GetComponent<PlayerCombat>().healthPointsMax = GameObject.Find("PlayerInformation").GetComponent<PlayerInformation>().knightMaxHealth;
            GetComponent<PlayerCombat>().healthPoints = GameObject.Find("PlayerInformation").GetComponent<PlayerInformation>().knightHealthPoints;
            GetComponent<PlayerCombat>().physicalDamage = GameObject.Find("PlayerInformation").GetComponent<PlayerInformation>().knightPhysicalDamage;
            GetComponent<PlayerCombat>().magicDamage = GameObject.Find("PlayerInformation").GetComponent<PlayerInformation>().knightMagicDamage;
            GetComponent<PlayerCombat>().armorValue = GameObject.Find("PlayerInformation").GetComponent<PlayerInformation>().knightArmorValue;
            GetComponent<PlayerCombat>().resistValue = GameObject.Find("PlayerInformation").GetComponent<PlayerInformation>().knightResistValue;
        }

        // The archer is "FriendlyUnit2", so if we're "FriendlyUnit2" we will grab the archer's stats from "PlayerInformation"
        if (gameObject.name == "FriendlyUnit2")
        {
            GetComponent<PlayerCombat>().healthPointsMax = GameObject.Find("PlayerInformation").GetComponent<PlayerInformation>().archerMaxHealth;
            GetComponent<PlayerCombat>().healthPoints = GameObject.Find("PlayerInformation").GetComponent<PlayerInformation>().archerHealthPoints;
            GetComponent<PlayerCombat>().physicalDamage = GameObject.Find("PlayerInformation").GetComponent<PlayerInformation>().archerPhysicalDamage;
            GetComponent<PlayerCombat>().magicDamage = GameObject.Find("PlayerInformation").GetComponent<PlayerInformation>().archerMagicDamage;
            GetComponent<PlayerCombat>().armorValue = GameObject.Find("PlayerInformation").GetComponent<PlayerInformation>().archerArmorValue;
            GetComponent<PlayerCombat>().resistValue = GameObject.Find("PlayerInformation").GetComponent<PlayerInformation>().archerResistValue;
        }

        // The healer is "FriendlyUnit3", so if we're "FriendlyUnit3" we will grab the healer's stats from "PlayerInformation"
        if (gameObject.name == "FriendlyUnit3")
        {
            GetComponent<PlayerCombat>().healthPointsMax = GameObject.Find("PlayerInformation").GetComponent<PlayerInformation>().healerMaxHealth;
            GetComponent<PlayerCombat>().healthPoints = GameObject.Find("PlayerInformation").GetComponent<PlayerInformation>().healerHealthPoints;
            GetComponent<PlayerCombat>().physicalDamage = GameObject.Find("PlayerInformation").GetComponent<PlayerInformation>().healerPhysicalDamage;
            GetComponent<PlayerCombat>().magicDamage = GameObject.Find("PlayerInformation").GetComponent<PlayerInformation>().healerMagicDamage;
            GetComponent<PlayerCombat>().armorValue = GameObject.Find("PlayerInformation").GetComponent<PlayerInformation>().healerArmorValue;
            GetComponent<PlayerCombat>().resistValue = GameObject.Find("PlayerInformation").GetComponent<PlayerInformation>().healerResistValue;
        }

        // The mage is "FriendlyUnit4", so if we're "FriendlyUnit4" we will grab the mage's stats from "PlayerInformation"
        if (gameObject.name == "FriendlyUnit4")
        {
            GetComponent<PlayerCombat>().healthPointsMax = GameObject.Find("PlayerInformation").GetComponent<PlayerInformation>().mageMaxHealth;
            GetComponent<PlayerCombat>().healthPoints = GameObject.Find("PlayerInformation").GetComponent<PlayerInformation>().mageHealthPoints;
            GetComponent<PlayerCombat>().physicalDamage = GameObject.Find("PlayerInformation").GetComponent<PlayerInformation>().magePhysicalDamage;
            GetComponent<PlayerCombat>().magicDamage = GameObject.Find("PlayerInformation").GetComponent<PlayerInformation>().mageMagicDamage;
            GetComponent<PlayerCombat>().armorValue = GameObject.Find("PlayerInformation").GetComponent<PlayerInformation>().mageArmorValue;
            GetComponent<PlayerCombat>().resistValue = GameObject.Find("PlayerInformation").GetComponent<PlayerInformation>().mageResistValue;
        }
    }

    void Update()
    {

    }

    void knightAttack()
    {
        armorValue = GameObject.Find("PlayerInformation").GetComponent<PlayerInformation>().knightArmorValue;

        if (useDouble_edge == true)
        {
            physicalDamage *= 2;
            GetComponent<PlayerInformation>().knightHealthPoints -= GameObject.Find("PlayerInformation").GetComponent<PlayerInformation>().knightPhysicalDamage;
            useDouble_edge = false;
        }

        if (useTaunt == true)
        {
            int successRating = Random.Range(0, 7);
            if (successRating >= 1)
            {
                GameObject.Find("EnemyUnit1").GetComponent<EnemyCombatScript>().targetUnit = gameObject;
            }

            if (successRating >= 2)
            {
                GameObject.Find("EnemyUnit2").GetComponent<EnemyCombatScript>().targetUnit = gameObject;
            }

            if (successRating >= 3)
            {
                GameObject.Find("EnemyUnit3").GetComponent<EnemyCombatScript>().targetUnit = gameObject;
            }

            if (successRating >= 4)
            {
                GameObject.Find("EnemyUnit4").GetComponent<EnemyCombatScript>().targetUnit = gameObject;
            }

            if (successRating >= 5)
            {
                GameObject.Find("EnemyUnit5").GetComponent<EnemyCombatScript>().targetUnit = gameObject;
            }

            if (successRating >= 6)
            {
                GameObject.Find("EnemyUnit6").GetComponent<EnemyCombatScript>().targetUnit = gameObject;
            }

            armorValue *= 2;
            
            useTaunt = false;
        }

        if (damageType == "Physical")
        {
            knightTargetUnit.GetComponent<EnemyCombatScript>().healthPoints -= physicalDamage + knightTargetUnit.GetComponent<EnemyCombatScript>().armorValue;
        }

        else
        {
            knightTargetUnit.GetComponent<EnemyCombatScript>().healthPoints -= magicDamage + knightTargetUnit.GetComponent<EnemyCombatScript>().resistValue;
        }
    }

    void archerAttack()
    {

    }

    void healerAttack()
    {
        if (useHeal == true)
        {
            healerTargetUnit.GetComponent<PlayerCombat>().healthPoints += magicDamage;        }
    }

    void mageAttack()
    {

    }

    void ReadyCombat()
    {

    }

    void RunCombat()
    {

    }
}
