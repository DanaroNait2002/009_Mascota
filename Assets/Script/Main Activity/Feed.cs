using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Feed : MonoBehaviour
{
    /*
    pA = puntos de amor 
    
    Al pulsar botón damos de comer en un minijuego donde cae comida y obstáculos:
    - El minijuego durará 30s
     - 4 comida (+3pA por cada)
     - 3 obstáculos (-1pA por cada)
    Movemos a la mascosta con dos botones

    Se pueden acumular hasta 12pA

    Si le damos sin hambre crecerá en el eje X

    Por cada 20m con hambre perderá 1pA
    */
    public enum StateSelector
    {
        Waiting,
        Playing,
    }

    [Header("Slimes")]
    [SerializeField]
    GameObject baby;
    [SerializeField]
    GameObject junior;
    [SerializeField]
    GameObject senior;
    [SerializeField]
    GameObject king;

    [Header("Obstacles")]
    [SerializeField]
    GameObject obstacle01;
    [SerializeField]
    GameObject obstacle02;

    [Header("Food")]
    [SerializeField]
    GameObject food01;
    [SerializeField]
    GameObject food02;

    [Header("Default Minigame Values")]
    [SerializeField]
    StateSelector currentState = StateSelector.Waiting;
    [SerializeField]
    float timer = 0f;
    [SerializeField]
    float time;
    [SerializeField]
    float timeMin;
    [SerializeField]
    float timeMax;

    [Header("Minigame stats")]
    [SerializeField]
    float speed = 50f;
    [SerializeField]
    int i = 0;
    [SerializeField]
    float[] spawner = { 7f, 15f, 17f, 20f, 24f, 25f, 28f };
    //                   0   1    2    3    4    5    6  = 7
    //float[] spawner = { 28f, 25f, 24f, 20f, 17f, 15f, 7f };
    [SerializeField]
    GameObject[] obtainable = new GameObject[7];


    void Update()
    {
        switch (currentState)
        {
            case StateSelector.Waiting:
                timer = 0f;
                break;
        }
        

        if (currentState == StateSelector.Playing)
        {
            if (timer <= 30f)
            {
                timer += Time.deltaTime;

                if (i < spawner.Length)
                {
                    Debug.Log(spawner[i]);
                    Debug.Log(i);

                    if (timer >= spawner[i])
                    {
                        Vector3 position = new Vector3(Random.Range(-2.65f, 2.65f), 6.70f, -1);
                        Instantiate(obtainable[i], position, Quaternion.identity);
                        i++;
                        Debug.Log("Dentro del if");
                    }
                }
            }
            if (timer >= 30f)
            {
                i = 0;
            
                LeanTween.moveLocalX(baby, 0f, 1f);
                LeanTween.moveLocalX(junior, 0f, 1f);
                LeanTween.moveLocalX(senior, 0f, 1f);
                LeanTween.moveLocalX(king, 0f, 1f);
                currentState = StateSelector.Waiting;
            }
        }    
    }
    
    public void SummonFood01()
    {
        Instantiate(food01, new Vector3(Random.Range(-3f, 3f), 6.7f, -1f), Quaternion.identity);
    }

    public void SummonFood02() 
    {
        Instantiate(food02, new Vector3(Random.Range(-3f, 3f), 6.7f, -1f), Quaternion.identity);
    }

    public void SummonObstacle01()
    {
        Instantiate(obstacle01, new Vector3(Random.Range(-3f, 3f), 6.7f, -1f), Quaternion.identity);
    }

    public void SummonObstacle02()
    {
        Instantiate(obstacle02, new Vector3(Random.Range(-3f, 3f), 6.7f, -1f), Quaternion.identity);
    }

    public void ButtonFeed()
    {
        currentState = StateSelector.Playing;
    }

    public void ButtonRight() 
    {
        baby.transform.position += Vector3.right * speed * Time.deltaTime;
        junior.transform.position += Vector3.right * (speed - 10f) * Time.deltaTime;
        senior.transform.position += Vector3.right * (speed - 20f) * Time.deltaTime;
        king.transform.position += Vector3.right * (speed - 30f) * Time.deltaTime;
    }

    public void ButtonLeft() 
    {
        baby.transform.position += Vector3.left * speed * Time.deltaTime;
        junior.transform.position += Vector3.left * (speed - 10f) * Time.deltaTime;
        senior.transform.position += Vector3.left * (speed - 20f) * Time.deltaTime;
        king.transform.position += Vector3.left * (speed - 30f) * Time.deltaTime;
    }
}
