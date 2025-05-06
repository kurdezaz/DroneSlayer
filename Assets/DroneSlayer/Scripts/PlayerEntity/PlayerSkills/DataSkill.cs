using UnityEngine;

namespace DroneSlayer.PlayerEntity.PlayerSkill
{
    public class DataSkill : MonoBehaviour
    {
        [SerializeField] private int _level;
        [SerializeField] private float[] _values;
        [SerializeField] private Stats _names;

        public int Level => _level;
        public float[] Values => _values;
        public Stats Names => _names;

        public void UpgradeLevel()
        {
            _level++;
        }

        public void ResetLevel()
        {
            _level = 0;
        }

        public void LoadLevel(int level)
        {
            _level = level;
        }
    }
}