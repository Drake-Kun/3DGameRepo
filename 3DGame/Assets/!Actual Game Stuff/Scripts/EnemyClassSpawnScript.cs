using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyClassSpawnScript : MonoBehaviour {

    // Our enemy types:
    // 1 = Spider
    // 2 = Wraith
    public int enemyType;

    public GameObject SpiderPrefab;
    public GameObject WraithPrefab;

    public int areaID;

	// Use this for initialization
	void Start () {
        if (areaID == 1)
        {
            int enemyType = Random.Range(1, 3);
            if (enemyType == 1)
            {
                Instantiate(SpiderPrefab);
            }

            else if (enemyType == 2)
            {
                Instantiate(WraithPrefab);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
