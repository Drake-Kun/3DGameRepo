using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMove : MonoBehaviour {
    public GameObject showMe;
    public GameObject talkToMe;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Oof");
        if (other.gameObject.tag == "Interactable" && !other.GetComponent<Talking>().instantStart)
        {
            showMe.SetActive(true);
        } else if (other.GetComponent<Talking>().instantStart)
        {
            talkToMe.GetComponentInChildren<Typing>().instantStart = true;
            StartConversation(other);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Interactable" && Input.GetButtonDown("Fire1"))
        {
            if (talkToMe.active == false)
            {
                talkToMe.GetComponentInChildren<Typing>().instantStart = false;
                StartConversation(other);
            } 
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Interactable")
        {
            showMe.SetActive(false);
        }
    }

    private void StartConversation(Collider other)
    {
        talkToMe.SetActive(true);
        talkToMe.GetComponentInChildren<Typing>().Restart();
        showMe.SetActive(false);
        talkToMe.GetComponentInChildren<Typing>().conversation = other.GetComponent<Talking>().conversation;
        talkToMe.GetComponentInChildren<Typing>().semiCutscene = other.GetComponent<Talking>().semiCutscene;
        talkToMe.GetComponentInChildren<Typing>().onlyOnce = other.GetComponent<Talking>().onlyOnce;
        talkToMe.GetComponentInChildren<Typing>().choice = other.GetComponent<Talking>().choice;
        talkToMe.GetComponentInChildren<Typing>().yesOrNo = other.GetComponent<Talking>().yesOrNo;
        if (other.GetComponent<Talking>().onlyOnce)
        {
            //talkToMe.GetComponentInChildren<Typing>().activationSpot = other.gameObject;
        }
        if (other.GetComponentInChildren<Talking>().semiCutscene)
        {
            //GameObject.FindGameObjectWithTag("Fade").GetComponent<Fading>().Darkness(other.GetComponent<Talking>().changeCamera);
        }
        //Debug.Log("Atttaaaaacccckckkkk");
        //talkToMe.GetComponentInChildren<Typing>().combat = other.GetComponent<Talking>().combat;
    }
}
