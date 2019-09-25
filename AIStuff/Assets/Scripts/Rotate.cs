using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Rotate : MonoBehaviour
{
    public float rotationSpeed = 10f;
    public float movementSpeed = 10f;

    private Transform thisTransform;

    private void Awake()
    {
        thisTransform = GetComponent<Transform>();
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            thisTransform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            thisTransform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            thisTransform.transform.Translate(thisTransform.forward * Time.deltaTime * movementSpeed, Space.World );
        }
    }
}
