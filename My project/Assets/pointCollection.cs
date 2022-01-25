using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.AI;

public class PointCollection : MonoBehaviour
{

    public List<GameObject> points;
    
    private NavMeshAgent agent;
    public SoundManager soundManager;
    public GameObject player;

    public GameObject bottleOdesinfect;
    public GameObject Door;

    private Animator anim;

    private bool isRunning = false;
    static float t = 0.0f;
    
    public void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

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
            if (i != 6)
            {
                //yield return new WaitUntil(() => Door.GetComponent<Animation>());
                agent.isStopped = false;
                Vector3 point = points[i].transform.position;
                agent.SetDestination(point);
                yield return new WaitUntil(() => agent.remainingDistance != 0);
                yield return new WaitUntil(() => agent.remainingDistance < 0.0005f);
                //LookAt(player.transform.position);
                yield return new WaitForSeconds(0.5f);
                agent.isStopped = true;
                yield return new WaitForSeconds(0.2f);
                soundManager.PlayVoice(SoundManager.Voice.kyle, i);
                yield return new WaitUntil(() => soundManager.audioSource.isPlaying == false);
                yield return new WaitForSeconds(0.5f);
                if (i == 1)
                {
                    LookAt(bottleOdesinfect.transform.position);
                    anim.SetInteger("LookTowardsPlayer", 4);
                    soundManager.PlaySound(SoundManager.Sound.Desinfection);
                    yield return new WaitUntil(() => soundManager.audioSource.isPlaying == false);
                    yield return new WaitForSeconds(0.5f);
                    anim.SetInteger("LookTowardsPlayer", 5);
                }

                if (i == 2)
                {
                    anim.Play("tabletshow");
                }

                if (i == 4)
                {
                    anim.SetInteger("LookTowardsPlayer", 13);
                    yield return new WaitForSeconds(2f);
                    anim.SetInteger("LookTowardsPlayer", 14);
                }

               if (i == 5)
                {
                    anim.SetInteger("LookTowardsPlayer", 9);
                    soundManager.PlaySound(SoundManager.Sound.OpenWindow);
                    yield return new WaitUntil(() => soundManager.audioSource.isPlaying == false);
                    yield return new WaitForSeconds(0.5f);
                    points[i].GetComponent<AudioSource>().Play();
                    anim.SetInteger("LookTowardsPlayer", 10);
                }
            }
            else 
            {
                
                agent.isStopped = false;
                Vector3 point = points[i].transform.position;
                agent.SetDestination(point);
                yield return new WaitUntil(() => agent.remainingDistance != 0);
                yield return new WaitUntil(() => agent.remainingDistance < 0.0005f);
                //LookAt(player.transform.position);
                yield return new WaitForSeconds(0.5f);
                agent.isStopped = true;
                yield return new WaitForSeconds(0.2f);
                anim.SetInteger("LookTowardsPlayer", 15);
                soundManager.PlayVoice(SoundManager.Voice.kyle, i);
                yield return new WaitUntil(() => soundManager.audioSource.isPlaying == false);
                yield return new WaitForSeconds(0.5f);
                anim.SetInteger("LookTowardsPlayer", 16);
            }


        }
    }

    private bool LookAt(Vector3 pos)
    {
        Vector3 lookPos = pos - transform.position;
        lookPos.y = 0;
        Quaternion rotation = Quaternion.LookRotation(lookPos);
        agent.transform.rotation = Quaternion.Slerp(agent.transform.rotation, rotation, 5f);
        return true; // TODO

    }
    

}
