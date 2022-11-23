// Author: gérald
// Date: 23.11.2022

using System;
using System.ComponentModel;

namespace OceAufgaben.DelegatesOce {
    public class Unit : Entity {
        private int _level;
        
        public Unit(string name, Action<Entity> unregisterAction) : base(name, unregisterAction) {
            var random = new Random();
            _maxHealth = random.Next(30, 100);
            _speed = random.Next(0, 100);
            _currentHealth = _maxHealth;
            _damage = random.Next(5, 20);
            _level = 1;
        }

        public override void Attack(Entity other) {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{Name} greift {other.Name} an.");
            other.TakeDamage(_damage + _level, LevelUp);
        }

        private void LevelUp() {
            _level++;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{Name} ist aufgelevelt!");
        }
    }
}
