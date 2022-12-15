using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class Change_Language : MonoBehaviour
{
    public int currentLanguage;
    int TOTALLANGUAGES;

    private void Awake()
    {
        LoadLanguage();
    }

    private void Start()
    {
        TOTALLANGUAGES = LocalizationSettings.AvailableLocales.Locales.Count;
        //Languages = {Español, English}
        SelectCurrentLanguage();
    }

    void SelectCurrentLanguage()
    {
        UnityEngine.Localization.Locale searcher = LocalizationSettings.AvailableLocales.Locales[currentLanguage];

        while (searcher != LocalizationSettings.SelectedLocale && currentLanguage < LocalizationSettings.AvailableLocales.Locales.Count)
        {
            currentLanguage++;
            searcher = LocalizationSettings.AvailableLocales.Locales[currentLanguage];
        }
    }

    public void ClickPrevious()
    {
        currentLanguage -= 1;

        if (currentLanguage < 0)
        {
            currentLanguage = 1;
        }

        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[currentLanguage];
    }

    public void ClickNext()
    {
        currentLanguage += 1;

        if (currentLanguage >= TOTALLANGUAGES)
        {
            currentLanguage = 0;
        }

        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[currentLanguage];
    }

    public void SaveLanguage()
    {
        PlayerPrefs.SetInt("currentLanguage", currentLanguage);
        PlayerPrefs.Save();
    }

    public void LoadLanguage()
    {
        currentLanguage = PlayerPrefs.GetInt("currentLanguage", 0);
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[currentLanguage];
    }
}
