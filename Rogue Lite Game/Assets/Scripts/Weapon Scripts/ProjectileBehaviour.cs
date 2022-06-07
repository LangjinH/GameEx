using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    //Very important for a functioning weapon
    public float Speed = 4.5f;      //Speed of the projectile, can be modified
    public float lifetime = 2.0f;    //How long it lasts, prevents lag 
    public float damage = 5.0f;      //General damage
    private float shot = 0.1f;              //Unchangable, bullets are small
    public LayerMask whatIsEnemies; //Determines what an enemy is
    public Transform bullet;

    //Audio
    AudioSource Source;
    public AudioClip Hit, Explosion;

    //Explosive stuff, not important for a majority of weapons
    public bool explosive;                   //Kaboom? (True will cause explosions to happen on collision)
    public float exploSize = 1f;        //Explosive radius, unimportant for most weapons
    public double exploDamage = 50f;  //kaboom. (explosion damage)

    private void Start()
    {
        Source = GetComponent<AudioSource>();
    }
    private void Update()
    {
        transform.position += transform.right * Time.deltaTime * Speed;
    }
    private void OnCollisionEnter2D()  //Destroys the object upon impacing another rigid body
    {
        Collider2D[] hitbox = Physics2D.OverlapCircleAll(bullet.position, shot, whatIsEnemies);
        Source.PlayOneShot(Hit, 0.7f);
        for (int i = 0; i < hitbox.Length; i++)
        {
            hitbox[i].GetComponent<Enemy>().TakeDamage(damage);
        }
        //if explosive was set to true
        if (explosive == true)
        {
            Collider2D[] Killspot = Physics2D.OverlapCircleAll(bullet.position, exploSize, whatIsEnemies);
            Source.PlayOneShot(Explosion, 0.7f);
            for (int i = 0; i < Killspot.Length; i++)
            {
                Killspot[i].GetComponent<Enemy>().TakeDamage(exploDamage);
            }

        }
            Destroy(gameObject);
    }
    void Awake()
    {
        Destroy(gameObject, lifetime);
    }

}
