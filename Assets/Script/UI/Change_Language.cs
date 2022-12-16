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
        //Call funtion
        LoadLanguage();
    }

    private void Start()
    {
        //At the start the amount of languages available is count
        TOTALLANGUAGES = LocalizationSettings.AvailableLocales.Locales.Count;
            //Languages = {Español, English}

        //Call funtion
        SelectCurrentLanguage();
    }


    //FUNTIONS

        public void LoadLanguage()
        {
            //The value of the current Language is set to the one that has been save or to 0 in case there's none
            currentLanguage = PlayerPrefs.GetInt("currentLanguage", 0);

            //The Language is set to the value that current Language has
            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[currentLanguage];
        }

        void SelectCurrentLanguage()
        {
            //La verdad no recuerdo que hacia esto
            UnityEngine.Localization.Locale searcher = LocalizationSettings.AvailableLocales.Locales[currentLanguage];

            while (searcher != LocalizationSettings.SelectedLocale && currentLanguage < LocalizationSettings.AvailableLocales.Locales.Count)
            {
                currentLanguage++;
                searcher = LocalizationSettings.AvailableLocales.Locales[currentLanguage];
            }
        }

        

    //BUTTONS FUNTIONS
        public void ClickPrevious()
        {   
            //Current Language -1
            currentLanguage -= 1;
            
            //In case Current Language reach a value lower than 0 the value is set to the maximun of languages available
            if (currentLanguage < 0)
            {
                currentLanguage = 1;
            }

            //The language is set to the value that current Language has
            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[currentLanguage];
        }

        public void ClickNext()
        {
            //Current Language +1
            currentLanguage += 1;
            
            //If case Current Language reach a value higher that the maximun of languages available the value is set to zero
            if (currentLanguage >= TOTALLANGUAGES)
            {
                currentLanguage = 0;
            }

            //The language is set to the value that current Language has
            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[currentLanguage];
        }

        public void SaveLanguage()
        {
            // The value given to current language is saved
            PlayerPrefs.SetInt("currentLanguage", currentLanguage);
            PlayerPrefs.Save();
        }

    public void ResetLanguageSettings()
    {
        PlayerPrefs.DeleteAll();
        LoadLanguage();
    }
}
