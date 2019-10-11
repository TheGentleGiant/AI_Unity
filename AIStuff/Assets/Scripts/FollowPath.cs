using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    public GameObject wpManager;
    private GameObject[] waypoints;
    private UnityEngine.AI.NavMeshAgent navAgent;

    
    void Start()
    {
        waypoints = wpManager.GetComponent<WPManager>().waypoints;
        navAgent = this.GetComponent<UnityEngine.AI.NavMeshAgent>();
        //g = wpManager.GetComponent<WPManager>().graph;
        //currentNode = waypoints[0];
    }

    public void GoToHeliport()
    {
        navAgent.SetDestination(waypoints[0].transform.position);
        //g.AStar(currentNode, waypoints[0]);
        //waypointIndex = 0;
    }

    public void GoToRuin()
    {
        navAgent.SetDestination(waypoints[3].transform.position);
        //g.AStar(currentNode, waypoints[3]);
        //waypointIndex = 0;
    }

    void LateUpdate()
    {
        
        
    }
    
}
