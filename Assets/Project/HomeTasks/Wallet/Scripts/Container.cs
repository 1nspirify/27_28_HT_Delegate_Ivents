using System;
using UnityEngine;

public class Container : MonoBehaviour
{
    public event Action OnCountChanged;
    private int _count;
    public int Count => _count; 
    
    [SerializeField] private CurrencyType _type;
    public CurrencyType Type => _type;

    public void Increase(int amount)
    {
        _count += amount;

        Debug.Log($"Storage {Type} Increased {_count}");
        OnCountChanged?.Invoke();
    }

    public void Decrease(int amount)
    {
        _count -= amount;

        if (_count <= 0)
            _count = 0;

        Debug.Log($"Storage {Type} Decreased {_count}");
        OnCountChanged?.Invoke();
    }
}