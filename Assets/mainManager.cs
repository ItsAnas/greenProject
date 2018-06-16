using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class mainManager : MonoBehaviour {


	public Image life_sprite;
	private int life = 4;
	public TextMeshProUGUI chrono;
	private float time = 99;
	
	// Update is called once per frame
	void Update () {
		time -= Time.deltaTime;
		chrono.text = "" + (int) time;
		if (time <= 0)
		{
			die();
		}
	}

	void hit()
	{
		life--;
		life_sprite.fillAmount -= 0.25f;
		if (life <= 0)
		{
			die();
		}
	}

	void die()
	{
		
	}


}
