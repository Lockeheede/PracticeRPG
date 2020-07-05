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

<<<<<<< HEAD
            if (!GetIsInRange())
             {
                GetComponent<Mover>().MoveTo(target.position);
             }
=======
            if (!GetInRange())
            {
                GetComponent<Mover>().MoveTo(target.position);
            }
>>>>>>> origin/master
            else
            {
                GetComponent<Mover>().Stop();
            }

        }
<<<<<<< HEAD
=======

>>>>>>> origin/master

        private bool GetIsInRange()
        {
           return Vector3.Distance(transform.position, target.position) < weaponRange;
        }

<<<<<<< HEAD
        // public bool CanAttack(CombatTarget combatTarget)
        // {
        //     if(combatTarget == null) { return false; }

        //     else {return true;}
        // }
=======
        public bool CanAttack(CombatTarget combatTarget)
        {
            if (combatTarget == null) { return false; }

            else { return true; }
        }
>>>>>>> origin/master

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

        void Hit()
        {

        }
    }
}