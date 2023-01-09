using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Pipeline.Interfaces;
using UnityEngine;

public class Love_Points : MonoBehaviour
{
    
    public enum StateSelector
    {
        Waiting,
        Death,
        Baby,
        Junior,
        Senior,
        King,
    }

    [SerializeField]
    StateSelector currentState = StateSelector.Waiting;
    
    [SerializeField]
    int lovePoints;

    [Header("Slimes")]
    [SerializeField]
    GameObject baby;
    [SerializeField]
    GameObject junior;
    [SerializeField]
    GameObject senior;
    [SerializeField]
    GameObject king;

    public void Start()
    {
        lovePoints = PlayerPrefs.GetInt("lovePoints", 1);
        LovePointsChecker();
        CurrentSlime();
    }

    public void Update()
    {
        PlayerPrefs.SetInt("lovePoints", lovePoints);
        PlayerPrefs.Save();

        LovePointsChecker();
        CurrentSlime();
    }

    public void CurrentSlime()
    {
        switch (currentState) 
        {
            case StateSelector.Death:
                baby.SetActive(false); 
                junior.SetActive(false);
                senior.SetActive(false);
                king.SetActive(false);
                break;

            case StateSelector.Baby:
                baby.SetActive(true);
                junior.SetActive(false);
                senior.SetActive(false);
                king.SetActive(false);
                break;

            case StateSelector.Junior:
                baby.SetActive(false);
                junior.SetActive(true);
                senior.SetActive(false);
                king.SetActive(false);
                break;

            case StateSelector.Senior:
                baby.SetActive(false);
                junior.SetActive(false);
                senior.SetActive(true);
                king.SetActive(false);
                break;

            case StateSelector.King:
                baby.SetActive(false);
                junior.SetActive(false);
                senior.SetActive(false);
                king.SetActive(true);
                break;
        }
    }

    public void LovePointsChecker()
    {

        if (lovePoints <= 0)
        {
            currentState = StateSelector.Death;
        }

        if (lovePoints >= 1 && lovePoints <= 5)
        {
            currentState= StateSelector.Baby;
        }

        if (lovePoints >= 6 && lovePoints <= 20)
        {
            currentState= StateSelector.Junior;
        }

        if (lovePoints >= 21 && lovePoints <= 60)
        {
            currentState= StateSelector.Senior;
        }

        if (lovePoints >= 61)
        {
            currentState= StateSelector.King;
        }
    }
}