using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class pointCollection : MonoBehaviour
{

    public GameObject point1;
    public GameObject point2;
    public GameObject point3;
    public GameObject point4;
    public GameObject point5;
    public GameObject point6;
    public GameObject point7;
    public GameObject point8;
    public List<GameObject> points;
    private NavMeshAgent agent;
    private Animator anim;
    private SoundManager soundManager;
    

    private void Start()
    {
        points = new List<GameObject>();
        points.Add(point1);
        points.Add(point2);
        points.Add(point3);
        points.Add(point4);
        points.Add(point5);
        points.Add(point6);
        points.Add(point7);
        points.Add(point8);
        agent = GetComponent<NavMeshAgent>();
    }

    public void Update()
    {
        setRoutine();
    }

    public void setRoutine()
    {
        foreach (var point in points)
        {
            anim.SetBool("move", true);
            agent.SetDestination(point.transform.position);
            anim.SetBool("move", false);
            //point.GetComponent<AudioSource>().Play();
            if (point == point1)
            {
                soundManager.PlayVoice("kyle", "1", agent.nextPosition);
            }
        }

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



        /*if (point1 != null)
    {
        agent.SetDestination(point1.transform.position);
    }*/

        /*
         * Music File and Punkt 1 dauert 10 Sekunden
         * TODO check ob 0.1 richtig?
         */
       if (agent.remainingDistance < 0.1) // keine ahnung ob das stimmt
        {
            /*
             * spiel datei ab
             * währenddessen warte 10 Sekunden
             */
        }

        /*if (point2 != null)
        {
            agent.SetDestination(point2.transform.position);
            anim.SetBool("move", true);
        }*/

    }
}
