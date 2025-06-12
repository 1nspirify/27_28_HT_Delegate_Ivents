using System;
using System.Collections.Generic;

public class Wallet
{
    public event Action<CurrencyType, int> OnCountChanged;

    private Dictionary<CurrencyType, int> _currencies = new();

    public Wallet(Dictionary<CurrencyType, int> currencies)
    {
        _currencies = currencies;
    }

    public void AddValue(CurrencyType currency, int value)
    {
        if (_currencies.ContainsKey(currency) == false || value <= 0)
            return;
        
        if (_currencies[currency] <= 0)
            _currencies[currency] = 0;

        _currencies[currency] += value;
        OnCountChanged?.Invoke(currency, _currencies[currency]);
    }

    public void RemoveValue(CurrencyType currency, int value)
    {
        if (_currencies.ContainsKey(currency) == false || value <= 0)
            return;
        _currencies[currency] -= value;
        
        if (_currencies[currency] <= 0)
            _currencies[currency] = 0;
        
        OnCountChanged?.Invoke(currency, _currencies[currency]);
    }

    public int GetValue(CurrencyType currency)
    {
        return _currencies[currency];
    }

    public enum CurrencyType
    {
        Coins,
        Crystals,
        Energy
    }
}