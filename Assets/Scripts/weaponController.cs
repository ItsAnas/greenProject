using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponController : MonoBehaviour {

	
	private float rJoystickHorizontal;
	private float rJoystickVertical;
	
	// Update is called once per frame
	void Update () {
		
		rJoystickHorizontal = Input.GetAxis("Right Horizontal");
		rJoystickVertical = Input.GetAxis("Right Vertical");

		float angle = Mathf.Atan2(-rJoystickVertical,rJoystickHorizontal) * Mathf.Rad2Deg;

		transform.rotation = Quaternion.Euler(0,0,angle);

	}
}
