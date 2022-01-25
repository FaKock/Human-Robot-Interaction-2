using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    private Animator dooranimator;

    // Start is called before the first frame update
    void Start()
    {
        dooranimator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            dooranimator.SetBool("open", true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
