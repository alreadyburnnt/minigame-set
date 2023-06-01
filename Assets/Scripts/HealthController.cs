using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    private int player1HP = 3, player2HP = 3;

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
            if(player1HP == 1){
                Debug.Log("Player 1 Loses!");
                Application.Quit();
            }
            else player1HP--;
        }
        else if(num == 2){
            if(player2HP == 1){
                Debug.Log("Player 2 Loses!");
                Application.Quit();
            }
            else player2HP--;
        }
    }

    public void incHP(int num){
        if(num == 1 && player1HP < 3) player1HP++;
        else if(num == 2 && player2HP < 3) player2HP++;
    }
}
