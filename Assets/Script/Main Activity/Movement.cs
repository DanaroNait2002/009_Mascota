using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    GameObject slime;

    [SerializeField]
    float speed = 50f;

    public void ButtonRight()
    {
        slime.transform.position += Vector3.right * speed * Time.deltaTime;
    }

    public void ButtonLeft()
    {
        slime.transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
