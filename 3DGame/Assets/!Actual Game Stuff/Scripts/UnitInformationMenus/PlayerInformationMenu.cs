using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInformationMenu : MonoBehaviour {

    public string player1Name;
    public int player1HealthValueMax;
    public int player1HealthValue;
    public GameObject Player1NameText;
    public GameObject Player1HealthText;

    public string player2Name;
    public int player2HealthValueMax;
    public int player2HealthValue;
    public GameObject Player2NameText;
    public GameObject Player2HealthText;

    public string player3Name;
    public int player3HealthValueMax;
    public int player3HealthValue;
    public GameObject Player3NameText;
    public GameObject Player3HealthText;

    public string player4Name;
    public int player4HealthValueMax;
    public int player4HealthValue;
    public GameObject Player4NameText;
    public GameObject Player4HealthText;
	
	void Update () {
        player1Name = GameObject.Find("FriendlyUnit1").GetComponent<PlayerInformation>().playerName;
        player1HealthValueMax = GameObject.Find("FriendlyUnit1").GetComponent<PlayerInformation>().healthPointsMax;
        player1HealthValue = GameObject.Find("FriendlyUnit1").GetComponent<PlayerInformation>().healthPointsCurrent;
        Player1NameText.GetComponent<Text>().text = player1Name;
        Player1HealthText.GetComponent<Text>().text = player1HealthValue + "   l   " + player1HealthValueMax;

        player2Name = GameObject.Find("FriendlyUnit2").GetComponent<PlayerInformation>().playerName;
        player2HealthValueMax = GameObject.Find("FriendlyUnit2").GetComponent<PlayerInformation>().healthPointsMax;
        player2HealthValue = GameObject.Find("FriendlyUnit2").GetComponent<PlayerInformation>().healthPointsCurrent;
        Player2NameText.GetComponent<Text>().text = player2Name;
        Player2HealthText.GetComponent<Text>().text = player2HealthValue + "   l   " + player2HealthValueMax;

        player3Name = GameObject.Find("FriendlyUnit3").GetComponent<PlayerInformation>().playerName;
        player3HealthValueMax = GameObject.Find("FriendlyUnit3").GetComponent<PlayerInformation>().healthPointsMax;
        player3HealthValue = GameObject.Find("FriendlyUnit3").GetComponent<PlayerInformation>().healthPointsCurrent;
        Player3NameText.GetComponent<Text>().text = player3Name;
        Player3HealthText.GetComponent<Text>().text = player3HealthValue + "   l   " + player3HealthValueMax;

        player4Name = GameObject.Find("FriendlyUnit4").GetComponent<PlayerInformation>().playerName;
        player4HealthValueMax = GameObject.Find("FriendlyUnit4").GetComponent<PlayerInformation>().healthPointsMax;
        player4HealthValue = GameObject.Find("FriendlyUnit4").GetComponent<PlayerInformation>().healthPointsCurrent;
        Player4NameText.GetComponent<Text>().text = player4Name;
        Player4HealthText.GetComponent<Text>().text = player4HealthValue + "   l   " + player4HealthValueMax;

    }
}
