using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public AudioClip damaged, death;
    public double health = 100f;
    public bool invulnerable = false;

    private AudioSource source;
    private Rigidbody2D r2d;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInParent<Animator>();
        r2d = GetComponentInParent<Rigidbody2D>();
        source = GetComponent<AudioSource>();
    }

    public void TakeDamage(double dmg_num)
    {
        if (health > 0 && invulnerable == false)
        {
            anim.SetTrigger("EnemyHit");
            source.PlayOneShot(damaged, 0.7f);
            health -= dmg_num;
        }

        if (health <= 0)
        {
            r2d.bodyType = RigidbodyType2D.Static;
            anim.SetTrigger("EnemyDeath");
            source.PlayOneShot(death, 0.7f);
        }
    }
}
