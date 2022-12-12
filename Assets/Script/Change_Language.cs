using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class Change_Language : MonoBehaviour
{
    int currentLanguage = 0;
    int TOTALLANGUAGES;

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
            currentLanguage = 4;
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

}
