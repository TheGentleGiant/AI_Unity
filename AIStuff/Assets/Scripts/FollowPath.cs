using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    private Transform goal;
    private float speed = 5.0f;
    private float accuracy = 1.0f;
    private float rotationSpeed = 2.0f;
    public GameObject wpManager;
    private GameObject[] waypoints;
    private GameObject currentNode;
    private int waypointIndex = 0;
    private Graph g;
    
    void Start()
    {
        waypoints = wpManager.GetComponent<WPManager>().waypoints;
        g = wpManager.GetComponent<WPManager>().graph;
        currentNode = waypoints[0];
    }

    public void GoToHeliport()
    {
        g.AStar(currentNode, waypoints[0]);
        waypointIndex = 0;
    }

    public void GoToRuin()
    {
        g.AStar(currentNode, waypoints[3]);
        waypointIndex = 0;
    }

    void LateUpdate()
    {
        if (g.getPathLength() == 0 && waypointIndex == g.getPathLength())
            return;

            currentNode = g.getPathPoint(waypointIndex);
            
        if (Vector3.Distance(g.getPathPoint(waypointIndex).transform.position, transform.position)< accuracy)
            waypointIndex++;

        if (waypointIndex < g.getPathLength())
        {
            goal = g.getPathPoint(waypointIndex).transform;
            Vector3 lookAtGoal = new Vector3(goal.position.x, this.transform.position.y, goal.position.z);
            Vector3 direction = lookAtGoal- this.transform.position;
            
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotationSpeed);
            this.transform.Translate(0,0, speed* Time.deltaTime);
        }
        
    }
    
}
