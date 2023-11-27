using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarMoveScript : MonoBehaviour
{
    public int move_method;
    public float speed;
    private Rigidbody2D rb;
    private Vector2 barVelocity = new Vector2(4, 0);

    void Start(){
        rb = gameObject.GetComponent<Rigidbody2D>();
        Debug.Log(rb.IsAwake());
    }

    void Update()
    {

        if (move_method == 0)
        {
            if(Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.LeftArrow));
            else if(Input.GetKey(KeyCode.RightArrow)) rb.velocity = barVelocity;
            else if(Input.GetKey(KeyCode.LeftArrow)) rb.velocity = -barVelocity;
        }
        else if (move_method == 1)
        {
            if(Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.A));
            else if(Input.GetKey(KeyCode.D)) rb.velocity = barVelocity;
            else if(Input.GetKey(KeyCode.A)) rb.velocity = -barVelocity;
        }
    }
}