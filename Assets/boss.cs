using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss : MonoBehaviour
{

    public GameObject bullet;

    public int health;
    public int points;

    private Transform Player;
    public float MoveSpeed = 4;
    public float MinDist = 5;
    public GameObject[] afterBoss;

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
            if (!IsInvoking("shoot"))
            {
                InvokeRepeating("shoot", 0, 3f);
            }
        }
        else
        {
            GetComponent<Animator>().SetBool("attacking", false);
        }
    }

    private void shoot()
    {
        GetComponent<Animator>().SetTrigger("attack");
        if (transform.position.x < Player.transform.position.x)
        {
            GameObject go = Instantiate(bullet, new Vector2(this.transform.position.x, Player.transform.position.y), this.transform.rotation);
            go.GetComponent<Rigidbody2D>().velocity = go.transform.right * 0.5f;
        }
        else if (transform.position.x > Player.transform.position.x)
        {
            GameObject go = Instantiate(bullet, new Vector2(this.transform.position.x, Player.transform.position.y), this.transform.rotation);
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
        for (int i = 0; i < afterBoss.Length; i++)
        {
            afterBoss[i].SetActive(true);
        }

        Camera.main.GetComponent<cameraShake>().ShakeCamera(3, 3);
        Destroy(this.gameObject);
    }

}
