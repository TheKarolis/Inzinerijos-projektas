using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float speed;

    Rigidbody2D rb;
    Animator an;

    bool dead = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        an = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if(!dead)
        {
            rb.MovePosition(transform.position+new Vector3(speed,0,0));
        }
    }

    private void Update()
    {
        an.SetBool("Jump", ControllerInput.jump);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(Die());
    }

    IEnumerator Die()
    {
        dead = true;
        an.SetBool("Dead",true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
