using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WraithClass : MonoBehaviour {

    public int maxHealth = 10;
    public int health = 10;
    public int physicalDamage = 2;
    public int physicalResist = 6;
    public int techDamage = 6;
    public int techResist = 2;

    public int expGiven = 15;


    void Start()
    {
        GetComponentInParent<EnemyInformation>().maxHealthPoints = maxHealth;
        GetComponentInParent<EnemyInformation>().currentHealthPoints = health;
        GetComponentInParent<EnemyInformation>().physicalDamage = physicalDamage;
        GetComponentInParent<EnemyInformation>().physicalResist = physicalResist;
        GetComponentInParent<EnemyInformation>().techDamage = techDamage;
        GetComponentInParent<EnemyInformation>().techResist = techResist;
        GetComponentInParent<EnemyInformation>().expGiven = expGiven;
    }
}
