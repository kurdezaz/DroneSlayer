using System.Collections.Generic;
using UnityEngine;

public class Spawner<T> : MonoBehaviour where T : MonoBehaviour
{
    public ObjectPool<T> _objectPool;

    public T Spawn(T prefab)
    {
        T instance = Instantiate(prefab);
        return instance;
    }

    public T GetObject(Queue<T> objects, T objectPrefab)
    {
        if (objects.Count == 0)
        {
            return Spawn(objectPrefab);
        }

        return _objectPool.GetObject();
    }
}
