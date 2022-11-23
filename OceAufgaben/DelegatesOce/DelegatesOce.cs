// Author: gérald
// Date: 23.11.2022

using System;
using System.Collections.Generic;

namespace OceAufgaben.DelegatesOce {
    public class DelegatesOce {
        private readonly List<Enemy> _enemies;
        private readonly List<Unit> _party;
        private List<Entity> _attackOrder;
        private readonly List<Entity> _toRemove = new();

        public DelegatesOce() {
            _party = new List<Unit> {
                new("Harald der Tapfere", Remove),
                new("Brunhilde die Mutige", Remove),
                new("Tristan der Gutmütige", Remove)
            };

            _enemies = new List<Enemy> {
                new("Schmorp der Eklige", Remove),
                new Undead("Zoinks der Wilde", Remove, 1),
                new("Ashka die Hinterlistige", Remove)
            };
        }

        public void Play() {
            GameLoop();
        }

        private void GameLoop() {
            var random = new Random();
            _attackOrder = new List<Entity>(_party);
            _attackOrder.AddRange(_enemies);
            _attackOrder.Sort(Entity.HighestSpeed);

            while (_party.Count > 0 && _enemies.Count > 0) {
                Console.Clear();

                foreach (var entity in _attackOrder) {
                    if (_enemies.Count == 0 || _party.Count == 0) break;

                    if (_toRemove.Contains(entity)) continue;

                    switch (entity) {
                        case Enemy enemy:
                            enemy.Attack(_party[random.Next(0, _party.Count)]);

                            break;
                        case Unit unit:
                            List<Enemy> enemyCopy = new List<Enemy>(_enemies);
                            enemyCopy.Sort(Entity.HighestHealth);
                            unit.Attack(enemyCopy[0]);

                            break;
                        default:
                            throw new ArgumentOutOfRangeException(nameof(entity));
                    }

                    Console.WriteLine();
                }

                foreach (var entity in _toRemove) _attackOrder.Remove(entity);
                _toRemove.Clear();

                Console.ReadKey(true);
            }

            if (_party.Count == 0)
                Console.WriteLine("Unsere Helden wurden besiegt.");
            else
                Console.WriteLine("Unsere Helden haben den Kampf überstanden.");
        }

        private void Remove(Entity entity) {
            if (_attackOrder.Contains(entity)) _toRemove.Add(entity);

            switch (entity) {
                case Enemy enemy:
                    if (_enemies.Contains(enemy))
                        _enemies.Remove(enemy);

                    break;
                case Unit unit:
                    if (_party.Contains(unit))
                        _party.Remove(unit);

                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(entity));
            }
        }
    }
}
