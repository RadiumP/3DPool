using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camCtrlManager : MonoBehaviour {

    public Camera topCam;
    public Camera fpsCam;
    public Camera followCam;

	// Use this for initialization
	void Start () {
        Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            topCam.enabled = true;
            followCam.enabled = false;
        }

        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            topCam.enabled = false;
            followCam.enabled = true;
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            Cursor.visible = true;
        }

        if(Input.GetMouseButtonDown(1))
        {
            Cursor.visible = false;
        }
    }
}
