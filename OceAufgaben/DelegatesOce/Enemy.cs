// Author: gérald
// Date: 23.11.2022

using System;

namespace OceAufgaben.DelegatesOce {
    public class Enemy : Entity {
        public Enemy(DelegatesOce gameManager, string name) : base(gameManager, name) {
            var random = new Random();
            _maxHealth = random.Next(30, 100);
            _currentHealth = _maxHealth;
            _damage = random.Next(5, 20);
        }

        public override void Attack(Entity other) {
            Console.ForegroundColor = ConsoleColor.Red;
            base.Attack(other);
        }
    }
}
