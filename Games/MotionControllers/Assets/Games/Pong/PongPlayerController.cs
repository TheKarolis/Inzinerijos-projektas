using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongPlayerController : MonoBehaviour
{
    public float playerSpeed;
    public GameInput player;

    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player.Initialize();
        
    }
    void FixedUpdate()
    {
        if(player.TiltUp)
        {
            rb.MovePosition(transform.position + Vector3.up*playerSpeed);
        }
        else
        {
            rb.MovePosition(transform.position + -Vector3.up * playerSpeed);
        }

    }
}
