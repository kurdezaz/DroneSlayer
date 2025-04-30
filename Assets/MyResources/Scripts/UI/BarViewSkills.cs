using UnityEngine;

public abstract class BarViewSkills : MonoBehaviour
{
    [SerializeField] protected Player _player;

    private void OnEnable()
    {
        _player.SkillPointsChanged += DisplayValue;
        Init();
    }

    private void OnDisable()
    {
        _player.SkillPointsChanged -= DisplayValue;
    }

    public abstract void DisplayValue();

    public abstract void Init();
}
