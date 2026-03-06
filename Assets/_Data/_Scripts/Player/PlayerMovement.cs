using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    protected float horizonInput, verticalInput;
    [SerializeField] protected float speed = 5f;
    [SerializeField] protected float dashSpeed = 5f;
    [SerializeField] protected float dashTime = .25f;
    [SerializeField] protected float dashCooldown = .75f, dashCooldownTimer, dashCounter;
    [SerializeField] protected bool isDashing = false;
    public Rigidbody2D rigi2D;

    void Start()
    {
        this.rigi2D = transform.parent.GetComponent<Rigidbody2D>();
    }

    void Update()
    {

    }

    private void FixedUpdate()
    {
        this.horizonInput = Input.GetAxisRaw("Horizontal");
        this.verticalInput = Input.GetAxisRaw("Vertical");

        this.Moving();
    }

    protected void Moving()
    {
        Vector2 direction = new(this.horizonInput, this.verticalInput);
        direction.Normalize();

        rigi2D.MovePosition(rigi2D.position + direction * this.ActiveSpeed() * Time.fixedDeltaTime);
    }

    protected virtual float ActiveSpeed()
    {
        if (Input.GetAxisRaw("Jump") >.1f && this.dashCooldownTimer <= 0f) this.StartDashing();
        if (this.dashCounter < 0 && this.isDashing) this.StopDashing();
        this.DashTimerDown();

        return this.speed;
    }

    protected virtual void StartDashing()
    {
        this.isDashing = true;
        this.speed += this.dashSpeed;
        this.dashCounter = this.dashTime;
        this.dashCooldownTimer = this.dashCooldown;
    }

    protected virtual void StopDashing()
    {
        this.isDashing = false;
        this.speed -= this.dashSpeed;
    }

    protected virtual void DashTimerDown()
    {
        if (this.dashCounter < 0f && this.dashCooldownTimer < 0f) return;
        this.dashCounter -= Time.fixedDeltaTime;
        this.dashCooldownTimer -= Time.fixedDeltaTime;
    }
}
