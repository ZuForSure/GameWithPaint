using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float horizonInput, verticalInput;
    public float speed = 5f;
    public Rigidbody2D rigi2D;

    void Start()
    {
        // start game se tu dong add rigibody2D vao bien rigi2D
        this.rigi2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

    }

    private void FixedUpdate()
    {
        // lay input di chuyen gan vao bien horizonInput, "Horizontal" "Vertical" la mac dinh cua Unity
        // horizon la di chuyen theo truc x (1: right, -1: left), vertical la truc y (1: up, -1: down)
        // GetAxisRaw de lay so nguyen

        this.horizonInput = Input.GetAxisRaw("Horizontal");
        this.verticalInput = Input.GetAxisRaw("Vertical");

        this.Moving();
    }

    protected void Moving()
    {
        // tao 1 bien Vector2 la huong di chuyen cua player
        // duong cheo cua hinh vuong 1, la 1.4. Dung Normalize de duong cheo la 1

        Vector2 direction = new(this.horizonInput, this.verticalInput);
        direction.Normalize();

        rigi2D.MovePosition(rigi2D.position + direction * this.speed * Time.fixedDeltaTime);
    }
}
