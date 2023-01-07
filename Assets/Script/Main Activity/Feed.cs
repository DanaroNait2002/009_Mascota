using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

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
