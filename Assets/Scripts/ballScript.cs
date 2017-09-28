using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballScript : MonoBehaviour {
    Rigidbody rb;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if (rb.velocity.magnitude > 4.5f)
        {
            //rb.velocity = Vector3.Lerp(rb.velocity, Vector3.zero, 0.98f);
            //rb.velocity = rb.velocity / 1.01f;
            rb.angularDrag = 1.5f;
        }
        if (rb.velocity.magnitude < 3.5f)
        {
            rb.angularDrag = 1.2f;
        }
        if (rb.velocity.magnitude < 0.1f)
        {
            rb.velocity = Vector3.zero;
        }


        Debug.Log("V: " + rb.velocity);
    }
}
