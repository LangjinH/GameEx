using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthBar;
    Player_Health player_Health;

    // Start is called before the first frame update
    void Start()
    {
        player_Health = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Health>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = player_Health.health;
    }
}
