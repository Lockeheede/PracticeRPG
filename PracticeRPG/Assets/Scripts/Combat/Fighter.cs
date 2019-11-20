using UnityEngine;
using PracticeRPG.Movement;

namespace PracticeRPG.Combat
{
    public class Fighter : MonoBehaviour 
    {
        [SerializeField] float weaponRange = 2f;
        Transform target;

        private void Update() 
        {
            print(Vector3.Distance(transform.position, target.position) < weaponRange);
            /*if(target != null)
            {
                GetComponent<Mover>().MoveTo(target.position);
            }
            else
            {
                GetComponent<Mover>().Stop();
            }*/
            
        }
        public void Attack(CombatTarget combatTarget)
        {
            target = combatTarget.transform;
            print("HiYAHHHH!!!");
        }
        public void Cancel()
        {
            target = null;
        }
    }
}