using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float Speed =2f;
    public float accuracy = 0.1f;
    //public Vector3 Goal = new Vector3(5, 0, 4);
    public Transform goalTransform;
    void Start()
    {
        
    }
    void LateUpdate()
    {
        this.transform.LookAt(goalTransform.position);
        Vector3 dir = goalTransform.position - this.transform.position;
        if (dir.magnitude > accuracy)
        {
            this.transform.Translate(dir.normalized * Time.deltaTime * Speed, Space.World);
        }
    }
}
