using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    public int hitBoxDamage = 25;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Player_Health player_stats = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Health>();
            player_stats.TakeDmg(hitBoxDamage);
        }
    }
}
