using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmmoDisplay : MonoBehaviour
{
    public TextMeshProUGUI ammoDisplay;
    Shoot currentWeapon;

    // Start is called before the first frame update
    void Start()
    {
        currentWeapon = gameObject.GetComponent<Shoot>();
        ammoDisplay = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        ammoDisplay.text = currentWeapon.ammo.ToString();
    }
}
