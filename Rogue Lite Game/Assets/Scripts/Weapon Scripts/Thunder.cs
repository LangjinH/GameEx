using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thunder : MonoBehaviour
{
    public GameObject thunderStrike;
    public float timer = 0f;
    public float damage;
    public AudioClip thunderSound;
    public LayerMask whatIsEnemies;
    public float attackRange;
    public Transform attackPos;

    Rigidbody2D r2d;
    Animator playerAnim;
    public bool cooling = false;
    AudioSource source;
    float intTimer;

    // Start is called before the first frame update
    void Start()
    {
        intTimer = timer;
        playerAnim = GetComponentInParent<Animator>();
        source = GetComponentInChildren<AudioSource>();
        r2d = GetComponentInParent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && cooling == false && GetComponentInParent<CharacterController2D>().isGrounded)
        {
            cooling = true;
            r2d.bodyType = RigidbodyType2D.Static;
            playerAnim.SetTrigger("ThunderAttack");
        }

        if (cooling == true)
        {
            intTimer -= Time.deltaTime;

            if(intTimer <=0)
            {
                cooling = false;
                intTimer = timer;
            }
        }
    }

    public void AttackCircle()
    {
        Collider2D[] Killspot = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
        for (int i = 0; i < Killspot.Length; i++)
        {
            Killspot[i].GetComponent<EnemyHealth>().TakeDamage(damage);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
