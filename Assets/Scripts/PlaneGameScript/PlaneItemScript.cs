using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneItemScript : MonoBehaviour
{
    public int itemNum;
    Rigidbody2D rb;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -3f);
    }

    void Update(){
        if(transform.position.y < -6f) Destroy(gameObject);
    }
}
