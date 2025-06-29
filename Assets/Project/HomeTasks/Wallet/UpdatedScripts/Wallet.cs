using System;
using System.Collections.Generic;

public class Wallet
{
    private Dictionary<CurrencyType, ReactiveVariable<int>> _currencies = new();

    public Wallet(Dictionary<CurrencyType, int> currencies)
    {
        foreach (KeyValuePair<CurrencyType, int> currencyPair in currencies)
        {
            ReactiveVariable<int> reactiveValue = new ReactiveVariable<int>(currencyPair.Value);
            _currencies.Add(currencyPair.Key, reactiveValue);
        }
    }

    public void AddValue(CurrencyType currency, int value)
    {
        if (_currencies.ContainsKey(currency) == false || value <= 0)
            return;

        _currencies[currency].Value += value;
    }

    public void RemoveValue(CurrencyType currency, int value)
    {
        if (_currencies.ContainsKey(currency) == false || value <= 0)
            return;
        
        _currencies[currency].Value -= value;
        
    }

    public int GetValue(CurrencyType currency)
    {
        return _currencies[currency].Value;
    }
    
    public ReactiveVariable<int> GetReactive(CurrencyType currency)
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