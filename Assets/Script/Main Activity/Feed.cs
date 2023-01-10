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
    
    Al pulsar bot�n damos de comer en un minijuego donde cae comida y obst�culos:
    - El minijuego durar� 30s
     - 4 comida (+3pA por cada)
     - 3 obst�culos (-1pA por cada)
    Movemos a la mascosta con dos botones

    Se pueden acumular hasta 12pA

    Si le damos sin hambre crecer� en el eje X

    Por cada 20m con hambre perder� 1pA
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

    [Header("Minigame stats")]
    [SerializeField]
    int i = 0;
    [SerializeField]
    float[] spawner = { 7f, 15f, 17f, 20f, 24f, 25f, 28f };
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
}
