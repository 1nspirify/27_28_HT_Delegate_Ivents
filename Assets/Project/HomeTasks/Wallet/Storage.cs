using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Storage : MonoBehaviour
{
    private StorageType _storageType;
    [SerializeField] private List<Container> _containers;
    [SerializeField] private ContainersView _containersView;

    private void Awake()
    {
        if (_containersView)
            _containersView.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _storageType = StorageType.Coins;
            Debug.LogWarning("Coins Storage has been chosen");
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _storageType = StorageType.Energy;
            Debug.LogWarning("Energy Storage has been chosen");
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _storageType = StorageType.Crystals;
            Debug.LogWarning("Crystals Storage has been chosen");
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            ApplyToStorage(_storageType, (container, amount) => container.Increase(amount));
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            ApplyToStorage(_storageType, (container, amount) => container.Decrease(amount));
        }
    }

    private void ApplyToStorage(StorageType type, Action<Container, int> action)
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

    private void OnDisable()
    {
        if (_containersView)
            _containersView.gameObject.SetActive(false);
    }
}