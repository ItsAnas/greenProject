using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class worldManager : MonoBehaviour
{


    public GameObject grounds;

    public GameObject clouds;

	public void changebackground()
	{
        changeElement[] c = grounds.GetComponentsInChildren<changeElement>();
		for (int i = 0; i < c.Length; i++)
		{
			c[i].change();
		}
	}

	public void changeClouds()
	{
		SpriteRenderer[] sr = clouds.GetComponentsInChildren<SpriteRenderer>();
		for (var i = 0; i < sr.Length; i++)
		{
			sr[i].color = Color.white;
		}
	}




}
