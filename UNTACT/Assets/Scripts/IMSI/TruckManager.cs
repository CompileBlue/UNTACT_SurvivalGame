using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TruckManager : MonoBehaviour
{
    // public float moveSpeed;
    // public Transform endPoint;
    // public Transform startPoint;
    public float delayTime = 1.2f;
    private float fTickTime;

    void Start()
    {
        
    }

    void Update()
    {
        Move();
    }

    public void Move()
    {
        if (Wait(delayTime))
        {
            // Vector3 velocity = Vector3.zero;
            // transform.position = Vector3.MoveTowards(transform.position, endPoint.position, moveSpeed * Time.deltaTime);
        }
    }

    public bool Wait(float delayTime)
    {
        fTickTime += Time.deltaTime;
        return (fTickTime >= delayTime);
    }
}
