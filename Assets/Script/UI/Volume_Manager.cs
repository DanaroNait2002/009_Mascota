using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Volume_Manager : MonoBehaviour
{
    [Header("Volume")]
        [SerializeField]
        Slider volumeSlider;

    void Start()
    {
        //At the start the value in the slider is set to the one that has been save or to 1f in case there's none
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume", 1f);
    }

    //FUNTIONS
        public void ChangeVolume()
        {
            //As soon as the value in the Slider change the volumes change to that value
            AudioListener.volume = volumeSlider.value;
        }

    //BUTTONS FUNTIONS
        public void SaveVolume()
        {
            //The value given to the slider is saved
            PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
            PlayerPrefs.Save();
        }
}
