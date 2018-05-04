using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

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

    public void SaveData()
    {
        BinaryFormatter bf = new BinaryFormatter();
        //ASSUMPTION: all objects using this script will have unique names
        FileStream file = File.Open(Application.persistentDataPath
            + "/" + gameObject.name + ".dat", FileMode.OpenOrCreate);
        BasicSaveObj myData = new BasicSaveObj();

        //Saving player1 data
        myData.player1Name = GameObject.Find("GameInformation").GetComponent<PlayerGlobalInformation>().player1Name;
        myData.player1HPMax = GameObject.Find("GameInformation").GetComponent<PlayerGlobalInformation>().player1HealthPointsMax;
        myData.player1HPCurrent = GameObject.Find("GameInformation").GetComponent<PlayerGlobalInformation>().Player1HealthPointsCurrent;
        myData.player1PhysicalDamage = GameObject.Find("GameInformation").GetComponent<PlayerGlobalInformation>().player1PhysicalDamage;
        myData.player1PhysicalResist = GameObject.Find("GameInformation").GetComponent<PlayerGlobalInformation>().player1PhysicalResist;
        myData.player1TechDamage = GameObject.Find("GameInformation").GetComponent<PlayerGlobalInformation>().player1TechDamage;
        myData.player1TechResist = GameObject.Find("GameInformation").GetComponent<PlayerGlobalInformation>().player1TechResist;
        myData.player1EXPcurrent = GameObject.Find("GameInformation").GetComponent<PlayerGlobalInformation>().player1CurrentEXP;
        myData.player1EXPneeded = GameObject.Find("GameInformation").GetComponent<PlayerGlobalInformation>().player1NeededEXP;
        myData.player1level = GameObject.Find("GameInformation").GetComponent<PlayerGlobalInformation>().player1Level;

        //Saving player2 data
        myData.player2Name = GameObject.Find("GameInformation").GetComponent<PlayerGlobalInformation>().player2Name;
        myData.player2HPMax = GameObject.Find("GameInformation").GetComponent<PlayerGlobalInformation>().player2HealthPointsMax;
        myData.player2HPCurrent = GameObject.Find("GameInformation").GetComponent<PlayerGlobalInformation>().Player2HealthPointsCurrent;
        myData.player2PhysicalDamage = GameObject.Find("GameInformation").GetComponent<PlayerGlobalInformation>().player2PhysicalDamage;
        myData.player2PhysicalResist = GameObject.Find("GameInformation").GetComponent<PlayerGlobalInformation>().player2PhysicalResist;
        myData.player2TechDamage = GameObject.Find("GameInformation").GetComponent<PlayerGlobalInformation>().player2TechDamage;
        myData.player2TechResist = GameObject.Find("GameInformation").GetComponent<PlayerGlobalInformation>().player2TechResist;
        myData.player2EXPcurrent = GameObject.Find("GameInformation").GetComponent<PlayerGlobalInformation>().player2CurrentEXP;
        myData.player2EXPneeded = GameObject.Find("GameInformation").GetComponent<PlayerGlobalInformation>().player2NeededEXP;
        myData.player2level = GameObject.Find("GameInformation").GetComponent<PlayerGlobalInformation>().player2Level;

        //Saving player3 data
        myData.player3Name = GameObject.Find("GameInformation").GetComponent<PlayerGlobalInformation>().player3Name;
        myData.player3HPMax = GameObject.Find("GameInformation").GetComponent<PlayerGlobalInformation>().player3HealthPointsMax;
        myData.player3HPCurrent = GameObject.Find("GameInformation").GetComponent<PlayerGlobalInformation>().Player3HealthPointsCurrent;
        myData.player3PhysicalDamage = GameObject.Find("GameInformation").GetComponent<PlayerGlobalInformation>().player3PhysicalDamage;
        myData.player3PhysicalResist = GameObject.Find("GameInformation").GetComponent<PlayerGlobalInformation>().player3PhysicalResist;
        myData.player3TechDamage = GameObject.Find("GameInformation").GetComponent<PlayerGlobalInformation>().player3TechDamage;
        myData.player3TechResist = GameObject.Find("GameInformation").GetComponent<PlayerGlobalInformation>().player3TechResist;
        myData.player3EXPcurrent = GameObject.Find("GameInformation").GetComponent<PlayerGlobalInformation>().player3CurrentEXP;
        myData.player3EXPneeded = GameObject.Find("GameInformation").GetComponent<PlayerGlobalInformation>().player3NeededEXP;
        myData.player3level = GameObject.Find("GameInformation").GetComponent<PlayerGlobalInformation>().player3Level;

        //Saving player4 data
        myData.player4Name = GameObject.Find("GameInformation").GetComponent<PlayerGlobalInformation>().player4Name;
        myData.player4HPMax = GameObject.Find("GameInformation").GetComponent<PlayerGlobalInformation>().player4HealthPointsMax;
        myData.player4HPCurrent = GameObject.Find("GameInformation").GetComponent<PlayerGlobalInformation>().Player4HealthPointsCurrent;
        myData.player4PhysicalDamage = GameObject.Find("GameInformation").GetComponent<PlayerGlobalInformation>().player4PhysicalDamage;
        myData.player4PhysicalResist = GameObject.Find("GameInformation").GetComponent<PlayerGlobalInformation>().player4PhysicalResist;
        myData.player4TechDamage = GameObject.Find("GameInformation").GetComponent<PlayerGlobalInformation>().player4TechDamage;
        myData.player4TechResist = GameObject.Find("GameInformation").GetComponent<PlayerGlobalInformation>().player4TechResist;
        myData.player4EXPcurrent = GameObject.Find("GameInformation").GetComponent<PlayerGlobalInformation>().player4CurrentEXP;
        myData.player4EXPneeded = GameObject.Find("GameInformation").GetComponent<PlayerGlobalInformation>().player4NeededEXP;
        myData.player4level = GameObject.Find("GameInformation").GetComponent<PlayerGlobalInformation>().player4Level;

        
        myData.x = transform.position.x;
        myData.y = transform.position.y;
        myData.z = transform.position.z;
        bf.Serialize(file, myData);
        file.Close();

        SceneManager.LoadScene("MainMenu");
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

[System.Serializable]
public class BasicSaveObj
{
    //Player1 stats
    public string player1Name;
    public int player1HPMax;
    public int player1HPCurrent;
    public int player1PhysicalDamage;
    public int player1PhysicalResist;
    public int player1TechDamage;
    public int player1TechResist;
    public int player1EXPcurrent;
    public int player1EXPneeded;
    public int player1level;

    //Player2 stats
    public string player2Name;
    public int player2HPMax;
    public int player2HPCurrent;
    public int player2PhysicalDamage;
    public int player2PhysicalResist;
    public int player2TechDamage;
    public int player2TechResist;
    public int player2EXPcurrent;
    public int player2EXPneeded;
    public int player2level;

    //Player3 stats
    public string player3Name;
    public int player3HPMax;
    public int player3HPCurrent;
    public int player3PhysicalDamage;
    public int player3PhysicalResist;
    public int player3TechDamage;
    public int player3TechResist;
    public int player3EXPcurrent;
    public int player3EXPneeded;
    public int player3level;

    //Player4 stats
    public string player4Name;
    public int player4HPMax;
    public int player4HPCurrent;
    public int player4PhysicalDamage;
    public int player4PhysicalResist;
    public int player4TechDamage;
    public int player4TechResist;
    public int player4EXPcurrent;
    public int player4EXPneeded;
    public int player4level;

    //Player location
    public float x;
    public float y;
    public float z;
}
