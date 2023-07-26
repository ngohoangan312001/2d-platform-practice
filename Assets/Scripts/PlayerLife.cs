using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rigidbody;
    static private int dieCount = 0;
    private bool playerIsDead = false;
    [SerializeField] private Text dieCountText;

    [SerializeField] private AudioSource dyingSFX;
    // Start is called before the first frame update
    private void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
        dieCountText.text = "Die: " + dieCount.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!playerIsDead)
        {
            if (collision.gameObject.CompareTag("Trap"))
            {
                Die();
                playerIsDead = true;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (!playerIsDead)
        {
            if (collider.gameObject.CompareTag("Trap"))
            {
                Die();
                playerIsDead = true;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (!playerIsDead)
        {
            if (collider.gameObject.CompareTag("Trap"))
            {
                Die();
                playerIsDead = true;
            }
        }
    }

    private void Die()
    {
        dyingSFX.Play();
        rigidbody.bodyType = RigidbodyType2D.Static;
        animator.SetTrigger("death");
        dieCount++;
        dieCountText.text ="Die: " + dieCount.ToString();
    }

    private void Restart()
    {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
