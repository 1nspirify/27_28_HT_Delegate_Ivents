using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Storage 
{
    private CurrencyType _currencyType;
    [SerializeField] private List<Container> _containers;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _currencyType = CurrencyType.Coins;
            Debug.LogWarning("Coins Storage has been chosen");
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _currencyType = CurrencyType.Energy;
            Debug.LogWarning("Energy Storage has been chosen");
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _currencyType = CurrencyType.Crystals;
            Debug.LogWarning("Crystals Storage has been chosen");
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            ApplyToStorage(_currencyType, (container, amount) => container.Increase(amount));
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            ApplyToStorage(_currencyType, (container, amount) => container.Decrease(amount));
        }
    }

    private void ApplyToStorage(CurrencyType type, Action<Container, int> action)
    {
        int amount = Random.Range(0, 11);
        foreach (Container container in _containers)
        {
            if (container.Type == type)
            {
                action?.Invoke(container, amount);
            }
        }
    }
}