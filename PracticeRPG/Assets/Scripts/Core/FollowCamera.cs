using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] Transform target;
    //It is transform because we need to know the position
        
    void LateUpdate()//Using LateUpdate for order of execution
    //Updating the camera late (after the mover) will make it to where
    //There is no problem with the camera moving first, before the character
    //Causing a jittery movement.
    {
    transform.position = target.position;
    }
}
