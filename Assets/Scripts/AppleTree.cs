using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class AppleTree : MonoBehaviour
{

    [Header("Inscribed")] public GameObject applePrefab;

    public float speed = 1f;

    public float leftAndRightEdge = 10f;

    public float changeDirChance = 0.1f;

    public float appleDropDelay = 1f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Basic Movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        
        // Changing Direction
        if (pos.x < -leftAndRightEdge) //currently moving left
        {
            speed = Mathf.Abs(speed); // move right
        }
        else if (pos.x > leftAndRightEdge) // currently moving right
        {
            speed = -Math.Abs(speed); // move left
            
        }
        
    }

    void FixedUpdate()
    {
        if (Random.value < changeDirChance)
        {
            speed *= -1; //change direction
        }
    }
}
