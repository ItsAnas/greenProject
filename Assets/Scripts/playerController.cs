using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{

    float moveHorizontal;
    [Range(1, 10)]
    public float speed;
    private SpriteRenderer spritePlayer;

    // Use this for initialization
    void Start()
    {
        spritePlayer = GetComponent<SpriteRenderer>();
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
        }
        if (movement.x > 0f && spritePlayer.flipX)
        {
            spritePlayer.flipX = false;
        }
    }

	
}
