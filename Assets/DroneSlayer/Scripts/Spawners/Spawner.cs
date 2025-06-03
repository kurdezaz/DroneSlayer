using System.Collections.Generic;
using DroneSlayer.Pools;
using UnityEngine;

namespace DroneSlayer.Spawners
{
    public class Spawner<T> : MonoBehaviour
        where T : MonoBehaviour
    {
        [SerializeField] protected List<T> _prefabArray;

        protected List<ObjectPool<T>> _objectPool = new List<ObjectPool<T>>();

        public void Init(T prefab)
        {
            _objectPool.Add(new ObjectPool<T>(prefab));
        }

        protected T GetObject(T enemy)
        {
            for (int i = 0; i < _objectPool.Count; i++)
            {
                if (_objectPool[i].GetPrefab() == enemy)
                {
                    return _objectPool[i].GetObject();
                }
            }

            return null;
        }
    }
}