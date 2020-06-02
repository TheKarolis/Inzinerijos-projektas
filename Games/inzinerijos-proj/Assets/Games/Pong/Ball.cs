using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI LSide;
    [SerializeField]
    TextMeshProUGUI RSide;

    public Vector2 startingForce;

    Rigidbody2D rb;

    int left = 0;
    int right = 0;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        rb.AddForce(startingForce, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        rb.velocity = new Vector2();

        switch (collision.tag)
        {
            case "Pong/Right_Side":
                rb.AddForce(-startingForce, ForceMode2D.Impulse);
                right++;
                break;
            case "Pong/Left_Side":
                rb.AddForce(startingForce, ForceMode2D.Impulse);
                left++;
                break;
            default:
                break;
        }
        LSide.text = left.ToString();
        RSide.text = right.ToString();

        if (right >= 10 || left >= 10)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        transform.position = new Vector3();
        GetComponent<TrailRenderer>().Clear();
    }
}
