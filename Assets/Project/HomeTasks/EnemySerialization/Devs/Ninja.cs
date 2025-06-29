using UnityEngine;

namespace EnemySerialize
{
    public class Ninja : Enemy
    {
        private int _health; 
        private int _agility;
        private int _stamina;
        
        public  void Initialize(NinjaConfig config)
        {
            _health = config.Health;
            _agility = config.Agility;
            _stamina = config.Stamina;
        }
    }
}