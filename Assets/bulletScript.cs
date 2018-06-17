using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour {




	// Use this for initialization
	/// <summary>
	/// Sent when another object enters a trigger collider attached to this
	/// object (2D physics only).
	/// </summary>
	/// <param name="other">The other Collider2D involved in this collision.</param>
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("gluant"))
		{
			other.gameObject.GetComponent<gluant>().takedamage();
			Destroy(this.gameObject);
		}
		else if (other.gameObject.CompareTag("cigarette"))
		{
			other.gameObject.GetComponent<cigarette>().takedamage();
			Destroy(this.gameObject);
		}
		else if (other.gameObject.CompareTag("boss"))
		{
			other.gameObject.GetComponent<boss>().takedamage();
			Destroy(this.gameObject);
		}
	}
}
