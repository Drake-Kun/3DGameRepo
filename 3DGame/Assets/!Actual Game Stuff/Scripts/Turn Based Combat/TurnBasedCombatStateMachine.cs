using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TurnBasedCombatStateMachine : MonoBehaviour {

    public GameObject combatCanvas;

    public GameObject damageCalculationsCanvas;
    public GameObject damageCalculationsText;

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
    public GameObject player4SpellsMenuCanvas;

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


    // Players actions/turns
    public bool player1Action;
    public bool player2Action;
    public bool player3Action;
    public bool player4Action;


    //Player 1 stats and spells selected

    public int player1TotalDamage;
    public int player1PhysicalDamage;
    public int player1PhysicalResist;
    public int player1TotalResist;
    public int player1TechDamage;
    public int player1TechResist;

    public bool player1SpellTaunt;
    public bool player1SpellDoubleEdge;

    //Player 2 stats and spells selected

    public int player2TotalDamage;
    public int player2PhysicalDamage;
    public int player2PhysicalResist;
    public int player2TotalResist;
    public int player2TechDamage;
    public int player2TechResist;

    public bool player2SpellPoison;

    //Player 3 stats and spells selected

    public int player3TotalDamage;
    public int player3PhysicalDamage;
    public int player3PhysicalResist;
    public int player3TotalResist;
    public int player3TechDamage;
    public int player3TechResist;

    //Player 4 stats and spells selected

    public int player4TotalDamage;
    public int player4PhysicalDamage;
    public int player4PhysicalResist;
    public int player4TotalResist;
    public int player4TechDamage;
    public int player4TechResist;

    //What kind of attack are our players using?

    public bool player1BasicAttackSelected = false;
    public bool player2BasicAttackSelected = false;
    public bool player3BasicAttackSelected = false;
    public bool player4BasicAttackSelected = false;

    public bool player1SpellSelected = false;
    public bool player2SpellSelected = false;
    public bool player3SpellSelected = false;
    public bool player4SpellSelected = false;


    // Enemy 1 stats and spells selected

    public bool enemy1ValidUnitSelection;
    public int enemy1TotalDamage;
    public int enemy1PhysicalDamage;
    public int enemy1PhysicalResist;
    public int enemy1TotalResist;
    public int enemy1TechDamage;
    public int enemy1TechResist;

    // Enemy 2 stats and spells selected

    public bool enemy2ValidUnitSelection;
    public int enemy2TotalDamage;
    public int enemy2PhysicalDamage;
    public int enemy2PhysicalResist;
    public int enemy2TotalResist;
    public int enemy2TechDamage;
    public int enemy2TechResist;

    // Enemy 3 stats and spells selected

    public bool enemy3ValidUnitSelection;
    public int enemy3TotalDamage;
    public int enemy3PhysicalDamage;
    public int enemy3PhysicalResist;
    public int enemy3TotalResist;
    public int enemy3TechDamage;
    public int enemy3TechResist;

    // Enemy 4 stats and spells selected

    public bool enemy4ValidUnitSelection;
    public int enemy4TotalDamage;
    public int enemy4PhysicalDamage;
    public int enemy4PhysicalResist;
    public int enemy4TotalResist;
    public int enemy4TechDamage;
    public int enemy4TechResist;

    // Enemy 5 stats and spells selected

    public bool enemy5ValidUnitSelection;
    public int enemy5TotalDamage;
    public int enemy5PhysicalDamage;
    public int enemy5PhysicalResist;
    public int enemy5TotalResist;
    public int enemy5TechDamage;
    public int enemy5TechResist;

    // Enemy 6 stats and spells selected

    public bool enemy6ValidUnitSelection;
    public int enemy6TotalDamage;
    public int enemy6PhysicalDamage;
    public int enemy6PhysicalResist;
    public int enemy6TotalResist;
    public int enemy6TechDamage;
    public int enemy6TechResist;

    // Who all has attacked?

    public bool player1TurnReady;
    public bool player2TurnReady;
    public bool player3TurnReady;
    public bool player4TurnReady;
    public bool enemy1TurnReady;
    public bool enemy2TurnReady;
    public bool enemy3TurnReady;
    public bool enemy4TurnReady;
    public bool enemy5TurnReady;
    public bool enemy6TurnReady;


    //
    //STATUS EFFECTS
    //


    //Are the enemies TAUNTED?

    public bool enemy1Taunted;
    public int enemy1TauntTimer;

    public bool enemy2Taunted;
    public int enemy2TauntTImer;

    public bool enemy3Taunted;
    public int enemy3TauntTimer;

    public bool enemy4Taunted;
    public int enemy4TauntTimer;

    public bool enemy5Taunted;
    public int enemy5TauntTimer;

    public bool enemy6Taunted;
    public int enemy6TauntTimer;

    //Are the players TAUNTED?

    public bool player1Taunted;
    public int player1TauntTimer;

    public bool player2Taunted;
    public int player2TauntTimer;

    public bool player3Taunted;
    public int player3TauntTimer;

    public bool player4Taunted;
    public int player4TauntTimer;

    // Hey, a timer

    public float timer;

    // We need this so we don't repeat things unecessarily

    public bool damageCalculationStarted;

    public enum BattleStates
    {
        NULL,
        START,
        PLAYERCHOICE,
        CALCULATEDAMAGE,
        ENEMYCHOICE,
        LOSE,
        WIN,
        FLED
    }

    public static BattleStates currentState;

    public void AntiNull()
    {
        currentState = BattleStates.START;
        damageCalculationStarted = false;
    }

    public void SpawnEnemies()
    {
        int areaID = GameObject.Find("GameInformation").GetComponent<GameInformation>().areaID;


        if (areaID == 1)
        {
            int spawnSpiders = 0;
            int spawnWraiths = 0;

            // Enemy1 type
            int enemyType = Random.Range(1, 3);
            if (enemyType == 1)
            {
                spawnSpiders += 1;
            }
            else if (enemyType == 2)
            {
                spawnWraiths += 1;
            }

            // Enemy2 type
            enemyType = Random.Range(1, 3);
            if (enemyType == 1)
            {
                spawnSpiders += 1;
            }
            else if (enemyType == 2)
            {
                spawnWraiths += 1;
            }

            // Enemy3 type
            enemyType = Random.Range(1, 3);
            if (enemyType == 1)
            {
                spawnSpiders += 1;
            }
            else if (enemyType == 2)
            {
                spawnWraiths += 1;
            }

            // Enemy4 type
            enemyType = Random.Range(1, 3);
            if (enemyType == 1)
            {
                spawnSpiders += 1;
            }
            else if (enemyType == 2)
            {
                spawnWraiths += 1;
            }

            // Enemy5 type
            enemyType = Random.Range(1, 3);
            if (enemyType == 1)
            {
                spawnSpiders += 1;
            }
            else if (enemyType == 2)
            {
                spawnWraiths += 1;
            }

            // Enemy6 type
            enemyType = Random.Range(1, 3);
            if (enemyType == 1)
            {
                spawnSpiders += 1;
            }
            else if (enemyType == 2)
            {
                spawnWraiths += 1;
            }


            // Spawn enemy1!
            if (spawnSpiders > 0)
            {
                spawnSpiders -= 1;
                GameObject.Find("EnemyUnit1").GetComponent<EnemyInformation>().SpawnSpider();
                GameObject.Find("EnemyUnit1").GetComponent<EnemyInformation>().Enemy.name = "Spider";
            }
            else if (spawnWraiths > 0)
            {
                spawnWraiths -= 1;
                GameObject.Find("EnemyUnit1").GetComponent<EnemyInformation>().SpawnWraith();
                GameObject.Find("EnemyUnit1").GetComponent<EnemyInformation>().Enemy.name = "Wraith";
            }

            // Spawn enemy2!
            if (spawnSpiders > 0)
            {
                spawnSpiders -= 1;
                GameObject.Find("EnemyUnit2").GetComponent<EnemyInformation>().SpawnSpider();
                GameObject.Find("EnemyUnit1").GetComponent<EnemyInformation>().Enemy.name = "Spider 1";
                GameObject.Find("EnemyUnit2").GetComponent<EnemyInformation>().Enemy.name = "Spider 2";
            }
            else if (spawnWraiths > 0)
            {
                spawnWraiths -= 1;
                GameObject.Find("EnemyUnit1").GetComponent<EnemyInformation>().SpawnWraith();
                if (GameObject.Find("EnemyUnit1").GetComponent<EnemyInformation>().Enemy.name == "Wraith")
                {
                    GameObject.Find("EnemyUnit1").GetComponent<EnemyInformation>().Enemy.name = "Wraith 1";
                    GameObject.Find("EnemyUnit2").GetComponent<EnemyInformation>().Enemy.name = "Wraith 2";
                }
            }

            // Spawn enemy3!
            if (spawnSpiders > 0)
            {
                spawnSpiders -= 1;
                GameObject.Find("EnemyUnit3").GetComponent<EnemyInformation>().SpawnSpider();
                GameObject.Find("EnemyUnit3").GetComponent<EnemyInformation>().Enemy.name = "Spider 3";
            }
            else if (spawnWraiths > 0)
            {
                spawnWraiths -= 1;
                GameObject.Find("EnemyUnit3").GetComponent<EnemyInformation>().SpawnWraith();
                if (GameObject.Find("EnemyUnit2").GetComponent<EnemyInformation>().Enemy.name == "Wraith")
                {
                    GameObject.Find("EnemyUnit2").GetComponent<EnemyInformation>().Enemy.name = "Wraith 1";
                    GameObject.Find("EnemyUnit3").GetComponent<EnemyInformation>().Enemy.name = "Wraith 2";
                }
                else if (GameObject.Find("EnemyUnit2").GetComponent<EnemyInformation>().Enemy.name == "Wraith 2")
                {
                    GameObject.Find("EnemyUnit3").GetComponent<EnemyInformation>().Enemy.name = "Wraith 3";
                }
                else
                {
                    GameObject.Find("EnemyUnit3").GetComponent<EnemyInformation>().Enemy.name = "Wraith";
                }
                
            }

            // Spawn enemy4!
            if (spawnSpiders > 0)
            {
                spawnSpiders -= 1;
                GameObject.Find("EnemyUnit4").GetComponent<EnemyInformation>().SpawnSpider();
                GameObject.Find("EnemyUnit4").GetComponent<EnemyInformation>().Enemy.name = "Spider 4";
            }
            else if (spawnWraiths > 0)
            {
                spawnWraiths -= 1;
                GameObject.Find("EnemyUnit4").GetComponent<EnemyInformation>().SpawnWraith();
                if (GameObject.Find("EnemyUnit3").GetComponent<EnemyInformation>().Enemy.name == "Wraith")
                {
                    GameObject.Find("EnemyUnit3").GetComponent<EnemyInformation>().Enemy.name = "Wraith 1";
                    GameObject.Find("EnemyUnit4").GetComponent<EnemyInformation>().Enemy.name = "Wraith 2";
                }
                else if (GameObject.Find("EnemyUnit3").GetComponent<EnemyInformation>().Enemy.name == "Wraith 2")
                {
                    GameObject.Find("EnemyUnit4").GetComponent<EnemyInformation>().Enemy.name = "Wraith 3";
                }
                else if (GameObject.Find("EnemyUnit3").GetComponent<EnemyInformation>().Enemy.name == "Wraith 3")
                {
                    GameObject.Find("EnemyUnit4").GetComponent<EnemyInformation>().Enemy.name = "Wraith 4";
                }
                else
                {
                    GameObject.Find("EnemyUnit4").GetComponent<EnemyInformation>().Enemy.name = "Wraith";
                }
            }

            // Spawn enemy5!
            if (spawnSpiders > 0)
            {
                spawnSpiders -= 1;
                GameObject.Find("EnemyUnit5").GetComponent<EnemyInformation>().SpawnSpider();
                GameObject.Find("EnemyUnit5").GetComponent<EnemyInformation>().Enemy.name = "Spider 5";
            }
            else if (spawnWraiths > 0)
            {
                spawnWraiths -= 1;
                GameObject.Find("EnemyUnit5").GetComponent<EnemyInformation>().SpawnWraith();
                if (GameObject.Find("EnemyUnit4").GetComponent<EnemyInformation>().Enemy.name == "Wraith")
                {
                    GameObject.Find("EnemyUnit4").GetComponent<EnemyInformation>().Enemy.name = "Wraith 1";
                    GameObject.Find("EnemyUnit5").GetComponent<EnemyInformation>().Enemy.name = "Wraith 2";
                }
                else if (GameObject.Find("EnemyUnit4").GetComponent<EnemyInformation>().Enemy.name == "Wraith 2")
                {
                    GameObject.Find("EnemyUnit5").GetComponent<EnemyInformation>().Enemy.name = "Wraith 3";
                }
                else if (GameObject.Find("EnemyUnit4").GetComponent<EnemyInformation>().Enemy.name == "Wraith 3")
                {
                    GameObject.Find("EnemyUnit5").GetComponent<EnemyInformation>().Enemy.name = "Wraith 4";
                }
                else if (GameObject.Find("EnemyUnit4").GetComponent<EnemyInformation>().Enemy.name == "Wraith 4")
                {
                    GameObject.Find("EnemyUnit5").GetComponent<EnemyInformation>().Enemy.name = "Wraith 5";
                }
                else
                {
                    GameObject.Find("EnemyUnit5").GetComponent<EnemyInformation>().Enemy.name = "Wraith";
                }
            }

            // Spawn enemy6!
            if (spawnSpiders > 0)
            {
                spawnSpiders -= 1;
                GameObject.Find("EnemyUnit6").GetComponent<EnemyInformation>().SpawnSpider();
                GameObject.Find("EnemyUnit6").GetComponent<EnemyInformation>().Enemy.name = "Spider 6";
            }
            else if (spawnWraiths > 0)
            {
                spawnWraiths -= 1;
                GameObject.Find("EnemyUnit6").GetComponent<EnemyInformation>().SpawnWraith();
                if (GameObject.Find("EnemyUnit5").GetComponent<EnemyInformation>().Enemy.name == "Wraith")
                {
                    GameObject.Find("EnemyUnit5").GetComponent<EnemyInformation>().Enemy.name = "Wraith 1";
                    GameObject.Find("EnemyUnit6").GetComponent<EnemyInformation>().Enemy.name = "Wraith 2";
                }
                else if (GameObject.Find("EnemyUnit5").GetComponent<EnemyInformation>().Enemy.name == "Wraith 2")
                {
                    GameObject.Find("EnemyUnit6").GetComponent<EnemyInformation>().Enemy.name = "Wraith 3";
                }
                else if (GameObject.Find("EnemyUnit5").GetComponent<EnemyInformation>().Enemy.name == "Wraith 3")
                {
                    GameObject.Find("EnemyUnit6").GetComponent<EnemyInformation>().Enemy.name = "Wraith 4";
                }
                else if (GameObject.Find("EnemyUnit5").GetComponent<EnemyInformation>().Enemy.name == "Wraith 4")
                {
                    GameObject.Find("EnemyUnit6").GetComponent<EnemyInformation>().Enemy.name = "Wraith 5";
                }
                else if (GameObject.Find("EnemyUnit5").GetComponent<EnemyInformation>().Enemy.name == "Wraith 5")
                {
                    GameObject.Find("EnemyUnit6").GetComponent<EnemyInformation>().Enemy.name = "Wraith 6";
                }
                else
                {
                    GameObject.Find("EnemyUnit6").GetComponent<EnemyInformation>().Enemy.name = "Wraith";
                }
            }
        }
    }

	// Use this for initialization
	void Start () {

        SpawnEnemies();

        GameObject.Find("GameInformation").GetComponent<PlayerGlobalInformation>().EnterBattle();
        timer = 0;
        currentState = BattleStates.NULL;

	}

    // Update is called once per frame
    void Update() {
        Debug.Log(currentState);

        if (GameObject.Find("EnemyUnit1").GetComponent<EnemyInformation>().fallen
                && GameObject.Find("EnemyUnit2").GetComponent<EnemyInformation>().fallen
                    && GameObject.Find("EnemyUnit3").GetComponent<EnemyInformation>().fallen
                        && GameObject.Find("EnemyUnit4").GetComponent<EnemyInformation>().fallen
                            && GameObject.Find("EnemyUnit5").GetComponent<EnemyInformation>().fallen
                                && GameObject.Find("EnemyUnit6").GetComponent<EnemyInformation>().fallen)
        {
            currentState = BattleStates.WIN;
        }

        else if (GameObject.Find("FriendlyUnit1").GetComponent<PlayerInformation>().fallen && GameObject.Find("FriendlyUnit2").GetComponent<PlayerInformation>().fallen
                        && GameObject.Find("FriendlyUnit3").GetComponent<PlayerInformation>().fallen && GameObject.Find("FriendlyUnit4").GetComponent<PlayerInformation>().fallen)
        {
            currentState = BattleStates.LOSE;
        }

        else
        {

        }

        switch (currentState)
        {
            case (BattleStates.START):

                combatCanvas.SetActive(true);

                //We don't need damage calculations right now
                damageCalculationsCanvas.SetActive(false);

                // Player 1's canvas is ACTIVE
                player1CombatCanvas.SetActive(true);
                player1BaseMenuCanvas.SetActive(true);
                player1SelectEnemyCanvas.SetActive(false);
                player1SpellsMenuCanvas.SetActive(false);

                //Make sure player2's canvas is set to inactive
                player2BaseMenuCanvas.SetActive(false);
                player2SpellsMenuCanvas.SetActive(false);
                player2SelectEnemyCanvas.SetActive(false);
                player2CombatCanvas.SetActive(false);

                //Make sure player3's canvas is set to inactive
                player3BaseMenuCanvas.SetActive(false);
                player3SpellsMenuCanvas.SetActive(false);
                player3SelectEnemyCanvas.SetActive(false);
                player3CombatCanvas.SetActive(false);

                //Make sure player4's canvas is set to inactive
                player4BaseMenuCanvas.SetActive(false);
                player4SpellsMenuCanvas.SetActive(false);
                player4SelectEnemyCanvas.SetActive(false);
                player4CombatCanvas.SetActive(false);

                EventSystem.current.SetSelectedGameObject(GameObject.Find("Attack"), new BaseEventData(EventSystem.current));
                currentState = BattleStates.PLAYERCHOICE;

                break;

            case (BattleStates.PLAYERCHOICE):

                //Press B to go back.
                // I need A LOT of functions for this... Because reasons.

                // Who's action are we currently deciding?


                // Me trying to highlight people WOOOOOO
                if (player1Action == true)
                {
                    GameObject.Find("PlayerHighlighter").GetComponent<Transform>().position = GameObject.Find("FriendlyUnit4").GetComponent<Transform>().position;
                }

                else if (player2Action == true)
                {
                    GameObject.Find("PlayerHighlighter").GetComponent<Transform>().position = GameObject.Find("FriendlyUnit2").GetComponent<Transform>().position;
                }

                else if (player3Action == true)
                {
                    GameObject.Find("PlayerHighlighter").GetComponent<Transform>().position = GameObject.Find("FriendlyUnit3").GetComponent<Transform>().position;
                }

                else if (player4Action == true)
                {
                    GameObject.Find("PlayerHighlighter").GetComponent<Transform>().position = GameObject.Find("FriendlyUnit4").GetComponent<Transform>().position;
                }


                // Player 1 press B

                if (Input.GetButtonDown("Fire2") && player1SelectEnemyCanvas.activeSelf && player1BasicAttackSelected)
                {
                    player1SelectEnemyCanvas.SetActive(false);
                    player1BasicAttackSelected = false;
                    player1BaseMenuCanvas.SetActive(true);
                    EventSystem.current.SetSelectedGameObject(GameObject.Find("Attack"), new BaseEventData(EventSystem.current));
                }

                if (Input.GetButtonDown("Fire2") && player1SpellsMenuCanvas.activeSelf == true)
                {
                    player1SpellsMenuCanvas.SetActive(false);

                    player1BaseMenuCanvas.SetActive(true);
                    EventSystem.current.SetSelectedGameObject(GameObject.Find("Attack"), new BaseEventData(EventSystem.current));
                }

                if (Input.GetButtonDown("Fire2") && player1SelectEnemyCanvas.activeSelf && player1SpellSelected)
                {
                    player1SelectEnemyCanvas.SetActive(false);

                    player1SpellSelected = false;

                    player1SpellTaunt = false;
                    player1SpellDoubleEdge = false;
                    player1SpellsMenuCanvas.SetActive(true);
                    EventSystem.current.SetSelectedGameObject(GameObject.Find("Spell1"), new BaseEventData(EventSystem.current));
                }

                // Player 2 press B

                if (Input.GetButtonDown("Fire2") && player2BaseMenuCanvas.activeSelf)
                {
                    player2CombatCanvas.SetActive(false);
                    player1TargetUnit = null;
                    player1SelectEnemyCanvas.SetActive(true);
                    EventSystem.current.SetSelectedGameObject(GameObject.Find("Enemy1"), new BaseEventData(EventSystem.current));
                }

                if (Input.GetButtonDown("Fire2") && player2SelectEnemyCanvas.activeSelf && player2BasicAttackSelected)
                {
                    player2SelectEnemyCanvas.SetActive(false);
                    player2BasicAttackSelected = false;
                    player2BaseMenuCanvas.SetActive(true);
                    EventSystem.current.SetSelectedGameObject(GameObject.Find("Attack"), new BaseEventData(EventSystem.current));
                }

                if (Input.GetButtonDown("Fire2") && player2SpellsMenuCanvas.activeSelf == true)
                {
                    player2SpellsMenuCanvas.SetActive(false);

                    player2BaseMenuCanvas.SetActive(true);
                    EventSystem.current.SetSelectedGameObject(GameObject.Find("Attack"), new BaseEventData(EventSystem.current));
                }

                if (Input.GetButtonDown("Fire2") && player2SelectEnemyCanvas.activeSelf && player2SpellSelected)
                {
                    player2SelectEnemyCanvas.SetActive(false);

                    player2SpellSelected = false;

                    player2SpellsMenuCanvas.SetActive(true);
                    EventSystem.current.SetSelectedGameObject(GameObject.Find("Spell1"), new BaseEventData(EventSystem.current));
                }

                // Player 3 press B

                if (Input.GetButtonDown("Fire2") && player3BaseMenuCanvas.activeSelf)
                {
                    player3CombatCanvas.SetActive(false);
                    player2TargetUnit = null;
                    player2SelectEnemyCanvas.SetActive(true);
                    EventSystem.current.SetSelectedGameObject(GameObject.Find("Enemy1"), new BaseEventData(EventSystem.current));
                }

                if (Input.GetButtonDown("Fire2") && player3SelectEnemyCanvas.activeSelf && player3BasicAttackSelected)
                {
                    player3SelectEnemyCanvas.SetActive(false);
                    player3BasicAttackSelected = false;
                    player3BaseMenuCanvas.SetActive(true);
                    EventSystem.current.SetSelectedGameObject(GameObject.Find("Attack"), new BaseEventData(EventSystem.current));
                }

                if (Input.GetButtonDown("Fire2") && player3SpellsMenuCanvas.activeSelf == true)
                {
                    player3SpellsMenuCanvas.SetActive(false);

                    player3BaseMenuCanvas.SetActive(true);
                    EventSystem.current.SetSelectedGameObject(GameObject.Find("Attack"), new BaseEventData(EventSystem.current));
                }

                if (Input.GetButtonDown("Fire2") && player3SelectEnemyCanvas.activeSelf && player3SpellSelected)
                {
                    player3SelectEnemyCanvas.SetActive(false);

                    player3SpellSelected = false;

                    player3SpellsMenuCanvas.SetActive(true);
                    EventSystem.current.SetSelectedGameObject(GameObject.Find("Spell1"), new BaseEventData(EventSystem.current));
                }

                // Player 4 press B

                if (Input.GetButtonDown("Fire2") && player4BaseMenuCanvas.activeSelf)
                {
                    player4CombatCanvas.SetActive(false);
                    player3TargetUnit = null;
                    player3SelectEnemyCanvas.SetActive(true);
                    EventSystem.current.SetSelectedGameObject(GameObject.Find("Enemy1"), new BaseEventData(EventSystem.current));
                }

                if (Input.GetButtonDown("Fire2") && player4SelectEnemyCanvas.activeSelf && player4BasicAttackSelected)
                {
                    player4SelectEnemyCanvas.SetActive(false);
                    player4BasicAttackSelected = false;
                    player4BaseMenuCanvas.SetActive(true);
                    EventSystem.current.SetSelectedGameObject(GameObject.Find("Attack"), new BaseEventData(EventSystem.current));
                }

                if (Input.GetButtonDown("Fire2") && player4SpellsMenuCanvas.activeSelf == true)
                {
                    player4SpellsMenuCanvas.SetActive(false);

                    player4BaseMenuCanvas.SetActive(true);
                    EventSystem.current.SetSelectedGameObject(GameObject.Find("Attack"), new BaseEventData(EventSystem.current));
                }

                if (Input.GetButtonDown("Fire2") && player4SelectEnemyCanvas.activeSelf && player4SpellSelected)
                {
                    player4SelectEnemyCanvas.SetActive(false);

                    player4SpellSelected = false;

                    player4SpellsMenuCanvas.SetActive(true);
                    EventSystem.current.SetSelectedGameObject(GameObject.Find("Spell1"), new BaseEventData(EventSystem.current));
                }


                break;

            case (BattleStates.ENEMYCHOICE):


                

                if (GameObject.Find("EnemyUnit1").GetComponent<EnemyInformation>().fallen == false || enemy1TargetUnit.GetComponent<PlayerInformation>().fallen == true)
                {
                    int unitSelected = Random.Range(1, 5);

                    if (enemy1Taunted == true)
                    {
                        unitSelected = 1;
                    }

                    enemy1TargetUnit = GameObject.Find("FriendlyUnit" + unitSelected);
                    if (enemy1TargetUnit.GetComponent<PlayerInformation>().fallen == false)
                    {
                        enemy1ValidUnitSelection = true;
                        enemy1TurnReady = true;
                    }

                    else
                    {
                        enemy1ValidUnitSelection = false;
                    }
                }

                if (GameObject.Find("EnemyUnit2").GetComponent<EnemyInformation>().fallen == false || enemy2TargetUnit.GetComponent<PlayerInformation>().fallen == true)
                {
                    int unitSelected = Random.Range(1, 5);

                    if (enemy2Taunted == true)
                    {
                        unitSelected = 1;
                    }

                    enemy2TargetUnit = GameObject.Find("FriendlyUnit" + unitSelected);
                    if (enemy2TargetUnit.GetComponent<PlayerInformation>().fallen == false)
                    {
                        enemy2ValidUnitSelection = true;
                        enemy2TurnReady = true;
                    }

                    else
                    {
                        enemy2ValidUnitSelection = false;
                    }
                }

                if (GameObject.Find("EnemyUnit3").GetComponent<EnemyInformation>().fallen == false || enemy3TargetUnit.GetComponent<PlayerInformation>().fallen == true)
                {
                    int unitSelected = Random.Range(1, 5);

                    if (enemy3Taunted == true)
                    {
                        unitSelected = 1;
                    }

                    enemy3TargetUnit = GameObject.Find("FriendlyUnit" + unitSelected);
                    if (enemy3TargetUnit.GetComponent<PlayerInformation>().fallen == false)
                    {
                        enemy3ValidUnitSelection = true;
                        enemy3TurnReady = true;
                    }

                    else
                    {
                        enemy3ValidUnitSelection = false;
                    }
                }

                if (GameObject.Find("EnemyUnit4").GetComponent<EnemyInformation>().fallen == false || enemy4TargetUnit.GetComponent<PlayerInformation>().fallen == true)
                {
                    int unitSelected = Random.Range(1, 5);

                    if (enemy4Taunted == true)
                    {
                        unitSelected = 1;
                    }

                    enemy4TargetUnit = GameObject.Find("FriendlyUnit" + unitSelected);
                    if (enemy4TargetUnit.GetComponent<PlayerInformation>().fallen == false)
                    {
                        enemy4ValidUnitSelection = true;
                        enemy4TurnReady = true;
                    }

                    else
                    {
                        enemy4ValidUnitSelection = false;
                    }
                }

                if (GameObject.Find("EnemyUnit5").GetComponent<EnemyInformation>().fallen == false || enemy5TargetUnit.GetComponent<PlayerInformation>().fallen == true)
                {
                    int unitSelected = Random.Range(1, 5);

                    if (enemy5Taunted == true)
                    {
                        unitSelected = 1;
                    }

                    enemy5TargetUnit = GameObject.Find("FriendlyUnit" + unitSelected);
                    if (enemy5TargetUnit.GetComponent<PlayerInformation>().fallen == false)
                    {
                        enemy5ValidUnitSelection = true;
                        enemy5TurnReady = true;
                    }

                    else
                    {
                        enemy5ValidUnitSelection = false;
                    }
                }

                if (GameObject.Find("EnemyUnit6").GetComponent<EnemyInformation>().fallen == false || enemy6TargetUnit.GetComponent<PlayerInformation>().fallen == true)
                {
                    int unitSelected = Random.Range(1, 5);

                    if (enemy6Taunted == true)
                    {
                        unitSelected = 1;
                    }

                    enemy6TargetUnit = GameObject.Find("FriendlyUnit" + unitSelected);
                    if (enemy6TargetUnit.GetComponent<PlayerInformation>().fallen == false)
                    {
                        enemy6ValidUnitSelection = true;
                        enemy6TurnReady = true;
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

                if (damageCalculationStarted == false)
                {
                    damageCalculationsCanvas.SetActive(true);
                    damageCalculationsText.GetComponent<Text>().text = "";

                    player1TotalResist = player1PhysicalResist + player1TechResist;
                    player2TotalResist = player2PhysicalResist + player2TechResist;
                    player3TotalResist = player3PhysicalResist + player3TechResist;
                    player4TotalResist = player4PhysicalResist + player4TechResist;

                    damageCalculationStarted = true;
                }

                timer += Time.deltaTime;

                if (timer >= 2 && player1TurnReady)
                {
                    player1PhysicalDamage -= player1TargetUnit.GetComponent<EnemyInformation>().physicalResist;
                    if (player1PhysicalDamage <= 0)
                    {
                        player1PhysicalDamage = 1;
                    }

                    player1TechDamage -= player1TargetUnit.GetComponent<EnemyInformation>().techResist;
                    if (player1TechDamage <= 0)
                    {
                        player1TechDamage = 1;
                    }

                    player1TotalDamage = player1PhysicalDamage + player1TechDamage;

                    player1TargetUnit.GetComponent<EnemyInformation>().currentHealthPoints -= player1TotalDamage;
                    damageCalculationsText.GetComponent<Text>().text =  GameObject.Find("FriendlyUnit1").GetComponent<PlayerInformation>().playerName + " attacks! \n" + player1TargetUnit.name + " takes " + player1TotalDamage + " damage!";
                    player1PhysicalDamage = 0;
                    player1TechDamage = 0;
                    player1TotalDamage = 0;
                    player1TurnReady = false;
                }

                if (timer >= 4 && player2TurnReady)
                {
                    player2PhysicalDamage -= player2TargetUnit.GetComponent<EnemyInformation>().physicalResist;
                    if (player2PhysicalDamage <= 0)
                    {
                        player2PhysicalDamage = 1;
                    }

                    player2TechDamage -= player2TargetUnit.GetComponent<EnemyInformation>().techResist;
                    if (player2TechDamage <= 0)
                    {
                        player2TechDamage = 1;
                    }

                    player2TotalDamage = player2PhysicalDamage + player1TechDamage;

                    if (player2SpellPoison)
                    {
                        damageCalculationsText.GetComponent<Text>().text = player2TargetUnit.name + " is now poisoned!";
                        int poisonDamage = player2TechDamage - player2TargetUnit.GetComponent<EnemyInformation>().techResist;
                        if (poisonDamage <= 0)
                        {
                            poisonDamage = 1;
                        }
                        player2TargetUnit.GetComponent<EnemyInformation>().poisoned = true;
                        player2TargetUnit.GetComponent<EnemyInformation>().poisonTimer += 2;
                        player2TargetUnit.GetComponent<EnemyInformation>().poisonDamage = poisonDamage;
                    }

                    player2TargetUnit.GetComponent<EnemyInformation>().currentHealthPoints -= player2TotalDamage;
                    damageCalculationsText.GetComponent<Text>().text = GameObject.Find("FriendlyUnit2").GetComponent<PlayerInformation>().playerName + " attacks! \n" + player2TargetUnit.name + " takes " + player2TotalDamage + " damage!";
                    player2PhysicalDamage = 0;
                    player2TechDamage = 0;
                    player2TotalDamage = 0;
                    player2TurnReady = false;
                }

                if (timer >= 6 && player3TurnReady)
                {
                    player3PhysicalDamage -= player3TargetUnit.GetComponent<EnemyInformation>().physicalResist;
                    if (player3PhysicalDamage <= 0)
                    {
                        player3PhysicalDamage = 1;
                    }

                    player3TechDamage -= player3TargetUnit.GetComponent<EnemyInformation>().techResist;
                    if (player3TechDamage <= 0)
                    {
                        player3TechDamage = 1;
                    }

                    player3TotalDamage = player3PhysicalDamage + player3TechDamage;

                    player3TargetUnit.GetComponent<EnemyInformation>().currentHealthPoints -= player3TotalDamage;
                    damageCalculationsText.GetComponent<Text>().text = GameObject.Find("FriendlyUnit3").GetComponent<PlayerInformation>().playerName + " attacks! \n" + player3TargetUnit.name + " takes " + player3TotalDamage + " damage!";
                    player3PhysicalDamage = 0;
                    player3TechDamage = 0;
                    player3TotalDamage = 0;
                    player3TurnReady = false;
                }

                if (timer >= 8 && player4TurnReady)
                {
                    player4PhysicalDamage -= player4TargetUnit.GetComponent<EnemyInformation>().physicalResist;
                    if (player4PhysicalDamage <= 0)
                    {
                        player4PhysicalDamage = 1;
                    }

                    player4TechDamage -= player4TargetUnit.GetComponent<EnemyInformation>().techResist;
                    if (player4TechDamage <= 0)
                    {
                        player4TechDamage = 1;
                    }

                    player4TotalDamage = player4PhysicalDamage + player4TechDamage;

                    player4TargetUnit.GetComponent<EnemyInformation>().currentHealthPoints -= player4TotalDamage;
                    damageCalculationsText.GetComponent<Text>().text = GameObject.Find("FriendlyUnit4").GetComponent<PlayerInformation>().playerName + " attacks! \n" + player4TargetUnit.name + " takes " + player4TotalDamage + " damage!";
                    player4PhysicalDamage = 0;
                    player4TechDamage = 0;
                    player4TotalDamage = 0;
                    player4TurnReady = false;
                }

                if (timer >= 10 && enemy1TurnReady)
                {
                    enemy1TurnReady = false;
                    Debug.Log("Enemy1s turn");
                    if (GameObject.Find("EnemyUnit1").GetComponent<EnemyInformation>().fallen == false && enemy1TargetUnit.GetComponent<PlayerInformation>().fallen == false)
                    {
                        Debug.Log("Enemy1 attacks.");
                        enemy1PhysicalDamage = GameObject.Find("EnemyUnit1").GetComponent<EnemyInformation>().physicalDamage - enemy1TargetUnit.GetComponent<PlayerInformation>().physicalResist;
                        if (enemy1PhysicalDamage <= 0)
                        {
                            enemy1PhysicalDamage = 1;
                        }

                        if (enemy1TechDamage <= 0)
                        {
                            enemy1TechDamage = 1;
                        }

                        enemy1TotalDamage = enemy1PhysicalDamage + enemy1TechDamage;

                        GameObject.Find("EnemyUnit1").GetComponent<EnemyInformation>().attacks = true;
                        enemy1TargetUnit.GetComponent<PlayerInformation>().healthPointsCurrent -= enemy1TotalDamage;
                        damageCalculationsText.GetComponent<Text>().text = GameObject.Find("EnemyUnit1").GetComponent<EnemyInformation>().Enemy.name + " attacks! \n" + enemy1TargetUnit.name + " takes " + enemy1TotalDamage + " damage!";
                        enemy1PhysicalDamage = 0;
                        enemy1TechDamage = 0;
                        enemy1TotalDamage = 0;

                        if (GameObject.Find("EnemyUnit1").GetComponent<EnemyInformation>().poisoned)
                        {
                            GameObject.Find("EnemyUnit1").GetComponent<EnemyInformation>().currentHealthPoints -= GameObject.Find("EnemyUnit1").GetComponent<EnemyInformation>().poisonDamage;
                            GameObject.Find("EnemyUnit1").GetComponent<EnemyInformation>().poisonTimer -= 1;
                        }
                    }
                    else
                    {
                        damageCalculationsText.GetComponent<Text>().text = "Enemy1 is DEAD!";
                    }
                }

                if (timer >= 12 && enemy2TurnReady)
                {
                    enemy2TurnReady = false;
                    Debug.Log("Enemy2's turn");
                    if (GameObject.Find("EnemyUnit2").GetComponent<EnemyInformation>().fallen == false && enemy2TargetUnit.GetComponent<PlayerInformation>().fallen == false)
                    {
                        enemy2PhysicalDamage = GameObject.Find("EnemyUnit2").GetComponent<EnemyInformation>().physicalDamage - enemy2TargetUnit.GetComponent<PlayerInformation>().physicalResist;
                        if (enemy2PhysicalDamage <= 0)
                        {
                            enemy2PhysicalDamage = 1;
                        }

                        if (enemy2TechDamage <= 0)
                        {
                            enemy2TechDamage = 1;
                        }

                        enemy2TotalDamage = enemy2PhysicalDamage + enemy2TechDamage;

                        GameObject.Find("EnemyUnit2").GetComponent<EnemyInformation>().attacks = true;
                        enemy2TargetUnit.GetComponent<PlayerInformation>().healthPointsCurrent -= enemy2TotalDamage;
                        damageCalculationsText.GetComponent<Text>().text = GameObject.Find("EnemyUnit2").GetComponent<EnemyInformation>().Enemy.name + " attacks! \n" + enemy2TargetUnit.name + " takes " + enemy2TotalDamage + " damage!";
                        enemy2PhysicalDamage = 0;
                        enemy2TechDamage = 0;
                        enemy2TotalDamage = 0;

                        if (GameObject.Find("EnemyUnit2").GetComponent<EnemyInformation>().poisoned)
                        {
                            GameObject.Find("EnemyUnit2").GetComponent<EnemyInformation>().currentHealthPoints -= GameObject.Find("EnemyUnit2").GetComponent<EnemyInformation>().poisonDamage;
                            GameObject.Find("EnemyUnit2").GetComponent<EnemyInformation>().poisonTimer -= 1;
                        }
                    }
                    else
                    {
                        damageCalculationsText.GetComponent<Text>().text = "Enemy2 is DEAD!";
                    }
                }

                if (timer >= 14 && enemy3TurnReady)
                {
                    enemy3TurnReady = false;
                    if (GameObject.Find("EnemyUnit3").GetComponent<EnemyInformation>().fallen == false && enemy3TargetUnit.GetComponent<PlayerInformation>().fallen == false)
                    {
                        enemy3PhysicalDamage = GameObject.Find("EnemyUnit3").GetComponent<EnemyInformation>().physicalDamage - enemy3TargetUnit.GetComponent<PlayerInformation>().physicalResist;
                        if (enemy3PhysicalDamage <= 0)
                        {
                            enemy3PhysicalDamage = 1;
                        }

                        if (enemy3TechDamage <= 0)
                        {
                            enemy3TechDamage = 1;
                        }

                        enemy3TotalDamage = enemy3PhysicalDamage + enemy3TechDamage;

                        GameObject.Find("EnemyUnit3").GetComponent<EnemyInformation>().attacks = true;
                        enemy3TargetUnit.GetComponent<PlayerInformation>().healthPointsCurrent -= enemy3TotalDamage;
                        damageCalculationsText.GetComponent<Text>().text = GameObject.Find("EnemyUnit3").GetComponent<EnemyInformation>().Enemy.name + " attacks! \n" + enemy3TargetUnit.name + " takes " + enemy3TotalDamage + " damage!";
                        enemy3PhysicalDamage = 0;
                        enemy3TechDamage = 0;
                        enemy3TotalDamage = 0;

                        if (GameObject.Find("EnemyUnit3").GetComponent<EnemyInformation>().poisoned)
                        {
                            GameObject.Find("EnemyUnit3").GetComponent<EnemyInformation>().currentHealthPoints -= GameObject.Find("EnemyUnit3").GetComponent<EnemyInformation>().poisonDamage;
                            GameObject.Find("EnemyUnit3").GetComponent<EnemyInformation>().poisonTimer -= 1;
                        }
                    }
                    else
                    {
                        damageCalculationsText.GetComponent<Text>().text = "Enemy3 is DEAD!";
                    }
                }

                if (timer >= 16 && enemy4TurnReady)
                {
                    enemy4TurnReady = false;
                    if (GameObject.Find("EnemyUnit4").GetComponent<EnemyInformation>().fallen == false && enemy4TargetUnit.GetComponent<PlayerInformation>().fallen == false)
                    {
                        enemy4PhysicalDamage = GameObject.Find("EnemyUnit4").GetComponent<EnemyInformation>().physicalDamage - enemy4TargetUnit.GetComponent<PlayerInformation>().physicalResist;
                        if (enemy4PhysicalDamage <= 0)
                        {
                            enemy4PhysicalDamage = 1;
                        }

                        if (enemy4TechDamage <= 0)
                        {
                            enemy4TechDamage = 1;
                        }

                        enemy4TotalDamage = enemy4PhysicalDamage + enemy4TechDamage;

                        GameObject.Find("EnemyUnit4").GetComponent<EnemyInformation>().attacks = true;
                        enemy4TargetUnit.GetComponent<PlayerInformation>().healthPointsCurrent -= enemy4TotalDamage;
                        damageCalculationsText.GetComponent<Text>().text = GameObject.Find("EnemyUnit4").GetComponent<EnemyInformation>().Enemy.name + " attacks! \n" + enemy4TargetUnit.name + " takes " + enemy4TotalDamage + " damage!";
                        enemy4PhysicalDamage = 0;
                        enemy4TechDamage = 0;
                        enemy4TotalDamage = 0;

                        if (GameObject.Find("EnemyUnit4").GetComponent<EnemyInformation>().poisoned)
                        {
                            GameObject.Find("EnemyUnit4").GetComponent<EnemyInformation>().currentHealthPoints -= GameObject.Find("EnemyUnit4").GetComponent<EnemyInformation>().poisonDamage;
                            GameObject.Find("EnemyUnit4").GetComponent<EnemyInformation>().poisonTimer -= 1;
                        }
                    }
                    else
                    {
                        damageCalculationsText.GetComponent<Text>().text = "Enemy4 is DEAD!";
                    }
                }

                if (timer >= 18 && enemy5TurnReady)
                {
                    enemy5TurnReady = false;
                    if (GameObject.Find("EnemyUnit5").GetComponent<EnemyInformation>().fallen == false && enemy5TargetUnit.GetComponent<PlayerInformation>().fallen == false)
                    {
                        enemy5PhysicalDamage = GameObject.Find("EnemyUnit5").GetComponent<EnemyInformation>().physicalDamage - enemy5TargetUnit.GetComponent<PlayerInformation>().physicalResist;
                        if (enemy5PhysicalDamage <= 0)
                        {
                            enemy5PhysicalDamage = 1;
                        }

                        if (enemy5TechDamage <= 0)
                        {
                            enemy5TechDamage = 1;
                        }

                        enemy5TotalDamage = enemy5PhysicalDamage + enemy5TechDamage;

                        GameObject.Find("EnemyUnit5").GetComponent<EnemyInformation>().attacks = true;
                        enemy5TargetUnit.GetComponent<PlayerInformation>().healthPointsCurrent -= enemy5TotalDamage;
                        damageCalculationsText.GetComponent<Text>().text = GameObject.Find("EnemyUnit5").GetComponent<EnemyInformation>().Enemy.name + " attacks! \n" + enemy5TargetUnit.name + " takes " + enemy5TotalDamage + " damage!";
                        enemy5PhysicalDamage = 0;
                        enemy5TechDamage = 0;
                        enemy5TotalDamage = 0;

                        if (GameObject.Find("EnemyUnit5").GetComponent<EnemyInformation>().poisoned)
                        {
                            GameObject.Find("EnemyUnit5").GetComponent<EnemyInformation>().currentHealthPoints -= GameObject.Find("EnemyUnit5").GetComponent<EnemyInformation>().poisonDamage;
                            GameObject.Find("EnemyUnit5").GetComponent<EnemyInformation>().poisonTimer -= 1;
                        }
                    }
                    else
                    {
                        damageCalculationsText.GetComponent<Text>().text = "Enemy5 is DEAD!";
                    }
                }

                if (timer >= 20 && enemy6TurnReady)
                {
                    enemy6TurnReady = false;
                    if (GameObject.Find("EnemyUnit6").GetComponent<EnemyInformation>().fallen == false && enemy6TargetUnit.GetComponent<PlayerInformation>().fallen == false)
                    {
                        enemy6PhysicalDamage = GameObject.Find("EnemyUnit6").GetComponent<EnemyInformation>().physicalDamage - enemy6TargetUnit.GetComponent<PlayerInformation>().physicalResist;
                        if (enemy6PhysicalDamage <= 0)
                        {
                            enemy6PhysicalDamage = 1;
                        }

                        if (enemy6TechDamage <= 0)
                        {
                            enemy6TechDamage = 1;
                        }

                        enemy6TotalDamage = enemy6PhysicalDamage + enemy6TechDamage;

                        GameObject.Find("EnemyUnit6").GetComponent<EnemyInformation>().attacks = true;
                        enemy6TargetUnit.GetComponent<PlayerInformation>().healthPointsCurrent -= enemy6TotalDamage;
                        damageCalculationsText.GetComponent<Text>().text = GameObject.Find("EnemyUnit6").GetComponent<EnemyInformation>().Enemy.name + " attacks! \n" + enemy6TargetUnit.name + " takes " + enemy6TotalDamage + " damage!";
                        enemy6PhysicalDamage = 0;
                        enemy6TechDamage = 0;
                        enemy6TotalDamage = 0;

                        if (GameObject.Find("EnemyUnit6").GetComponent<EnemyInformation>().poisoned)
                        {
                            GameObject.Find("EnemyUnit6").GetComponent<EnemyInformation>().currentHealthPoints -= GameObject.Find("EnemyUnit6").GetComponent<EnemyInformation>().poisonDamage;
                            GameObject.Find("EnemyUnit6").GetComponent<EnemyInformation>().poisonTimer -= 1;
                        }
                    }
                    else
                    {
                        damageCalculationsText.GetComponent<Text>().text = "Enemy6 is DEAD!";
                    }
                }

                if (timer >= 22)
                {
                    Debug.Log("Start next turn.");
                    player1TotalResist = 0;
                    player1PhysicalResist = GameObject.Find("FriendlyUnit1").GetComponent<PlayerInformation>().physicalResist;
                    player1TechResist = GameObject.Find("FriendlyUnit1").GetComponent<PlayerInformation>().techResist;

                    player2TotalResist = 0;
                    player2PhysicalResist = GameObject.Find("FriendlyUnit2").GetComponent<PlayerInformation>().physicalResist;
                    player2TechResist = GameObject.Find("FriendlyUnit2").GetComponent<PlayerInformation>().techResist;

                    player3TotalResist = 0;
                    player3PhysicalResist = GameObject.Find("FriendlyUnit3").GetComponent<PlayerInformation>().physicalResist;
                    player3TechResist = GameObject.Find("FriendlyUnit3").GetComponent<PlayerInformation>().techResist;

                    player4TotalResist = 0;
                    player4PhysicalResist = GameObject.Find("FriendlyUnit4").GetComponent<PlayerInformation>().physicalResist;
                    player4TechResist = GameObject.Find("FriendlyUnit4").GetComponent<PlayerInformation>().techResist;

                    enemy1Taunted = false;
                    enemy2Taunted = false;
                    enemy3Taunted = false;
                    enemy4Taunted = false;
                    enemy5Taunted = false;
                    enemy6Taunted = false;

                    timer = 0;
                    damageCalculationStarted = false;
                    currentState = BattleStates.START;
                }
            
                



                //calculateDamageTargetUnit = null;
                break;

            case (BattleStates.WIN):

                damageCalculationsCanvas.SetActive(true);
                damageCalculationsText.GetComponent<Text>().text = "Your party wins!";

                GivePlayer1Experience();
                GivePlayer2Experience();
                GivePlayer3Experience();
                GivePlayer4Experience();

                if (Input.GetButtonDown("Fire1"))
                {
                    SceneManager.LoadScene("");
                }


                // Bring up a victory message!
                // On click/confirm send player back into world

                break;

            case (BattleStates.LOSE):

                damageCalculationsText.GetComponent<Text>().text = "Your party loses...";

                if (Input.GetButtonDown("Fire1"))
                {
                    SceneManager.LoadScene("MainMenu");
                }
                // Bring up a loss message!
                // Send the player back to the main menu

                break;
        }
    }

    // Give players experience functions

    public void GivePlayer1Experience()
    {
        GameObject.Find("GameInformation").GetComponent<PlayerGlobalInformation>().player1CurrentEXP +=
                    GameObject.Find("EnemyUnit1").GetComponent<EnemyInformation>().expGiven +
                        GameObject.Find("EnemyUnit2").GetComponent<EnemyInformation>().expGiven +
                            GameObject.Find("EnemyUnit3").GetComponent<EnemyInformation>().expGiven +
                                GameObject.Find("EnemyUnit4").GetComponent<EnemyInformation>().expGiven +
                                    GameObject.Find("EnemyUnit5").GetComponent<EnemyInformation>().expGiven +
                                        GameObject.Find("EnemyUnit6").GetComponent<EnemyInformation>().expGiven;
    }

    public void GivePlayer2Experience()
    {
        GameObject.Find("GameInformation").GetComponent<PlayerGlobalInformation>().player2CurrentEXP +=
                    GameObject.Find("EnemyUnit1").GetComponent<EnemyInformation>().expGiven +
                        GameObject.Find("EnemyUnit2").GetComponent<EnemyInformation>().expGiven +
                            GameObject.Find("EnemyUnit3").GetComponent<EnemyInformation>().expGiven +
                                GameObject.Find("EnemyUnit4").GetComponent<EnemyInformation>().expGiven +
                                    GameObject.Find("EnemyUnit5").GetComponent<EnemyInformation>().expGiven +
                                        GameObject.Find("EnemyUnit6").GetComponent<EnemyInformation>().expGiven;
    }

    public void GivePlayer3Experience()
    {
        GameObject.Find("GameInformation").GetComponent<PlayerGlobalInformation>().player3CurrentEXP +=
                    GameObject.Find("EnemyUnit1").GetComponent<EnemyInformation>().expGiven +
                        GameObject.Find("EnemyUnit2").GetComponent<EnemyInformation>().expGiven +
                            GameObject.Find("EnemyUnit3").GetComponent<EnemyInformation>().expGiven +
                                GameObject.Find("EnemyUnit4").GetComponent<EnemyInformation>().expGiven +
                                    GameObject.Find("EnemyUnit5").GetComponent<EnemyInformation>().expGiven +
                                        GameObject.Find("EnemyUnit6").GetComponent<EnemyInformation>().expGiven;
    }

    public void GivePlayer4Experience()
    {
        GameObject.Find("GameInformation").GetComponent<PlayerGlobalInformation>().player4CurrentEXP +=
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
        player1PhysicalDamage += GameObject.Find("FriendlyUnit1").GetComponent<PlayerInformation>().physicalDamage * 1;
        player1SelectEnemyCanvas.SetActive(true);
        EventSystem.current.SetSelectedGameObject(GameObject.Find ("Enemy1"), new BaseEventData (EventSystem.current));
    }

    public void OnPlayer2ClickAttack()
    {
        player2BaseMenuCanvas.SetActive(false);
        player2BasicAttackSelected = true;
        player2PhysicalDamage += GameObject.Find("FriendlyUnit2").GetComponent<PlayerInformation>().physicalDamage * 1;
        player2SelectEnemyCanvas.SetActive(true);
        EventSystem.current.SetSelectedGameObject(GameObject.Find("Enemy1"), new BaseEventData(EventSystem.current));
    }

    public void OnPlayer3ClickAttack()
    {
        player3BaseMenuCanvas.SetActive(false);
        player3BasicAttackSelected = true;
        player3PhysicalDamage += GameObject.Find("FriendlyUnit3").GetComponent<PlayerInformation>().physicalDamage * 1;
        player3SelectEnemyCanvas.SetActive(true);
        EventSystem.current.SetSelectedGameObject(GameObject.Find("Enemy1"), new BaseEventData(EventSystem.current));
    }

    public void OnPlayer4ClickAttack()
    {
        player4BaseMenuCanvas.SetActive(false);
        player4BasicAttackSelected = true;
        player4PhysicalDamage += GameObject.Find("FriendlyUnit4").GetComponent<PlayerInformation>().physicalDamage * 1;
        player4SelectEnemyCanvas.SetActive(true);
        EventSystem.current.SetSelectedGameObject(GameObject.Find("Enemy1"), new BaseEventData(EventSystem.current));
    }

    // Player1ClickSpells buttons

    public void OnPlayer1ClickSpells()
    {
        player1SpellsMenuCanvas.SetActive(true);
    }

    public void OnPlayer1ClickSpellTaunt()
    {
        player1SpellsMenuCanvas.SetActive(false);

        int tauntSuccess = Random.Range(1, 7);

        if (tauntSuccess == 1)
        {
            enemy1Taunted = true;
        }

        else if (tauntSuccess == 2)
        {
            enemy1Taunted = true;
            enemy2Taunted = true;
        }

        else if (tauntSuccess == 3)
        {
            enemy1Taunted = true;
            enemy2Taunted = true;
            enemy3Taunted = true;
        }

        else if (tauntSuccess == 4)
        {
            enemy1Taunted = true;
            enemy2Taunted = true;
            enemy3Taunted = true;
            enemy4Taunted = true;
        }

        else if (tauntSuccess == 5)
        {
            enemy1Taunted = true;
            enemy2Taunted = true;
            enemy3Taunted = true;
            enemy4Taunted = true;
            enemy5Taunted = true;
        }

        else
        {
            enemy1Taunted = true;
            enemy2Taunted = true;
            enemy3Taunted = true;
            enemy4Taunted = true;
            enemy5Taunted = true;
            enemy6Taunted = true;
        }

        player1PhysicalResist += GameObject.Find("FriendlyUnit1").GetComponent<PlayerInformation>().physicalResist * 2;
        player1TechResist += GameObject.Find("FriendlyUnit1").GetComponent<PlayerInformation>().techResist * 1;

        

        player1SelectEnemyCanvas.SetActive(true);
    }

    // Player2ClickSpells buttons

    public void OnPlayer2ClickSpells()
    {
        player2SpellsMenuCanvas.SetActive(true);
    }

    public void OnPlayer2ClickSpellPoison()
    {
        player2SpellsMenuCanvas.SetActive(false);
        player2PhysicalDamage += GameObject.Find("FriendlyUnit2").GetComponent<PlayerInformation>().physicalDamage;
        player2SelectEnemyCanvas.SetActive(true);
        EventSystem.current.SetSelectedGameObject(GameObject.Find("Enemy1"), new BaseEventData(EventSystem.current));
    }

    // Player3ClickSpells buttons

    public void OnPlayer3ClickSpells()
    {
        player3SpellsMenuCanvas.SetActive(true);
    }

    // Player4ClickSpells buttons

    public void OnPlayer4ClickSpells()
    {
        player4SpellsMenuCanvas.SetActive(true);
    }

    // PlayersClickGuard

    public void OnPlayer1ClickGuard()
    {
        player1PhysicalResist += GameObject.Find("FriendlyUnit1").GetComponent<PlayerInformation>().physicalResist * 1;
        player1TechResist += GameObject.Find("FriendlyUnit1").GetComponent<PlayerInformation>().techResist * 1;

        player1BaseMenuCanvas.SetActive(false);
        player2BaseMenuCanvas.SetActive(true);
        currentState = BattleStates.ENEMYCHOICE;
    }

    public void OnPlayer2ClickGuard()
    {
        player2PhysicalResist += GameObject.Find("FriendlyUnit2").GetComponent<PlayerInformation>().physicalResist * 1;
        player2TechResist += GameObject.Find("FriendlyUnit2").GetComponent<PlayerInformation>().techResist * 1;

        player2BaseMenuCanvas.SetActive(false);
        player3BaseMenuCanvas.SetActive(true);
        currentState = BattleStates.ENEMYCHOICE;
    }

    public void OnPlayer3ClickGuard()
    {
        player3PhysicalResist += GameObject.Find("FriendlyUnit3").GetComponent<PlayerInformation>().physicalResist * 1;
        player3TechResist += GameObject.Find("FriendlyUnit3").GetComponent<PlayerInformation>().techResist * 1;

        player3BaseMenuCanvas.SetActive(false);
        player4BaseMenuCanvas.SetActive(true);
        currentState = BattleStates.ENEMYCHOICE;
    }

    public void OnPlayer4ClickGuard()
    {
        player4PhysicalResist += GameObject.Find("FriendlyUnit4").GetComponent<PlayerInformation>().physicalResist * 1;
        player4TechResist += GameObject.Find("FriendlyUnit4").GetComponent<PlayerInformation>().techResist * 1;

        player4BaseMenuCanvas.SetActive(false);

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
        player2CombatCanvas.SetActive(true);
        player2BaseMenuCanvas.SetActive(true);
        player2SpellsMenuCanvas.SetActive(false);
        player2SelectEnemyCanvas.SetActive(false);
        player1TurnReady = true;
        EventSystem.current.SetSelectedGameObject(GameObject.Find("Attack"), new BaseEventData(EventSystem.current));
    }

    public void OnPlayer1ClickEnemy2Button()
    {
        player1TargetUnit = GameObject.Find("EnemyUnit2");
        if (player1TargetUnit.GetComponent<EnemyInformation>().fallen == true)
        {
            return;
        }
        player1SelectEnemyCanvas.SetActive(false);
        player2CombatCanvas.SetActive(true);
        player2BaseMenuCanvas.SetActive(true);
        player2SpellsMenuCanvas.SetActive(false);
        player2SelectEnemyCanvas.SetActive(false);
        player1TurnReady = true;
        EventSystem.current.SetSelectedGameObject(GameObject.Find("Attack"), new BaseEventData(EventSystem.current));
    }

    public void OnPlayer1ClickEnemy3Button()
    {
        player1TargetUnit = GameObject.Find("EnemyUnit3");
        if (player1TargetUnit.GetComponent<EnemyInformation>().fallen == true)
        {
            return;
        }
        player1SelectEnemyCanvas.SetActive(false);
        player2CombatCanvas.SetActive(true);
        player2BaseMenuCanvas.SetActive(true);
        player2SpellsMenuCanvas.SetActive(false);
        player2SelectEnemyCanvas.SetActive(false);
        player1TurnReady = true;
        EventSystem.current.SetSelectedGameObject(GameObject.Find("Attack"), new BaseEventData(EventSystem.current));
    }

    public void OnPlayer1ClickEnemy4Button()
    {
        player1TargetUnit = GameObject.Find("EnemyUnit4");
        if (player1TargetUnit.GetComponent<EnemyInformation>().fallen == true)
        {
            return;
        }
        player1SelectEnemyCanvas.SetActive(false);
        player2CombatCanvas.SetActive(true);
        player2BaseMenuCanvas.SetActive(true);
        player2SpellsMenuCanvas.SetActive(false);
        player2SelectEnemyCanvas.SetActive(false);
        player1TurnReady = true;
        EventSystem.current.SetSelectedGameObject(GameObject.Find("Attack"), new BaseEventData(EventSystem.current));
    }

    public void OnPlayer1ClickEnemy5Button()
    {
        player1TargetUnit = GameObject.Find("EnemyUnit5");
        if (player1TargetUnit.GetComponent<EnemyInformation>().fallen == true)
        {
            return;
        }
        player1SelectEnemyCanvas.SetActive(false);
        player2CombatCanvas.SetActive(true);
        player2BaseMenuCanvas.SetActive(true);
        player2SpellsMenuCanvas.SetActive(false);
        player2SelectEnemyCanvas.SetActive(false);
        player1TurnReady = true;
        EventSystem.current.SetSelectedGameObject(GameObject.Find("Attack"), new BaseEventData(EventSystem.current));
    }

    public void OnPlayer1ClickEnemy6Button()
    {
        player1TargetUnit = GameObject.Find("EnemyUnit6");
        if (player1TargetUnit.GetComponent<EnemyInformation>().fallen == true)
        {
            return;
        }
        player1SelectEnemyCanvas.SetActive(false);
        player2CombatCanvas.SetActive(true);
        player2BaseMenuCanvas.SetActive(true);
        player2SpellsMenuCanvas.SetActive(false);
        player2SelectEnemyCanvas.SetActive(false);
        player1TurnReady = true;
        EventSystem.current.SetSelectedGameObject(GameObject.Find("Attack"), new BaseEventData(EventSystem.current));
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
        player3CombatCanvas.SetActive(true);
        player3BaseMenuCanvas.SetActive(true);
        player3SpellsMenuCanvas.SetActive(false);
        player3SelectEnemyCanvas.SetActive(false);
        player2TurnReady = true;
        EventSystem.current.SetSelectedGameObject(GameObject.Find("Attack"), new BaseEventData(EventSystem.current));
    }

    public void OnPlayer2ClickEnemy2Button()
    {
        player2TargetUnit = GameObject.Find("EnemyUnit2");
        if (player2TargetUnit.GetComponent<EnemyInformation>().fallen == true)
        {
            return;
        }
        player2SelectEnemyCanvas.SetActive(false);
        player3CombatCanvas.SetActive(true);
        player3BaseMenuCanvas.SetActive(true);
        player3SpellsMenuCanvas.SetActive(false);
        player3SelectEnemyCanvas.SetActive(false);
        player2TurnReady = true;
        EventSystem.current.SetSelectedGameObject(GameObject.Find("Attack"), new BaseEventData(EventSystem.current));
    }

    public void OnPlayer2ClickEnemy3Button()
    {
        player2TargetUnit = GameObject.Find("EnemyUnit3");
        if (player2TargetUnit.GetComponent<EnemyInformation>().fallen == true)
        {
            return;
        }
        player2SelectEnemyCanvas.SetActive(false);
        player3CombatCanvas.SetActive(true);
        player3BaseMenuCanvas.SetActive(true);
        player3SpellsMenuCanvas.SetActive(false);
        player3SelectEnemyCanvas.SetActive(false);
        player2TurnReady = true;
        EventSystem.current.SetSelectedGameObject(GameObject.Find("Attack"), new BaseEventData(EventSystem.current));
    }

    public void OnPlayer2ClickEnemy4Button()
    {
        player2TargetUnit = GameObject.Find("EnemyUnit4");
        if (player2TargetUnit.GetComponent<EnemyInformation>().fallen == true)
        {
            return;
        }
        player2SelectEnemyCanvas.SetActive(false);
        player3CombatCanvas.SetActive(true);
        player3BaseMenuCanvas.SetActive(true);
        player3SpellsMenuCanvas.SetActive(false);
        player3SelectEnemyCanvas.SetActive(false);
        player2TurnReady = true;
        EventSystem.current.SetSelectedGameObject(GameObject.Find("Attack"), new BaseEventData(EventSystem.current));
    }

    public void OnPlayer2ClickEnemy5Button()
    {
        player2TargetUnit = GameObject.Find("EnemyUnit5");
        if (player2TargetUnit.GetComponent<EnemyInformation>().fallen == true)
        {
            return;
        }
        player2SelectEnemyCanvas.SetActive(false);
        player3CombatCanvas.SetActive(true);
        player3BaseMenuCanvas.SetActive(true);
        player3SpellsMenuCanvas.SetActive(false);
        player3SelectEnemyCanvas.SetActive(false);
        player2TurnReady = true;
        EventSystem.current.SetSelectedGameObject(GameObject.Find("Attack"), new BaseEventData(EventSystem.current));
    }

    public void OnPlayer2ClickEnemy6Button()
    {
        player2TargetUnit = GameObject.Find("EnemyUnit6");
        if (player2TargetUnit.GetComponent<EnemyInformation>().fallen == true)
        {
            return;
        }
        player2SelectEnemyCanvas.SetActive(false);
        player3CombatCanvas.SetActive(true);
        player3BaseMenuCanvas.SetActive(true);
        player3SpellsMenuCanvas.SetActive(false);
        player3SelectEnemyCanvas.SetActive(false);
        player2TurnReady = true;
        EventSystem.current.SetSelectedGameObject(GameObject.Find("Attack"), new BaseEventData(EventSystem.current));
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
        player4CombatCanvas.SetActive(true);
        player4BaseMenuCanvas.SetActive(true);
        player4SpellsMenuCanvas.SetActive(false);
        player4SelectEnemyCanvas.SetActive(false);
        player3TurnReady = true;
        EventSystem.current.SetSelectedGameObject(GameObject.Find("Attack"), new BaseEventData(EventSystem.current));
    }

    public void OnPlayer3ClickEnemy2Button()
    {
        player3TargetUnit = GameObject.Find("EnemyUnit2");
        if (player3TargetUnit.GetComponent<EnemyInformation>().fallen == true)
        {
            return;
        }
        player3SelectEnemyCanvas.SetActive(false);
        player4CombatCanvas.SetActive(true);
        player4BaseMenuCanvas.SetActive(true);
        player4SpellsMenuCanvas.SetActive(false);
        player4SelectEnemyCanvas.SetActive(false);
        player3TurnReady = true;
        EventSystem.current.SetSelectedGameObject(GameObject.Find("Attack"), new BaseEventData(EventSystem.current));
    }

    public void OnPlayer3ClickEnemy3Button()
    {
        player3TargetUnit = GameObject.Find("EnemyUnit3");
        if (player3TargetUnit.GetComponent<EnemyInformation>().fallen == true)
        {
            return;
        }
        player3SelectEnemyCanvas.SetActive(false);
        player4CombatCanvas.SetActive(true);
        player4BaseMenuCanvas.SetActive(true);
        player4SpellsMenuCanvas.SetActive(false);
        player4SelectEnemyCanvas.SetActive(false);
        player3TurnReady = true;
        EventSystem.current.SetSelectedGameObject(GameObject.Find("Attack"), new BaseEventData(EventSystem.current));
    }

    public void OnPlayer3ClickEnemy4Button()
    {
        player3TargetUnit = GameObject.Find("EnemyUnit4");
        if (player3TargetUnit.GetComponent<EnemyInformation>().fallen == true)
        {
            return;
        }
        player3SelectEnemyCanvas.SetActive(false);
        player4CombatCanvas.SetActive(true);
        player4BaseMenuCanvas.SetActive(true);
        player4SpellsMenuCanvas.SetActive(false);
        player4SelectEnemyCanvas.SetActive(false);
        player3TurnReady = true;
        EventSystem.current.SetSelectedGameObject(GameObject.Find("Attack"), new BaseEventData(EventSystem.current));
    }

    public void OnPlayer3ClickEnemy5Button()
    {
        player3TargetUnit = GameObject.Find("EnemyUnit5");
        if (player3TargetUnit.GetComponent<EnemyInformation>().fallen == true)
        {
            return;
        }
        player3SelectEnemyCanvas.SetActive(false);
        player4CombatCanvas.SetActive(true);
        player4BaseMenuCanvas.SetActive(true);
        player4SpellsMenuCanvas.SetActive(false);
        player4SelectEnemyCanvas.SetActive(false);
        player3TurnReady = true;
        EventSystem.current.SetSelectedGameObject(GameObject.Find("Attack"), new BaseEventData(EventSystem.current));

    }

    public void OnPlayer3ClickEnemy6Button()
    {
        player3TargetUnit = GameObject.Find("EnemyUnit6");
        if (player3TargetUnit.GetComponent<EnemyInformation>().fallen == true)
        {
            return;
        }
        player3SelectEnemyCanvas.SetActive(false);
        player4CombatCanvas.SetActive(true);
        player4BaseMenuCanvas.SetActive(true);
        player4SpellsMenuCanvas.SetActive(false);
        player4SelectEnemyCanvas.SetActive(false);
        player3TurnReady = true;
        EventSystem.current.SetSelectedGameObject(GameObject.Find("Attack"), new BaseEventData(EventSystem.current));
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
        player4CombatCanvas.SetActive(false);
        player4TurnReady = true;
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
        player4CombatCanvas.SetActive(false);
        player4TurnReady = true;
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
        player4CombatCanvas.SetActive(false);
        player4TurnReady = true;
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
        player4CombatCanvas.SetActive(false);
        player4TurnReady = true;
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
        player4CombatCanvas.SetActive(false);
        player4TurnReady = true;
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
        player4CombatCanvas.SetActive(false);
        player4TurnReady = true;
        currentState = BattleStates.ENEMYCHOICE;
    }
}
