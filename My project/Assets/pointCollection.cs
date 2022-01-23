using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class pointCollection : MonoBehaviour
{

    public GameObject point1;
    public GameObject point2;

    private NavMeshAgent agent;
    /*
     * 
     */

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void Awake()
    {
        setRoutine();
    }

    public void setRoutine()
    {
        /*
         * Punkte in array
         */
        
        /*
         * foreach: Punkt im Array zum Punkt gehen
         */
            /*
            * jeweils wenn an Punkt angekommen
             * Soundfile abspielen
             * warte soundlänge ab <----
            */



            if (point1 != null)
        {
            agent.SetDestination(point1.transform.position);
        }
        /*
         * Music File and Punkt 1 dauert 10 Sekunden
         * TODO check ob 0.1 richtig?
         */
        if (agent.remainingDistance < 0.1) // keine ahnung ob das stimmt
        {
            /*
             * spiel datei ab
             * währenddessen ware 10 Sekunden
             */
        }
        
        if (point2 != null)
        {
            agent.SetDestination(point2.transform.position);
        }
        
        
    }
}
