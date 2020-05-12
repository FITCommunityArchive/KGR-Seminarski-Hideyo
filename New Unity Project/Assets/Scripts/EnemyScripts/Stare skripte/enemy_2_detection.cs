﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy_2_detection : MonoBehaviour
{
    public Transform player;
    public static bool detekcija = false;
    // public enemy_moving_around skripa;
    NavMeshAgent navMeshAgent;

    private Animator animator;

    void Start()
    {
        // skripa = this.GetComponent<enemy_moving_around>();
        navMeshAgent = this.GetComponent<NavMeshAgent>();
        animator=this.GetComponent<Animator>();
    }

    public void isDetected()
    {

        Vector3 direction = player.position - this.transform.position;
        float angle = Vector3.Angle(direction, this.transform.forward);
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (Vector3.Distance(player.position, this.transform.position) < 20 && angle < 180)
        {
            navMeshAgent.speed = 3;
            direction.y = 0;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);
            if (direction.magnitude >= 3)
            {
                navMeshAgent.speed = 5;
                navMeshAgent.destination = player.position;
                navMeshAgent.stoppingDistance = 3;


            }
            else
            {
                animator.SetTrigger("IsAttacking");
            }

        }

        



        navMeshAgent.stoppingDistance = 3;
    }
    void Update()
    {
        isDetected();

    }
}
