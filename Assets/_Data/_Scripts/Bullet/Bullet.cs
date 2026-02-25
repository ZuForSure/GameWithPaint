using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IPoolable
{
    [HideInInspector]
    public GameObject prefab;

    public Rigidbody2D bulletRB;
    [SerializeField] protected BulletFly bulletFly;
    [SerializeField] protected float flySpeed = 10f;
    public Vector2 flyDirection = Vector2.right;
    public float FlySpeed => flySpeed;

    void Awake()
    {
        bulletRB = GetComponent<Rigidbody2D>();
        bulletFly = GetComponentInChildren<BulletFly>();
    }

    public void OnDeSpawn()
    {
        bulletRB.velocity = Vector2.zero;
        Debug.Log("OnDeSpawn");
    }

    public void OnSpawn()
    {
        this.bulletFly.GetDictionForFlying();
        Debug.Log("OnSpawn");
    }

    void OnBecameInvisible()
    {
        PoolManager.Instance.DeSpawn(prefab, gameObject);
    }
}
