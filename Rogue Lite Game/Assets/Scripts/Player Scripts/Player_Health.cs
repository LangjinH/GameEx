using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Health : MonoBehaviour
{
    public int health = 100;
    Animator anim;
    Rigidbody2D r2b;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        r2b = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Function that makes player health go lower by dmg variable when called
    public void TakeDmg(int dmg)
    {
        if (health > 0)
        {
            Debug.Log("Player took dmg");
            health -= dmg;
        }

        //Kills Player if no health
        if (health <= 0)
        {
            Debug.Log("Player Has Died");
            r2b.bodyType = RigidbodyType2D.Static;
            anim.SetTrigger("Death");
        }
    }
}
