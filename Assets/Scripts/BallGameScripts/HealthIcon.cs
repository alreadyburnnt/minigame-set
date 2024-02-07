using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthIcon : MonoBehaviour
{
    public int healthNum;
    public int team;
    public Sprite[] healthSprite = new Sprite[2];
    public GameObject healthControllerObj;
    HealthController healthController;
    SpriteRenderer spriteRenderer;
    bool changeFlag = false, onoffFlag = true;

    void Start()
    {
        healthController = healthControllerObj.GetComponent<HealthController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        int health = healthController.getHP(team);
        if(changeFlag){
            onoffFlag = !onoffFlag;
            int temp;
            if(onoffFlag) temp = 1;
            else temp = 0;
            spriteRenderer.sprite = healthSprite[temp];
            changeFlag = false;
        }
        if((healthNum <= health && !onoffFlag) || (healthNum > health && onoffFlag)) changeFlag = true;
    }
}
