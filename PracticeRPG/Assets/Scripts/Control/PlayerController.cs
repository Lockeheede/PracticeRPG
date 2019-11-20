using System;
using PracticeRPG.Combat;
using PracticeRPG.Movement;
using UnityEngine;

//Use a namespace to control dependencies. See section 4-25
namespace PracticeRPG.Control
{

    public class PlayerController : MonoBehaviour   
    {
    private void Update()
        {
            //Highlight a block of code, hold ctrl and press '/' to comment out the block
            //And to mass rename, select a piece of code and press F2 to rename
            if(InteractWithMovement()) return;
            if(InteractWithCombat()) return;
            print("Nothing to do");
        }

        private bool InteractWithCombat()
        {
            RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());
            foreach(RaycastHit hit in hits)
            {
                CombatTarget target = hit.transform.GetComponent<CombatTarget>();
                if(target == null) continue;

                if(Input.GetMouseButtonDown(0))
                {
                    GetComponent<Fighter>().Attack(target);
                }
                return true;
            }
            return false;
        }

        private bool InteractWithMovement()
        {
            RaycastHit hit;

            bool hasHit = Physics.Raycast(GetMouseRay(), out hit);

            if (hasHit)
            {
                if(Input.GetMouseButton(0))
                {
                GetComponent<Mover>().StartMoveAction(hit.point);
                }
                return true;
            }
            return false;
        }

        private static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    }
}