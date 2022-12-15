using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Animation_Interface : MonoBehaviour
{
    [Header("Initial Interface")]
    [SerializeField]
    GameObject tittleBackground;
    [SerializeField]
    GameObject tittle;
    [SerializeField]
    GameObject buttonsBackground_01;
    [SerializeField]
    GameObject buttonContinue;
    [SerializeField]
    GameObject buttonOptions_01;
    [SerializeField]
    GameObject buttonExit;

    [Header("Main Menu")]
    [SerializeField]
    GameObject buttonsBackground_02;
    [SerializeField]
    GameObject buttonOptions_02;

    [Header("Settings Menu")]
    [SerializeField]
    GameObject tittleSettings;
    [SerializeField]
    GameObject settingsBackground;
    [SerializeField]
    GameObject changeLanguageText;
    [SerializeField]
    GameObject buttonPreviousLanguage;
    [SerializeField]
    GameObject buttonNextLanguage;
    [SerializeField]
    GameObject flag;
    [SerializeField]
    GameObject currentLanguage;
    [SerializeField]
    GameObject adjustVolumeText;
    [SerializeField]
    GameObject musicSliderVolume;
    [SerializeField]
    GameObject musicText;
    [SerializeField]
    GameObject effectsSliderVolume;
    [SerializeField]
    GameObject effectsText;
    [SerializeField]
    GameObject buttonBack_InitialInterface;
    [SerializeField]
    GameObject buttonSave;

    void OnEnable()
    {
        //The scale of the UI is changed to 0 as soon as the script is enabled
        LeanTween.scale(tittleBackground, Vector3.zero, 0.0f);
        LeanTween.scale(tittle, Vector3.zero, 0.0f);
        LeanTween.scale(buttonsBackground_01, Vector3.zero, 0.0f);
        LeanTween.scale(buttonContinue, Vector3.zero, 0.0f);
        LeanTween.scale(buttonOptions_01, Vector3.zero, 0.0f);
        LeanTween.scale(buttonExit, Vector3.zero, 0.0f);

        //An making sure this is set as 0 as soon as the script is enabled
        LeanTween.scale(tittleSettings, Vector3.zero, 0.0f);
        LeanTween.scale(settingsBackground, Vector3.zero, 0.0f);
        LeanTween.scale(changeLanguageText, Vector3.zero, 0.0f);
        LeanTween.scale(buttonPreviousLanguage, Vector3.zero, 0.0f);
        LeanTween.scale(buttonNextLanguage, Vector3.zero, 0.0f);
        LeanTween.scale(flag, Vector3.zero, 0.0f);
        LeanTween.scale(currentLanguage, Vector3.zero, 0.0f);
        LeanTween.scale(adjustVolumeText, Vector3.zero, 0.0f);
        LeanTween.scale(musicSliderVolume, Vector3.zero, 0.0f);
        LeanTween.scale(musicText, Vector3.zero, 0.0f);
        LeanTween.scale(effectsSliderVolume, Vector3.zero, 0.0f);
        LeanTween.scale(effectsText, Vector3.zero, 0.0f);
        LeanTween.scale(buttonSave, Vector3.zero, 0.0f);

        //The UI that we don't want in the screen is moved out
        LeanTween.moveLocalY(buttonsBackground_02, -2063f, 0.0f);
        LeanTween.moveLocalX(buttonOptions_02, 1087f, 0.0f);

        //Call funtion
        ChangeScaleTittleBackground();
    }
    //ANIMATIONS
    //INITIAL INTERFACE
    void ChangeScaleTittleBackground()
    {
        LeanTween.scale(tittleBackground, Vector3.one, 0.5f).setEaseInOutBack().setOnComplete(ChangeScalesTittle);
    }

    void ChangeScalesTittle()
    {
        LeanTween.scale(tittle, Vector3.one, 0.5f).setEaseInOutBack().setOnComplete(ChangeScaleButtonBackground);
    }

    void ChangeScaleButtonBackground()
    {
        LeanTween.scale(buttonsBackground_01, Vector3.one, 0.5f).setEaseInOutBack().setOnComplete(ChangeScaleButtonContinue);
    }

    void ChangeScaleButtonContinue()
    {
        LeanTween.scale(buttonContinue, Vector3.one, 0.5f).setEaseInOutBack().setOnComplete(ChangeScaleButtonOptions);
    }

    void ChangeScaleButtonOptions()
    {
        LeanTween.scale(buttonOptions_01, Vector3.one, 0.5f).setEaseInOutBack().setOnComplete(ChangeScaleButtonExit);
    }

    void ChangeScaleButtonExit()
    {
        LeanTween.scale(buttonExit, Vector3.one, 0.5f).setEaseInOutBack();
    }

    //MAIN MENU
    void AnimationActivationMainMenu()
    {
        LeanTween.moveLocalY(buttonsBackground_02, -1450f, 1f);
        LeanTween.moveLocalX(buttonOptions_02, 861.18f, 1f);
    }
    //OPTIONS MENU
    void AnimationActivationOptionsMenu()
    {
        LeanTween.scale(tittleSettings, Vector3.zero, 0.0f);
        LeanTween.scale(settingsBackground, Vector3.zero, 0.0f);
        LeanTween.scale(changeLanguageText, Vector3.zero, 0.0f);
        LeanTween.scale(buttonPreviousLanguage, Vector3.zero, 0.0f);
        LeanTween.scale(buttonNextLanguage, Vector3.zero, 0.0f);
        LeanTween.scale(flag, Vector3.zero, 0.0f);
        LeanTween.scale(currentLanguage, Vector3.zero, 0.0f);
        LeanTween.scale(adjustVolumeText, Vector3.zero, 0.0f);
        LeanTween.scale(musicSliderVolume, Vector3.zero, 0.0f);
        LeanTween.scale(musicText, Vector3.zero, 0.0f);
        LeanTween.scale(effectsSliderVolume, Vector3.zero, 0.0f);
        LeanTween.scale(effectsText, Vector3.zero, 0.0f);
        LeanTween.scale(buttonSave, Vector3.zero, 0.0f);

        LeanTween.scale(settingsBackground, Vector3.one, 1f).setOnComplete(ChangeScaleTittleOptions);
    }

    void ChangeScaleTittleOptions()
    {
        LeanTween.scale(tittleSettings, Vector3.one, 1f).setOnComplete(ChangeScaleSubtittles);
    }

    void ChangeScaleSubtittles()
    {
        LeanTween.scale(changeLanguageText, Vector3.one, 1f);
        LeanTween.scale(adjustVolumeText, Vector3.one, 1f);
        LeanTween.scale(buttonPreviousLanguage, Vector3.one, 1f);
        LeanTween.scale(buttonNextLanguage, Vector3.one, 1f);
        LeanTween.scale(flag, Vector3.one, 1f);
        LeanTween.scale(currentLanguage, Vector3.one, 1f);
        LeanTween.scale(musicSliderVolume, Vector3.one, 1f);
        LeanTween.scale(musicText, Vector3.one, 1f);
        LeanTween.scale(effectsSliderVolume, Vector3.one, 1f);
        LeanTween.scale(effectsText, Vector3.one, 1f);
        LeanTween.scale(buttonSave, Vector3.one, 1f).setOnComplete(ChangePositionButtonBack);
    }

    void ChangePositionButtonBack()
    {
        LeanTween.moveLocalX(buttonBack_InitialInterface, -861.18f, 1f);
    }

    void AnimationDesactivationOptionsMenu()
    {
        LeanTween.scale(settingsBackground, Vector3.zero, 1f).setOnComplete(AnimationBackToInitialInterface);
    }

    void AnimationBackToInitialInterface()
    {
        LeanTween.moveLocalY(tittleBackground, 1481f, 1f);
        LeanTween.moveLocalX(buttonsBackground_01, 0f, 1f);
    }

    //BUTTON FUNTIONS
    public void ButtonContinue()
    {
        LeanTween.moveLocalY(tittleBackground, 2459f, 1f);
        LeanTween.moveLocalX(buttonsBackground_01, 1682f, 1f).setOnComplete(AnimationActivationMainMenu);
    }

    public void ButtonOptions()
    {
        //In case the click is on the INITIAL INTERFACE
        LeanTween.moveLocalY(tittleBackground, 2459f, 1f);
        LeanTween.moveLocalX(buttonsBackground_01, 1682f, 1f);

        //In case the click is on the MAIN MENU
        LeanTween.moveLocalY(buttonsBackground_02, -2063f, 1f);
        LeanTween.moveLocalX(buttonOptions_02, 1087f, 1f).setOnComplete(AnimationActivationOptionsMenu);
    }

    public void ButtonBack()
    {
        LeanTween.scale(tittleSettings, Vector3.zero, 1f);
        LeanTween.scale(changeLanguageText, Vector3.zero, 1f);
        LeanTween.scale(adjustVolumeText, Vector3.zero, 1f);
        LeanTween.scale(buttonPreviousLanguage, Vector3.zero, 1f);
        LeanTween.scale(buttonNextLanguage, Vector3.zero, 1f);
        LeanTween.scale(flag, Vector3.zero, 1f);
        LeanTween.scale(currentLanguage, Vector3.zero, 1f);
        LeanTween.scale(musicSliderVolume, Vector3.zero, 1f);
        LeanTween.scale(musicText, Vector3.zero, 1f);
        LeanTween.scale(effectsSliderVolume, Vector3.zero, 1f);
        LeanTween.scale(effectsText, Vector3.zero, 1f);
        LeanTween.scale(buttonSave, Vector3.zero, 1f);
        LeanTween.moveLocalX(buttonBack_InitialInterface, -1152f, 1f).setOnComplete(AnimationDesactivationOptionsMenu);
    }
}
