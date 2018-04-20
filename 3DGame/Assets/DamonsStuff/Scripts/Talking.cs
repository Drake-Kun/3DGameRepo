using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talking : MonoBehaviour {
    public string[] conversation;
    public bool semiCutscene = false;
    public GameObject changeCamera;
    public bool combat = false;
    // Use this for initialization
    void Start () {
        combat = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
