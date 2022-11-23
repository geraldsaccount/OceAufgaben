// Author: gérald
// Date: 23.11.2022

using System;
using System.Collections.Generic;

namespace OceAufgaben.DelegatesOce {
    public class DelegatesOce {
        private readonly List<Enemy> _enemies;
        private readonly List<Unit> _party;

        public DelegatesOce() {
            _party = new List<Unit> {
                new Unit(this, "Harald der Tapfere"), 
                new Unit(this, "Brunhilde die Mutige"), 
                new Unit(this, "Tristan der Gutmütige")
            };
            _enemies = new List<Enemy> {
                new Enemy(this, "Schmorp der Eklige"), 
                new Enemy(this, "Zoinks der Wilde"), 
                new Enemy(this, "Ashka die Hinterlistige")
            };
        }

        public void Play() {
            GameLoop();
        }

        private void GameLoop() {
            var random = new Random();
            while (_party.Count > 0 && _enemies.Count > 0) {
                Console.Clear();

                foreach (var unit in _party) {
                    if (_enemies.Count == 0) break;
                    
                    unit.Attack(_enemies[random.Next(0, _enemies.Count)]);
                    Console.WriteLine();
                }

                foreach (var enemy in _enemies) {
                    if (_party.Count == 0) break;

                    enemy.Attack(_party[random.Next(0, _party.Count)]);
                    Console.WriteLine();
                }
                Console.ReadKey(true);
            }

            if (_party.Count == 0)
                Console.WriteLine("Unsere Helden wurden besiegt.");
            else
                Console.WriteLine("Unsere Helden haben den Kampf überstanden.");
        } 

        public void Remove(Entity entity) {
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
