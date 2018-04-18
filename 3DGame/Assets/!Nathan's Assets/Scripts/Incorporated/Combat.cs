using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour {

    public GameObject BattleMenu;
    public GameObject InfoPanel;
    public GameObject MovesInfo;
    public GameObject MessagePanel;

    public enum BattleStates
    {
        Start,
        PlayerChoice,
        PlayerPhase1,
        PlayerPhase2,
        PlayerPhase3,
        PlayerPhase4,
        //EnemyChoice, // I *THINK* this is necessary
        EnemyPhase1,
        EnemyPhase2,
        EnemyPhase3,
        EnemyPhase4,
        EnemyPhase5,
        EnemyPhase6,
        UpdatePhase,
        Win,
        Lose
    }

    private void Awake()
    {
        currentState = BattleStates.Start;
    }

    public static BattleStates currentState;

    void Start()
    {
        
    }

    void Update()
    {
        Debug.Log(currentState);
        switch (currentState)
        {
            case (BattleStates.Start):
                //battleStartScript.PrepareBattle();

                break;

            case (BattleStates.PlayerChoice):

                break;

            case (BattleStates.PlayerPhase1):

                break;

            case (BattleStates.EnemyPhase1):

                break;

            case (BattleStates.UpdatePhase):

                break;

            case (BattleStates.Win):

                break;

            case (BattleStates.Lose):

                break;
        }

        if (currentState == BattleStates.Start)
        {
            currentState = BattleStates.PlayerChoice;
        }

        if (currentState == BattleStates.PlayerChoice)
        {
            BattleMenu.SetActive(true);
            InfoPanel.SetActive(false);
            MessagePanel.SetActive(false);
        }

        if (currentState == BattleStates.UpdatePhase)
        {
            BattleMenu.SetActive(false);
        }
    }


}
