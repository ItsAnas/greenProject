using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{

    float moveHorizontal;
    [Range(1, 10)]
    public float speed;
    public float jumpForce;
    private SpriteRenderer spritePlayer;
    private Animator anim;
    private bool canjump = true;
    private GameObject turret;

    // Use this for initialization
    void Start()
    {
        spritePlayer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        turret = GameObject.FindGameObjectWithTag("turret");
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(moveHorizontal, 0.0f);
        transform.Translate(movement * speed * Time.deltaTime);

        if (movement.x < 0f && !spritePlayer.flipX)
        {
            spritePlayer.flipX = true;
            turret.transform.position = new Vector3(turret.transform.position.x+0.08f,turret.transform.position.y,1);

        }
        if (movement.x > 0f && spritePlayer.flipX)
        {
            spritePlayer.flipX = false;
                        turret.transform.position = new Vector3(turret.transform.position.x-0.08f,turret.transform.position.y,-1);
        }

        if (movement.x != 0)
        {
            anim.SetBool("running", true);
        }
        else
        {
            anim.SetBool("running", false);
        }


        if (Input.GetButtonDown("Fire1") && canjump)
        {
            StartCoroutine(jump());
        }
    }

    IEnumerator jump()
    {
        canjump = false;
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce,ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.5f);
        canjump = true;
    }

}
