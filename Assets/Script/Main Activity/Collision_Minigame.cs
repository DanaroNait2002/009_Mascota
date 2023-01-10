using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision_Minigame : MonoBehaviour
{


    private void OnTriggerEnter(Collider slime)
    {
        if (slime.CompareTag("Foods"))
        {
            Debug.Log("Food");
            Love_Points.instance.lovePointsManager(3);
        }

        if (slime.CompareTag("Obstacles"))
        {
            Debug.Log("Obstacle");
            Love_Points.instance.lovePointsManager(-1);
        }
    }
}
