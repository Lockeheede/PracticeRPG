using System.Runtime.InteropServices;
using System;
using UnityEngine;

namespace PracticeRPG.Combat
{
    public class Health : MonoBehaviour
    {
        [SerializeField] float health = 100f;

        public void TakeDamage(float damage)
        {
            health = Mathf.Max(health - damage, 0);//A math function that takes either the health minus damage or 0 so it won't go below 0
            print(health);
        }
    }
}
