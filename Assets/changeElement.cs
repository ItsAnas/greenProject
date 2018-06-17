using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeElement : MonoBehaviour {



	public Sprite aliveElement;
	

	public void change()
	{
		GetComponent<SpriteRenderer>().sprite = aliveElement;
		StartCoroutine(colorFade());
	}

	    IEnumerator colorFade()
    {
        float ElapsedTime = 0.0f;
        float TotalTime = 1.0f;
        while (ElapsedTime < TotalTime)
        {
            ElapsedTime += Time.deltaTime;
            GetComponent<SpriteRenderer>().color = Color.Lerp(Color.green, Color.white, (ElapsedTime / TotalTime));
            yield return null;
        }
    }
	
}
