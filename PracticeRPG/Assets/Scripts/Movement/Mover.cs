using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using PracticeRPG.Combat;
//Hold Ctrl+Shift+Spacebar when trying to find info on methods

namespace PracticeRPG.Movement
{

    public class Mover : MonoBehaviour
    {
        [SerializeField] Transform target;

        NavMeshAgent navMeshAgent;

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
            GetComponent<Fighter>().Cancel();
            MoveTo(destination);
        }
            

        public void MoveTo(Vector3 destination)
        {
            GetComponent<NavMeshAgent>().destination = destination;
            navMeshAgent.isStopped = false;
        }

        public void Stop()
        {
            navMeshAgent.isStopped = true;
        }

        private void UpdateAnimator()
            {
                Vector3 velocity = GetComponent<NavMeshAgent>().velocity;//Get velocity from navmesh
                Vector3 localVelocity = transform.InverseTransformDirection(velocity);//Makes the velocity meaningful for the character
                float speed = localVelocity.z;//Passing it to speed
                GetComponent<Animator>().SetFloat("forwardSpeed", speed);//Put into the animator
            }
        
    }
}