using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    public Transform target;
    public float speed = 10f;
    public float nextWayPointDistance = 0f;
    Path path;
    int currentWayPoint = 0 ;
    bool reachEndOfPath =false;
    Seeker seeker;
    Rigidbody2D rb;
    public Transform enemyGraphics;
    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("UpdatingPath", 0f, 0.5f);
        

    }
    void UpdatingPath()
    {
        if (seeker.IsDone() )
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
    }
    void OnPathComplete(Path p)
    {
        if(!p.error)
        {
            path = p;
            currentWayPoint = 0; 
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(path == null)
        {
            return;
            
        }
        if(currentWayPoint >= path.vectorPath.Count)
        {
            reachEndOfPath = true;
            return;
        }
        else
        {
            reachEndOfPath = false;
        }
        Vector2 Direction = ((Vector2)path.vectorPath[currentWayPoint] - rb.position).normalized;
        Vector2 force = Direction * speed * Time.deltaTime;
        rb.AddForce(force);
        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWayPoint]);
        if(distance < nextWayPointDistance)
        {
            currentWayPoint++;
        }
        if(force.x >=0.01f)
        {
            enemyGraphics.localScale = new Vector3(-5f, 5f, 1f);

        }
        else if (force.x <=0)
        {
            enemyGraphics.localScale = new Vector3(5f, 5f, 1f);
        }
    }
}
