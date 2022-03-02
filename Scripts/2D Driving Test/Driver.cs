using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float turnSpeed = 0.5f;
    [SerializeField] float moveSpeed = 0.01f;
    void Start()
    {
        
    }

    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;
        float carSpeed = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, carSpeed, 0);
    }
}
