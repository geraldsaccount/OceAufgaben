// Author: gérald
// Date: 23.11.2022

using System;

namespace OceAufgaben.DelegatesOce {
    public class Enemy : Entity {
        public Enemy(string name, Action<Entity> unregisterAction) : base(name, unregisterAction) {
            var random = new Random();
            _maxHealth = random.Next(30, 100);
            _speed = random.Next(0, 100);
            _currentHealth = _maxHealth;
            _damage = random.Next(5, 20);
        }

        public override void Attack(Entity other) {
            Console.ForegroundColor = ConsoleColor.Red;
            base.Attack(other);
        }
    }
}
