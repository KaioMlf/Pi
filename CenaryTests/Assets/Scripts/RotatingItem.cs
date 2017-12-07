using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingItem : MonoBehaviour {
    public float rotationSpeed = 150;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.Rotate(new Vector3(0, Time.deltaTime * rotationSpeed, 0));
	}
}
