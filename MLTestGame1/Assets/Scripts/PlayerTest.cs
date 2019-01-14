using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTest : MonoBehaviour {
    Rigidbody rbody;
    public float Force;
	// Use this for initialization
	void Start () {
        rbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKey(KeyCode.W))
            rbody.AddForce(transform.forward * Force);
        if(Input.GetKey(KeyCode.S))
            rbody.AddForce(-transform.forward * Force);
        if(Input.GetKey(KeyCode.D))
            rbody.AddForce(transform.right * Force);
        if(Input.GetKey(KeyCode.A))
            rbody.AddForce(-transform.right * Force);
    }
}
