﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using PracticeRPG.Combat;
using PracticeRPG.Control;
using PracticeRPG.Core;

//Hold Ctrl+Shift+Spacebar when trying to find info on methods

namespace PracticeRPG.Movement
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] Transform target;

        NavMeshAgent navMeshAgent;//created a navmeshagent variable so we won't have to constantly getcomponent<navmeshagent>();

        private void Start()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
        }


        void Update()
        {
        UpdateAnimator();
        }

        public void StartMoveAction(Vector3 destination)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            GetComponent<Fighter>().Cancel();
            MoveTo(destination);
        }
            
        public void MoveTo(Vector3 destination)
        {
            navMeshAgent.destination = destination;
            navMeshAgent.isStopped = false;
        }

        public void Stop()
        {
            navMeshAgent.isStopped = true;
        }

        private void UpdateAnimator()
        {
            Vector3 velocity = navMeshAgent.velocity;//Get velocity from navmesh
            Vector3 localVelocity = transform.InverseTransformDirection(velocity);//Makes the velocity meaningful for the character
            float speed = localVelocity.z;//Passing it to speed
            GetComponent<Animator>().SetFloat("forwardSpeed", speed);//Put into the animator
        }
        
    }
}