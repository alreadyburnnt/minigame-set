using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthController : MonoBehaviour
{
    private int player1HP = 5, player2HP = 5;

    public int getHP(int num){
        if(num == 1) return player1HP;
        else if(num == 2) return player2HP;
        else{
            Debug.Log("getHP Parameter Error");
            return 0;
        }
    }

    public void decHP(int num){
        if(num == 1) player1HP--;
        else if(num == 2) player2HP--;
    }

    public void incHP(int num){
        if(num == 1) player1HP++;
        else if(num == 2) player2HP++;
    }
}
