using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]

public class Enemy : MonoBehaviour
{
    private Animator anim;
    Rigidbody2D r2d;
    CapsuleCollider2D mainCollider;
    public double health;
    double dmg_num;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        r2d = GetComponent<Rigidbody2D>();
        mainCollider = GetComponent<CapsuleCollider2D>();
        health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            r2d.bodyType = RigidbodyType2D.Static;
            anim.SetTrigger("EnemyDeath");
            health = 0.01;
        }
    }

    public void TakeDamage(double dmg_num)
    {
        if (health > 0)
        {
            health -= dmg_num;
        }
    }

    void Death()
    {
        Destroy(gameObject);
    }
}
