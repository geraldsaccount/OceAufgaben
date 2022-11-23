// Author: gérald
// Date: 23.11.2022

using System;

namespace OceAufgaben.DelegatesOce {
    public class Undead : Enemy {
        private int _deathCount;
        private readonly int _liveCount;
        
        public Undead(string name, Action<Entity> unregisterAction, int liveCount) : base(name, unregisterAction) {
            _liveCount = liveCount;
            _checkDeath = HandleDeath;
        }

        private bool HandleDeath() {
            if (_currentHealth > 0) {
                return false;
            }

            if (_deathCount < _liveCount) {
                _currentHealth = _maxHealth;
                _deathCount++;
                
                Console.WriteLine($"{Name} ist gestorben, aber wieder auferstanden.");
                return false;
            }

            return true;
        }
    }
}
