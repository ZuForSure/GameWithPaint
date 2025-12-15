using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : MonoBehaviour
{
    public Player player;
    [SerializeField] protected Rigidbody2D bulletRB;
    [SerializeField] protected float flySpeed = 10f;
    [SerializeField] protected Vector2 flyDirection = Vector2.right;

    private void Reset()
    {
        if (this.player != null) return;
        this.player = GameObject.Find("Player").GetComponent<Player>();
    }

    void Start()
    {
        this.bulletRB = transform.parent.GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        this.flyDirection = this.player.PlayerShooting.ShootDirection;
        this.Flying();
    }

    protected void Flying()
    {
        this.bulletRB.velocity = this.flySpeed * this.flyDirection;
    }
}
