using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBehavior : MonoBehaviour {

	private bool inFlight = true;
	private Rigidbody rb;

	public PhysicMaterial canStickTo;

	void Start () {
		rb = GetComponent<Rigidbody>();
	}


	// Update is called once per frame
	void FixedUpdate () {
		if(rb.velocity.magnitude > 2 && inFlight) {
			transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(rb.velocity), 0.05f);
		}
	}

	void StickTo (GameObject parent) {
		inFlight = false;
		print (parent.GetComponent<Collider>().material);
		if(parent.GetComponent<Collider>().material.name == "canStickTo (Instance)") {
			rb.isKinematic = true;
			transform.parent = parent.transform;
			transform.localPosition += transform.forward*0.2f;
		}
	}

	void OnTriggerEnter(Collider collider) {
		if(inFlight) {
			StickTo(collider.gameObject);
		}
	}
}
