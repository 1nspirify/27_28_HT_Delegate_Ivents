using UnityEngine;

namespace EnemySerialize
{
    public class Samurai : Enemy
    {
        private int _health;
        private int _agility;
        private int _stamina;

        public void Initialize(SamuraiConfig config)
        {
            _health = config.Health;
            _agility = config.Agility;
            _stamina = config.Stamina;
        }
    }
}