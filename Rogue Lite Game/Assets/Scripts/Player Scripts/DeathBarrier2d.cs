using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathBarrier2d : MonoBehaviour
{
    private Rigidbody2D r2b;
    private Animator anim;

    private void Start()
    {
        r2b = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DeathZone"))
        {
            Debug.Log("Player has died"); //Notifies that the player has entered the kill barrier
            Die();
        }
    }

    private void Die()
    {
        r2b.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("Death");
    }

    private void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
