using UnityEngine;
using static UnityEditor.PlayerSettings;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] protected GameObject bullet;
    [SerializeField] protected LookAtMouse lookAtMouse;
    [SerializeField] protected float timeBtwShoot = 1f;
    protected Vector3 shootStartPos;
    protected Vector3 shootDirection;
    private float nextTimeShoot;

    public Vector3 ShootDirection => shootDirection;

    void Start()
    {
        this.lookAtMouse = GetComponent<LookAtMouse>();
    }

    void Update()
    {
        this.Shooting();
    }

    protected void Shooting()
    {
        if (Input.GetMouseButtonDown(0))
        {
            this.TryShoot();
        }
    }

    protected void TryShoot()
    {
        if (Time.time < this.nextTimeShoot) return;

        this.nextTimeShoot = Time.time + timeBtwShoot;
        this.Shoot();
    }

    protected void Shoot()
    {
        this.shootDirection = lookAtMouse.DirectionFromPlayer;
        this.shootStartPos = transform.position;

        GameObject bullet = PoolManager.Instance.Spawn(this.bullet, shootStartPos, transform.rotation);
        bullet.GetComponent<Bullet>().prefab = this.bullet;
    }
}
