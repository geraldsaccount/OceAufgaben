// Author: gérald
// Date: 23.11.2022

using System;

namespace OceAufgaben.DelegatesOce {
    public class Entity {
        public readonly string Name;
        protected int _damage;
        protected int _currentHealth;
        protected int _maxHealth;

        public DelegatesOce _gameManager;
        
        public int Damage => _damage;
        public bool IsDead { get; private set; }

        public Entity(DelegatesOce gameManager, string name) {
            _gameManager = gameManager;
            Name = name;
            IsDead = false;
        }

        public virtual void Attack(Entity other) {
            Console.WriteLine($"{Name} greift {other.Name} an.");
            other.TakeDamage(_damage);
        }

        public void TakeDamage(int damage) {
            if (_currentHealth <= 0) return;
            
            _currentHealth -= damage;
            Console.WriteLine($"{Name} nimmt {damage} Schaden.");
            if (_currentHealth <= 0) {
                Die();
                return;
            }
            Console.WriteLine($"{Name} hat noch {_currentHealth} Leben.");
        }

        private void Die() {
            Console.WriteLine($"{Name} ist gestorben.");
            _gameManager.Remove(this);
            IsDead = true;
        }
    }
}
