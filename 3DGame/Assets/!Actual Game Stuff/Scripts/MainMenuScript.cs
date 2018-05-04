using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenuScript : MonoBehaviour {

    void Start()
    {
        EventSystem.current.SetSelectedGameObject(GameObject.Find("New Game"), new BaseEventData(EventSystem.current));
    }

    public void NewGame()
    {
        SceneManager.LoadScene("ThreeChoices");
    }

    public void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath +
            "/" + gameObject.name + ".dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath +
            "/" + gameObject.name + ".dat", FileMode.Open);
            BasicSaveObj myData = (BasicSaveObj)bf.Deserialize(file);

            //Loading player1 data
            GameObject.Find("GameInformation").GetComponent<PlayerGlobalInformation>().player1Name = myData.player1Name;
            GameObject.Find("GameInformation").GetComponent<PlayerGlobalInformation>().player1HealthPointsMax = myData.player1HPMax;
            GameObject.Find("GameInformation").GetComponent<PlayerGlobalInformation>().Player1HealthPointsCurrent = myData.player1HPCurrent;
            GameObject.Find("GameInformation").GetComponent<PlayerGlobalInformation>().player1PhysicalDamage = myData.player1PhysicalDamage;
            GameObject.Find("GameInformation").GetComponent<PlayerGlobalInformation>().player1PhysicalResist = myData.player1PhysicalResist;
            GameObject.Find("GameInformation").GetComponent<PlayerGlobalInformation>().player1TechDamage = myData.player1TechDamage;
            GameObject.Find("GameInformation").GetComponent<PlayerGlobalInformation>().player1TechResist = myData.player1TechResist;
            GameObject.Find("GameInformation").GetComponent<PlayerGlobalInformation>().player1CurrentEXP = myData.player1EXPcurrent;
            GameObject.Find("GameInformation").GetComponent<PlayerGlobalInformation>().player1NeededEXP = myData.player1EXPneeded;
            GameObject.Find("GameInformation").GetComponent<PlayerGlobalInformation>().player1Level = myData.player1level;

            //Loading player2 data
            GameObject.Find("GameInformation").GetComponent<PlayerGlobalInformation>().player2Name = myData.player2Name;
            GameObject.Find("GameInformation").GetComponent<PlayerGlobalInformation>().player2HealthPointsMax = myData.player2HPMax;
            GameObject.Find("GameInformation").GetComponent<PlayerGlobalInformation>().Player2HealthPointsCurrent = myData.player2HPCurrent;
            GameObject.Find("GameInformation").GetComponent<PlayerGlobalInformation>().player2PhysicalDamage = myData.player2PhysicalDamage;
            GameObject.Find("GameInformation").GetComponent<PlayerGlobalInformation>().player2PhysicalResist = myData.player2PhysicalResist;
            GameObject.Find("GameInformation").GetComponent<PlayerGlobalInformation>().player2TechDamage = myData.player2TechDamage;
            GameObject.Find("GameInformation").GetComponent<PlayerGlobalInformation>().player2TechResist = myData.player2TechResist;
            GameObject.Find("GameInformation").GetComponent<PlayerGlobalInformation>().player2CurrentEXP = myData.player2EXPcurrent;
            GameObject.Find("GameInformation").GetComponent<PlayerGlobalInformation>().player2NeededEXP = myData.player2EXPneeded;
            GameObject.Find("GameInformation").GetComponent<PlayerGlobalInformation>().player2Level = myData.player2level;

            //Loading player3 data
            GameObject.Find("GameInformation").GetComponent<PlayerGlobalInformation>().player3Name = myData.player3Name;
            GameObject.Find("GameInformation").GetComponent<PlayerGlobalInformation>().player3HealthPointsMax = myData.player3HPMax;
            GameObject.Find("GameInformation").GetComponent<PlayerGlobalInformation>().Player3HealthPointsCurrent = myData.player3HPCurrent;
            GameObject.Find("GameInformation").GetComponent<PlayerGlobalInformation>().player3PhysicalDamage = myData.player3PhysicalDamage;
            GameObject.Find("GameInformation").GetComponent<PlayerGlobalInformation>().player3PhysicalResist = myData.player3PhysicalResist;
            GameObject.Find("GameInformation").GetComponent<PlayerGlobalInformation>().player3TechDamage = myData.player3TechDamage;
            GameObject.Find("GameInformation").GetComponent<PlayerGlobalInformation>().player3TechResist = myData.player3TechResist;
            GameObject.Find("GameInformation").GetComponent<PlayerGlobalInformation>().player3CurrentEXP = myData.player3EXPcurrent;
            GameObject.Find("GameInformation").GetComponent<PlayerGlobalInformation>().player3NeededEXP = myData.player3EXPneeded;
            GameObject.Find("GameInformation").GetComponent<PlayerGlobalInformation>().player3Level = myData.player3level;

            //Loading player4 data
            GameObject.Find("GameInformation").GetComponent<PlayerGlobalInformation>().player4Name = myData.player4Name;
            GameObject.Find("GameInformation").GetComponent<PlayerGlobalInformation>().player4HealthPointsMax = myData.player4HPMax;
            GameObject.Find("GameInformation").GetComponent<PlayerGlobalInformation>().Player4HealthPointsCurrent = myData.player4HPCurrent;
            GameObject.Find("GameInformation").GetComponent<PlayerGlobalInformation>().player4PhysicalDamage = myData.player4PhysicalDamage;
            GameObject.Find("GameInformation").GetComponent<PlayerGlobalInformation>().player4PhysicalResist = myData.player4PhysicalResist;
            GameObject.Find("GameInformation").GetComponent<PlayerGlobalInformation>().player4TechDamage = myData.player4TechDamage;
            GameObject.Find("GameInformation").GetComponent<PlayerGlobalInformation>().player4TechResist = myData.player4TechResist;
            GameObject.Find("GameInformation").GetComponent<PlayerGlobalInformation>().player4CurrentEXP = myData.player4EXPcurrent;
            GameObject.Find("GameInformation").GetComponent<PlayerGlobalInformation>().player4NeededEXP = myData.player4EXPneeded;
            GameObject.Find("GameInformation").GetComponent<PlayerGlobalInformation>().player4Level = myData.player4level;

            transform.position = new Vector3(myData.x, myData.y, myData.z);
            file.Close();

            SceneManager.LoadScene("DamonDemoScene");
        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
