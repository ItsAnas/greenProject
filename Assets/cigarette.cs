using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cigarette : MonoBehaviour
{

    public GameObject bullet;

    public int health;
    public int points;

    private Transform Player;
    public float MoveSpeed = 4;
    public float MinDist = 5;

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
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }

        if (Vector3.Distance(transform.position, Player.position) <= MinDist)
        {
            GetComponent<Animator>().SetBool("attacking", true);
            if (!IsInvoking("shoot"))
            {
                InvokeRepeating("shoot", 0, 2f);

            }
        }
        else
        {
            GetComponent<Animator>().SetBool("attacking", false);
        }
    }

    private void shoot()
    {

        if (transform.position.x < Player.transform.position.x)
        {
            GameObject go = Instantiate(bullet, this.transform.position, this.transform.rotation);
            go.GetComponent<Rigidbody2D>().velocity = go.transform.right * 0.5f;
        }
        else if (transform.position.x > Player.transform.position.x)
        {
            GameObject go = Instantiate(bullet, this.transform.position, this.transform.rotation);
            go.GetComponent<Rigidbody2D>().velocity = -go.transform.right * 0.5f;
        }
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
		Destroy(this.gameObject);
	}

}
