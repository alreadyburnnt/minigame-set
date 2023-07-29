using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonControl : MonoBehaviour
{
    public void StartSceneBtn(){
        SceneManager.LoadScene(0);
    }

    public void SelectSceneBtn(){
        SceneManager.LoadScene(1);
    }

    public void BallGameSceneBtn(){
        SceneManager.LoadScene(2);
    }
}
