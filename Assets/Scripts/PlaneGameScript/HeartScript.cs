using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartScript : MonoBehaviour
{
    public GameObject gameController;
    GameControllerScript gameControllerScript;
    public int heartNum, team;
    public Sprite[] heartSprites = new Sprite[2];
    Image img;
    void Start()
    {
        img = GetComponent<Image>();
        img.sprite = heartSprites[1];
        gameControllerScript = gameController.GetComponent<GameControllerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameControllerScript.lives[team] <= heartNum) img.sprite = heartSprites[0];
        else img.sprite = heartSprites[1];
    }
}
