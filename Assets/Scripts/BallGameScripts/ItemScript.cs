using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    public int towards;
    public int type;  //1: longer bar, 2: ball+, 3: life+
    public Sprite[] alterSprite = new Sprite[2];
    SpriteRenderer spriteRenderer;
    Rigidbody2D rb;
    Vector3 moveVec;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        if(towards == 1) rb.AddForce(new Vector2(0, -100));
        else if(towards == 2) rb.AddForce(new Vector2(0, 100));
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(spriteAlterEnum());
    }

    void Update()
    {
        if(transform.position.y < -8 || transform.position.y > 8) Destroy(transform.gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision){
        Debug.Log("ItemCollided");
        if(collision.gameObject.CompareTag("blueBar") || collision.gameObject.CompareTag("redBar")) Destroy(transform.gameObject);
    }

    IEnumerator spriteAlterEnum(){
        while(true){
            spriteRenderer.sprite = alterSprite[0];
            yield return new WaitForSeconds(0.15f);
            spriteRenderer.sprite = alterSprite[1];
            yield return new WaitForSeconds(0.15f);
        }
    }
}
