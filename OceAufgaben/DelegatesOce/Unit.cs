// Author: gérald
// Date: 23.11.2022

using System;
using System.ComponentModel;

namespace OceAufgaben.DelegatesOce {
    public class Unit : Entity {
        private int _level;
        
        public Unit(DelegatesOce gameManager, string name) : base(gameManager, name) {
            var random = new Random();
            _maxHealth = random.Next(30, 100);
            _currentHealth = _maxHealth;
            _damage = random.Next(5, 20);
            _level = 1;
        }

        public override void Attack(Entity other) {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{Name} greift {other.Name} an.");
            other.TakeDamage(_damage + _level);
        }
    }
}
