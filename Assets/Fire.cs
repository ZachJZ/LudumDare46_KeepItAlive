using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{

    public float speed = 20f;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Tilemap_Walls&Bounds")
        {
            print("Hit bounds");
            Destroy(gameObject);
        }

        if (col.gameObject.GetComponent<SkeletonBrain>())
        {
            Destroy(col.gameObject);
            rb.velocity = transform.right * speed * 2;
        }
    }
}
