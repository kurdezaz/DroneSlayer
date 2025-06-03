using System.Collections.Generic;
using UnityEngine;

namespace DroneSlayer.Pools
{
    public class ObjectPool<T>
        where T : MonoBehaviour
    {
        private Queue<T> _objects;
        private T _prefab;

        public ObjectPool(T prefab)
        {
            _prefab = prefab;
            _objects = new Queue<T>();
        }

        public T Prefab => _prefab;

        public T GetObject()
        {
            if (_objects.Count != 0)
            {
                return _objects.Dequeue();
            }

            return Object.Instantiate(_prefab);
        }

        public void PutObject(T objectPrefab)
        {
            _objects.Enqueue(objectPrefab);
        }

        public T GetPrefab()
        {
            return _prefab;
        }

        public void InitQueue()
        {
            _objects = new Queue<T>();
        }

        public Queue<T> ReturnQueue()
        {
            return _objects;
        }
    }
}