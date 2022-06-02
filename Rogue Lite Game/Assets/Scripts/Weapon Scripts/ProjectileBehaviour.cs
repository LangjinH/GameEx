using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    public float Speed = 4.5f;      //Speed of the projectile, can be modified
    public float lifetime = 2.0f;    //How long it lasts, useful for swords!
    private void Update()
    {
        transform.position += transform.right * Time.deltaTime * Speed;
    }
    private void OnCollisionEnter2D(Collision2D collision)  //Destroys the object upon impacing another rigid body
    {
        Destroy(gameObject);
    }
    void Awake()
    {
        Destroy(gameObject, lifetime);
    }

}
