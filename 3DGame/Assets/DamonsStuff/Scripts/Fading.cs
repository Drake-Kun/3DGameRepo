using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fading : MonoBehaviour {
    public float fadingTimer = 1;
    float origin;
    float timer;
    bool fadingIn = false;
    bool actuallyIn = true;
    GameObject switchCamera;
    GameObject MainCamera;
    // Use this for initialization
    void Start () {
        MainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        origin = fadingTimer;
	}
	
	// Update is called once per frame
	void Update () {
		if (fadingIn == true)
        {
            timer += Time.deltaTime;
            if (fadingTimer <= timer && actuallyIn)
            {
                FadingIn();
            } else if (fadingTimer <= timer && !actuallyIn)
            {
                FadingOut();
            }
        }
	}
    void FadingOut()
    {
        float alpha = GetComponent<Image>().color.a;
        if (alpha > 0)
        {
            alpha -= Time.deltaTime;
            Color newColor = new Color(0, 0, 0, alpha);
            GetComponent<Image>().color = newColor;
        } else
        {
            fadingIn = false;
            actuallyIn = true;
        }
        timer = 0;
    }
    void FadingIn()
    {
        float alpha = GetComponent<Image>().color.a;
        if (alpha < 1)
        {
            alpha += Time.deltaTime;
            Color newColor = new Color(0, 0, 0, alpha);
            GetComponent<Image>().color = newColor;
        } else
        {
            actuallyIn = false;
            if (switchCamera!= GameObject.FindGameObjectWithTag("MainCamera"))
            {
                MainCamera.SetActive(false);
                switchCamera.SetActive(true);
            } else
            {
                MainCamera.SetActive(true);
                switchCamera.SetActive(false);
            }
        }
        timer = 0;
    }
    public void Darkness(GameObject changeCamera)
    {
        if (changeCamera != MainCamera)
        {
            switchCamera = changeCamera;
        }
        fadingIn = true;
    }
}
