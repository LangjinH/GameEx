using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public int button;
    public ProjectileBehaviour ProjectilePrefab;
    public Transform LaunchOffset;
    public float firerate = 0.5f;
    public float reload = 2f;
    public int ammo = 9;
    public int reserves = 30;
    float reloadtime;   //Reload conter, time dependant on "reload"
    float firetime;       //Firerate counter, time dependant "firerate"
    int clipsize;
    bool reloading;        //Currently reloading, no animation cancelling!
    bool firing;              //Currently firing

    AudioSource Source;
    public AudioClip Fire, Reload, NoAmmo;

    private void Start()
    {
        reloading = false;
        firing = false;
        clipsize = ammo;
        Source = GetComponent<AudioSource>();
    }
    private void Update()
    {
        //Shooting
        if (Input.GetMouseButton(button) && reloading == false && firing == false)
        {
            Source.PlayOneShot(Fire, 0.7f);
            Instantiate(ProjectilePrefab, LaunchOffset.position, transform.rotation);

            //Ammo time
            if (ammo > 0 && firing == false)
            {         
                ammo--;
                firing = true;
                firetime = firerate;
            }
        }// if Shooting

        //Reloading initiation
        if (ammo == 0 && reloading == false || Input.GetKeyDown(KeyCode.R))
        {
            //Begin sequence
            reloading = true;
            reloadtime = reload;
            Source.PlayOneShot(Reload);
        }//If reload initiation

        //Reload
        if (reloading == true)
        {
            reloadtime -= Time.deltaTime;
            if (reloadtime <= 0)
            {
                reloading = false;
                reserves -= (clipsize - ammo);
                ammo = clipsize;
            }
        }//Reload 

        //firing
        if (firing == true)
        {
            firetime -= Time.deltaTime;
            if (firetime <= 0)
            {
                firing = false;
            }
        }
    }
}
