using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgScript : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject bgPrefab;
    private bool madeAnother = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(0, -0.7f, 0);
        if(gameObject.transform.position.y < -20 && !madeAnother){
            Instantiate(bgPrefab, new Vector3(0, 33.7f, 10), Quaternion.identity);
            madeAnother = true;
        }
        if(gameObject.transform.position.y < -33){
            Destroy(gameObject);
        }
    }
}
