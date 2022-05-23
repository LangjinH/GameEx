using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{

    public Toggle fullscrrenTog, vsyncTog;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ApplyGraphics()
    {
        // Apply fullscreen 
        Screen.fullscrern = fullscrrenTog.isOn;
        
        if (vsyncTog.isOn)
        {
            QualitySettings.vSyncCount = 1;

        }
        else
        {
            QualitySettings.vSyncCount = 0;
        }
    }
}
