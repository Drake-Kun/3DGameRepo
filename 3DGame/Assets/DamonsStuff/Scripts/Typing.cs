﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Typing : MonoBehaviour {

    // Use this for initialization
    public string[] conversation;
    int conversationIndex = 0;
    string text;
    float totalTime = 0;
    int charCount = 0;
    public float textSpeed = 0.1f;
    public GameObject showMe;
    public GameObject talkToMe;
    public GameObject activationSpot;
    public GameObject yesOrNo;
    public bool choice = false;
    GameObject MainCamera;
    public bool combat = false;
    public bool instantStart = false;
    bool activateME = false;
    private bool isTalking = false;
    public bool semiCutscene = false;
    public bool onlyOnce = false;
    void Start () {
        MainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        text = gameObject.GetComponent<Text>().text;
    }
	
	// Update is called once per frame
	void LateUpdate () {
        Debug.Log(conversationIndex);
        text = conversation[conversationIndex];
        totalTime += Time.deltaTime;
        if (totalTime >= textSpeed && charCount < text.Length)
        {
            //if our time is greater than or equal to the time interval
            //do the thing
            charCount += 1;
            totalTime = 0;
            // Debug.Log("Running");
        }
        string words = text.Substring(0, charCount);
        //Debug.Log(words);
        gameObject.GetComponent<Text>().text = words;
        if (Input.GetButtonDown("Fire1") && activateME)
        {
            conversationIndex++;
            charCount = 0;
            if (conversationIndex >= conversation.Length)
            {
                Restart();
                Debug.Log(instantStart);
                if (!instantStart)
                {
                    showMe.SetActive(true);
                }
                talkToMe.SetActive(false);
                if (semiCutscene)
                {
                    GameObject.FindGameObjectWithTag("Fade").GetComponent<Fading>().Darkness(MainCamera);
                }
                if (combat)
                {
                    SceneManager.LoadScene("BattleScene");
                    Debug.Log("Yeah, we wanna fight");
                }
                if (onlyOnce)
                {
                    activationSpot.SetActive(false);
                }
            }
        }
        activateME = true;
    }

    public void Restart()
    {
        conversationIndex = 0;
        totalTime = 0;
        charCount = 0;
        activateME = false;
    }
    public void Noooo()
    {
        isTalking = false;
        if (!instantStart)
        {
            showMe.SetActive(true);
        }
        talkToMe.SetActive(false);
        if (semiCutscene)
        {
            GameObject.FindGameObjectWithTag("Fade").GetComponent<Fading>().Darkness(MainCamera);
        }
        if (combat)
        {
            SceneManager.LoadScene("BattleScene");
            Debug.Log("Yeah, we wanna fight");
        }
        if (onlyOnce)
        {
            activationSpot.SetActive(false);
        }
    }
}
