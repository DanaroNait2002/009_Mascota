using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pet : MonoBehaviour
{
    public enum StateSelector
    {
        Waiting,
        Playing,
    }

    [Header("Default Minigame Values")]
    [SerializeField]
    StateSelector currentState = StateSelector.Waiting;

    private void Update()
    {
        switch (currentState) 
        {

            case StateSelector.Waiting:
                break;
        }
    }
}
