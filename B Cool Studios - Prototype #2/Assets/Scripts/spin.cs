using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spin : MonoBehaviour
{

    public int speed;

    void Start()
    {
        
    }

    
    void Update()
    {
        transform.Rotate(Vector3.up * speed * Time.deltaTime);
    }
}
