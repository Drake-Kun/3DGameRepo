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
        if (other.gameObject.tag == "Interactable")
        {
            showMe.SetActive(true);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Interactable" && Input.GetKeyDown(KeyCode.Alpha0))
        {
            talkToMe.SetActive(true);
            showMe.SetActive(false);
            talkToMe.GetComponentInChildren<Typing>().conversation = other.GetComponent<Talking>().conversation;
            talkToMe.GetComponentInChildren<Typing>().Restart();
            if (other.GetComponentInChildren<Talking>().semiCutscene)
            {
                GameObject.FindGameObjectWithTag("Fade").GetComponent<Fading>().Darkness(other.GetComponent<Talking>().changeCamera);
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
}
