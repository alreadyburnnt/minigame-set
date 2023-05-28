using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballBounce : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 1000f;
    public float xDir = 1f, yDir = 0.1f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        Vector2 dir = new Vector2(xDir, yDir).normalized;
        rb.AddForce(dir * speed);
    }
}
