using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class SkeletonBrain : MonoBehaviour
{
    //https://www.youtube.com/watch?v=jvtFUfJ6CP8

    public Transform target;

    public float speed;
    public float nextWaypointDistance;

    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;

    int health;
    string weakness;

    int headHunt;

    public GameObject player;
    public GameObject spawn;


    // Start is called before the first frame update
    void Start()
    {
        nextWaypointDistance = 3;

        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        headHunt = Random.Range(1, 4);

        if (headHunt == 1)
        {
            target = player.transform;
        }
        else
        {
            target = spawn.transform;
        }
        weakness = "Thunder";
        speed = Random.Range(200, 230);
        health = 2;

        InvokeRepeating("UpdatePath", 0f, .5f);
    }

    void UpdatePath()
    {
        if (seeker.IsDone())
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (path == null)
        {
            return;
        }
        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;   
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        float dis = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (dis < nextWaypointDistance)
        {
            currentWaypoint++;
        }
        //transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed);
    }
}
