using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OptionsMenu : MonoBehaviour
{

    public Toggle fullscreenTog, vsyncTog;

    public ResItem[] resolutions;

    public int selectedResolution;

    public TMP_Text resolutionLable;  
    
    // Start is called before the first frame update
    void Start()
    {
        fullscreenTog.isOn = Screen.fullScreen;

        if (QualitySettings.vSyncCount == 0)
        {
            vsyncTog.isOn = false;
        }
        else
        {
            vsyncTog.isOn = true;
        }
        bool foundRes = false;
        for (int i =0; i<resolutions.Count; i++)
        {
            if (Screen.width == resolutions[i].horizontal && Screen.height == resolutions[i].vertical)
            {
                foundRes = true;
                selectedResolution = i;
                UpdateResLabel();
            }
        }

        // if resolution is not found
        if (!foundRes)
        {
            resolutionLable.text = Screen.width.ToString() + " x " + Screen.height.ToString();
            
        }
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
        UpdateResLabel();
    }

    public void ResRight()
    {
        selectedResolution++;
            if (selectedResolution >resolutions.Length -1)
        {
            selectedResolution = resolutions.Length - 1;
        }
        UpdateResLabel();
    }

    public void UpdateResLabel()
    {
        resolutionLable.text = resolutions[selectedResolution].horizontal.ToString() + " x " + resolutions[selectedResolution].vertical.ToString();
    }

    public void ApplyGraphics()
    {
        // Apply fullscreen
       // Screen.fullScreen = fullscreenTog.isOn;
        

        if (vsyncTog.isOn)
        {
            QualitySettings.vSyncCount = 1;
        }//if
        else
        {
            QualitySettings.vSyncCount = 0;
        }//else

        // set resolution
        Screen.SetResolution(resolutions[selectedResolution].horizontal, resolutions[selectedResolution].vertical, fullscreenTog.isOn);

    }//apply graphics 
}


[System.Serializable]
public class ResItem
{
    public int horizontal, vertical;

}