using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cueBallScript : MonoBehaviour {

    public float speed = 100.0f;
    Rigidbody rb;
    // Use this for initialization
    void Start () {
         rb = GetComponent<Rigidbody>();
        
        Debug.Log(rb.angularDrag);
    }
	
	// Update is called once per frame
	void FixedUpdate () {
		if(Input.GetKey(KeyCode.Space))
        {
            speed += 10.0f * Time.deltaTime;
            //Debug.Log("Speed: " + speed);


        }

        if (Input.GetKeyUp(KeyCode.Space))
        {

            rb.AddForce(new Vector3(3f * speed, 0.0f, 0.0f), ForceMode.Impulse);
            
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


        Debug.Log("V: " + rb.velocity);
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