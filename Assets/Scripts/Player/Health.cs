using Platformer.Player;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class Health 
    {
        public float MaxHealth { get; private set; }
        public float CurrentHealth { get; private set; }

        public event Action ChangeHealthE;

        internal void Fall()
        {
            CurrentHealth = 0;
            ChangeHealthE?.Invoke();
        }
    }
}
