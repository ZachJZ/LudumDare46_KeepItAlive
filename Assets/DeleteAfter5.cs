using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteAfter5 : MonoBehaviour
{
    float timer;
    float maxTimer;

    // Start is called before the first frame update
    void Start()
    {
        maxTimer = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= maxTimer)
        {
            Destroy(gameObject);
        }
    }
}
