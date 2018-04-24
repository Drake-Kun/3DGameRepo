using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TurnBasedCombatStateMachine : MonoBehaviour {

    public GameObject combatCanvas;

    public GameObject player1CombatCanvas;
    public GameObject player2CombatCanvas;
    public GameObject player3CombatCanvas;
    public GameObject player4CombatCanvas;

    public GameObject player1BaseMenuCanvas;
    public GameObject player2BaseMenuCanvas;
    public GameObject player3BaseMenuCanvas;
    public GameObject player4BaseMenuCanvas;

    public GameObject player1SpellsMenuCanvas;
    public GameObject player2SpellsMenuCanvas;
    public GameObject player3SpellsMenuCanvas;
    public GameObject player4SpellMenuCanvas;

    public GameObject player1SelectEnemyCanvas;
    public GameObject player2SelectEnemyCanvas;
    public GameObject player3SelectEnemyCanvas;
    public GameObject player4SelectEnemyCanvas;

    public GameObject player1TargetUnit;
    public GameObject player2TargetUnit;
    public GameObject player3TargetUnit;
    public GameObject player4TargetUnit;

    public GameObject enemy1TargetUnit;
    public GameObject enemy2TargetUnit;
    public GameObject enemy3TargetUnit;
    public GameObject enemy4TargetUnit;
    public GameObject enemy5TargetUnit;
    public GameObject enemy6TargetUnit;

    public GameObject calculateDamageTargetUnit;

    public int playerDamage;
    public int playerResist;

    public bool basicAttackSelected = false;
    public bool spellRektSelected = false;

    public int enemy1Damage;
    public int enemy1Resist;

    public int enemy2Damage;
    public int enemy2Resist;

    public float timer;

    public enum BattleStates
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

    public static BattleStates currentState;

	// Use this for initialization
	void Start () {

        timer = 0;
        currentState = BattleStates.START;

	}

    // Update is called once per frame
    void Update() {
        Debug.Log(currentState);

        if (GameObject.Find("EnemyUnit1").GetComponent<EnemyInformation>().fallen == true
                && GameObject.Find("EnemyUnit2").GetComponent<EnemyInformation>().fallen == true)
        {
            currentState = BattleStates.WIN;
        }

        else if (GameObject.Find("FriendlyUnit1").GetComponent<PlayerInformation>().fallen == true)
        {
            currentState = BattleStates.LOSE;
        }

        switch (currentState)
        {
            case (BattleStates.START):

                combatCanvas.SetActive(true);
                player1BaseMenuCanvas.SetActive(true);
                player1SelectEnemyCanvas.SetActive(false);
                player1SpellsMenuCanvas.SetActive(false);
                currentState = BattleStates.PLAYERCHOICE;

                break;

            case (BattleStates.PLAYERCHOICE):

                if (Input.GetKeyDown(KeyCode.Alpha1) && player1SelectEnemyCanvas.activeSelf && basicAttackSelected)
                {
                    player1SelectEnemyCanvas.SetActive(false);

                    player1BaseMenuCanvas.SetActive(true);
                }

                if (Input.GetKeyDown(KeyCode.Alpha1) && player1SpellsMenuCanvas.activeSelf == true)
                {
                    player1SpellsMenuCanvas.SetActive(false);

                    player1BaseMenuCanvas.SetActive(true);
                }

                break;

            case (BattleStates.ENEMY1CHOICE):
                if (GameObject.Find("EnemyUnit2").GetComponent<EnemyInformation>().fallen)
                {
                    currentState = BattleStates.ENEMY2CHOICE;
                }
                enemy1TargetUnit = GameObject.Find("FriendlyUnit1");
                enemy1Damage += GameObject.Find("EnemyUnit1").GetComponent<EnemyInformation>().physicalDamage;

                currentState = BattleStates.ENEMY2CHOICE;

                break;

            case (BattleStates.ENEMY2CHOICE):
                enemy2TargetUnit = GameObject.Find("FriendlyUnit1");
                enemy2Damage += GameObject.Find("EnemyUnit2").GetComponent<EnemyInformation>().physicalDamage;

                currentState = BattleStates.CALCULATEDAMAGE;

                break;

            case (BattleStates.CALCULATEDAMAGE):

                timer += Time.deltaTime;

                if (timer >= 2)
                {
                    player1TargetUnit.GetComponent<EnemyInformation>().currentHealthPoints -= playerDamage;
                    Debug.Log(player1TargetUnit.name + " takes " + playerDamage + " damage!");
                    playerDamage = 0;
                }

                if (timer >= 4)
                {
                    if (GameObject.Find("EnemyUnit1").GetComponent<EnemyInformation>().fallen == false)
                    {
                        GameObject.Find("EnemyUnit1").GetComponent<EnemyInformation>().attacks = true;
                        enemy1TargetUnit.GetComponent<PlayerInformation>().healthPointsCurrent -= enemy1Damage;
                        Debug.Log(enemy1TargetUnit.name + " takes " + enemy1Damage + " damage!");
                        enemy1Damage = 0;
                    }
                }

                if (timer >= 6)
                {
                    if (GameObject.Find("EnemyUnit2").GetComponent<EnemyInformation>().fallen == false)
                    {
                        GameObject.Find("EnemyUnit2").GetComponent<EnemyInformation>().attacks = true;
                        enemy2TargetUnit.GetComponent<PlayerInformation>().healthPointsCurrent -= enemy2Damage;
                        Debug.Log(enemy2TargetUnit.name + " takes " + enemy2Damage + " damage!");
                        enemy2Damage = 0;
                    }
                    timer = 0;
                    currentState = BattleStates.START;
                }



                //calculateDamageTargetUnit = null;
                break;

            case (BattleStates.WIN):

                GameObject.Find("FriendlyUnit1").GetComponent<PlayerInformation>().currentEXP +=
                    GameObject.Find("EnemyUnit1").GetComponent<EnemyInformation>().expGiven +
                        GameObject.Find("EnemyUnit2").GetComponent<EnemyInformation>().expGiven;
                SceneManager.LoadScene("ThreeChoices");



                // Bring up a victory message!
                // On click/confirm send player back into world

                break;

            case (BattleStates.LOSE):

                SceneManager.LoadScene("MainMenu");
                // Bring up a loss message!
                // Send the player back to the main menu

                break;
        }
    }

    public void OnPlayer1ClickAttack()
    {
        player1BaseMenuCanvas.SetActive(false);
        basicAttackSelected = true;
        playerDamage += GameObject.Find("FriendlyUnit1").GetComponent<PlayerInformation>().physicalDamage * 1;
        player1SelectEnemyCanvas.SetActive(true);
    }

    public void OnPlayer1ClickSpells()
    {
        player1BaseMenuCanvas.SetActive(false);

        player1SpellsMenuCanvas.SetActive(true);
    }

    public void OnPlayer1ClickSpellRekt()
    {
        player1SpellsMenuCanvas.SetActive(false);
        spellRektSelected = true;

        playerDamage += GameObject.Find("FriendlyUnit1").GetComponent<PlayerInformation>().physicalDamage * 2;
        playerDamage += GameObject.Find("FriendlyUnit1").GetComponent<PlayerInformation>().techDamage * 2;

        player1SelectEnemyCanvas.SetActive(true);
    }

    public void OnPlayer1ClickGuard()
    {
        playerResist += GameObject.Find("FriendlyUnit1").GetComponent<PlayerInformation>().physicalResist * 1;
        player1BaseMenuCanvas.SetActive(false);
        currentState = BattleStates.ENEMY1CHOICE;
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

    public void OnPlayer1ClickEnemy1Button()
    {
        player1TargetUnit = GameObject.Find("EnemyUnit1");
        player1SelectEnemyCanvas.SetActive(false);
        player2BaseMenuCanvas.SetActive(true);
    }

    public void OnPlayer1ClickEnemy2Button()
    {
        player1TargetUnit = GameObject.Find("EnemyUnit2");
        player1SelectEnemyCanvas.SetActive(false);
        player2BaseMenuCanvas.SetActive(true);
    }
}
