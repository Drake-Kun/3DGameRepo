using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Typing : MonoBehaviour {

    // Use this for initialization
    public string[] conversation;
    int conversationIndex = 0;
    int conversationBranchIndex = 0;
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
    GameObject player;
    public bool loadScene = false;
    public bool instantStart = false;
    public string sceneName;
    bool activateME = false;
    private bool isTalking = false;
    public bool semiCutscene = false;
    public bool onlyOnce = false;
    public bool branching = false;

    public StringArray[] conversationList;
    void Start () {
        MainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        text = gameObject.GetComponent<Text>().text;
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void LateUpdate () {
        Debug.Log(conversationIndex);
        //text = conversation[conversationIndex];
        text = conversationList[conversationBranchIndex].conversation[conversationIndex];
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
            if (charCount >= text.Length)
            {
                conversationIndex++;
                charCount = 0;
                if (conversationIndex >= conversation.Length)
                {
                    Restart();
                    Debug.Log(instantStart);

                    if (!choice)
                    {
                        player.GetComponent<SimpleMove>().isTalking = false;
                        if (!instantStart)
                        {
                            showMe.SetActive(true);
                        }
                        talkToMe.SetActive(false);
                        if (semiCutscene)
                        {
                            GameObject.FindGameObjectWithTag("Fade").GetComponent<Fading>().Darkness(MainCamera);
                        }
                        if (loadScene)
                        {
                            SceneManager.LoadScene("BattleScene");
                            Debug.Log("Yeah, we wanna fight");
                        }
                        if (onlyOnce)
                        {
                            activationSpot.SetActive(false);
                        }
                    }
                    else
                    {
                        yesOrNo.SetActive(true);
                    }
                }
            }
            else
            {
                charCount = text.Length;
                if (choice)
                {
                    yesOrNo.SetActive(true);
                }
            } 
            
        }
        activateME = true;
    }

    public void Restart()
    {
        conversationBranchIndex = 0;
        conversationIndex = 0;
        totalTime = 0;
        charCount = 0;
        activateME = false;
    }
    public void Noooo()
    {
        player.GetComponent<SimpleMove>().isTalking = false;
        yesOrNo.SetActive(false);
        if (!instantStart)
        {
            showMe.SetActive(true);
        }
        talkToMe.SetActive(false);
        if (semiCutscene)
        {
            GameObject.FindGameObjectWithTag("Fade").GetComponent<Fading>().Darkness(MainCamera);
        }
        if (loadScene)
        {
            SceneManager.LoadScene("BattleScene");
            Debug.Log("Yeah, we wanna fight");
        }
        if (onlyOnce)
        {
            activationSpot.SetActive(false);
        }
    }
    public void ChangeConversation(int index)
    {
        conversationBranchIndex = index;
        conversationIndex = 0;
        totalTime = 0;
        charCount = 0;
        activateME = false;
        if (choice)
        {
            choice = false;
            yesOrNo.SetActive(false);
        }
    }
}
