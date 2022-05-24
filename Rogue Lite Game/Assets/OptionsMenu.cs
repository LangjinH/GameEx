using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{

    public Toggle fullscreenTog, vsyncTog;

    public ResItem[] resolutions;

    private int selectedResolution;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResLeft()
    {
        selectedResolution--;
        if (selectedResolution < 0)
        {
            selectedResolution = 0;
        }
    }

    public void ResRight()
    {
        selectedResolution++'
            if (selectedResolution >resolutions.Length -1)
        {
            selectedResolution = resolutions.Length - 1;
        }
        
    }


    public void ApplyGraphics()
    {
        // Apply fullscreen
        Screen.fullScreen = fullscreenTog.isOn;
        

        if (vsyncTog.isOn)
        {
            QualitySettings.vSyncCount = 1;
        }//if
        else
        {
            QualitySettings.vSyncCount = 0;
        }//else
        
    }//apply graphics 
}


[System.Serializable]
public class ResItem
{
    public int horizontal, vertical;

}