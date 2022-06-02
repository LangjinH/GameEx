using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public int button;
    public ProjectileBehaviour ProjectilePrefab;
    public Transform LaunchOffset;
    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(button))
        {
            Instantiate(ProjectilePrefab, LaunchOffset.position, transform.rotation); 
        }
    }
}
