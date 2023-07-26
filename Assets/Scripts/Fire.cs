using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    private Animator animator;
    [SerializeField]private AudioSource FireActiveSFX;
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Player")
        {
            Invoke("FireActive", 0);
        }
    }

    private void FireOn()
    {
        gameObject.tag = "Trap";
        animator.SetTrigger("FireOn");
        Invoke("FireOff", 1f);
    }

    private void FireActive()
    {
        FireActiveSFX.Play();
        animator.SetTrigger("FireActive");
        Invoke("FireOn", 1f);
    }

    private void FireOff()
    {
        gameObject.tag = "Untagged";
        animator.SetTrigger("FireOff");
    }
}
