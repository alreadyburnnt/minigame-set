using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class move : MonoBehaviour
{
    public int move_method;
    public float speed;
    public Vector2 speed_vec;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (move_method == 0)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                speed_vec.x = speed;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                speed_vec.x = -speed;
            }
            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                speed_vec.x = 0;
            }
            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                speed_vec.x = 0;
            }

            GetComponent<Rigidbody2D>().velocity = speed_vec;
        }
        else if (move_method == 1)
        {
            speed_vec.x = Input.GetAxis("Horizontal") * speed;
            transform.Translate(speed_vec);
        }
    }
}
    

           /* if (Input.GetKey(KeyCode.RightArrow))
            {
                speed_vec.x += speed;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                speed_vec.x -= speed;
            }

           GetComponent<Ridgidbody2D>().velocity = speed_vec;*/
            
    
