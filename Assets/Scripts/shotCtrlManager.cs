using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotCtrlManager : MonoBehaviour {

    public GameObject laserPrefab;
    public GameObject cueBall;


    private GameObject laser;
    private Transform laserTransform;
    private Vector3 hitPoint;
    private Vector3 direction;

	// Use this for initialization
	void Start () {
        laser = Instantiate(laserPrefab);
        laserTransform = laser.transform;
        
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        direction = cueBall.GetComponent<cueBallScript>().shotDirection;
        Debug.Log(direction);
        if(Physics.Raycast(cueBall.transform.position, direction, out hit, 500))
        {
            hitPoint = hit.point;
            ShowLaser(hit);
        }
	}

    private void ShowLaser(RaycastHit hit)
    {
        laser.SetActive(true);
        laserTransform.position = Vector3.Lerp(cueBall.transform.position, hitPoint, 0.5f);
        laserTransform.LookAt(hitPoint);
        laserTransform.localScale = new Vector3(laserTransform.localScale.x, laserTransform.localScale.y, hit.distance);
    }
}
