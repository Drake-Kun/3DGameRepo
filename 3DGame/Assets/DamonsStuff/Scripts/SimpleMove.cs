using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SimpleMove : MonoBehaviour {
    public GameObject showMe;
    public GameObject talkToMe;
    public bool isTalking = false;
    bool isPaused = false;
    float originTime = 0;
    public GameObject pauseMenu;
	// Use this for initialization
	void Start () {
        isTalking = false;
        originTime = Time.timeScale;
	}
	
	// Update is called once per frame
	void Update () {
        if (!isTalking)
        {
            var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
            var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

            transform.Rotate(0, x, 0);
            transform.Translate(0, 0, z);
        }
        if(Input.GetKeyDown(KeyCode.Joystick1Button7)|| Input.GetButtonDown("Cancel"))
        {
            if (!isPaused)
            {
                isPaused = true;
                Time.timeScale = 0;
                pauseMenu.SetActive(true);
                EventSystem.current.SetSelectedGameObject(GameObject.Find("Resume"), new BaseEventData(EventSystem.current));
            } else
            {
                Unpause();
            }
        }
    }

    public void Unpause()
    {
        isPaused = false;
        Time.timeScale = originTime;
        pauseMenu.SetActive(false);
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
            isTalking = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Interactable" && Input.GetButtonDown("Fire1") && !other.GetComponent<Talking>().instantStart)
        {
            if (talkToMe.active == false)
            {
                talkToMe.GetComponentInChildren<Typing>().instantStart = false;
                StartConversation(other);
                isTalking = true;
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
        //talkToMe.GetComponentInChildren<Typing>().conversation = other.GetComponent<Talking>().conversation;
        talkToMe.GetComponentInChildren<Typing>().conversationList = other.GetComponent<Talking>().conversationList;
        talkToMe.GetComponentInChildren<Typing>().semiCutscene = other.GetComponent<Talking>().semiCutscene;
        talkToMe.GetComponentInChildren<Typing>().onlyOnce = other.GetComponent<Talking>().onlyOnce;
        talkToMe.GetComponentInChildren<Typing>().choice = other.GetComponent<Talking>().choice;
        talkToMe.GetComponentInChildren<Typing>().yesOrNo = other.GetComponent<Talking>().yesOrNo;
        if (other.GetComponent<Talking>().onlyOnce)
        {
            talkToMe.GetComponentInChildren<Typing>().activationSpot = other.gameObject;
        }
        if (other.GetComponentInChildren<Talking>().semiCutscene)
        {
            GameObject.FindGameObjectWithTag("Fade").GetComponent<Fading>().Darkness(other.GetComponent<Talking>().changeCamera);
        }
        //Debug.Log("Atttaaaaacccckckkkk");
        talkToMe.GetComponentInChildren<Typing>().loadScene = other.GetComponent<Talking>().loadScene;
        talkToMe.GetComponentInChildren<Typing>().sceneName = other.GetComponent<Talking>().sceneName;
    }
}
