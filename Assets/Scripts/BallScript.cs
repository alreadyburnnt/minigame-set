using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public bool defaultBall = false;
    public Rigidbody2D rb;
    public float speed = 200f;
    public int lastCollision = 1;
    public GameObject HealthControllerObj;
    public GameObject[] BarScriptObj = new GameObject[2];
    HealthController healthController;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        healthController = HealthControllerObj.GetComponent<HealthController>();

        ballInit(lastCollision);
    }

    void ballInit(int player){
        rb.velocity = Vector2.zero;
        float randomNum = Random.Range(-0.2f, 0.2f);
        if(player == 1){
            rb.AddForce(new Vector2(randomNum, -1).normalized * speed);
            transform.position = BarScriptObj[0].transform.position + new Vector3(0, 1, 0);
        } else if(player == 2){
            rb.AddForce(new Vector2(randomNum, 1).normalized * speed);
            transform.position = BarScriptObj[1].transform.position + new Vector3(0, -1, 0);
        }
    }

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("blueBar")) lastCollision = 1;
        else if(collision.gameObject.CompareTag("redBar")) lastCollision = 2;
    }

    void Update(){
        if(transform.position.y < -5.5f){
            healthController.decHP(1);
            if(defaultBall) ballInit(lastCollision);
            else Destroy(transform.gameObject);
        }
        else if(transform.position.y > 5.5f){
            healthController.decHP(2);
            if(defaultBall) ballInit(lastCollision);
            else Destroy(transform.gameObject);
        }
    }
}
