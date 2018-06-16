using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundSpawner : MonoBehaviour
{

    public Sprite[] background;

    void Start()
    {
        GameObject previous = new GameObject();
        previous.name = background[0].name;
        previous.AddComponent<SpriteRenderer>().sprite = background[0];
        previous.AddComponent<Rigidbody2D>();
        previous.transform.position = Vector2.zero;
		previous.AddComponent<BoxCollider2D>();

        for (int i = 1; i < background.Length; i++)
        {
            GameObject current = new GameObject();
            current.name = background[i].name;
            current.AddComponent<SpriteRenderer>().sprite = background[i];
            current.transform.position = new Vector3(0,0,-1) + previous.transform.position + previous.transform.right * 2;
            current.AddComponent<Rigidbody2D>();
			current.AddComponent<BoxCollider2D>();
            previous = current;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
