using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockCollision : MonoBehaviour
{
    public Sprite[] blockColor = new Sprite[4];
    public GameObject ball;
    public int color;
    SpriteRenderer spriteRenderer;

    void Start(){
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("ball")){
            Debug.Log("Collided!");
            if(color == 0) Destroy(transform.gameObject);
            else spriteRenderer.sprite = blockColor[--color];
        }
    }
}
