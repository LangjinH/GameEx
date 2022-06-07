using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    int time_stop;
    // Start is called before the first frame update
    void Start()
    {
        time_stop = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            switch(time_stop)
            {
                case 0:
                    Time.timeScale = 0;
                    time_stop = 1;
                    break;
                case 1:
                    Time.timeScale = 1;
                    time_stop = 0;
                    break;
            }
        }
    }
}
