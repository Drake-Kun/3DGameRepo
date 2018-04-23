using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInformation : MonoBehaviour {

    public int currentHealthPoints = 5;
    public int physicalDamage = 2;
    public int techDamage = 1;
    public int physicalResist = 1;
    public int techResist = 1;

    public bool fallen = false;

    public int expGiven = 5;

    void Update()
    {
        if (currentHealthPoints <= 0)
        {
            fallen = true;
        }
    }
}
