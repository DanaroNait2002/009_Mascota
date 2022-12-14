using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;

public class Animation_Interface : MonoBehaviour
{
    public static Animation_Interface instance;

    [Header("Initial Interface")]
    [SerializeField]
    GameObject tittleBackground;
    [SerializeField]
    GameObject tittle;
    [SerializeField]
    GameObject buttonsBackground_01;
    [SerializeField]
    GameObject buttonNewGame;
    [SerializeField]
    GameObject buttonContinue;
    [SerializeField]
    GameObject buttonSettings_01;
    [SerializeField]
    GameObject buttonExit;

    [Header("Main Menu")]
    [SerializeField]
    GameObject buttonsBackground_02;
    [SerializeField]
    GameObject buttonSettings_02;
    [SerializeField]
    GameObject labelHungry;
    [SerializeField]
    GameObject labelGameOver;

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
    [SerializeField]
    GameObject buttonDefaultSettings;

    [Header("Save Menu")]
    [SerializeField]
    GameObject tittleContinueSave;
    [SerializeField]
    GameObject saveBackground;
    [SerializeField]
    GameObject buttonYesSave;
    [SerializeField]
    GameObject buttonNoSave;
    
    [Header("Reset Menu")]
    [SerializeField]
    GameObject tittleContinueReset;
    [SerializeField]
    GameObject resetBackground;
    [SerializeField]
    GameObject buttonYesReset;
    [SerializeField]
    GameObject buttonNoReset;

    [Header("Feed_Minigame")]
    [SerializeField]
    GameObject buttonRight;
    [SerializeField]
    GameObject buttonLeft;

