using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rigidbody;

    [SerializeField] private AudioSource dyingSFX;
    // Start is called before the first frame update
    private void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap")) 
        {
            Die();
        }
    }

    private void Die()
    {
        dyingSFX.Play();
        rigidbody.bodyType = RigidbodyType2D.Static;
        animator.SetTrigger("death");
    }

    private void Restart()
    {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
