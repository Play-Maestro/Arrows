using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowController : MonoBehaviour {

	public GameObject bow;
	public GameObject arrow;
	public Camera playerCamera;
	public GameObject aim;

	private Animator bowAnimator;
	private bool shooting = false;
	private float drawStart;
	private float drawEnd;
	private float fireForce = 0;

	// Use this for initialization
	void Start () {
		bowAnimator = bow.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0) && !shooting) {
			bowAnimator.SetTrigger("Draw");
			drawStart = Time.time;
			shooting = true;
		}
		if(Input.GetMouseButtonUp(0) && shooting) {
			bowAnimator.SetTrigger("Release");
			drawEnd = Time.time;
			fireForce = Mathf.Clamp(drawEnd-drawStart, 0, 0.5f)*100;
			Fire();
			shooting = false;
		}

		Ray lookRay = playerCamera.ScreenPointToRay(Input.mousePosition);
		aim.transform.rotation = Quaternion.LookRotation(lookRay.direction);

		//zoom
		if (Input.GetMouseButton (1)) {
			playerCamera.fieldOfView = Mathf.Lerp(playerCamera.fieldOfView, 20, 0.5f);
		} else {
			playerCamera.fieldOfView = Mathf.Lerp(playerCamera.fieldOfView, 60, 0.5f);
		}

	}

	void Reload () {
		shooting = false;
	}

	void Fire () {
		GameObject shotArrow = Instantiate(arrow, aim.transform.position + (aim.transform.forward/2), aim.transform.rotation);
		shotArrow.GetComponent<Rigidbody>().AddForce(aim.transform.forward*fireForce, ForceMode.Impulse);
	}
}
