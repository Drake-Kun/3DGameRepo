using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animc : MonoBehaviour {
    Animator anim;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void Attack()
    {
        anim.SetBool("Attack", true);
    }
}
