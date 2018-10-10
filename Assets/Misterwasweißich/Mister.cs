using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mister : MonoBehaviour {
	public Rigidbody rigidbody;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		rigidbody.AddForce(Vector3.up);
	}
}
