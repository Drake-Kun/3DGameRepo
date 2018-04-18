using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameController : MonoBehaviour {

    public bool openMenu = false;

    void Update()
    {
        if (openMenu == true)
        {
            openMenu = false;
        }
    }

}
