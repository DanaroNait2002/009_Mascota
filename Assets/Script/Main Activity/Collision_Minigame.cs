using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision_Minigame : MonoBehaviour
{


    private void OnTriggerEnter(Collider slime)
    {
        if (slime.CompareTag("Foods"))
        {
            Love_Points.instance.lovePointsManager(3);
        }

        if (slime.CompareTag("Obstacles"))
        {
            Love_Points.instance.lovePointsManager(-1);
        }
    }
}
