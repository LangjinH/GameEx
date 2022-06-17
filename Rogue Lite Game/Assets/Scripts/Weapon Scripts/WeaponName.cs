using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponName : MonoBehaviour
{
    public TextMeshProUGUI weaponName;
    public string nameOfWeapon;
    // Start is called before the first frame update
    void Update()
    {
        weaponName.text = nameOfWeapon;
    }
}
