using UnityEngine;
using PracticeRPG.Movement;
using PracticeRPG.Control;
using PracticeRPG.Core;

namespace PracticeRPG.Combat
{
    public class Fighter : MonoBehaviour
    {
        Transform target;

        [SerializeField] float weaponRange = 2.0f;

        [SerializeField] float weaponDamage = 5;
        [SerializeField] float timeBtwAttacks = 1f;
        float timeSinceLastAttack = 0;

        private void Update()
        {
            timeSinceLastAttack += Time.deltaTime;

            if (target == null) return;

            if (!GetIsInRange())
            {
                GetComponent<Mover>().MoveTo(target.position);
            }
            else
            {
                GetComponent<Mover>().Stop();
                AttackBehavior();
            }

        }

        private void AttackBehavior()
        {
            if (timeSinceLastAttack > timeBtwAttacks)
            {
                GetComponent<Animator>().SetTrigger("attack");
                timeSinceLastAttack = 0;
            }
        }

        //This is an animation event
        void Hit()
        {
            Health healthComponent = target.GetComponent<Health>();
            healthComponent.TakeDamage(weaponDamage);
        }

        private bool GetIsInRange()
        {
           return Vector3.Distance(transform.position, target.position) < weaponRange;
        }

        public bool CanAttack(CombatTarget combatTarget)
        {
            if (combatTarget == null) { return false; }

            else { return true; }
        }

        public void Attack(CombatTarget combatTarget)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            target = combatTarget.transform;
            print("Hoyah!");
        }
        
        public void Cancel()
        {
            target = null;
        }
    }
}