using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarScript : MonoBehaviour
{
    public Sprite[] barSprite = new Sprite[2];
    public int team; //team 1 or 2
    public GameObject healthControllerObj;
    public GameObject ballObj;
    public GameObject ballParentObj;
    HealthController healthController;
    SpriteRenderer spriteRenderer;
    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        healthController = healthControllerObj.GetComponent<HealthController>();
    }

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("HPItem")){
            healthController.incHP(team);
        } else if(collision.gameObject.CompareTag("barItem")){
            StartCoroutine(barItemGet());
        } else if(collision.gameObject.CompareTag("ballItem")){
            GameObject temp = Instantiate(ballObj, new Vector2(100, 100), Quaternion.identity);
            temp.transform.SetParent(ballParentObj.transform);
        }
    }

    IEnumerator barItemGet(){
        spriteRenderer.sprite = barSprite[1];
        yield return new WaitForSeconds(10.0f);
        spriteRenderer.sprite = barSprite[0];
    }
}
