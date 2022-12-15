using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Volume_Manager : MonoBehaviour
{
    [Header("Volume")]
    [SerializeField]
    Slider volumeSlider;
    
    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
    }
}
