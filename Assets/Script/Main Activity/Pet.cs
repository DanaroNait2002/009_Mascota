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

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 pos = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(pos);
            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo))
            {
                if (hitInfo.collider.tag.Equals("Slime"))
                {

                }
            }
        }
    }


}
