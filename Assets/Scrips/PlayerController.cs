using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float pSpeed = 5f;

    public Rigidbody2D rb;

    Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        //Movement
        rb.MovePosition(rb.position + movement * pSpeed * Time.fixedDeltaTime);

    }

}
