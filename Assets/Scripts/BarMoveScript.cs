using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarMoveScript : MonoBehaviour
{
    public int move_method;
    public float speed;
    public Vector2 speed_vec;

    void Update()
    {
        if (move_method == 0)
        {
            if (Input.GetKey(KeyCode.RightArrow)) speed_vec.x = speed;
            if (Input.GetKey(KeyCode.LeftArrow)) speed_vec.x = -speed;
            if (Input.GetKeyUp(KeyCode.RightArrow)) speed_vec.x = 0;
            if (Input.GetKeyUp(KeyCode.LeftArrow)) speed_vec.x = 0;

            GetComponent<Rigidbody2D>().velocity = speed_vec;
        }
        else if (move_method == 1)
        {
            if (Input.GetKey(KeyCode.A)) speed_vec.x = speed;
            if (Input.GetKey(KeyCode.D)) speed_vec.x = -speed;
            if (Input.GetKeyUp(KeyCode.A)) speed_vec.x = 0;
            if (Input.GetKeyUp(KeyCode.D)) speed_vec.x = 0;

            GetComponent<Rigidbody2D>().velocity = speed_vec;
        }
    }
}