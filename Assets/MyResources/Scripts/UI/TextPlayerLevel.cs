using UnityEngine;
using TMPro;

public class TextPlayerLevel : BarView
{
    [SerializeField] private TextMeshProUGUI _textPlayerLevel;

    private void Start()
    {
        DisplayValue();
    }

    public override void DisplayValue()
    {
        _textPlayerLevel.text = _playerExpirience.PlayerLevel.ToString();
    }
}
