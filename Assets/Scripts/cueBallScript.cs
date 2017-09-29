﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cueBallScript : MonoBehaviour {

    public float speed = 100.0f;
    public Vector3 shotDirection;
    public Camera topCam;


    private Rigidbody rb;

    private Vector3 mouseStartPos;
    private Vector3 ballScreenPos;


    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();

        ballScreenPos = topCam.WorldToScreenPoint(rb.transform.position);
        mouseStartPos = Input.mousePosition - ballScreenPos;

        shotDirection = transform.right;
        Debug.Log(rb.angularDrag);
    }
	
	// Update is called once per frame
	void Update () {

        Vector3 mouseCurPos = Input.mousePosition - ballScreenPos;
        Vector3 mouseDelta = mouseCurPos - mouseStartPos;
        

        //if (mouseDelta.sqrMagnitude < 0.1f)
        //{
        //    return;
        //}

        float angle = Mathf.Acos((Vector3.Dot(mouseCurPos, Vector3.right)) / (Vector3.right.magnitude * mouseCurPos.magnitude)) * Mathf.Rad2Deg;
        //if (angle < 0f) angle += 360f;
        Debug.Log(angle);

        mouseStartPos = mouseCurPos;


        shotDirection = Quaternion.AngleAxis(angle, Vector3.up) * Vector3.right;
        shotDirection.Normalize();

		if(Input.GetKey(KeyCode.Space))
        {
            speed += 10.0f * Time.deltaTime;
            //Debug.Log("Speed: " + speed);


        }

        if (Input.GetKeyUp(KeyCode.Space))
        {

            rb.AddForce(speed * shotDirection, ForceMode.Impulse);
            
            speed = 100.0f;
        }
        //else rb.angularDrag = 0.0f;

        if (rb.velocity.magnitude > 4.5f)
        {
            //rb.velocity = Vector3.Lerp(rb.velocity, Vector3.zero, 0.98f);
            //rb.velocity = rb.velocity / 1.01f;
            rb.angularDrag = 1.5f;
        }
        if(rb.velocity.magnitude < 3.5f)
        {
            rb.angularDrag = 1.2f;
        }
        if (rb.velocity.magnitude < 0.1f)
        {
            rb.velocity = Vector3.zero;
        }


        //Debug.Log("V: " + rb.velocity);
        //Debug.Log(rb.angularDrag);
        //Debug.Log(rb.mass);
    }
}
//void OnCollisionEnter(Collision other)
//{
//    if (other.rigidbody)
//    {
//        if (!other.gameObject.GetComponent<ConstantForce>())
//            other.gameObject.AddComponent<ConstantForce>();
//        else
//            other.rigidbody.constantForce.force = rigidbody.velocity;
//    }
//}