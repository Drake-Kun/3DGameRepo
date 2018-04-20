using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartDemoScript : MonoBehaviour {

    public void DemoStartButton()
    {
        SceneManager.LoadScene("ThreeChoices");
    }
}
