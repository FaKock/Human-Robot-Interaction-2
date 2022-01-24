using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.AI;

public class PointCollection : MonoBehaviour
{

    public List<GameObject> points;
    
    private NavMeshAgent agent;
    public SoundManager soundManager;

    private bool isRunning = false;
    public void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updatePosition = false;

    }

    public void Update()
    {
        if (!isRunning)
        {
            isRunning = true;
            StartCoroutine(SetRoutine());
        }
    }

    IEnumerator SetRoutine()
    {
        for (int i = 0; i < points.Count; i++)
        { 
            agent.isStopped = false;
            Debug.Log(i);
            Vector3 point = points[i].transform.position;
            agent.SetDestination(point);
            yield return new WaitUntil(() => agent.remainingDistance < 0.005f);
            agent.isStopped = true;
            yield return new WaitForSeconds(0.5f);
            Debug.Log("walking done. Voice now");
            soundManager.PlayVoice(SoundManager.Voice.kyle, i);
            yield return new WaitUntil(() => soundManager.audioSource.isPlaying == false);
            yield return new WaitForSeconds(0.5f);
            Debug.Log("One sequence done");
        }
    }

}
