using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyType Type { get; private set; }

    public void Initialize(EnemyType type)
    {
        Type = type;
    }
}