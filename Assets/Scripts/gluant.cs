using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gluant : MonoBehaviour
{

    // Use this for initialization
    public int health;
    public int points;

    private Transform Player;
    public float MoveSpeed = 4;
    public float MinDist = 5;
    public GameObject bubble;


    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if (transform.position.x < Player.transform.position.x)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }

        if (Vector3.Distance(transform.position, Player.position) <= MinDist)
        {
            if (transform.position.x < Player.transform.position.x)
            {
                transform.position += Vector3.right * MoveSpeed * Time.deltaTime;
            }
            else
            {
                transform.position += Vector3.left * MoveSpeed * Time.deltaTime;
            }
        }
    }




    /// <summary>
    /// OnCollisionEnter is called when this collider/rigidbody has begun
    /// touching another rigidbody/collider.
    /// </summary>
    /// <param name="other">The Collision data associated with this collision.</param>
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<playerController>().getDamage();
        }
		/*
        else if (other.gameObject.CompareTag("bullet"))
        {
			Debug.Log("touched!");
            takedamage();
        } */
    }


    public void takedamage()
    {
        health--;
		if (health <= 0)
		{
			die();
		}
        StartCoroutine(colorFade());
    }

    IEnumerator colorFade()
    {
        float ElapsedTime = 0.0f;
        float TotalTime = 1.0f;
        while (ElapsedTime < TotalTime)
        {
            ElapsedTime += Time.deltaTime;
            GetComponent<SpriteRenderer>().color = Color.Lerp(Color.red, Color.white, (ElapsedTime / TotalTime));
            yield return null;
        }
    }

	private void die()
	{
        Instantiate(bubble).transform.position = this.transform.position;
		Destroy(this.gameObject);
	}


}
