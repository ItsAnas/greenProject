using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pokecenter : MonoBehaviour {

    public GameObject check;
    public GameObject texte;

	void Start () {
        check.SetActive(false);
        texte.SetActive(true);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            check.SetActive(true);
            check.SetActive(false);
        }
    }
}
