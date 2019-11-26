using UnityEngine;
using PracticeRPG.Movement;
using PracticeRPG.Control;
using PracticeRPG.Core;

namespace PracticeRPG.Combat
{
    public class Fighter : MonoBehaviour 
    {
        [SerializeField] float weaponRange = 2.0f;
        Transform target;

        private void Update()
        {
            if (target == null) return;

            if (!GetIsInRange())
             {
                GetComponent<Mover>().MoveTo(target.position);
             }
            else
            {
                GetComponent<Mover>().Stop();
            }

        }

        private bool GetIsInRange()
        {
           return Vector3.Distance(transform.position, target.position) < weaponRange;
        }

        // public bool CanAttack(CombatTarget combatTarget)
        // {
        //     if(combatTarget == null) { return false; }

        //     else {return true;}
        // }

        public void Attack(CombatTarget combatTarget)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            target = combatTarget.transform;
            print("HiYAHHHH!!!");
        }
        
        public void Cancel()
        {
            target = null;
        }
    }
}