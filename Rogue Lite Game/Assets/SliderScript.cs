using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider = null;


    [SerializeField] private Text volumeTextUI = null;

    public void VolumeSlider (int volume)
    {
        volumeTextUI.text = volume.ToString("0");
    }

}
