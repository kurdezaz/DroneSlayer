using System;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    [SerializeField] private Button _button;

    public event Action ButtonClicked;

    private void OnEnable()
    {
        _button.onClick.AddListener(ClickOnEffect);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(ClickOnEffect);
    }

    private void ClickOnEffect()
    {
        ButtonClicked?.Invoke();
    }
}