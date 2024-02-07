using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour
{
    public int[] lives = new int[2];
    public int[] scores = new int[2];
    private float elapsedTime = 0;
    public GameObject[] enemyPrefabs0 = new GameObject[12];
    public bool endGameFlag = false;
    public GameObject[] winEvent = new GameObject[2];
    Animator winEventAnimator;


    void Update()
    {
        for(int i=0;i<2;i++){
            if(lives[i] > 3) lives[i] = 3;
            else if((scores[1-i] >= 1000 || lives[i] <= 0) && !endGameFlag){
                winEvent[0].SetActive(true);
                winEventAnimator = winEvent[0].transform.GetComponent<Animator>();
                winEventAnimator.SetTrigger("winEvent");
                endGameFlag = true;
            }
        }
        elapsedTime += Time.deltaTime;

        if(elapsedTime >= 5f){
            elapsedTime = 0;
            float randomNum = Random.Range(0.0f, 1.0f);
            if(randomNum < 0.5f) StartCoroutine(SummonEnemy(0));
            else StartCoroutine(SummonEnemy(0));
        }
    }

    IEnumerator SummonEnemy(int enemyType){
        if(enemyType == 0){
            int[] randomGroup = new int[2];
            randomGroup[0] = Random.Range(0, 2);
            randomGroup[1] = 1 - randomGroup[0];
            Debug.Log(randomGroup[0]);

            for(int i=0;i<6;i++){
                for(int j=0;j<3;j++){
                    for(int k=0;k<2;k++){
                        GameObject enemyTemp = Instantiate(enemyPrefabs0[j + 3 * randomGroup[k] + 6 * k], new Vector3(0, 10f, 0), Quaternion.identity);
                        enemyTemp.GetComponent<Enemy0Script>().gameController = gameObject;
                    }
                    yield return new WaitForSeconds(0.03f);
                }
                yield return new WaitForSeconds(0.2f);
            }
        }
    }
}
