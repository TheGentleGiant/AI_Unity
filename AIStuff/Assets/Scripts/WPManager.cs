using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Link
{
    public enum direction
    {
        UNIDIRECTIONAL,
        BIDIRECTIONAL
    };
    public GameObject node1;
    public GameObject node2;
    public direction dir;
}
public class WPManager : MonoBehaviour
{
    public GameObject[] waypoints;
    public Link[] links;
    public Graph graph = new Graph();
    void Start()
    {
        if (waypoints.Length > 0)
        {
            foreach (GameObject go in waypoints)
            {
                graph.AddNode(go);
            }

            foreach (Link l in links)
            {
                graph.AddEdge(l.node1, l.node2);
                if (l.dir == Link.direction.BIDIRECTIONAL)
                {
                    graph.AddEdge(l.node2, l.node1);
                }
            }
        }
    }

    void Update()
    {
        graph.debugDraw();        
    }
}
