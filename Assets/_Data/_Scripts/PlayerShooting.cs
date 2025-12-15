using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Transform bullet;
    public LookAtMouse lookAtMouse;
    [SerializeField] protected float timeBtwShoot = 1f;
    [SerializeField] protected float nextTimeShoot;
    [SerializeField] protected bool shootInput;
    [SerializeField] protected Vector3 shootDirection;
    [SerializeField] protected Vector3 shootStartPos;
    public Vector3 ShootDirection => shootDirection;
    public Vector3 ShootStartPos => shootStartPos;

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
        Debug.Log("SHOOT");
        this.shootDirection = lookAtMouse.DirectionFromPlayer;
        this.shootStartPos = transform.position;

        Transform newBullet = Instantiate(bullet);
        newBullet.SetPositionAndRotation(transform.position, transform.rotation);
        newBullet.gameObject.SetActive(true);
    }
}
