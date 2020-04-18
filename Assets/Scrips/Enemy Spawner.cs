using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy(int Enemy)
    {
        if (Enemy == 0)
        {
            //spawn skeleton
        }
        else if (Enemy == 1)
        {
            //spawn zombie
        }
        else if (Enemy == 2)
        {
            //spawn demon
        }
        else
        {
            Debug.LogError("Enemy int was not in range. Spawning skeleton");
            //spawn skeleton
        }
    }
}
