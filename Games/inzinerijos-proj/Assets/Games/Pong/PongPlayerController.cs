using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongPlayerController : MonoBehaviour
{
    public enum Side { Right, Left};
    public Side side;

    public float playerSpeed;
    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        switch (side)
        {
            case Side.Right:
                if(ControllerInput.tilt)
                {
                    rb.MovePosition(transform.position + -Vector3.up * playerSpeed);
                }
                else
                {
                    rb.MovePosition(transform.position + Vector3.up * playerSpeed);
                }
                break;
            case Side.Left:
                if(ControllerInput.jump)
                {
                    rb.MovePosition(transform.position + -Vector3.up * playerSpeed);
                }
                else
                {
                    rb.MovePosition(transform.position + Vector3.up * playerSpeed);
                }
                break;
            default:
                break;
        }
    }
}
