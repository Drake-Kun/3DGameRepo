using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TurnBasedCombatStateMachine : MonoBehaviour {

    public GameObject playerTargetUnit;
    public GameObject enemy1TargetUnit;
    public GameObject enemy2TargetUnit;

    public GameObject calculateDamageTargetUnit;

    public GameObject PlayerHealthText;

    public GameObject Enemy1HealthText;

    public GameObject Enemy2HealthText;

    public int playerDamage;
    public int playerResist;

    public bool basicAttackSelected = false;
    public bool spellRektSelected = false;

    public int enemy1Damage;
    public int enemy1Resist;

    public int enemy2Damage;
    public int enemy2Resist;

    public enum battleStates
    {
        START,
        PLAYERCHOICE,
        CALCULATEDAMAGE,
        ENEMY1CHOICE,
        ENEMY2CHOICE,
        LOSE,
        WIN,
        FLED
    }

    public static battleStates currentState;

	// Use this for initialization
	void Start () {

        

        currentState = battleStates.START;
	}

    // Update is called once per frame
    void Update() {
        Debug.Log(currentState);

        if (GameObject.Find("EnemyUnit2").GetComponent<EnemyInformation>().currentHealthPoints <= 0
                && GameObject.Find("EnemyUnit3").GetComponent<EnemyInformation>().currentHealthPoints <= 0)
        {
            currentState = battleStates.WIN;
        }

        else if (GameObject.Find("FriendlyUnit1").GetComponent<PlayerInformation>().healthPointsCurrent <= 0)
        {
            currentState = battleStates.LOSE;
        }

        if (currentState == battleStates.PLAYERCHOICE)
        {
            GameObject.Find("CombatCanvas").SetActive(true);
        }

        else
        {
            GameObject.Find("CombatCanvas").SetActive(false);
        }

        switch (currentState)
        {
            case (battleStates.START):

                currentState = battleStates.PLAYERCHOICE;

                break;

            case (battleStates.PLAYERCHOICE):

                if (Input.GetButton("Escape") && GameObject.Find("PlayerSelectEnemyCanvas").activeSelf == true)
                {
                    GameObject.Find("PlayerSelectEnemyCanvas").GetComponentInChildren<GameObject>().SetActive(false);
                    GameObject.Find("PlayerSpellMenuButtons").GetComponentInChildren<GameObject>().SetActive(false);

                    GameObject.Find("BaseMenuButtons").GetComponentInChildren<GameObject>().SetActive(true);
                }

                break;

            case (battleStates.ENEMY1CHOICE):
                enemy1TargetUnit = GameObject.Find("FriendlyUnit1");
                enemy1Damage += GameObject.Find("EnemyUnit2").GetComponent<EnemyInformation>().physicalDamage;

                break;

            case (battleStates.ENEMY2CHOICE):
                enemy2TargetUnit = GameObject.Find("FriendlyUnit1");
                enemy2Damage += GameObject.Find("EnemyUnit3").GetComponent<EnemyInformation>().physicalDamage;

                break;

            case (battleStates.CALCULATEDAMAGE):
                float timer = 0;
                timer += Time.deltaTime;

                if (timer >= 2)
                {
                    playerTargetUnit.GetComponent<EnemyInformation>().currentHealthPoints -= playerDamage;
                    playerDamage = 0;
                }

                if (timer >= 4)
                {
                    enemy1TargetUnit.GetComponent<PlayerInformation>().healthPointsCurrent -= enemy1Damage;
                    enemy1Damage = 0;
                }

                if (timer >= 6)
                {
                    playerTargetUnit.GetComponent<PlayerInformation>().healthPointsCurrent -= enemy2Damage;
                    enemy2Damage = 0;
                    currentState = battleStates.START;
                }



                //calculateDamageTargetUnit = null;
                break;

            case (battleStates.WIN):

                GameObject.Find("FriendlyUnit1").GetComponent<PlayerInformation>().currentEXP +=
                    GameObject.Find("EnemyUnit2").GetComponent<EnemyInformation>().expGiven +
                        GameObject.Find("EnemyUnit3").GetComponent<EnemyInformation>().expGiven;

                // Bring up a victory message!
                // On click/confirm send player back into world

                break;

            case (battleStates.LOSE):

                // Bring up a loss message!
                // Send the player back to the main menu

                break;
        }

        PlayerHealthText.GetComponent<Text>().text = GameObject.Find("FriendlyUnit1").GetComponent<PlayerInformation>().healthPointsCurrent + "/" + GameObject.Find("FriendlyUnit1").GetComponent<PlayerInformation>().healthPointsMax;
        Enemy1HealthText.GetComponent<Text>().text = GameObject.Find("EnemyUnit2").GetComponent<EnemyInformation>().currentHealthPoints + "";
        Enemy2HealthText.GetComponent<Text>().text = GameObject.Find("EnemyUnit3").GetComponent<EnemyInformation>().currentHealthPoints + "";
    }

    public void OnClickAttack()
    {
        GameObject.Find("BaseMenuButtons").SetActive(false);
        basicAttackSelected = true;
        playerDamage += GameObject.Find("GameInformation").GetComponent<PlayerInformation>().physicalDamage * 1;
        GameObject.Find("PlayerSelectEnemyCanvas").SetActive(true);
    }

    public void OnClickSpells()
    {
        GameObject.Find("BaseMenuButtons").SetActive(false);

        GameObject.Find("PlayerSpellsMenuButtons").SetActive(true);
    }

    public void OnClickSpellRekt()
    {
        GameObject.Find("PlayerSpellsMenuButton").SetActive(false);
        spellRektSelected = true;

        playerDamage += GameObject.Find("GameInformation").GetComponent<PlayerInformation>().physicalDamage * 2;
        playerDamage += GameObject.Find("GameInformation").GetComponent<PlayerInformation>().techDamage * 2;

        GameObject.Find("PlayerSelectEnemyCanvas").SetActive(true);
    }

    public void OnClickGuard()
    {
        playerResist += GameObject.Find("GameInformation").GetComponent<PlayerInformation>().physicalResist * 1;
        GameObject.Find("BaseMenuButtons").SetActive(false);
        currentState = battleStates.ENEMY1CHOICE;
    }

    public void OnClickFlee()
    {
        SceneManager.LoadScene("ThreeChoices");

        //int fleeOutcome = Random.Range(0, 100);
        //if (fleeOutcome > 60)
        //{
            // You got away
            // Exit the combat scene
        //}
    }

    public void OnClickEnemy1Button()
    {
        playerTargetUnit = GameObject.Find("EnemyUnit2");
        GameObject.Find("BaseMenuButtons").SetActive(false);
        currentState = battleStates.ENEMY1CHOICE;
    }

    public void OnClickEnemy2Button()
    {
        playerTargetUnit = GameObject.Find("EnemyUnit3");
        GameObject.Find("BaseMenuButtons").SetActive(false);
        currentState = battleStates.ENEMY1CHOICE;
    }
}
