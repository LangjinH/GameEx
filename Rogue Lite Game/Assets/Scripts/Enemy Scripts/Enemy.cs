using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(AudioSource))]

public class Enemy : MonoBehaviour
{
    public int hitBoxDamage = 50;
    private Animator anim;
    Rigidbody2D r2d;
    CapsuleCollider2D mainCollider;
    public double health = 100f;
    double dmg_num;
    AudioSource source;
    public AudioClip hit1, hit2, death;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        r2d = GetComponent<Rigidbody2D>();
        mainCollider = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            r2d.bodyType = RigidbodyType2D.Static;
            anim.SetTrigger("EnemyDeath");
            health = 0.01;
            source.PlayOneShot(death, 0.7f);
        }
    }

    public void TakeDamage(double dmg_num)
    {
        if (health > 0)
        {
            switch(dmg_num)
            {
                case > 10: source.PlayOneShot(hit1, 0.7f); break;
                case < 10: source.PlayOneShot(hit2, 0.7f); break;
            }
            health -= dmg_num;
        }
    }

    void Death()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player_Health player_stats = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Health>();
            player_stats.TakeDmg(hitBoxDamage);
        }    
    }
}
