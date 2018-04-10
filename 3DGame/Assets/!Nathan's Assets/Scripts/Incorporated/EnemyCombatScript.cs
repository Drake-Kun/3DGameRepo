using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombatScript : MonoBehaviour {

    public GameObject targetUnit;

    public int maxHealthValue;
    int healthPoints;
    public int attackValue;
    public int armorValue;
    public int magicValue;
    public int resistValue;

    public bool canUseFireball;
    public bool useFireball;

    public bool canUseCurse;
    public bool useCurse;

    public bool canUseTaunt;
    public bool useTaunt;

    public bool canUseHeal;
    public bool useHeal;

    public float allyE1MaxHealthPoints;
    public int allyE1HealthPoints;

    public float allyE2MaxHealthPoints;
    public int allyE2HealthPoints;

    public float allyE3MaxHealthPoints;
    public int allyE3HealthPoints;

    public float allyE4MaxHealthPoints;
    public int allyE4HealthPoints;

    public float allyE5MaxHealthPoints;
    public int allyE5HealthPoints;

    void Start()
    {
        healthPoints = maxHealthValue;
    }
    void CheckForHealing()
    {
        if (allyE1HealthPoints < allyE1MaxHealthPoints * 0.5)
        {
            targetUnit = GameObject.Find("EnemyUnit1");
            useHeal = true;
        }
    }

    void TakeTurn()
    {
        CheckForHealing();
    }
}
