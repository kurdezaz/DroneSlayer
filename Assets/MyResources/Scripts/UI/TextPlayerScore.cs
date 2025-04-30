using TMPro;
using UnityEngine;

public class TextPlayerScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textPlayerScorePoints;
    [SerializeField] private PlayerScore _playerScore;

    private void OnEnable()
    {
        _playerScore.ScoreChanged += DisplayValue;
        DisplayValue();
    }

    private void OnDisable()
    {
        _playerScore.ScoreChanged -= DisplayValue;
    }

    private void DisplayValue()
    {
        _textPlayerScorePoints.text = _playerScore.Score.ToString();
    }
}
