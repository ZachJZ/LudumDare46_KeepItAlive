using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ouch : MonoBehaviour
{

    int SkeleHealth;

    // Start is called before the first frame update
    void Start()
    {
        SkeleHealth = Random.Range(2, 4);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Death()
    {
        Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetComponent<Fire>())
        {
            SkeleHealth--;
            Destroy(col.gameObject);
            Death();
        }
        //addforce being flung backwards
        //decrement health
    }
}
