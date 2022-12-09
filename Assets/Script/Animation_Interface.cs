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
    GameObject buttonsBackground;
    [SerializeField]
    GameObject buttonContinue;
    [SerializeField]
    GameObject buttonOptions;
    [SerializeField]
    GameObject buttonExit;

    [Header("Main Menu")]
    [SerializeField]
    GameObject Feed;
    [SerializeField]
    GameObject Pet;

    void OnEnable()
    {
        //The scale of the UI is changed to 0 as soon as the script is enabled
        LeanTween.scale(tittleBackground, Vector3.zero, 0.0f);
        LeanTween.scale(tittle, Vector3.zero, 0.0f);
        LeanTween.scale(buttonsBackground, Vector3.zero, 0.0f);
        LeanTween.scale(buttonContinue, Vector3.zero, 0.0f);
        LeanTween.scale(buttonOptions, Vector3.zero, 0.0f);
        LeanTween.scale(buttonExit, Vector3.zero, 0.0f);


        //Call funtion
        ChangeScaleTittleBackground();
    }

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
            LeanTween.scale(buttonsBackground, Vector3.one, 0.5f).setEaseInOutBack().setOnComplete(ChangeScaleButtonContinue);
        }

        void ChangeScaleButtonContinue()
        {
            LeanTween.scale(buttonContinue, Vector3.one, 0.5f).setEaseInOutBack().setOnComplete(ChangeScaleButtonOptions);
        }

        void ChangeScaleButtonOptions()
        {
            LeanTween.scale(buttonOptions, Vector3.one, 0.5f).setEaseInOutBack().setOnComplete(ChangeScaleButtonExit);
        }

        void ChangeScaleButtonExit()
        {
            LeanTween.scale(buttonExit, Vector3.one, 0.5f).setEaseInOutBack();
        }

    //MAIN MENU




    //BUTTON FUNTIONS
    public void ButtonContinue()
    {
        LeanTween.moveLocalY(tittleBackground, 2459f, 1f);
        LeanTween.moveLocalX(buttonsBackground, 1682f, 1f);
    }
}
