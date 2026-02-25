using UnityEngine;

public class BulletDespawn : BulletAbstract
{
    [Header("Bullet Despawn")]
    [SerializeField] float maxDistance = 20f;

    void Update()
    {
        this.DespawnByDistance();
    }

    protected void DespawnByDistance()
    {
        float distance = Vector3.Distance(this.player.PlayerShooting.ShootDirection, transform.position);
        if (distance < maxDistance) return;
        //Destroy(transform.parent.gameObject);
    }
}
