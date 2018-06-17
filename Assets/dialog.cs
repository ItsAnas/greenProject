using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialog : MonoBehaviour
{


    public GameObject dialogbox;
    public GameObject flo;
    public GameObject captain;
    public GameObject ade;

    private int index = 0;

    private bool triggered = false;
	private GameObject player;

    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            triggered = true;
            other.gameObject.GetComponent<playerController>().enabled = false;
            index++;
			player = other.gameObject;
        }
    }


    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if (index == 1)
        {
            dialogbox.SetActive(true);
            flo.SetActive(true);
            captain.SetActive(false);
            ade.SetActive(false);
        }
        if (index == 2)
        {
            dialogbox.SetActive(true);
            flo.SetActive(false);
            captain.SetActive(true);
            ade.SetActive(false);
        }
        if (index == 3)
        {
            dialogbox.SetActive(true);
            flo.SetActive(false);
            captain.SetActive(false);
            ade.SetActive(true);
        }
		if (index == 4)
		{
			dialogbox.SetActive(false);
            flo.SetActive(false);
            captain.SetActive(false);
            ade.SetActive(false);
			player.GetComponent<playerController>().enabled = true;
			Destroy(this.gameObject);
		}

		if (Input.anyKeyDown && triggered)
		{
			index++;
		}

    }
}
