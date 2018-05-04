using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayObjective : MonoBehaviour {
    public string Objective;
	// Use this for initialization
	void Start () {
        PlayerPrefs.SetString("Objective", Objective);
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.GetComponent<Text>().text = PlayerPrefs.GetString("Objective");
	}
}
