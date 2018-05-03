using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyInformationMenu : MonoBehaviour {

    public GameObject enemy1NameText;
    public GameObject enemy2NameText;
    public GameObject enemy3NameText;
    public GameObject enemy4NameText;
    public GameObject enemy5NameText;
    public GameObject enemy6NameText;

    void Update()
    {
        enemy1NameText.GetComponent<Text>().text = GameObject.Find("EnemyUnit1").GetComponentInChildren<EnemyInformation>().Enemy.name;
        enemy2NameText.GetComponent<Text>().text = GameObject.Find("EnemyUnit2").GetComponentInChildren<EnemyInformation>().Enemy.name;
        enemy3NameText.GetComponent<Text>().text = GameObject.Find("EnemyUnit3").GetComponentInChildren<EnemyInformation>().Enemy.name;
        enemy4NameText.GetComponent<Text>().text = GameObject.Find("EnemyUnit4").GetComponentInChildren<EnemyInformation>().Enemy.name;
        enemy5NameText.GetComponent<Text>().text = GameObject.Find("EnemyUnit5").GetComponentInChildren<EnemyInformation>().Enemy.name;
        enemy6NameText.GetComponent<Text>().text = GameObject.Find("EnemyUnit6").GetComponentInChildren<EnemyInformation>().Enemy.name;
    }

}
