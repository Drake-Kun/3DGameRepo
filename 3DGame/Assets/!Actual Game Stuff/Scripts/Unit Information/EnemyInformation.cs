using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInformation : MonoBehaviour {

    Animator anim;

    public int currentHealthPoints;
    public int physicalDamage;
    public int techDamage;
    public int physicalResist;
    public int techResist;

    public bool fallen = false;
    public bool attacks = false;

    public int expGiven;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
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
    }
}
