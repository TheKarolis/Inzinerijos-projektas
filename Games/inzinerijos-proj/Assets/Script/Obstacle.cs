using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    Animator an;
    private void Awake()
    {
        an = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        an.SetTrigger("Destroy");
    }
}
