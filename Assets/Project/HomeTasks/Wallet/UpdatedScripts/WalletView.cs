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

        _wallet.OnCountChanged += OnCountChanged;
    }

    private void OnCountChanged(Wallet.CurrencyType type, int value)
    {
        switch (type)
        {
            case Wallet.CurrencyType.Coins:
                _coins.text = value.ToString();
                break;
            case Wallet.CurrencyType.Energy:
                _energy.text = value.ToString();
                break;
            case Wallet.CurrencyType.Crystals:
                _crystals.text = value.ToString();
                break;
        }
    }

    private void OnDestroy()
    {
        _wallet.OnCountChanged -= OnCountChanged;
        gameObject.SetActive(false);
    }
}