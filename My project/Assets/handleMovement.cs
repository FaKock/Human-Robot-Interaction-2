using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class handleMovement : MonoBehaviour
{
    NavMeshAgent myNavMeshAgent;
    public Camera cam;
    
    /*Animation Handle*/
    private Animator anim;
    private NavMeshAgent agent;
    private Vector3 worldDeltaPosition;
    private Vector2 groundDeltaPosition;
    private  Vector2 velocity = Vector2.zero;
    public Transform target;

    Vector3 lastPosition;
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        /*
         * Transform position not synched
         */
        agent.updatePosition = false;
    }

    void Update()
    {
        /*
         * Test raycast logic
         */
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (Input.GetMouseButtonDown(1))
            {
                agent.SetDestination(hit.point);
            }
        }
        
        /*
         * Animation needs this
         */

        /*
         * 3d position
         */
        worldDeltaPosition = agent.nextPosition - transform.position;
        
        /*
         * velocity of char
         */
        groundDeltaPosition.x = Vector3.Dot(transform.right, worldDeltaPosition);
        groundDeltaPosition.y = Vector3.Dot(transform.forward, worldDeltaPosition);
        velocity = (Time.deltaTime > 1e-5f) ? groundDeltaPosition / Time.deltaTime : velocity = Vector2.zero;

        /*
         * not arrived to destination --> move animator
         */
        
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, worldDeltaPosition, 0.1f, 0.0f);
        Debug.DrawRay(transform.position, agent.nextPosition.normalized, Color.green);
        Debug.DrawRay(transform.position, newDirection, Color.red);
        
        
        bool shallMove = velocity.magnitude > 0.025f && agent.remainingDistance > agent.radius;
        
        anim.SetBool("move", shallMove);
        anim.SetFloat("velx", velocity.x);
        anim.SetFloat("vely", velocity.y);

    }

    private void OnAnimatorMove()
    {
        /*
         * Char should move after agent --> drift apart in each update call
         */
        
        transform.position = agent.nextPosition;
    }
}
