using UnityEngine;

namespace EnemySerialize

{
    public class ImperorConfig : EnemyConfig
    {
        [field: SerializeField] public int Health { get; private set; }
        [field: SerializeField] public int Stamina { get; private set; }
        [field: SerializeField] public int Agility { get; private set; }
    }
}