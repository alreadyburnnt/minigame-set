using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public GameObject[] winEvent = new GameObject[2];
    Animator winEventAnimator;
    private int player1HP = 3, player2HP = 3;
    bool endGameFlag = false;

    public int getHP(int num){
        if(num == 1) return player1HP;
        else if(num == 2) return player2HP;
        else{
            Debug.Log("getHP Parameter Error");
            return 0;
        }
    }

    public void decHP(int num){
        if(num == 1){
            if(player1HP == 1 && !endGameFlag){
                winEvent[1].SetActive(true);
                winEventAnimator = winEvent[1].transform.GetComponent<Animator>();
                winEventAnimator.SetTrigger("winEvent");
                endGameFlag = true;
                StartCoroutine(gameQuit(2.0f));
            }
            else player1HP--;
        }
        else if(num == 2){
            if(player2HP == 1 && !endGameFlag){
                winEvent[0].SetActive(true);
                winEventAnimator = winEvent[0].transform.GetComponent<Animator>();
                winEventAnimator.SetTrigger("winEvent");
                endGameFlag = true;
                StartCoroutine(gameQuit(2.0f));
            }
            else player2HP--;
        }
    }

    public void incHP(int num){
        if(num == 1 && player1HP < 3) player1HP++;
        else if(num == 2 && player2HP < 3) player2HP++;
    }

    IEnumerator gameQuit(float num){
        yield return new WaitForSeconds(num);
        Application.Quit();
    }
}
