using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInformation : MonoBehaviour {

    public GameObject SpiderPrefab;
    public GameObject WraithPrefab;

    public GameObject Enemy;

    public int areaID;


    // Animator
    public Animator anim;

    //Enemy stats
    public int maxHealthPoints;
    public int currentHealthPoints;
    public int physicalDamage;
    public int techDamage;
    public int physicalResist;
    public int techResist;

    //Is the enemy poisoned?
    public bool poisoned;
    public int poisonTimer;
    public int poisonDamage;

    public bool fallen = false;
    public bool attacks = false;

    public int expGiven;

    void Start()
    {
        
    }

    void Update()
    {
        if (poisonTimer <= 0)
        {
            poisoned = false;
            poisonTimer = 0;
            poisonDamage = 0;
        }

        if (currentHealthPoints <= 0)
        {
            fallen = true;
            anim.SetBool("Dies", true);
        }

        if (attacks == true)
        {
            anim.SetBool("Attacks", true);
            attacks = false;
        }
        else if (attacks == false)
        {
            anim.SetBool("Attacks", false);
        }
    }

    public void SpawnSpider()
    {
        Enemy = Instantiate(SpiderPrefab, GetComponentInParent<Transform>());
        anim = Enemy.GetComponent<Animator>();
        //ememy.transform.parent = transform;
    }

    public void SpawnWraith()
    {
        Enemy = Instantiate(WraithPrefab, GetComponentInParent<Transform>());
        anim = Enemy.GetComponent<Animator>();
        //ememy.transform.parent = transform;
    }
}
