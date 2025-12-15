using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : MonoBehaviour
{
    public PlayerShooting playerShooting;
    [SerializeField] protected Rigidbody2D bulletRB;
    [SerializeField] protected float flySpeed = 10f;
    [SerializeField] protected Vector2 flyDirection = Vector2.right;

    void Start()
    {
        this.bulletRB = transform.parent.GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        this.flyDirection = playerShooting.ShootDirection;
        this.Flying();
    }

    protected void Flying()
    {
        this.bulletRB.velocity = this.flySpeed * this.flyDirection;
    }
}
