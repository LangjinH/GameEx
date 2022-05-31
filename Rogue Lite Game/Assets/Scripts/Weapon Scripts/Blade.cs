using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script allows the Katana to use it's abilities
public class Blade : MonoBehaviour {
    float CDtime; //The wait after the combo ends
    public float StartCD = 1.5f;   //Starts cooldown
    float ComboTime;  //Determines how long the player is allowed to continue their combo 
    public float StartCombo = 1.5f;    //Starts ComboTime;
    public Transform attackPos;
    Animator playerAnim; 
    public LayerMask whatIsEnemies;
    public float attackRange;
    public int damage;              //Damage number
    private float slash;          //The number of slashes until the combo resets
    private int button;
    private bool slashing;
    private bool oncoolddown;

    void Start()
    {
        playerAnim = GetComponent<Animator>();
        slashing = false;
        oncoolddown = false;
        slash = 1;
        CDtime = StartCD;
        ComboTime = StartCombo;
    }

    void Update() 
    {
            //Attack
            if (Input.GetMouseButtonDown(button) && oncoolddown == false)
            {
                ComboTime = StartCombo;
                slashing = true;
                    switch (slash)
                    {
                        case 1:
                            playerAnim.SetTrigger("Sword_Slash1"); //First hit, weakest
                    playerAnim.SetTrigger("reset");
                    Debug.Log("slash1");
                            ComboTime = StartCombo;
                            slash++;
                            break;
                        case 2:
                            playerAnim.SetTrigger("Sword_Slash2"); //second hit, stronger
                    playerAnim.SetTrigger("reset");
                    slash++;
                            Debug.Log("slash2");
                            ComboTime = StartCombo;
                        break;
                        case 3:
                            playerAnim.SetTrigger("Sword_Slash3");  //Final hit, strongest and reset
                            playerAnim.SetTrigger("reset");
                            Debug.Log("slash3");
                            slash = 1;
                            break;
                    }

            if (oncoolddown == true)
            {
                CDtime -= Time.deltaTime;
                if (CDtime <= 0)
                {
                    oncoolddown = false;
                    CDtime = StartCD;
                }
            }

            if (slashing == true)
            {
                ComboTime -= Time.deltaTime;

                if (ComboTime <= 0)
                {
                    if (slash == 3)
                    {
                        oncoolddown = true;
                    }

                    slashing = false;
                    slash = 1;
                    ComboTime = StartCombo;
                }
            }
                Collider2D[] Killspot = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);

                for (int i = 0; i < Killspot.Length; i++)
                {
                    Killspot[i].GetComponent<Enemy>().TakeDamage(damage * (slash/1.2));
                }
            }//If Slash   

    }//Update

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
