using TMPro;
using UnityEngine;

public abstract class MoneyView : MonoBehaviour
{
    [SerializeField] protected Wallet _playerMoney;
    [SerializeField] protected TextMeshProUGUI _textMoney;

    private void OnEnable()
    {
        _playerMoney.MoneyChanged += DisplayValue;
        DisplayValue();
    }

    private void OnDisable()
    {
        _playerMoney.MoneyChanged -= DisplayValue;
    }

    public abstract void DisplayValue();
}
