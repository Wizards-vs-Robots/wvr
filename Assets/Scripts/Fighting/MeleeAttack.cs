﻿using System;
using Pathfinding;
using UnityEngine;

namespace Fighting
{
    public class MeleeAttack : Attack
    {
        /// <summary>
        /// damage is used for the attack
        /// </summary>
        public Damage damage;
        
        public float animationDuration = 0.5f;

        private AIPath _path;
        private float _animationStart;
        
        public override void Perform(Damagable target, GameObject by)
        {
            target.ReceiveDamage(damage);
            _animationStart = Time.time;
            _path.canMove = false;
        }

        private void Start()
        {
            _path = this.GetComponent<AIPath>();
        }

        public void Update()
        {
            // Do animation
            if (Time.time > _animationStart + animationDuration)
            {
                _path.canMove = true; 
            }
        }
    }
}