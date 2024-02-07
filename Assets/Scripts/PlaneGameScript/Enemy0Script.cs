using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy0Script : MonoBehaviour
{
    private float elapsedTime = 0;
    Rigidbody2D rb;
    public int teamNum, groupNum, entityNum;
    public GameObject gameController;
    public GameObject[] itemPrefabs = new GameObject[2];
    GameControllerScript gameControllerScript;
    private bool connectFlag = true;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        transform.position = new Vector3(0, 10f, 0);

        Vector3 resPos;

        if(groupNum == 0){
            resPos = new Vector3(-9.5f, 6f, 0);
            elapsedTime = 0.75f;
            transform.Rotate(0, 0, 40f);
        }
        else{
            resPos = new Vector3(0.5f, 6f, 0);
            elapsedTime = 0.25f;
            transform.Rotate(0, 0, -40f);
        }

        if(entityNum == 1) resPos = resPos - new Vector3(1f, 0, 0);
        else if(entityNum == 2) resPos = resPos + new Vector3(1f, 0, 0);

        if(teamNum == 1) resPos = resPos + new Vector3(9f, 0, 0);

        transform.position = resPos;
    }

    void Update()
    {
        if(elapsedTime != 0){
            if(transform.position.y < -6f) Destroy(gameObject);
            if(connectFlag) gameControllerScript = gameController.GetComponent<GameControllerScript>();

            elapsedTime += Time.deltaTime;
            int flagNum = 1;
            if((int)(elapsedTime*2) % 2 == 1) flagNum = -1;
            transform.Rotate(0, 0, 50f * Time.deltaTime * flagNum);

            Vector3 direction = transform.rotation * new Vector2(0, -1);
            Vector2 direction2D = new Vector2(direction.x, direction.y);
            rb.velocity = direction2D * 4f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "bullet"){
            Debug.Log("collided");
            gameControllerScript.scores[teamNum] += 2;
            StartCoroutine(DropItem());
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else if(collision.gameObject.tag == "plane"){
            gameControllerScript.lives[teamNum] -= 1;
            Destroy(gameObject);
        }
    }

    IEnumerator DropItem(){
        float tempRand = Random.Range(0.0f, 1.0f);
        if(tempRand < 0.02f) Instantiate(itemPrefabs[0], transform.position, Quaternion.identity);
        else if(tempRand < 0.04f) Instantiate(itemPrefabs[1], transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0);
    }
}
