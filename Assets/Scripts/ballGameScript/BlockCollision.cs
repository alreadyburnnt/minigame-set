using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCollision : MonoBehaviour
{
    public Sprite[] blockColor = new Sprite[4];
    public GameObject[] items = new GameObject[6];
    public int blockHP;
    SpriteRenderer spriteRenderer;

    void Start(){
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("ball")){
            if(blockHP == 0){
                int towards = collision.gameObject.GetComponent<BallScript>().lastCollision;
                //item intantiation
                float randomNum = Random.Range(0.0f, 1.0f);
                if(randomNum <= 0.1) instantiateItem(0, towards);
                else if(randomNum <= 0.2) instantiateItem(1, towards);
                else if(randomNum <= 0.3) instantiateItem(2, towards);
                //Block destroyed
                Destroy(transform.gameObject);
            }
            else spriteRenderer.sprite = blockColor[--blockHP];
        }
    }

    void instantiateItem(int kind, int towards){
        Instantiate(items[2 * kind + towards - 1], transform.position, Quaternion.identity);
    }
}