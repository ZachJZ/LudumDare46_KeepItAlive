using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    //Variables
    public Transform player;
    public float smooth;
    public float height = 7;

    private Vector3 velocity = Vector3.zero;


    // Methods
    void Update()
    {
        Vector3 pos = new Vector3();

        pos.x = player.position.x;
        pos.z = player.position.z - (height * 2);
        pos.y = player.position.y;

        transform.position = Vector3.SmoothDamp(transform.position, pos, ref velocity, smooth);

    }
}
