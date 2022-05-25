using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script allows the Katana to use it's abilities
public class Blade : MonoBehaviour {
    private float CDtime; //The wait after the combo ends
    public float StartCD;   //Starts cooldown
    public float ComboTime;  //Determines how long the player is allowed to continue their combo 
    public float StartCombo;    //Starts ComboTime;
    public Transform attackPos;
    public Animator playerAnim; 
    public LayerMask whatIsEnemies;
    public float attackRange;
    public int damage;              //Damage number
    private float slash = 1;          //The number of slashes until the combo resets
    private int button;
    void Update() 
    {
        //Check if the weapon is cooling down
        if (CDtime <= 0)
        {
            //Attack
            if (Input.GetMouseButtonDown(button))
            {
                //Check combo stage
                if (ComboTime > 0)
                {
                    switch (slash)
                    {
                        case 1:
                            playerAnim.SetTrigger("slash1"); //First hit, weakest
                            slash++;
                            break;
                        case 2:
                            playerAnim.SetTrigger("slash2"); //second hit, stronger
                            slash++;
                            break;
                        case 3:
                            playerAnim.SetTrigger("slash3");  //Final hit, strongest and reset
                            slash = 1;
                            break;
                    }
                    ComboTime = StartCombo;
                }
                else
                {
                    slash = 1;
                    ComboTime -= Time.deltaTime;
                }
                Collider2D[] Killspot = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
             /*  for (int i = 0; i < Killspot.Length; i++)
                {
                    Killspot[i].GetComponent<Enemy>().TakeDamage(damage * (slash/1.2));
                } */
            }//If Slash
            CDtime = StartCD;
        }   
        else
        {
            CDtime -= Time.deltaTime;
        }
    }//Update

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
