using UnityEngine;
using PracticeRPG.Movement;
using PracticeRPG.Core;

namespace PracticeRPG.Combat
{
    public class Fighter : MonoBehaviour 
    {
        [SerializeField] float weaponRange = 2f;
        Transform target;

        private void Update() 
        {
            if(target == null) return;

           if(!GetInRange())
           {
               GetComponent<Mover>().MoveTo(target.position);
           } 
           else
           {
               GetComponent<Mover>().Stop();
           }
            
        }
    

        private bool GetInRange()
        {
            return Vector3.Distance(transform.position, target.position) < weaponRange;
        }

        public bool CanAttack(CombatTarget combatTarget)
        {
            if(combatTarget == null) { return false; }

            else {return true;}
        }

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