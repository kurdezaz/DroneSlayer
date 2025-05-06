using System.Collections.Generic;
using UnityEngine;

namespace DroneSlayer.Pools
{
    public class ObjectPool<T> : MonoBehaviour where T : MonoBehaviour
    {
        private Queue<T> _objects;

        private void Awake()
        {
            _objects = new Queue<T>();
        }

        public T GetObject()
        {
            return _objects.Dequeue();
        }

        public void PutObject(T objectPrefab)
        {
            _objects.Enqueue(objectPrefab);
        }

        public void FillEnemyData(T[] enemies)
        {
            _objects.Clear();

            for (int i = 0; i < enemies.Length; i++)
            {
                T enemy = Instantiate(enemies[i]);
                enemy.gameObject.SetActive(false);
                _objects.Enqueue(enemy);
            }
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