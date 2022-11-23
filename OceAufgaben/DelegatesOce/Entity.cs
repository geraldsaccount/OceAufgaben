// Author: gérald
// Date: 23.11.2022

using System;

namespace OceAufgaben.DelegatesOce {
    public class Entity {
        public readonly string Name;
        protected int _damage;
        protected int _speed;
        protected int _currentHealth;
        protected int _maxHealth;

        private readonly Action<Entity> _onDeath;
        private Action _deathCallback;
        protected Func<bool> _checkDeath;

        public int Damage => _damage;

        public Entity(string name, Action<Entity> unregisterAction) {
            _onDeath = unregisterAction;
            Name = name;
            _checkDeath = IsDead;
        }

        public virtual void Attack(Entity other) {
            Console.WriteLine($"{Name} greift {other.Name} an.");
            other.TakeDamage(_damage, null);
        }

        public void TakeDamage(int damage, Action deathCallback) {
            if (_checkDeath.Invoke()) return;

            _deathCallback += deathCallback;
            _currentHealth -= damage;
            Console.WriteLine($"{Name} nimmt {damage} Schaden.");
            if (_checkDeath.Invoke()) {
                Die();
                _deathCallback?.Invoke();
                return;
            }
            Console.WriteLine($"{Name} hat noch {_currentHealth} Leben.");
        }

        private void Die() {
            Console.WriteLine($"{Name} ist gestorben.");
            _onDeath?.Invoke(this);
        }

        private bool IsDead() {
            return _currentHealth <= 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>1 if lhs is higher, -1 if rhs is higher, 0 if both are equal</returns>
        public static int HighestSpeed(Entity lhs, Entity rhs) {
            if (lhs == null) {
                if (rhs == null) {
                    return 0;
                } else {
                    return 1;
                }
            } else {
                if (rhs == null) {
                    return -1;
                } else {
                    if (lhs._speed > rhs._speed) {
                        return -1;
                    } else if (lhs._speed == rhs._speed) {
                        return 0;
                    } else {
                        return 1;
                    }
                }
            }
        }

        public static int HighestRelativeHealth(Entity lhs, Entity rhs) {
            if (lhs == null) {
                if (rhs == null) {
                    return 0;
                } else {
                    return 1;
                }
            } else {
                if (rhs == null) {
                    return -1;
                } else {
                    float lhsRelativeHealth = (float)lhs._currentHealth / lhs._maxHealth;
                    float rhsRelativeHealth = (float)rhs._currentHealth / rhs._maxHealth;
                    if (lhsRelativeHealth > rhsRelativeHealth) {
                        return -1;
                    } else if (lhsRelativeHealth == rhsRelativeHealth) {
                        return 0;
                    } else {
                        return 1;
                    }
                }
            }
        }
        
        public static int HighestHealth(Entity lhs, Entity rhs) {
            if (lhs == null) {
                if (rhs == null) {
                    return 0;
                } else {
                    return 1;
                }
            } else {
                if (rhs == null) {
                    return -1;
                } else {
                    if (lhs._currentHealth > rhs._currentHealth) {
                        return -1;
                    } else if (lhs._currentHealth == rhs._currentHealth) {
                        return 0;
                    } else {
                        return 1;
                    }
                }
            }
        }
    }
}
