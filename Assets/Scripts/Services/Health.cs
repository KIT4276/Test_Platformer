using Platformer.Player;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Service
{
    public class Health  : IService
    {
        public float MaxHealth { get; private set; }
        public float CurrentHealth { get; private set; }

        public event Action ChangeHealthE;


        public Health()
        {
            MaxHealth = 100; // перенести в статы
            CurrentHealth = MaxHealth;
        }
    }
}
