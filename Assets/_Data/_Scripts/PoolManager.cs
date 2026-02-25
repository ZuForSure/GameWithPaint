using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.Pool;

public class PoolManager : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public GameObject prefab;
        public int size;
    }

    public static PoolManager Instance;

    [SerializeField] protected Pool[] pools;
    private Dictionary<GameObject, Queue<GameObject>> poolDict;

    private void Awake()
    {
        Instance = this;
        poolDict = new Dictionary<GameObject, Queue<GameObject>>();

        foreach (var pool in pools)
        {
            Queue<GameObject> poolQueue = new();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab, transform);
                obj.SetActive(false);
                poolQueue.Enqueue(obj);
            }

            poolDict.Add(pool.prefab, poolQueue);
        }
    }

    public GameObject Spawn(GameObject prefab, Vector3 pos, Quaternion rot)
    {
        if (!poolDict.ContainsKey(prefab))
        {
            Debug.LogError("Pool not exits: " + prefab.name);
            return null;
        }

        GameObject obj = poolDict[prefab].Dequeue();
        obj.transform.SetPositionAndRotation(pos, rot);
        obj.SetActive(true);

        if (obj.TryGetComponent(out IPoolable poolable))
            poolable.OnSpawn();

        return obj;
    }

    public void DeSpawn(GameObject prefab, GameObject obj)
    {
        if (obj.TryGetComponent(out IPoolable poolable))
            poolable.OnDeSpawn();

        obj.SetActive(false);
        poolDict[prefab].Enqueue(obj);
    }
}
