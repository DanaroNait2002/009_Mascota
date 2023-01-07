using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

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

    [SerializeField]
    bool feedMinigame = false;

    [SerializeField]
    float timer = 0f;

    void Update()
    {
        if (feedMinigame)
        {
            if (timer <= 20f) 
            {
                timer += Time.deltaTime;

                Debug.Log(timer);
            }

            if (timer >= 20f)
            {
                feedMinigame= false;
            }
        }    
    }

    public void ButtonFeed()
    {
        feedMinigame = true;
    }
}
