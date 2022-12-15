using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefabs : MonoBehaviour
{

    void Start()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume", 1f);
        Load();
    }

    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
        Save();
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }
}
