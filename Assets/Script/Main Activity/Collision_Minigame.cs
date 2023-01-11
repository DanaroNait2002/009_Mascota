using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision_Minigame : MonoBehaviour
{
    public static Collision_Minigame instance;

    [SerializeField]
    float scaleX;

    private void Awake()
    {
        if (Collision_Minigame.instance == null)
        {
            Collision_Minigame.instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void OnTriggerEnter(Collider slime)
    {

        if (slime.CompareTag("Foods"))
        {
            if (Hungry.instance.IsHungry())
            {
                Hungry.instance.hungerPoints += 3;
                Love_Points.instance.lovePointsManager(3);
                Animation_Interface.instance.AnimationHungryOut();
            }
            else
            {
                scaleX = transform.localScale.x;
                transform.localScale = new Vector3(scaleX + 0.1f, 1, 1);
            }
            slime.gameObject.SetActive(false);
        }

        if (slime.CompareTag("Obstacles"))
        {
            slime.gameObject.SetActive(false);
            Love_Points.instance.lovePointsManager(-1);
        }
    }
}
