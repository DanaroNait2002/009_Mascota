using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Pipeline.Interfaces;
using UnityEngine;

public class Love_Points : MonoBehaviour
{
    public static Love_Points instance;

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

    private void Awake()
    {
        //This makes the script available for using in other scripts
        if (Love_Points.instance == null)
        {
            Love_Points.instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void Start()
    {
        //This load the info from previous interactions and if there's none then set the amount of pA to 1
        lovePoints = PlayerPrefs.GetInt("lovePoints", 1);
        LovePointsChecker();
        CurrentSlime();
    }

    //This funtion edit the value of pA, compare the info and save the info every time after called
    public void lovePointsManager(int points)
    {
        lovePoints += points;

        LovePointsChecker();
        CurrentSlime();

        PlayerPrefs.SetInt("lovePoints", lovePoints);
        PlayerPrefs.Save();
    }

    public void CurrentSlime()
    {
        //This makes the Slime sprites visible according to the state
        switch (currentState) 
        {
            case StateSelector.Death:
                baby.SetActive(false); 
                junior.SetActive(false);
                senior.SetActive(false);
                king.SetActive(false);
                //Animation_Interface.instance.AnimationGameOver();
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

    //This funtion select an state depending on the amount of pA the player has
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

    //This funtion delete all saves
    public void DeleteLovePoints()
    {
        lovePoints= 1;

        LovePointsChecker();
        CurrentSlime();

        PlayerPrefs.SetInt("lovePoints", lovePoints);
        PlayerPrefs.Save();
    }
    
}
