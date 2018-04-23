using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TurnBasedCombatStateMachine : MonoBehaviour {

    public GameObject combatCanvas;
    public GameObject baseMenuCanvas;
    public GameObject playerSpellsMenuCanvas;
    public GameObject playerSelectEnemyCanvas;

    public GameObject playerTargetUnit;
    public GameObject enemy1TargetUnit;
    public GameObject enemy2TargetUnit;

    public GameObject calculateDamageTargetUnit;

    public int playerHealthValueMax;
    public int playerHealthValue;
    public GameObject PlayerHealthText;

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

        if (GameObject.Find("EnemyUnit2").GetComponent<EnemyInformation>().fallen == true
                && GameObject.Find("EnemyUnit3").GetComponent<EnemyInformation>().fallen == true)
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
                baseMenuCanvas.SetActive(true);
                playerSelectEnemyCanvas.SetActive(false);
                playerSpellsMenuCanvas.SetActive(false);
                currentState = BattleStates.PLAYERCHOICE;

                break;

            case (BattleStates.PLAYERCHOICE):

                if (Input.GetKeyDown(KeyCode.Alpha1) && playerSelectEnemyCanvas.activeSelf && basicAttackSelected)
                {
                    playerSelectEnemyCanvas.SetActive(false);

                    baseMenuCanvas.SetActive(true);
                }

                if (Input.GetKeyDown(KeyCode.Alpha1) && playerSpellsMenuCanvas.activeSelf == true)
                {
                    playerSpellsMenuCanvas.SetActive(false);

                    baseMenuCanvas.SetActive(true);
                }

                break;

            case (BattleStates.ENEMY1CHOICE):
                if (GameObject.Find("EnemyUnit2").GetComponent<EnemyInformation>().fallen)
                {
                    currentState = BattleStates.ENEMY2CHOICE;
                }
                enemy1TargetUnit = GameObject.Find("FriendlyUnit1");
                enemy1Damage += GameObject.Find("EnemyUnit2").GetComponent<EnemyInformation>().physicalDamage;

                currentState = BattleStates.ENEMY2CHOICE;

                break;

            case (BattleStates.ENEMY2CHOICE):
                enemy2TargetUnit = GameObject.Find("FriendlyUnit1");
                enemy2Damage += GameObject.Find("EnemyUnit3").GetComponent<EnemyInformation>().physicalDamage;

                currentState = BattleStates.CALCULATEDAMAGE;

                break;

            case (BattleStates.CALCULATEDAMAGE):

                timer += Time.deltaTime;

                if (timer >= 2)
                {
                    playerTargetUnit.GetComponent<EnemyInformation>().currentHealthPoints -= playerDamage;
                    Debug.Log(playerTargetUnit.name + " takes " + playerDamage + " damage!");
                    playerDamage = 0;
                }

                if (timer >= 4)
                {
                    if (GameObject.Find("EnemyUnit2").GetComponent<EnemyInformation>().fallen == false)
                    {
                        enemy1TargetUnit.GetComponent<PlayerInformation>().healthPointsCurrent -= enemy1Damage;
                        Debug.Log(enemy1TargetUnit.name + " takes " + enemy1Damage + " damage!");
                        enemy1Damage = 0;
                    }
                }

                if (timer >= 6)
                {
                    if (GameObject.Find("EnemyUnit3").GetComponent<EnemyInformation>().fallen == false)
                    {
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
                    GameObject.Find("EnemyUnit2").GetComponent<EnemyInformation>().expGiven +
                        GameObject.Find("EnemyUnit3").GetComponent<EnemyInformation>().expGiven;



                // Bring up a victory message!
                // On click/confirm send player back into world

                break;

            case (BattleStates.LOSE):

                // Bring up a loss message!
                // Send the player back to the main menu

                break;
        }

        playerHealthValueMax = GameObject.Find("FriendlyUnit1").GetComponent<PlayerInformation>().healthPointsMax;
        playerHealthValue = GameObject.Find("FriendlyUnit1").GetComponent<PlayerInformation>().healthPointsCurrent;

        PlayerHealthText.GetComponent<Text>().text = playerHealthValue + "/" + playerHealthValueMax;
    }

    public void OnClickAttack()
    {
        baseMenuCanvas.SetActive(false);
        basicAttackSelected = true;
        playerDamage += GameObject.Find("GameInformation").GetComponent<PlayerInformation>().physicalDamage * 1;
        playerSelectEnemyCanvas.SetActive(true);
    }

    public void OnClickSpells()
    {
        baseMenuCanvas.SetActive(false);

        playerSpellsMenuCanvas.SetActive(true);
    }

    public void OnClickSpellRekt()
    {
        playerSpellsMenuCanvas.SetActive(false);
        spellRektSelected = true;

        playerDamage += GameObject.Find("GameInformation").GetComponent<PlayerInformation>().physicalDamage * 2;
        playerDamage += GameObject.Find("GameInformation").GetComponent<PlayerInformation>().techDamage * 2;

        playerSelectEnemyCanvas.SetActive(true);
    }

    public void OnClickGuard()
    {
        playerResist += GameObject.Find("GameInformation").GetComponent<PlayerInformation>().physicalResist * 1;
        baseMenuCanvas.SetActive(false);
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

    public void OnClickEnemy1Button()
    {
        playerTargetUnit = GameObject.Find("EnemyUnit2");
        playerSelectEnemyCanvas.SetActive(false);
        currentState = BattleStates.ENEMY1CHOICE;
    }

    public void OnClickEnemy2Button()
    {
        playerTargetUnit = GameObject.Find("EnemyUnit3");
        playerSelectEnemyCanvas.SetActive(false);
        currentState = BattleStates.ENEMY1CHOICE;
    }
}
