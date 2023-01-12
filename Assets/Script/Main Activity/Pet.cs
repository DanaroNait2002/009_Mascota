using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pet : MonoBehaviour
{
    int timeToTouch = 2;
    DateTime timeTouching;
    bool alreadyTouch = false;

    //Time left to obtain pA
    int timeToPet = 2;
    //Time left to loose pA
    int timeToLosePoints = 30;
    //Time without being pet
    int timeWhitoutPet = 24;

    //Time left to obtain pA
    string hourPetString;
    //Time left to loose pA
    string lastTimeLosePointsPet;
    //Time without being pet
    string lastTimePetString;

    [SerializeField]
    GameObject particles, slime;

    void Start()
    {
        lastTimeLosePointsPet = PlayerPrefs.GetString("lastTimeLosePointsPet", DateTime.Now.AddMinutes(timeToLosePoints).ToString());
        hourPetString = PlayerPrefs.GetString("hourPetString", DateTime.Now.AddHours(timeToPet).ToString());
        lastTimePetString = PlayerPrefs.GetString("lastTimePetString", DateTime.Now.AddHours(timeWhitoutPet).ToString());
    }

    void Update()
    {
        if (NoPet() && CanLosePoints())
        {
            Love_Points.instance.lovePointsManager(-1);
            lastTimeLosePointsPet = DateTime.Now.ToString();
            PlayerPrefs.SetString("lastTimeLosePointsPet", lastTimeLosePointsPet);
            PlayerPrefs.Save();
        }

        //If the script detects a click
        if ((Input.GetMouseButton(0)) || (Input.touchCount >= 1 && Input.GetTouch(0).phase == TouchPhase.Moved))
        {
            Vector3 pos = Input.mousePosition;
            //In case the app is running on Android
            if (Application.platform == RuntimePlatform.Android)
            {
                pos = Input.GetTouch(0).position;
            }

            //Raycast info
            Ray ray = Camera.main.ScreenPointToRay(pos);
            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo))
            {
                //If the Raycast hits a slime
                if (hitInfo.collider.tag.Equals("Slime"))
                {
                    if (!alreadyTouch)
                    {

                        timeTouching = DateTime.Now.AddSeconds(timeToTouch);
                        alreadyTouch = true;
                    }

                    if (timeTouching < DateTime.Now)
                    {
                        if (CanPet())
                        {
                            Love_Points.instance.lovePointsManager(10);
                            hourPetString = DateTime.Now.AddHours(timeToPet).ToString();
                            lastTimePetString = DateTime.Now.AddHours(timeWhitoutPet).ToString();

                            PlayerPrefs.SetString("hourPetString", hourPetString);
                            PlayerPrefs.SetString("lastTimePetString", lastTimePetString);
                            PlayerPrefs.Save();
                        }

                        //Instantiate of a particle system
                        Instantiate(particles, new Vector3(slime.transform.position.x, slime.transform.position.y + 1, slime.transform.position.z), Quaternion.identity);
                        alreadyTouch = false;
                    }
                }
            }
        }
    }

    public bool CanPet()
    {
        DateTime whenCanPet = DateTime.Parse(hourPetString);
        return whenCanPet < DateTime.Now;
    }

    public bool NoPet()
    {
        DateTime whenNoPet = DateTime.Parse(lastTimePetString);
        return whenNoPet < DateTime.Now;
    }

    public bool CanLosePoints()
    {
        DateTime lastTimeLosePoints = DateTime.Parse(lastTimeLosePointsPet);
        return lastTimeLosePoints.AddMinutes(timeToLosePoints) < DateTime.Now;
    }
}
