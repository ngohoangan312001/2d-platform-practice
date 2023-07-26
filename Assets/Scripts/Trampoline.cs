using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    [SerializeField] private AudioSource trampolineSFX;
    private Animator animator;
    [SerializeField] private float jumpBoostStrenght = 30;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            animator.SetTrigger("Jump");
            trampolineSFX.Play();
            TrampolineBoostJump(collision.gameObject);
        }
    }

    private void TrampolineBoostJump(GameObject gameObject)
    {
        Rigidbody2D playerRigidbody; playerRigidbody = gameObject.GetComponent<Rigidbody2D>();

        playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, jumpBoostStrenght);
    }
}
