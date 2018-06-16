using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponController : MonoBehaviour {

	
	private float rJoystickHorizontal;
	private float rJoystickVertical;
	
	public GameObject bullet;
	public bullet b;

	private bool allowfire = true;

	// Update is called once per frame
	void Update () {
		rJoystickHorizontal = Input.GetAxis("Right Horizontal");
		rJoystickVertical = Input.GetAxis("Right Vertical");

		float angle = Mathf.Atan2(-rJoystickVertical,rJoystickHorizontal) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0,0,angle);

		if ((rJoystickHorizontal != 0 || rJoystickVertical != 0) && allowfire)
		{
			StartCoroutine(shoot());
		}
	}

	IEnumerator shoot()
	{
		allowfire = false;
		GameObject go = Instantiate(bullet, this.transform.position, this.transform.rotation);
		go.GetComponent<SpriteRenderer>().sprite = b.sprite;
		go.GetComponent<Rigidbody2D>().velocity = go.transform.right * b.speed;
		Destroy(go,2f);
		yield return new WaitForSeconds(b.rate);
		allowfire = true;
	}
}




