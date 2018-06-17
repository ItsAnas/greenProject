using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ending : MonoBehaviour {

	public GameObject endingg;

	/// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
	void Start()
	{
		Invoke("activate", 7f);
	}

	void activate()
	{
		endingg.SetActive(true);
	}

}
