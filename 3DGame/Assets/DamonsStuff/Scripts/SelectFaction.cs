using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectFaction : MonoBehaviour {

	// Use this for initialization
	void Start () {
        PlayerPrefs.SetString("Faction", "");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void ChoosePure()
    {
        PlayerPrefs.SetString("Faction", "Pure");
    }
    public void ChooseDivine()
    {
        PlayerPrefs.SetString("Faction", "Divine");
    }
    public void ChooseRose()
    {
        PlayerPrefs.SetString("Faction", "Rose");
    }
}
