using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hungry : MonoBehaviour
{
    public static Hungry instance;

    public int hungerPoints = 0;

    int maxHungerPoints = 12;

    string lastTimeLosePointsHungry;
    string hourHungryString;

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
        DateTime whenIsHungry = DateTime.Now.AddSeconds(10);
        hourHungryString = whenIsHungry.ToString();
        lastTimeLosePointsHungry = DateTime.Now.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (hungerPoints == maxHungerPoints)
        {
            DateTime whenIsHungry = DateTime.Now.AddMinutes(1);
            hourHungryString = whenIsHungry.ToString();
            hungerPoints = 0;
        }

        if (IsHungry() && CanLosePoints())
        {
            Love_Points.instance.lovePointsManager(-1);
            lastTimeLosePointsHungry = DateTime.Now.ToString();
            //Animation_Interface.instance.AnimationHungry();
        }
    }

    public bool CanLosePoints()
    {
        DateTime lastTimeLosePoints = DateTime.Parse(lastTimeLosePointsHungry);
        return lastTimeLosePoints.AddSeconds(20) < DateTime.Now;
    }

    public bool IsHungry()
    {
        DateTime whenIsHungry = DateTime.Parse(hourHungryString);
        return whenIsHungry < DateTime.Now;
    }
}
