using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] protected float horizonInput, verticalInput;
    [SerializeField] protected float speed = 5f;
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

        rigi2D.MovePosition(rigi2D.position + direction * this.speed * Time.fixedDeltaTime);
    }
}
