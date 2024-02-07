using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideLineScript : MonoBehaviour
{
    public int team;
    public GameObject gameController;
    GameControllerScript gameControllerScript;
    RectTransform rt;
    void Start()
    {
        gameControllerScript = gameController.GetComponent<GameControllerScript>();
        rt = GetComponent<RectTransform>();
    }

    void Update()
    {
        int score = gameControllerScript.scores[team];
        float y = -220 + score * 760 / 1000;
        if(team == 0) rt.anchoredPosition = new Vector2(-50f, y);
        else if(team == 1) rt.anchoredPosition = new Vector2(50f, y);
    }
}
