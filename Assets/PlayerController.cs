using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float cameraSpeed = 3;
	public float moveSpeed = 4;
	public Camera playerCamera;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float moveX = Input.GetAxis ("Horizontal") * Time.deltaTime * moveSpeed;
		float moveZ = Input.GetAxis ("Vertical") * Time.deltaTime * moveSpeed;
		transform.Translate (moveX, 0, moveZ);

		//Control the camera using sensitivity settings
		float mouseX = ((Input.mousePosition.x/Screen.width)*2)-1;
		float mouseY = (((Input.mousePosition.y/Screen.height)*2)-1)*-1;
		Vector3 rotation = new Vector3(0, mouseX*(Mathf.Abs(mouseX)*Mathf.Abs(mouseX))*cameraSpeed, 0);
		Vector3 pitch = new Vector3(mouseY*(Mathf.Abs(mouseY)*Mathf.Abs(mouseY))*cameraSpeed, 0, 0);

		transform.Rotate(rotation);
		float currentCameraRotation = playerCamera.transform.localRotation.x;
		if(currentCameraRotation < .5f && currentCameraRotation > -.5f)
			playerCamera.transform.Rotate(pitch);
		else if (currentCameraRotation >= .5f && pitch.x < 0)
			playerCamera.transform.Rotate(pitch);
		else if (currentCameraRotation <= -.5f && pitch.x > 0)
			playerCamera.transform.Rotate(pitch);
	}
}
