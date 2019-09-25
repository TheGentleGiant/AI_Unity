using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollow : MonoBehaviour
{
    //public GameObject[] waypoints;
    public UnityStandardAssets.Utility.WaypointCircuit circuit;
    private int currentWaypointID;
    public float Speed = 1.0f;
    public float Accuracy = 1.0f;
    public float RotationSpeed = 1.0f;
    
    void Start()
    {
        //waypoints = GameObject.FindGameObjectsWithTag("waypoint");
    }
    
    void LateUpdate()
    {
        if (circuit.Waypoints.Length == 0) return;
        
        Vector3 lookAtGoal = new Vector3(circuit.Waypoints[currentWaypointID].position.x, 
            this.transform.position.y, circuit.Waypoints[currentWaypointID].position.z);
        Vector3 direction = lookAtGoal - this.transform.position;
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction),
            Time.deltaTime * RotationSpeed);

        if (direction.magnitude  < Accuracy)
        {
            currentWaypointID++;
            if (currentWaypointID >= circuit.Waypoints.Length)
            {
                currentWaypointID = 0;
            }
        }
        this.transform.Translate(0,0,Speed * Time.deltaTime);
    }
}
