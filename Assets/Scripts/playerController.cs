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
    private GameObject manager;

    public GameObject check;
    public GameObject texte;

    // Use this for initialization
    void Start()
    {
        spritePlayer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        turret = GameObject.FindGameObjectWithTag("turret");
        manager = GameObject.FindGameObjectWithTag("manager");
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.P))
        {
            manager.GetComponent<worldManager>().changebackground();
        }

        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(moveHorizontal, 0.0f);
        transform.Translate(movement * speed * Time.deltaTime);

        if (movement.x < 0f && !spritePlayer.flipX)
        {
            spritePlayer.flipX = true;
            turret.transform.position = new Vector3(turret.transform.position.x + 0.08f, turret.transform.position.y, 1);

        }
        if (movement.x > 0f && spritePlayer.flipX)
        {
            spritePlayer.flipX = false;
            turret.transform.position = new Vector3(turret.transform.position.x - 0.08f, turret.transform.position.y, -1);
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

        if (Input.GetKeyDown(KeyCode.P))
        {
            getDamage();
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "control")
        {
            Animator animdoor = collision.gameObject.GetComponent<Animator>();
            animdoor.SetTrigger("openingDoor");
            print("door");
        }
        if (collision.gameObject.tag == "pokecenter")
        {
            check.SetActive(true);
            texte.SetActive(false);

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "control")
        {
            Animator animdoor = collision.gameObject.GetComponent<Animator>();
            animdoor.SetTrigger("closingDoor");
            print("door");
        }
    }

    public void getDamage()
    {
        StartCoroutine(colorFade());
        manager.GetComponent<mainManager>().hit();
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

    IEnumerator jump()
    {
        GetComponent<Animator>().SetTrigger("jumping");
        canjump = false;
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.5f);
        canjump = true;
    }

}
