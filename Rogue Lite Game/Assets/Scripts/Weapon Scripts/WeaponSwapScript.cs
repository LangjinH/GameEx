using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwapScript : MonoBehaviour
{
    int totalWeapons = 1;
    public int currentWeaponIndex;

    public GameObject[] Weps;
    public GameObject weaponHolder;
    public GameObject currentWep;

    // Start is called before the first frame update
    void Start()
    {
        totalWeapons = weaponHolder.transform.childCount;
        Weps = new GameObject[totalWeapons];

        for (int i = 0; i < totalWeapons; i++)
        {
            Weps[i] = weaponHolder.transform.GetChild(i).gameObject;
            Weps[i].SetActive(false);
        }

        Weps[0].SetActive(true);
        currentWep = Weps[0];
        currentWeaponIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            //check if next weapon exists
            if(currentWeaponIndex < totalWeapons-1)
            {
                Weps[currentWeaponIndex].SetActive(false);
                currentWeaponIndex++;
                Weps[currentWeaponIndex].SetActive(true);
            }    
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            //check if previous weapon exists
            if (currentWeaponIndex > 0)
            {
                Weps[currentWeaponIndex].SetActive(false);
                currentWeaponIndex--;
                Weps[currentWeaponIndex].SetActive(true);
            }
        }
    }
}
