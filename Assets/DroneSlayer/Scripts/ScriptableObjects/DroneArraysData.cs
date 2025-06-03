using UnityEngine;

namespace DroneSlayer.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New array data", menuName = "Drone Data/Create New ArrayData")]
    public class DroneArraysData : ScriptableObject
    {
        [SerializeField] private DroneArray[] _droneArrays;

        public DroneArray[] DroneArrays => _droneArrays;
    }
}