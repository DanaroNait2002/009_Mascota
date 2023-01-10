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
    GameObject slime;

    [Header("Default Minigame Values")]
    [SerializeField]
    StateSelector currentState = StateSelector.Waiting;
    [SerializeField]
    float timer = 0f;
    [SerializeField]
    float time;

    [Header("Minigame stats")]
    [SerializeField]
    float speed = 50f;
    [SerializeField]
    int i = 0;
    [SerializeField]
    float[] spawner = { 7f, 15f, 17f, 20f, 24f, 25f, 28f };
    //                   0   1    2    3    4    5    6  = 7
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
                    if (timer >= spawner[i])
                    {
                        Vector3 position = new Vector3(Random.Range(-2.65f, 2.65f), 6.70f, -1);
                        Instantiate(obtainable[i], position, Quaternion.identity);
                        i++;

                        
                    }
                }
            }
            if (timer >= 30f)
            {
                i = 0;
            
                LeanTween.moveLocalX(slime, 0f, 1f);
                currentState = StateSelector.Waiting;
            }
        }    
    }

    public void ButtonFeed()
    {
        currentState = StateSelector.Playing;
    }

    public void ButtonRight() 
    {
        slime.transform.position += Vector3.right * speed * Time.deltaTime;
    }

    public void ButtonLeft() 
    {
        slime.transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
