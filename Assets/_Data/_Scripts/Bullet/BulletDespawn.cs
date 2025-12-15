using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDespawn : MonoBehaviour
{
    public PlayerShooting playerShooting;
    [SerializeField] float maxDistance = 20f;

    void Update()
    {
        this.DespawnByDistance();
    }

    protected void DespawnByDistance()
    {
        float distance = Vector3.Distance(playerShooting.ShootDirection, transform.position);
        if (distance < maxDistance) return;
        Destroy(transform.parent.gameObject);
    }
}
