using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

	public GameObject effect;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider collider) {
		if (collider.GetComponent<ArrowBehavior>()) {
			Instantiate (effect, transform.position, transform.rotation);
			Destroy (collider.gameObject);
			Destroy(this.gameObject);
		}
	}
}
