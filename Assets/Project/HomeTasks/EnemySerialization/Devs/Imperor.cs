using System.Collections;
using System.Collections.Generic;

namespace EnemySerialize
{
    public class Imperor : Enemy
    {
        private int _health;
        private int _agility;
        private int _stamina;
        
        public void Initialize(ImperorConfig config)
        {
            _health = config.Health;
            _agility = config.Stamina;
            _stamina = config.Stamina;
        }
    }
} 