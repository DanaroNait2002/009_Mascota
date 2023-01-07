using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Pipeline.Interfaces;
using UnityEngine;

public class Love_Points : MonoBehaviour
{
    [SerializeField]
    int lovePoints = 0;

    public void LovePointsChecker()
    {
        if (lovePoints <= 0)
        {
            //Death
        }

        if (lovePoints >= 1 && lovePoints <= 5)
        {
            //Baby
        }

        if (lovePoints >= 6 && lovePoints <= 20)
        {
            //Junior
        }

        if (lovePoints >= 21 && lovePoints <= 60)
        {
            //Senior
        }

        if (lovePoints >= 61)
        {
            //King or Queen
        }
    }
}
