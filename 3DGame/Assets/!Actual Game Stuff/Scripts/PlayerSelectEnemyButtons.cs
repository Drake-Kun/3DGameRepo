using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelectEnemyButtons : MonoBehaviour {

    public GameObject enemy1SpiderButton;
    public GameObject enemy2SpiderButton;
    public GameObject enemy3SpiderButton;
    public GameObject enemy4SpiderButton;
    public GameObject enemy5SpiderButton;
    public GameObject enemy6SpiderButton;

    public GameObject enemy1WraithButton;
    public GameObject enemy2WraithButton;
    public GameObject enemy3WraithButton;
    public GameObject enemy4WraithButton;
    public GameObject enemy5WraithButton;
    public GameObject enemy6WraithButton;


    void Start () {

        // Enemy1 Button spawn
        if (GameObject.Find("EnemyUnit1").GetComponent<EnemyClassSpawnScript>().enemyType == 1)
        {
            Instantiate(enemy1SpiderButton);
        }

        else if (GameObject.Find("EnemyUnit1").GetComponent<EnemyClassSpawnScript>().enemyType == 2)
        {
            Instantiate(enemy1WraithButton);
        }


        // Enemy2 Button Spawn
        if (GameObject.Find("EnemyUnit2").GetComponent<EnemyClassSpawnScript>().enemyType == 1)
        {
            Instantiate(enemy2SpiderButton);
        }

        else if (GameObject.Find("EnemyUnit2").GetComponent<EnemyClassSpawnScript>().enemyType == 2)
        {
            Instantiate(enemy2WraithButton);
        }


        // Enemy3 Button Spawn
        if (GameObject.Find("EnemyUnit3").GetComponent<EnemyClassSpawnScript>().enemyType == 1)
        {
            Instantiate(enemy3SpiderButton);
        }

        else if (GameObject.Find("EnemyUnit3").GetComponent<EnemyClassSpawnScript>().enemyType == 2)
        {
            Instantiate(enemy3WraithButton);
        }


        // Enemy4 Button Spawn
        if (GameObject.Find("EnemyUnit4").GetComponent<EnemyClassSpawnScript>().enemyType == 1)
        {
            Instantiate(enemy4SpiderButton);
        }

        else if (GameObject.Find("EnemyUnit4").GetComponent<EnemyClassSpawnScript>().enemyType == 2)
        {
            Instantiate(enemy4WraithButton);
        }


        // Enemy5 Button Spawn
        if (GameObject.Find("EnemyUnit5").GetComponent<EnemyClassSpawnScript>().enemyType == 1)
        {
            Instantiate(enemy5SpiderButton);
        }

        else if (GameObject.Find("EnemyUnit5").GetComponent<EnemyClassSpawnScript>().enemyType == 2)
        {
            Instantiate(enemy5WraithButton);
        }


        // Enemy6 Button Spawn
        if (GameObject.Find("EnemyUnit6").GetComponent<EnemyClassSpawnScript>().enemyType == 1)
        {
            Instantiate(enemy6SpiderButton);
        }

        else if (GameObject.Find("EnemyUnit6").GetComponent<EnemyClassSpawnScript>().enemyType == 2)
        {
            Instantiate(enemy6WraithButton);
        }
    }
}
