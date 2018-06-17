using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudMouvement : MonoBehaviour {

	
	private float speed;
	/// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
	void Start()
	{
		speed = Random.Range(-0.2f,0.2f);
	}

	// Update is called once per frame
	void Update () {
		transform.Translate(speed*Time.deltaTime,0,0);
	}
}
