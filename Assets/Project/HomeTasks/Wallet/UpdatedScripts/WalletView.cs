using TMPro;
using UnityEngine;

public class WalletView : MonoBehaviour
{
    private Wallet _wallet;

    [SerializeField] TMP_Text _coins;
    [SerializeField] TMP_Text _energy;
    [SerializeField] TMP_Text _crystals;

    public void Initialize(Wallet wallet)
    {
        _wallet = wallet;

        _coins.text = wallet.GetValue(Wallet.CurrencyType.Coins).ToString();
        _energy.text = wallet.GetValue(Wallet.CurrencyType.Energy).ToString();
        _crystals.text = wallet.GetValue(Wallet.CurrencyType.Crystals).ToString();

         _wallet.GetReactive(Wallet.CurrencyType.Coins).Changed += OnCoinsChanged;
        _wallet.GetReactive(Wallet.CurrencyType.Energy).Changed += OnEnergyChanged;
        _wallet.GetReactive(Wallet.CurrencyType.Crystals).Changed += OnCrystalsChanged;
    }

    private void OnCoinsChanged(int oldValue, int newValue)
    {
        _coins.text = newValue.ToString();
    }

    private void OnEnergyChanged(int oldValue, int newValue)
    {
        _energy.text = newValue.ToString();
    }

    private void OnCrystalsChanged(int oldValue, int newValue)
    {
        _crystals.text = newValue.ToString();
    }

    private void OnDestroy()
    {
        _wallet.GetReactive(Wallet.CurrencyType.Coins).Changed -= OnCoinsChanged;
        _wallet.GetReactive(Wallet.CurrencyType.Energy).Changed -= OnEnergyChanged;
        _wallet.GetReactive(Wallet.CurrencyType.Crystals).Changed -= OnCrystalsChanged;
        
        gameObject.SetActive(false);
    }
}