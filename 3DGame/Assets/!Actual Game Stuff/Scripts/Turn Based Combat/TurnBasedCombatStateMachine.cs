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

    public int player1Damage;
    public int player1Resist;
    public int player2Damage;
    public int player2Resist;
    public int player3Damage;
    public int player3Resist;
    public int player4Damage;
    public int player4Resist;

    public bool player1BasicAttackSelected = false;
    public bool player2BasicAttackSelected = false;
    public bool player3BasicAttackSelected = false;
    public bool player4BasicAttackSelected = false;


    public bool spellRektSelected = false;

    public bool enemy1ValidUnitSelection;
    public int enemy1Damage;
    public int enemy1Resist;

    public bool enemy2ValidUnitSelection;
    public int enemy2Damage;
    public int enemy2Resist;

    public bool enemy3ValidUnitSelection;
    public int enemy3Damage;
    public int enemy3Resist;

    public bool enemy4ValidUnitSelection;
    public int enemy4Damage;
    public int enemy4Resist;

    public bool enemy5ValidUnitSelection;
    public int enemy5Damage;
    public int enemy5Resist;

    public bool enemy6ValidUnitSelection;
    public int enemy6Damage;
    public int enemy6Resist;

    public float timer;

    public enum BattleStates
    {
        START,
        PLAYERCHOICE,
        CALCULATEDAMAGE,
        ENEMYCHOICE,
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

                if (Input.GetKeyDown(KeyCode.Alpha1) && player1SelectEnemyCanvas.activeSelf && player1BasicAttackSelected)
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

            case (BattleStates.ENEMYCHOICE):


                

                if (GameObject.Find("EnemyUnit1").GetComponent<EnemyInformation>().fallen == false || enemy1TargetUnit.GetComponent<PlayerInformation>().fallen == true)
                {
                    enemy1Damage += GameObject.Find("EnemyUnit1").GetComponent<EnemyInformation>().physicalDamage;
                    int unitSelected = Random.Range(0, 4);

                    enemy1TargetUnit = GameObject.Find("FriendlyUnit" + unitSelected);
                    if (enemy1TargetUnit.GetComponent<PlayerInformation>().fallen == false)
                    {
                        enemy1ValidUnitSelection = true;
                    }

                    else
                    {
                        enemy1ValidUnitSelection = false;
                    }
                }

                if (GameObject.Find("EnemyUnit2").GetComponent<EnemyInformation>().fallen == false || enemy2TargetUnit.GetComponent<PlayerInformation>().fallen == true)
                {
                    enemy2Damage += GameObject.Find("EnemyUnit2").GetComponent<EnemyInformation>().physicalDamage;
                    int unitSelected = Random.Range(0, 4);

                    enemy2TargetUnit = GameObject.Find("FriendlyUnit" + unitSelected);
                    if (enemy2TargetUnit.GetComponent<PlayerInformation>().fallen == false)
                    {
                        enemy2ValidUnitSelection = true;
                    }

                    else
                    {
                        enemy2ValidUnitSelection = false;
                    }
                }

                if (GameObject.Find("EnemyUnit3").GetComponent<EnemyInformation>().fallen == false || enemy3TargetUnit.GetComponent<PlayerInformation>().fallen == true)
                {
                    enemy3Damage += GameObject.Find("EnemyUnit3").GetComponent<EnemyInformation>().physicalDamage;
                    int unitSelected = Random.Range(0, 4);

                    enemy3TargetUnit = GameObject.Find("FriendlyUnit" + unitSelected);
                    if (enemy3TargetUnit.GetComponent<PlayerInformation>().fallen == false)
                    {
                        enemy3ValidUnitSelection = true;
                    }

                    else
                    {
                        enemy3ValidUnitSelection = false;
                    }
                }

                if (GameObject.Find("EnemyUnit4").GetComponent<EnemyInformation>().fallen == false || enemy4TargetUnit.GetComponent<PlayerInformation>().fallen == true)
                {
                    enemy4Damage += GameObject.Find("EnemyUnit4").GetComponent<EnemyInformation>().physicalDamage;
                    int unitSelected = Random.Range(0, 4);

                    enemy4TargetUnit = GameObject.Find("FriendlyUnit" + unitSelected);
                    if (enemy4TargetUnit.GetComponent<PlayerInformation>().fallen == false)
                    {
                        enemy4ValidUnitSelection = true;
                    }

                    else
                    {
                        enemy4ValidUnitSelection = false;
                    }
                }

                if (GameObject.Find("EnemyUnit5").GetComponent<EnemyInformation>().fallen == false || enemy5TargetUnit.GetComponent<PlayerInformation>().fallen == true)
                {
                    enemy5Damage += GameObject.Find("EnemyUnit5").GetComponent<EnemyInformation>().physicalDamage;
                    int unitSelected = Random.Range(0, 4);

                    enemy5TargetUnit = GameObject.Find("FriendlyUnit" + unitSelected);
                    if (enemy5TargetUnit.GetComponent<PlayerInformation>().fallen == false)
                    {
                        enemy5ValidUnitSelection = true;
                    }

                    else
                    {
                        enemy5ValidUnitSelection = false;
                    }
                }

                if (GameObject.Find("EnemyUnit6").GetComponent<EnemyInformation>().fallen == false || enemy6TargetUnit.GetComponent<PlayerInformation>().fallen == true)
                {
                    enemy6Damage += GameObject.Find("EnemyUnit6").GetComponent<EnemyInformation>().physicalDamage;
                    int unitSelected = Random.Range(0, 4);

                    enemy6TargetUnit = GameObject.Find("FriendlyUnit" + unitSelected);
                    if (enemy6TargetUnit.GetComponent<PlayerInformation>().fallen == false)
                    {
                        enemy6ValidUnitSelection = true;
                    }

                    else
                    {
                        enemy6ValidUnitSelection = false;
                    }
                }


                if (enemy1ValidUnitSelection == true && enemy2ValidUnitSelection == true && enemy3ValidUnitSelection == true && enemy4ValidUnitSelection == true && enemy5ValidUnitSelection == true && enemy6ValidUnitSelection == true)
                {
                    currentState = BattleStates.CALCULATEDAMAGE;
                }

                break;

                

                


            case (BattleStates.CALCULATEDAMAGE):

                timer += Time.deltaTime;

                if (timer >= 2)
                {
                    player1TargetUnit.GetComponent<EnemyInformation>().currentHealthPoints -= player1Damage;
                    Debug.Log(player1TargetUnit.name + " takes " + player1Damage + " damage!");
                    player1Damage = 0;
                }

                if (timer >= 4)
                {
                    player2TargetUnit.GetComponent<EnemyInformation>().currentHealthPoints -= player2Damage;
                    Debug.Log(player2TargetUnit.name + " takes " + player2Damage + " damage!");
                    player2Damage = 0;
                }

                if (timer >= 6)
                {
                    player3TargetUnit.GetComponent<EnemyInformation>().currentHealthPoints -= player3Damage;
                    Debug.Log(player3TargetUnit.name + " takes " + player3Damage + " damage!");
                    player3Damage = 0;
                }

                if (timer >= 8)
                {
                    player4TargetUnit.GetComponent<EnemyInformation>().currentHealthPoints -= player4Damage;
                    Debug.Log(player1TargetUnit.name + " takes " + player4Damage + " damage!");
                    player4Damage = 0;
                }

                if (timer >= 10)
                {
                    if (GameObject.Find("EnemyUnit1").GetComponent<EnemyInformation>().fallen == false)
                    {
                        GameObject.Find("EnemyUnit1").GetComponent<EnemyInformation>().attacks = true;
                        enemy1TargetUnit.GetComponent<PlayerInformation>().healthPointsCurrent -= enemy1Damage;
                        Debug.Log(enemy1TargetUnit.name + " takes " + enemy1Damage + " damage!");
                        enemy1Damage = 0;
                    }
                    else
                    {
                        timer += 2;
                    }
                }

                if (timer >= 12)
                {
                    if (GameObject.Find("EnemyUnit2").GetComponent<EnemyInformation>().fallen == false)
                    {
                        GameObject.Find("EnemyUnit2").GetComponent<EnemyInformation>().attacks = true;
                        enemy2TargetUnit.GetComponent<PlayerInformation>().healthPointsCurrent -= enemy2Damage;
                        Debug.Log(enemy2TargetUnit.name + " takes " + enemy2Damage + " damage!");
                        enemy1Damage = 0;
                    }
                    else
                    {
                        timer += 2;
                    }
                }

                if (timer >= 14)
                {
                    if (GameObject.Find("EnemyUnit3").GetComponent<EnemyInformation>().fallen == false)
                    {
                        GameObject.Find("EnemyUnit3").GetComponent<EnemyInformation>().attacks = true;
                        enemy3TargetUnit.GetComponent<PlayerInformation>().healthPointsCurrent -= enemy3Damage;
                        Debug.Log(enemy3TargetUnit.name + " takes " + enemy3Damage + " damage!");
                        enemy1Damage = 0;
                    }
                    else
                    {
                        timer += 2;
                    }
                }

                if (timer >= 16)
                {
                    if (GameObject.Find("EnemyUnit4").GetComponent<EnemyInformation>().fallen == false)
                    {
                        GameObject.Find("EnemyUnit4").GetComponent<EnemyInformation>().attacks = true;
                        enemy4TargetUnit.GetComponent<PlayerInformation>().healthPointsCurrent -= enemy4Damage;
                        Debug.Log(enemy4TargetUnit.name + " takes " + enemy4Damage + " damage!");
                        enemy1Damage = 0;
                    }
                    else
                    {
                        timer += 2;
                    }
                }

                if (timer >= 18)
                {
                    if (GameObject.Find("EnemyUnit5").GetComponent<EnemyInformation>().fallen == false)
                    {
                        GameObject.Find("EnemyUnit5").GetComponent<EnemyInformation>().attacks = true;
                        enemy5TargetUnit.GetComponent<PlayerInformation>().healthPointsCurrent -= enemy5Damage;
                        Debug.Log(enemy5TargetUnit.name + " takes " + enemy5Damage + " damage!");
                        enemy5Damage = 0;
                    }
                    else
                    {
                        timer += 2;
                    }
                }

                if (timer >= 20)
                {
                    if (GameObject.Find("EnemyUnit6").GetComponent<EnemyInformation>().fallen == false)
                    {
                        GameObject.Find("EnemyUnit6").GetComponent<EnemyInformation>().attacks = true;
                        enemy6TargetUnit.GetComponent<PlayerInformation>().healthPointsCurrent -= enemy6Damage;
                        Debug.Log(enemy6TargetUnit.name + " takes " + enemy6Damage + " damage!");
                        enemy6Damage = 0;
                    }
                    else
                    {
                        timer += 2;
                    }

                    timer = 0;
                    currentState = BattleStates.START;
                }



                //calculateDamageTargetUnit = null;
                break;

            case (BattleStates.WIN):

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

    // Give players experience functions

    public void GivePlayer1Experience()
    {
        GameObject.Find("FriendlyUnit1").GetComponent<PlayerInformation>().currentEXP +=
                    GameObject.Find("EnemyUnit1").GetComponent<EnemyInformation>().expGiven +
                        GameObject.Find("EnemyUnit2").GetComponent<EnemyInformation>().expGiven +
                            GameObject.Find("EnemyUnit3").GetComponent<EnemyInformation>().expGiven +
                                GameObject.Find("EnemyUnit4").GetComponent<EnemyInformation>().expGiven +
                                    GameObject.Find("EnemyUnit5").GetComponent<EnemyInformation>().expGiven +
                                        GameObject.Find("EnemyUnit6").GetComponent<EnemyInformation>().expGiven;
    }

    public void GivePlayer2Experience()
    {
        GameObject.Find("FriendlyUnit2").GetComponent<PlayerInformation>().currentEXP +=
                    GameObject.Find("EnemyUnit1").GetComponent<EnemyInformation>().expGiven +
                        GameObject.Find("EnemyUnit2").GetComponent<EnemyInformation>().expGiven +
                            GameObject.Find("EnemyUnit3").GetComponent<EnemyInformation>().expGiven +
                                GameObject.Find("EnemyUnit4").GetComponent<EnemyInformation>().expGiven +
                                    GameObject.Find("EnemyUnit5").GetComponent<EnemyInformation>().expGiven +
                                        GameObject.Find("EnemyUnit6").GetComponent<EnemyInformation>().expGiven;
    }

    public void GivePlayer3Experience()
    {
        GameObject.Find("FriendlyUnit3").GetComponent<PlayerInformation>().currentEXP +=
                    GameObject.Find("EnemyUnit1").GetComponent<EnemyInformation>().expGiven +
                        GameObject.Find("EnemyUnit2").GetComponent<EnemyInformation>().expGiven +
                            GameObject.Find("EnemyUnit3").GetComponent<EnemyInformation>().expGiven +
                                GameObject.Find("EnemyUnit4").GetComponent<EnemyInformation>().expGiven +
                                    GameObject.Find("EnemyUnit5").GetComponent<EnemyInformation>().expGiven +
                                        GameObject.Find("EnemyUnit6").GetComponent<EnemyInformation>().expGiven;
    }

    public void GivePlayer4Experience()
    {
        GameObject.Find("FriendlyUnit4").GetComponent<PlayerInformation>().currentEXP +=
                    GameObject.Find("EnemyUnit1").GetComponent<EnemyInformation>().expGiven +
                        GameObject.Find("EnemyUnit2").GetComponent<EnemyInformation>().expGiven +
                            GameObject.Find("EnemyUnit3").GetComponent<EnemyInformation>().expGiven +
                                GameObject.Find("EnemyUnit4").GetComponent<EnemyInformation>().expGiven +
                                    GameObject.Find("EnemyUnit5").GetComponent<EnemyInformation>().expGiven +
                                        GameObject.Find("EnemyUnit6").GetComponent<EnemyInformation>().expGiven;
    }

    // PlayerClickAttack buttons

    public void OnPlayer1ClickAttack()
    {
        player1BaseMenuCanvas.SetActive(false);
        player1BasicAttackSelected = true;
        player1Damage += GameObject.Find("FriendlyUnit1").GetComponent<PlayerInformation>().physicalDamage * 1;
        player1SelectEnemyCanvas.SetActive(true);
    }

    public void OnPlayer2ClickAttack()
    {
        player2BaseMenuCanvas.SetActive(false);
        player2BasicAttackSelected = true;
        player2Damage += GameObject.Find("FriendlyUnit2").GetComponent<PlayerInformation>().physicalDamage * 1;
        player2SelectEnemyCanvas.SetActive(true);
    }

    public void OnPlayer3ClickAttack()
    {
        player3BaseMenuCanvas.SetActive(false);
        player3BasicAttackSelected = true;
        player3Damage += GameObject.Find("FriendlyUnit3").GetComponent<PlayerInformation>().physicalDamage * 1;
        player3SelectEnemyCanvas.SetActive(true);
    }

    public void OnPlayer4ClickAttack()
    {
        player4BaseMenuCanvas.SetActive(false);
        player4BasicAttackSelected = true;
        player4Damage += GameObject.Find("FriendlyUnit4").GetComponent<PlayerInformation>().physicalDamage * 1;
        player4SelectEnemyCanvas.SetActive(true);
    }

    // PlayerClickSpells buttons

    public void OnPlayer1ClickSpells()
    {
        player1BaseMenuCanvas.SetActive(false);

        player1SpellsMenuCanvas.SetActive(true);
    }

    public void OnPlayer1ClickSpellRekt()
    {
        player1SpellsMenuCanvas.SetActive(false);
        spellRektSelected = true;

        player1Damage += GameObject.Find("FriendlyUnit1").GetComponent<PlayerInformation>().physicalDamage * 2;
        player1Damage += GameObject.Find("FriendlyUnit1").GetComponent<PlayerInformation>().techDamage * 2;

        player1SelectEnemyCanvas.SetActive(true);
    }

    public void OnPlayer1ClickGuard()
    {
        player1Resist += GameObject.Find("FriendlyUnit1").GetComponent<PlayerInformation>().physicalResist * 1;
        player1BaseMenuCanvas.SetActive(false);
        currentState = BattleStates.ENEMYCHOICE;
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

    // Player1SelectEnemy buttons

    public void OnPlayer1ClickEnemy1Button()
    {
        player1TargetUnit = GameObject.Find("EnemyUnit1");
        if (player1TargetUnit.GetComponent<EnemyInformation>().fallen == true)
        {
            return;
        }
        player1SelectEnemyCanvas.SetActive(false);
        player2BaseMenuCanvas.SetActive(true);
    }

    public void OnPlayer1ClickEnemy2Button()
    {
        player1TargetUnit = GameObject.Find("EnemyUnit2");
        if (player1TargetUnit.GetComponent<EnemyInformation>().fallen == true)
        {
            return;
        }
        player1SelectEnemyCanvas.SetActive(false);
        player2BaseMenuCanvas.SetActive(true);
    }

    public void OnPlayer1ClickEnemy3Button()
    {
        player1TargetUnit = GameObject.Find("EnemyUnit3");
        if (player1TargetUnit.GetComponent<EnemyInformation>().fallen == true)
        {
            return;
        }
        player1SelectEnemyCanvas.SetActive(false);
        player2BaseMenuCanvas.SetActive(true);
    }

    public void OnPlayer1ClickEnemy4Button()
    {
        player1TargetUnit = GameObject.Find("EnemyUnit4");
        if (player1TargetUnit.GetComponent<EnemyInformation>().fallen == true)
        {
            return;
        }
        player1SelectEnemyCanvas.SetActive(false);
        player2BaseMenuCanvas.SetActive(true);
    }

    public void OnPlayer1ClickEnemy5Button()
    {
        player1TargetUnit = GameObject.Find("EnemyUnit5");
        if (player1TargetUnit.GetComponent<EnemyInformation>().fallen == true)
        {
            return;
        }
        player1SelectEnemyCanvas.SetActive(false);
        player2BaseMenuCanvas.SetActive(true);
    }

    public void OnPlayer1ClickEnemy6Button()
    {
        player1TargetUnit = GameObject.Find("EnemyUnit6");
        if (player1TargetUnit.GetComponent<EnemyInformation>().fallen == true)
        {
            return;
        }
        player1SelectEnemyCanvas.SetActive(false);
        player2BaseMenuCanvas.SetActive(true);
    }

    // Player2SelectEnemy buttons

    public void OnPlayer2ClickEnemy1Button()
    {
        player2TargetUnit = GameObject.Find("EnemyUnit1");
        if (player2TargetUnit.GetComponent<EnemyInformation>().fallen == true)
        {
            return;
        }
        player2SelectEnemyCanvas.SetActive(false);
        player3BaseMenuCanvas.SetActive(true);
    }

    public void OnPlayer2ClickEnemy2Button()
    {
        player2TargetUnit = GameObject.Find("EnemyUnit2");
        if (player2TargetUnit.GetComponent<EnemyInformation>().fallen == true)
        {
            return;
        }
        player2SelectEnemyCanvas.SetActive(false);
        player3BaseMenuCanvas.SetActive(true);
    }

    public void OnPlayer2ClickEnemy3Button()
    {
        player2TargetUnit = GameObject.Find("EnemyUnit3");
        if (player2TargetUnit.GetComponent<EnemyInformation>().fallen == true)
        {
            return;
        }
        player2SelectEnemyCanvas.SetActive(false);
        player3BaseMenuCanvas.SetActive(true);
    }

    public void OnPlayer2ClickEnemy4Button()
    {
        player2TargetUnit = GameObject.Find("EnemyUnit4");
        if (player2TargetUnit.GetComponent<EnemyInformation>().fallen == true)
        {
            return;
        }
        player2SelectEnemyCanvas.SetActive(false);
        player3BaseMenuCanvas.SetActive(true);
    }

    public void OnPlayer2ClickEnemy5Button()
    {
        player2TargetUnit = GameObject.Find("EnemyUnit5");
        if (player2TargetUnit.GetComponent<EnemyInformation>().fallen == true)
        {
            return;
        }
        player2SelectEnemyCanvas.SetActive(false);
        player3BaseMenuCanvas.SetActive(true);
    }

    public void OnPlayer2ClickEnemy6Button()
    {
        player2TargetUnit = GameObject.Find("EnemyUnit6");
        if (player2TargetUnit.GetComponent<EnemyInformation>().fallen == true)
        {
            return;
        }
        player2SelectEnemyCanvas.SetActive(false);
        player3BaseMenuCanvas.SetActive(true);
    }

    // Player3SelectEnemy buttons

    public void OnPlayer3ClickEnemy1Button()
    {
        player3TargetUnit = GameObject.Find("EnemyUnit1");
        if (player3TargetUnit.GetComponent<EnemyInformation>().fallen == true)
        {
            return;
        }
        player3SelectEnemyCanvas.SetActive(false);
        player4BaseMenuCanvas.SetActive(true);
    }

    public void OnPlayer3ClickEnemy2Button()
    {
        player3TargetUnit = GameObject.Find("EnemyUnit2");
        if (player3TargetUnit.GetComponent<EnemyInformation>().fallen == true)
        {
            return;
        }
        player3SelectEnemyCanvas.SetActive(false);
        player4BaseMenuCanvas.SetActive(true);
    }

    public void OnPlayer3ClickEnemy3Button()
    {
        player3TargetUnit = GameObject.Find("EnemyUnit3");
        if (player3TargetUnit.GetComponent<EnemyInformation>().fallen == true)
        {
            return;
        }
        player3SelectEnemyCanvas.SetActive(false);
        player4BaseMenuCanvas.SetActive(true);
    }

    public void OnPlayer3ClickEnemy4Button()
    {
        player3TargetUnit = GameObject.Find("EnemyUnit4");
        if (player3TargetUnit.GetComponent<EnemyInformation>().fallen == true)
        {
            return;
        }
        player3SelectEnemyCanvas.SetActive(false);
        player4BaseMenuCanvas.SetActive(true);
    }

    public void OnPlayer3ClickEnemy5Button()
    {
        player3TargetUnit = GameObject.Find("EnemyUnit5");
        if (player3TargetUnit.GetComponent<EnemyInformation>().fallen == true)
        {
            return;
        }
        player3SelectEnemyCanvas.SetActive(false);
        player4BaseMenuCanvas.SetActive(true);
    }

    public void OnPlayer3ClickEnemy6Button()
    {
        player3TargetUnit = GameObject.Find("EnemyUnit6");
        if (player3TargetUnit.GetComponent<EnemyInformation>().fallen == true)
        {
            return;
        }
        player3SelectEnemyCanvas.SetActive(false);
        player4BaseMenuCanvas.SetActive(true);
    }

    // Player4SelectEnemy buttons

    public void OnPlayer4ClickEnemy1Button()
    {
        player4TargetUnit = GameObject.Find("EnemyUnit1");
        if (player4TargetUnit.GetComponent<EnemyInformation>().fallen == true)
        {
            return;
        }
        player4SelectEnemyCanvas.SetActive(false);
        currentState = BattleStates.ENEMYCHOICE;
    }

    public void OnPlayer4ClickEnemy2Button()
    {
        player4TargetUnit = GameObject.Find("EnemyUnit2");
        if (player4TargetUnit.GetComponent<EnemyInformation>().fallen == true)
        {
            return;
        }
        player4SelectEnemyCanvas.SetActive(false);
        currentState = BattleStates.ENEMYCHOICE;
    }

    public void OnPlayer4ClickEnemy3Button()
    {
        player4TargetUnit = GameObject.Find("EnemyUnit3");
        if (player4TargetUnit.GetComponent<EnemyInformation>().fallen == true)
        {
            return;
        }
        player4SelectEnemyCanvas.SetActive(false);
        currentState = BattleStates.ENEMYCHOICE;
    }

    public void OnPlayer4ClickEnemy4Button()
    {
        player4TargetUnit = GameObject.Find("EnemyUnit4");
        if (player4TargetUnit.GetComponent<EnemyInformation>().fallen == true)
        {
            return;
        }
        player4SelectEnemyCanvas.SetActive(false);
        currentState = BattleStates.ENEMYCHOICE;
    }

    public void OnPlayer4ClickEnemy5Button()
    {
        player4TargetUnit = GameObject.Find("EnemyUnit5");
        if (player4TargetUnit.GetComponent<EnemyInformation>().fallen == true)
        {
            return;
        }
        player4SelectEnemyCanvas.SetActive(false);
        currentState = BattleStates.ENEMYCHOICE;
    }

    public void OnPlayer4ClickEnemy6Button()
    {
        player4TargetUnit = GameObject.Find("EnemyUnit6");
        if (player4TargetUnit.GetComponent<EnemyInformation>().fallen == true)
        {
            return;
        }
        player4SelectEnemyCanvas.SetActive(false);
        currentState = BattleStates.ENEMYCHOICE;
    }
}
