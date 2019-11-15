using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//Hold Ctrl+Shift+Spacebar when trying to find info on methods
public class Mover : MonoBehaviour
{
    [SerializeField] Transform target;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            MoveToCursor();
        }
        UpdateAnimator();
    }
        private void MoveToCursor()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            bool hasHit = Physics.Raycast(ray, out hit);

            if (hasHit)
            {
                GetComponent<NavMeshAgent>().destination = hit.point;
            }
        }
        private void UpdateAnimator()
        {
            Vector3 velocity = GetComponent<NavMeshAgent>().velocity;//Get velocity from navmesh
            Vector3 localVelocity = transform.InverseTransformDirection(velocity);//Makes the velocity meaningful for the character
            float speed = localVelocity.z;//Passing it to speed
            GetComponent<Animator>().SetFloat("forwardSpeed", speed);//Put into the animator
        }
    
}
