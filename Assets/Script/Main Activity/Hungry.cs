using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hungry : MonoBehaviour
{
    public static Hungry instance;

    public int hungerPoints = 0;

    int maxHungerPoints = 12;

    public string lastTimeLosePointsHungry;
    public string hourHungryString;

    public int timeToHungry = 3;
    public int timeToLosePoints = 20;

    private void Awake()
    {
        if (Hungry.instance == null)
        {
            Hungry.instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    void Start()
    {
        hourHungryString = PlayerPrefs.GetString("hourHungryString", DateTime.Now.AddHours(timeToHungry).ToString());        

        lastTimeLosePointsHungry = PlayerPrefs.GetString("lastTimeLosePointsHungry", DateTime.Now.AddMinutes(timeToLosePoints).ToString());
    }

    void Update()
    {
        if (hungerPoints == maxHungerPoints)
        {
            DateTime whenIsHungry = DateTime.Now.AddHours(timeToHungry);
            hourHungryString = whenIsHungry.ToString();
            PlayerPrefs.SetString("hourHungryString", hourHungryString);
            PlayerPrefs.Save();
            hungerPoints = 0;
            Animation_Interface.instance.AnimationHungry();
        }

        if (IsHungry() && CanLosePoints())
        {
            Animation_Interface.instance.AnimationHungry();
            Love_Points.instance.lovePointsManager(-1);
            lastTimeLosePointsHungry = DateTime.Now.ToString();
            PlayerPrefs.SetString("lastTimeLosePointsHungry", lastTimeLosePointsHungry);
            PlayerPrefs.Save();
        }
    }

    public bool IsHungry()
    {
        DateTime whenIsHungry = DateTime.Parse(hourHungryString);
        return whenIsHungry < DateTime.Now;
    }

    public bool CanLosePoints()
    {
        DateTime lastTimeLosePoints = DateTime.Parse(lastTimeLosePointsHungry);
        return lastTimeLosePoints.AddMinutes(timeToLosePoints) < DateTime.Now;
    }
}
