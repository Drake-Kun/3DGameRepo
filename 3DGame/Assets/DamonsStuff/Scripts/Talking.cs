using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talking : MonoBehaviour {

    public string[] conversation;
    public bool semiCutscene = false;
    public GameObject changeCamera;
    public GameObject yesOrNo;
    public bool loadScene = false;
    public string sceneName;
    public bool instantStart = false;
    public bool onlyOnce = false;
    public bool choice = false;
    
    
    public StringArray[] conversationList;
    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
}
