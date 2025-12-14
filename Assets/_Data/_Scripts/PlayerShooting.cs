using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Transform bullet;
    [SerializeField] protected float timeBtwShoot = 1f;
    [SerializeField] protected float nextTimeShoot;
    [SerializeField] protected bool shootInput;

    void Start()
    {
        
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

        Transform newBullet = Instantiate(bullet);
        newBullet.transform.position = transform.position;
        newBullet.gameObject.SetActive(true);
    }
}
