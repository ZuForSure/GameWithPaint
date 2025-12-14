using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Transform bullet;
    [SerializeField] protected float timeBtwShoot = 1f;
    [SerializeField] protected float timer;
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
            StartCoroutine(this.Shoot());
        }

        if (Input.GetMouseButtonUp(0))
        {
            StopCoroutine(this.Shoot());
        }
    }

    protected IEnumerator Shoot()
    {
        Debug.Log("SHOOT");

        Transform newBullet = Instantiate(bullet);
        newBullet.transform.position = transform.position;
        newBullet.gameObject.SetActive(true);

        yield return new WaitForSeconds(this.timeBtwShoot);
    }
}
