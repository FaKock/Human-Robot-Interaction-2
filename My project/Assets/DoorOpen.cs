using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DoorOpen : MonoBehaviour
{
    public float _distance;

    public GameObject ActionText;
    public GameObject Door;
    public AudioSource OpenSound;
    void Update()
    {
    // get the distance to the door
        _distance = RayCasting.DistanceFromTarget;

    }

   // The mouse is on the door
    private void OpenDoor()
    { 
        if (_distance <= 2f) 
        {
            this.GetComponent<BoxCollider>().enabled = false;
            Door.GetComponent<Animation>().Play("DoorOpenAnim001");
            OpenSound.Play();
        }
    }


}
