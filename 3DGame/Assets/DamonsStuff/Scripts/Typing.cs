using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    GameObject MainCamera;
    void Start () {
        MainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        text = gameObject.GetComponent<Text>().text;
    }
	
	// Update is called once per frame
	void Update () {
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
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            conversationIndex++;
            charCount = 0;
            if (conversationIndex >= conversation.Length)
            {
                showMe.SetActive(true);
                talkToMe.SetActive(false);
                GameObject.FindGameObjectWithTag("Fade").GetComponent<Fading>().Darkness(MainCamera);
            }
        }
    }

    public void Restart()
    {
        conversationIndex = 0;
        totalTime = 0;
        charCount = 0;
    }
}
