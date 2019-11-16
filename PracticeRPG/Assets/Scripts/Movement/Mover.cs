using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//Hold Ctrl+Shift+Spacebar when trying to find info on methods

namespace PracticeRPG.Movement
{

    public class Mover : MonoBehaviour
    {
        [SerializeField] Transform target;

        void Update()
        {
        UpdateAnimator();
        }
            

        public void MoveTo(Vector3 destination)
        {
            GetComponent<NavMeshAgent>().destination = destination;
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