using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{   
     public void StartButton()
    {
        SceneManager.LoadScene("SelectScene"); // 전환하고자 하는 화면인 B의 이름을 ""에 넣어준다.
    }
}
