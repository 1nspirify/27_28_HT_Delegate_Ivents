using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WalletExample : MonoBehaviour
{
    private Wallet.CurrencyType _selectedCurrency;
    private Wallet _wallet;
    [SerializeField] WalletView _walletView;

    private void Awake()
    {
        _wallet = new Wallet(new Dictionary<Wallet.CurrencyType, int>()
        {
            { Wallet.CurrencyType.Coins, 0 },
            { Wallet.CurrencyType.Energy, 0 },
            { Wallet.CurrencyType.Crystals, 0 }
        });
        
        _walletView.gameObject.SetActive(true);
    }

    private void Start()
    {
        _walletView.Initialize(_wallet);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _selectedCurrency = Wallet.CurrencyType.Coins;
            Debug.LogWarning("Coins selected");
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _selectedCurrency = Wallet.CurrencyType.Energy;
            Debug.LogWarning("Energy selected");
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _selectedCurrency = Wallet.CurrencyType.Crystals;
            Debug.LogWarning("Crystals selected");
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            int amount = Random.Range(1, 11);
            _wallet.AddValue(_selectedCurrency, amount);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            int amount = Random.Range(1, 11);
            _wallet.RemoveValue(_selectedCurrency, amount);
        }
    }
}