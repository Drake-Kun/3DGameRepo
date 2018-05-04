using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectFaction : MonoBehaviour {

    //public GameObject yesOrNo;
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
        Debug.Log(PlayerPrefs.GetString("Faction"));
    }
    public void ChooseDivine()
    {
        PlayerPrefs.SetString("Faction", "Divine");
        Debug.Log(PlayerPrefs.GetString("Faction"));
    }
    public void ChooseRose()
    {
        PlayerPrefs.SetString("Faction", "Rose");
        Debug.Log(PlayerPrefs.GetString("Faction"));
    }
}
