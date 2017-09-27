using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camMoveScript : MonoBehaviour {

    public GameObject ball;
    Camera cam;
    // Use this for initialization
    void Start () {
         cam = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {

        cam.transform.position = new Vector3(ball.transform.position.x, cam.transform.position.y, cam.transform.position.z);

	}
}
