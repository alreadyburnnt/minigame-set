using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirplaneController : MonoBehaviour
{
    public float speed = 5.0f;
    public int team;
    public GameObject[] bulletPrefabs;
    private Vector3 currentVelocity;
    public Sprite[] sprites; // 비행기의 스프라이트 배열
    private Vector2[] bulletSpawnpoint = new Vector2[4];
    public GameObject gameController;
    GameControllerScript gameControllerScript;
    Rigidbody2D rb;
    private SpriteRenderer spriteRenderer; // 비행기의 SpriteRenderer
    private int spriteIndex = 0; // 현재 사용 중인 스프라이트의 인덱스
    public float transitionTime = 1f; // 스프라이트 변경에 걸리는 시간
    private float elapsedTime = 0f; // 키를 누른 시간을 측정하는 변수
    private float powerUpTime = 0f;
    private float moveHorizontal, moveVertical;

    void Start()
    {
        StartCoroutine(Fire());
        if(team == 0) transform.position = new Vector3(-5f, -3f, 0);
        else if(team == 1) transform.position = new Vector3(5f, -3f, 0);
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        gameControllerScript = gameController.GetComponent<GameControllerScript>();
    }
    void Update()
    {
        if(powerUpTime > 0f) powerUpTime -= Time.deltaTime;
        if(team == 0){
            moveHorizontal = Input.GetAxisRaw("BlueHorizontal");
            moveVertical = Input.GetAxisRaw("BlueVertical");
        }
        else if(team == 1){
            moveHorizontal = Input.GetAxisRaw("RedHorizontal");
            moveVertical = Input.GetAxisRaw("RedVertical");
        }
        Vector3 Movement = new Vector3(moveHorizontal, moveVertical,0);

        // 정규화
        if(Movement != Vector3.zero){
            Movement = Movement.normalized * speed;
            currentVelocity = Movement;
        }
        else currentVelocity = Vector3.zero;

        rb.velocity = currentVelocity;
        
        ChangeSprite(moveHorizontal);
    }

    IEnumerator Fire()
    {
        while(true){
            bulletSpawnpoint[0] = gameObject.transform.position - new Vector3(0.35f, 0, 0);
            bulletSpawnpoint[1] = gameObject.transform.position + new Vector3(0.35f, 0, 0);

            Instantiate(bulletPrefabs[0], bulletSpawnpoint[0], Quaternion.identity);
            Instantiate(bulletPrefabs[1], bulletSpawnpoint[1], Quaternion.identity);

            if(powerUpTime > 0f){
                bulletSpawnpoint[2] = gameObject.transform.position - new Vector3(0.65f, 0, 0);
                bulletSpawnpoint[3] = gameObject.transform.position + new Vector3(0.65f, 0, 0);

                Instantiate(bulletPrefabs[0], bulletSpawnpoint[2], Quaternion.identity);
                Instantiate(bulletPrefabs[1], bulletSpawnpoint[3], Quaternion.identity);
            }

            yield return new WaitForSeconds(0.3f);
        }
    }

    private void ChangeSprite(float moveHorizontal)
    {
        if (moveHorizontal < 0)
        {
            // 왼쪽 키를 누르는 동안의 시간을 측정합니다.
            elapsedTime += Time.deltaTime;

            // 일정 시간이 지나면 스프라이트를 변경합니다.
            if (elapsedTime >= transitionTime)
            {
                spriteIndex = 2;
                spriteRenderer.sprite = sprites[spriteIndex];
            }
            else
            {
                spriteIndex = 1;
                spriteRenderer.sprite = sprites[spriteIndex];
            }
            

        }
        else if (moveHorizontal > 0)
        {
           // 오른쪽 키를 누르는 동안의 시간을 측정합니다.
            elapsedTime += Time.deltaTime;

            // 일정 시간이 지나면 스프라이트를 변경합니다.
            if (elapsedTime >= transitionTime)
            {
                spriteIndex = 4;
                spriteRenderer.sprite = sprites[spriteIndex];

            }
            else
            {
                spriteIndex = 3;
                spriteRenderer.sprite = sprites[spriteIndex];
            }
            
        }
        else
        {
            // 사용자가 키를 뗐다면 타이머를 리셋하고 스프라이트를 기본 상태로 돌립니다.
            elapsedTime = 0f;
            spriteIndex = 0;
            spriteRenderer.sprite = sprites[spriteIndex];
        }

    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "item"){
            gameControllerScript.scores[team] += 20;
            int itemKind = collision.gameObject.GetComponent<PlaneItemScript>().itemNum;
            if(itemKind == 0) gameControllerScript.lives[team] += 1;
            else if(itemKind == 1) powerUpTime = 10f;
            Destroy(collision.gameObject);
        }
    }
}
