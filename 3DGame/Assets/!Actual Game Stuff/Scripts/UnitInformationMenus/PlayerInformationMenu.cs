using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInformationMenu : MonoBehaviour {

    //Player1
    public string player1Name;
    public int player1HealthValueMax;
    public int player1HealthValue;
    public GameObject Player1NameText;
    public GameObject Player1HealthText;

    //Player2
    public string player2Name;
    public int player2HealthValueMax;
    public int player2HealthValue;
    public GameObject Player2NameText;
    public GameObject Player2HealthText;

    //Player3
    public string player3Name;
    public int player3HealthValueMax;
    public int player3HealthValue;
    public GameObject Player3NameText;
    public GameObject Player3HealthText;

    //Player4
    public string player4Name;
    public int player4HealthValueMax;
    public int player4HealthValue;
    public GameObject Player4NameText;
    public GameObject Player4HealthText;

    //Enemy1
    public string enemy1Name;
    public int enemy1HealthValueMax;
    public int enemy1HealthValue;
    public GameObject Enemy1NameText;
    public GameObject Enemy1HealthText;

    //Enemy2
    public string enemy2Name;
    public int enemy2HealthValueMax;
    public int enemy2HealthValue;
    public GameObject Enemy2NameText;
    public GameObject Enemy2HealthText;

    //Enemy3
    public string enemy3Name;
    public int enemy3HealthValueMax;
    public int enemy3HealthValue;
    public GameObject Enemy3NameText;
    public GameObject Enemy3HealthText;

    //Enemy4
    public string enemy4Name;
    public int enemy4HealthValueMax;
    public int enemy4HealthValue;
    public GameObject Enemy4NameText;
    public GameObject Enemy4HealthText;

    //Enemy5
    public string enemy5Name;
    public int enemy5HealthValueMax;
    public int enemy5HealthValue;
    public GameObject Enemy5NameText;
    public GameObject Enemy5HealthText;

    //Enemy6
    public string enemy6Name;
    public int enemy6HealthValueMax;
    public int enemy6HealthValue;
    public GameObject Enemy6NameText;
    public GameObject Enemy6HealthText;

    

    void Update () {
        //Player1
        player1Name = GameObject.Find("FriendlyUnit1").GetComponent<PlayerInformation>().playerName;
        player1HealthValueMax = GameObject.Find("FriendlyUnit1").GetComponent<PlayerInformation>().healthPointsMax;
        player1HealthValue = GameObject.Find("FriendlyUnit1").GetComponent<PlayerInformation>().healthPointsCurrent;
        if (player1HealthValue < 0)
        {
            player1HealthValue = 0;
        }
        Player1NameText.GetComponent<Text>().text = player1Name;
        Player1HealthText.GetComponent<Text>().text = player1HealthValue + "   l   " + player1HealthValueMax;

        //Player2
        player2Name = GameObject.Find("FriendlyUnit2").GetComponent<PlayerInformation>().playerName;
        player2HealthValueMax = GameObject.Find("FriendlyUnit2").GetComponent<PlayerInformation>().healthPointsMax;
        player2HealthValue = GameObject.Find("FriendlyUnit2").GetComponent<PlayerInformation>().healthPointsCurrent;
        if (player2HealthValue < 0)
        {
            player2HealthValue = 0;
        }
        Player2NameText.GetComponent<Text>().text = player2Name;
        Player2HealthText.GetComponent<Text>().text = player2HealthValue + "   l   " + player2HealthValueMax;

        //Player3
        player3Name = GameObject.Find("FriendlyUnit3").GetComponent<PlayerInformation>().playerName;
        player3HealthValueMax = GameObject.Find("FriendlyUnit3").GetComponent<PlayerInformation>().healthPointsMax;
        player3HealthValue = GameObject.Find("FriendlyUnit3").GetComponent<PlayerInformation>().healthPointsCurrent;
        if (player3HealthValue < 0)
        {
            player3HealthValue = 0;
        }
        Player3NameText.GetComponent<Text>().text = player3Name;
        Player3HealthText.GetComponent<Text>().text = player3HealthValue + "   l   " + player3HealthValueMax;

        //Player4
        player4Name = GameObject.Find("FriendlyUnit4").GetComponent<PlayerInformation>().playerName;
        player4HealthValueMax = GameObject.Find("FriendlyUnit4").GetComponent<PlayerInformation>().healthPointsMax;
        player4HealthValue = GameObject.Find("FriendlyUnit4").GetComponent<PlayerInformation>().healthPointsCurrent;
        if (player4HealthValue < 0)
        {
            player4HealthValue = 0;
        }
        Player4NameText.GetComponent<Text>().text = player4Name;
        Player4HealthText.GetComponent<Text>().text = player4HealthValue + "   l   " + player4HealthValueMax;

        //Enemy1
        enemy1Name = GameObject.Find("EnemyUnit1").GetComponentInChildren<EnemyInformation>().Enemy.name;
        enemy1HealthValueMax = GameObject.Find("EnemyUnit1").GetComponent<EnemyInformation>().maxHealthPoints;
        enemy1HealthValue = GameObject.Find("EnemyUnit1").GetComponent<EnemyInformation>().currentHealthPoints;
        if (enemy1HealthValue < 0)
        {
            enemy1HealthValue = 0;
        }
        Enemy1HealthText.GetComponent<Text>().text = enemy1HealthValue + "   l   " + enemy1HealthValueMax;

        //Enemy2
        enemy2Name = GameObject.Find("EnemyUnit2").GetComponentInChildren<EnemyInformation>().Enemy.name;
        enemy2HealthValueMax = GameObject.Find("EnemyUnit2").GetComponent<EnemyInformation>().maxHealthPoints;
        enemy2HealthValue = GameObject.Find("EnemyUnit2").GetComponent<EnemyInformation>().currentHealthPoints;
        if (enemy2HealthValue < 0)
        {
            enemy2HealthValue = 0;
        }
        Enemy2HealthText.GetComponent<Text>().text = enemy2HealthValue + "   l   " + enemy2HealthValueMax;

        //Enemy3
        enemy3Name = GameObject.Find("EnemyUnit3").GetComponentInChildren<EnemyInformation>().Enemy.name;
        enemy3HealthValueMax = GameObject.Find("EnemyUnit3").GetComponent<EnemyInformation>().maxHealthPoints;
        enemy3HealthValue = GameObject.Find("EnemyUnit3").GetComponent<EnemyInformation>().currentHealthPoints;
        if (enemy3HealthValue < 0)
        {
            enemy3HealthValue = 0;
        }
        Enemy3HealthText.GetComponent<Text>().text = enemy3HealthValue + "   l   " + enemy3HealthValueMax;

        //Enemy4
        enemy4Name = GameObject.Find("EnemyUnit4").GetComponentInChildren<EnemyInformation>().Enemy.name;
        enemy4HealthValueMax = GameObject.Find("EnemyUnit4").GetComponent<EnemyInformation>().maxHealthPoints;
        enemy4HealthValue = GameObject.Find("EnemyUnit4").GetComponent<EnemyInformation>().currentHealthPoints;
        if (enemy4HealthValue < 0)
        {
            enemy4HealthValue = 0;
        }
        Enemy4HealthText.GetComponent<Text>().text = enemy4HealthValue + "   l   " + enemy4HealthValueMax;

        //Enemy5
        enemy5Name = GameObject.Find("EnemyUnit5").GetComponentInChildren<EnemyInformation>().Enemy.name;
        enemy5HealthValueMax = GameObject.Find("EnemyUnit5").GetComponent<EnemyInformation>().maxHealthPoints;
        enemy5HealthValue = GameObject.Find("EnemyUnit5").GetComponent<EnemyInformation>().currentHealthPoints;
        if (enemy5HealthValue < 0)
        {
            enemy5HealthValue = 0;
        }
        Enemy5HealthText.GetComponent<Text>().text = enemy5HealthValue + "   l   " + enemy5HealthValueMax;

        //Enemy6
        enemy6Name = GameObject.Find("EnemyUnit6").GetComponentInChildren<EnemyInformation>().Enemy.name;
        enemy6HealthValueMax = GameObject.Find("EnemyUnit6").GetComponent<EnemyInformation>().maxHealthPoints;
        enemy6HealthValue = GameObject.Find("EnemyUnit6").GetComponent<EnemyInformation>().currentHealthPoints;
        if (enemy6HealthValue < 0)
        {
            enemy6HealthValue = 0;
        }
        Enemy6HealthText.GetComponent<Text>().text = enemy6HealthValue + "   l   " + enemy6HealthValueMax;
    }
}
