using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float speed;

    Rigidbody2D rb;
    Animator an;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        an = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(transform.position+new Vector3(speed,0,0));
    }

    private void Update()
    {
        an.SetBool("Jump", ControllerInput.jump);
    }
}
