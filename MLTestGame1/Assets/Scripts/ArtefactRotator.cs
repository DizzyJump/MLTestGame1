using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtefactRotator : MonoBehaviour {
    Rigidbody rbody;
    public Vector3 Axis;
    public float Speed;
	// Use this for initialization
	void Start () {
        rbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.Rotate(Axis, Speed * Time.fixedDeltaTime, Space.World);
	}
}
