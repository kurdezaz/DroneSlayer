using DroneSlayer.EnemyEntity;
using UnityEngine;

namespace DroneSlayer.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New array", menuName = "Drone Data/Create New Array")]
    public class DroneArray : ScriptableObject
    {
        [SerializeField] private Enemy[] _enemies;

        public Enemy[] Enemies => _enemies;
    }
}