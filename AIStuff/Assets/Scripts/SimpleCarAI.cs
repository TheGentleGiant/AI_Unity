using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCarAI : MonoBehaviour
{
    public Transform goalTransform;
    //public float movementSpeed = 200f;
    public float Speed = 0f;
    public float acceleration = 5f;
    public float deceleration = 0.01f;
    public float minSpeed = 0.0f;
    public float maxSpeed = 100.0f;
    public float Accuracy = 1f;
    public float rotationSpeed = 30f;
    public float brakeAngle = 5.0f;
    void Start()
    {
        
    }
    
    void LateUpdate()
    {
        Vector3 LookAtGoal = new Vector3(goalTransform.position.x, this.transform.position.y, goalTransform.position.z);
        Vector3 Direction = LookAtGoal - this.transform.position;
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(Direction),Time.deltaTime * rotationSpeed);
        if (Vector3.Angle(goalTransform.forward, this.transform.forward) > brakeAngle && Speed > 1f)
        {
            Speed = Mathf.Clamp(Speed - (deceleration * Time.deltaTime), minSpeed, maxSpeed);
        }
        else
        {
            Speed = Mathf.Clamp(Speed + (acceleration * Time.deltaTime), minSpeed, maxSpeed);
        }
        this.transform.Translate(0,0, Speed);
    }

    private void OnGUI()
    {
        GUILayout.Label("Speed:");
        GUILayout.TextArea(Speed.ToString());
    }
}
