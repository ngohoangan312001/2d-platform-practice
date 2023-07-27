using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private AudioSource finishSFX;
    private Animator animator;

    private bool levelCompleted = false;

    // Start is called before the first frame update
    void Start()
    {
        finishSFX = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !levelCompleted) 
        {
            collision.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            finishSFX.Play();
            levelCompleted = true;
            animator.SetTrigger("Finish");
        }
        // to call the level complete level with an interval use invoke
        // Invoke("LevelComplete", 2f);
    }

    private void LevelComplete()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
