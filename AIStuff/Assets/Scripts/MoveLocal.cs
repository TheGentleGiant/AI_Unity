using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class MoveLocal : MonoBehaviour
{
    public Transform goalTransform;
    public float movementSpeed = 5f;
    public float Accuracy = 1f;
    public float rotationSpeed = 100f;
    void Start()
    {
        
    }
    
    void LateUpdate()
    {
        Vector3 LookAtGoal = new Vector3(goalTransform.position.x, this.transform.position.y, goalTransform.position.z);
        Vector3 Direction = LookAtGoal - this.transform.position;
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(Direction),Time.deltaTime * rotationSpeed);
        //this.transform.LookAt(LookAtGoal);
        //if (Vector3.Distance(transform.position, goalTransform.position)> Accuracy)
        {
            
        }
        this.transform.Translate(0,0, movementSpeed * Time.deltaTime);
    }
}