    private void Awake()
    {
        if (Animation_Interface.instance == null)
        {
            Animation_Interface.instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    void OnEnable()
    {
        //INITAL INTERFACE
        //The scale of the UI is changed to 0 as soon as the script is enabled
        LeanTween.scale(tittleBackground, Vector3.zero, 0.0f);
        LeanTween.scale(tittle, Vector3.zero, 0.0f);
        LeanTween.scale(buttonsBackground_01, Vector3.zero, 0.0f);
        LeanTween.scale(buttonNewGame, Vector3.zero, 0.0f);
        LeanTween.scale(buttonContinue, Vector3.zero, 0.0f);
        LeanTween.scale(buttonSettings_01, Vector3.zero, 0.0f);
        LeanTween.scale(buttonExit, Vector3.zero, 0.0f);

        //SETTINGS MENU
        //Making sure this is set as scale 0 as soon as the script is enabled
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
        LeanTween.scale(buttonDefaultSettings, Vector3.zero, 0.0f);

        //MAIN MENU
        //The UI that we don't want in the screen is moved out
        LeanTween.moveLocalY(buttonsBackground_02, -2063f, 0.0f);
        LeanTween.moveLocalX(buttonSettings_02, 1087f, 0.0f);
        LeanTween.moveLocalY(labelHungry, 1900f, 0.0f);
        LeanTween.scale(labelGameOver, Vector3.zero, 0.0f);

        //SAVE MENU
        //Making sure this is set as scale 0 as soon as the script is enabled
        LeanTween.scale(tittleContinueSave, Vector3.zero, 0.0f);
        LeanTween.scale(saveBackground, Vector3.zero, 0.0f);
        LeanTween.scale(buttonYesSave, Vector3.zero, 0.0f);
        LeanTween.scale(buttonNoSave, Vector3.zero, 0.0f);
        
        //RESET MENU
        //Making sure this is set as scale 0 as soon as the script is enabled
        LeanTween.scale(tittleContinueReset, Vector3.zero, 0.0f);
        LeanTween.scale(resetBackground, Vector3.zero, 0.0f);
        LeanTween.scale(buttonYesReset, Vector3.zero, 0.0f);
        LeanTween.scale(buttonNoReset, Vector3.zero, 0.0f);

        //FEED MINIGAME
        //Making sure this is set as scale 0 as soon as the script is enabled
        LeanTween.scale(buttonRight, Vector3.zero, 0.0f);
        LeanTween.scale(buttonLeft, Vector3.zero, 0.0f);

        //Call funtion
        ChangeScaleTittleBackground();
    }

    //INITIAL INTERFACE
    void ChangeScaleTittleBackground()
    {
        //The Tittle's background scale to one as soon as the funtion is called
        LeanTween.scale(tittleBackground, Vector3.one, 0.5f).setEaseInOutBack().setOnComplete(ChangeScalesTittle);
    }

    void ChangeScalesTittle()
    {
        //Then the Tittle scale to one as soon as the background complete scale to one
        LeanTween.scale(tittle, Vector3.one, 0.5f).setEaseInOutBack().setOnComplete(ChangeScaleButtonBackground);
    }

    void ChangeScaleButtonBackground()
    {
        //The button's background scale to one as soon as the tittle complete scale to one
        LeanTween.scale(buttonsBackground_01, Vector3.one, 0.5f).setEaseInOutBack().setOnComplete(ChangeScaleButtonNewGame);
    }

    void ChangeScaleButtonNewGame()
    {
        //The New Game button scale to one as soon as the background complete scale to one
        LeanTween.scale(buttonNewGame, Vector3.one, 0.5f).setEaseInOutBack().setOnComplete(ChangeScaleButtonContinue);
    }

    void ChangeScaleButtonContinue()
    {
        //The Continue button scale to one as soon as the background complete scale to one
        LeanTween.scale(buttonContinue, Vector3.one, 0.5f).setEaseInOutBack().setOnComplete(ChangeScaleButtonOptions);
    }

    void ChangeScaleButtonOptions()
    {
        //The Settings button scale to one as soon as the Continue button complete scale to one
        LeanTween.scale(buttonSettings_01, Vector3.one, 0.5f).setEaseInOutBack().setOnComplete(ChangeScaleButtonExit);
    }

    void ChangeScaleButtonExit()
    {
        //The Exit button scale to one as soon as the Settings button complete scale to one
        LeanTween.scale(buttonExit, Vector3.one, 0.5f).setEaseInOutBack();
    }

    //MAIN MENU
    void AnimationActivationMainMenu()
    {
        //The Main Menu moves into the scene as soon as the funtion is called
        LeanTween.moveLocalY(buttonsBackground_02, -1450f, 1f);
        LeanTween.moveLocalX(buttonSettings_02, 861.18f, 1f);
    }
    //SETTINGS MENU
    void AnimationActivationSettingsMenu()
    {
        //The Settings' Background scale to one
        LeanTween.scale(settingsBackground, Vector3.one, 1f).setOnComplete(ChangeScaleTittleSettings);
    }

    void ChangeScaleTittleSettings()
    {
        //The tittle scale to one as soon as the funtion is called
        LeanTween.scale(tittleSettings, Vector3.one, 1f).setOnComplete(ChangeScaleSubtittles);
    }

    void ChangeScaleSubtittles()
    {
        //As soon as the funtion is called the UI scale to one
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
        LeanTween.scale(buttonSave, Vector3.one, 1f);
        LeanTween.scale(buttonDefaultSettings, Vector3.one, 1f).setOnComplete(ChangePositionButtonBack);
    }

    void ChangePositionButtonBack()
    {
        //The Back's button moves into the scene as soon as the funtion is called
        LeanTween.moveLocalX(buttonBack_InitialInterface, -861.18f, 1f);
    }

    void AnimationDesactivationSettingsMenu()
    {
        //The Settings' backgrouns scale to zero as soon as the funtion is called
        LeanTween.scale(settingsBackground, Vector3.zero, 1f).setOnComplete(AnimationBackToInitialInterface);
    }

    void AnimationBackToInitialInterface()
    {
        //As soon as the funtion is called the UI moves into scene
        LeanTween.moveLocalY(tittleBackground, 1481f, 1f);
        LeanTween.moveLocalX(buttonsBackground_01, 0f, 1f);
    }

    void AnimationSaveMenuIn()
    {
        LeanTween.scale(tittleContinueSave, Vector3.one, 0.75f);
        LeanTween.scale(buttonYesSave, Vector3.one, 0.75f);
        LeanTween.scale(buttonNoSave, Vector3.one, 0.75f);
    }
    void AnimationSaveMenuOut()
    {
        //As soon as the funtion is called the UI scale to zero
        LeanTween.scale(saveBackground, Vector3.zero, 0.5f);
    }

    void AnimationResetMenuIn()
    {
        LeanTween.scale(tittleContinueReset, Vector3.one, 0.75f);
        LeanTween.scale(buttonYesReset, Vector3.one, 0.75f);
        LeanTween.scale(buttonNoReset, Vector3.one, 0.75f);
    }

   void AnimationResetMenuOut()
   {
        //As soon as the funtion is called the UI scale to zero
        LeanTween.scale(resetBackground, Vector3.zero, 0.75f);
   }

    void AnimationFeedMinigameButton()
    {
        //As soon as the funtion is called the UI scale to one
        LeanTween.scale(buttonRight, Vector3.one, 0.5f);
        LeanTween.scale(buttonLeft, Vector3.one, 0.5f);
    }

    public void AnimationFeedMinigameButtonOut()
    {
        //As soon as the funtion is called the UI scale to zero
        LeanTween.scale(buttonRight, Vector3.zero, 0.5f);
        LeanTween.scale(buttonLeft, Vector3.zero, 0.5f).setOnComplete(AnimationActivationMainMenu);
    }

    public void AnimationGameOver()
    {
        LeanTween.scale(labelGameOver, Vector3.one, 0.75f);
    }

    public void AnimationGameOverOut()
    {
        LeanTween.scale(labelGameOver, Vector3.zero, 0.25f);
    }

    public void AnimationHungry()
    {
        LeanTween.moveLocalY(labelHungry, 1543.5f, 0.75f);
    }

    public void AnimationHungryOut()
    {
        LeanTween.moveLocalY(labelHungry, 1900f, 0.75f);
    }

    //BUTTON FUNTIONS
    public void ButtonContinue()
    {
        //As soon as the funtion is called the UI moves out the scene
        LeanTween.moveLocalY(tittleBackground, 2459f, 1f);
        LeanTween.moveLocalX(buttonsBackground_01, 1682f, 1f).setOnComplete(AnimationActivationMainMenu);
    }

    public void ButtonSettings()
    {
        //In case the click is on the INITIAL INTERFACE
        //As soon as the funtion is called the UI moves out the scene
        LeanTween.moveLocalY(tittleBackground, 2459f, 1f);
        LeanTween.moveLocalX(buttonsBackground_01, 1682f, 1f);

        //In case the click is on the MAIN MENU
        //As soon as the funtion is called the UI moves out the scene
        LeanTween.moveLocalY(buttonsBackground_02, -2063f, 1f);
        LeanTween.moveLocalX(buttonSettings_02, 1087f, 1f).setOnComplete(AnimationActivationSettingsMenu);

        LeanTween.scale(tittleContinueSave, Vector3.zero, 0.0f);
    }

    public void ButtonBack()
    {
        //As soon as the funtion is called the UI moves out the scene
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
        LeanTween.scale(buttonDefaultSettings, Vector3.zero, 1f);
        LeanTween.moveLocalX(buttonBack_InitialInterface, -1152f, 1f).setOnComplete(AnimationDesactivationSettingsMenu);
    }

    public void ButtonSave()
    {
        //As soon as the funtion is called the UI scale to one 
        LeanTween.scale(saveBackground, Vector3.one, 0.75f).setOnComplete(AnimationSaveMenuIn);
        
    }

    public void ButtonExitSaveInterface()
    {
        LeanTween.scale(tittleContinueSave, Vector3.zero, 0.75f);
        LeanTween.scale(buttonYesSave, Vector3.zero, 0.75f);
        LeanTween.scale(buttonNoSave, Vector3.zero, 0.75f).setOnComplete(AnimationSaveMenuOut);
    } 
    
    public void ButtonReset()
    {
        //As soon as the funtion is called the UI scale to one
        LeanTween.scale(resetBackground, Vector3.one, 0.75f).setOnComplete(AnimationResetMenuIn);
    }

    public void ButtonExitResetInterface()
    {
        LeanTween.scale(tittleContinueReset, Vector3.zero, 0.75f);
        LeanTween.scale(buttonYesReset, Vector3.zero, 0.75f);
        LeanTween.scale(buttonNoReset, Vector3.zero, 0.75f).setOnComplete(AnimationResetMenuOut);
    }

    // Hacer funci?n nueva donde el bot?n de Yes y el de No animen una l?nea donde se dice si se ha guardado o no los cambios. No hace falta gran cosa, I guess
    // 

    public void ButtonFeed()
    {
        //As soon as the funtion is called the UI moves out the screen
        LeanTween.moveLocalY(buttonsBackground_02, -2063f, 0.5f);
        LeanTween.moveLocalX(buttonSettings_02, 1087f, 0.5f);

        AnimationFeedMinigameButton();
    }
}

