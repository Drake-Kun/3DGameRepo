using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderClass : MonoBehaviour {
    
    public int health = 15;
    public int physicalDamage = 8;
    public int physicalResist = 4;
    public int techDamage = 4;
    public int techResist = 2;

    public int expGiven = 10;

    void Start()
    {
        GetComponentInParent<EnemyInformation>().currentHealthPoints = health;
        GetComponentInParent<EnemyInformation>().physicalDamage = physicalDamage;
        GetComponentInParent<EnemyInformation>().physicalResist = physicalResist;
        GetComponentInParent<EnemyInformation>().techDamage = techDamage;
        GetComponentInParent<EnemyInformation>().techResist = techResist;
        GetComponentInParent<EnemyInformation>().expGiven = expGiven;

        GetComponentInParent<EnemyInformation>().anim = GetComponent<Animator>();
    }

    void Update()
    {
        
    }
}
