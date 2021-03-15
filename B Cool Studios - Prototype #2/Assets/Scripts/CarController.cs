using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private float horizontalMove = 0f;
    
    public float veeringSpeed;
    public Joystick joystick;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = joystick.Horizontal * veeringSpeed;

        Debug.Log(horizontalMove);
    }
}
