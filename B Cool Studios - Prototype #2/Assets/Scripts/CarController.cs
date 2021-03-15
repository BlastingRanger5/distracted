using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private float horizontalMove = 0f;
    private Rigidbody rb;
    private Vector3 move;
    
    public float veeringSpeed;
    public Joystick joystick;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = joystick.Horizontal * veeringSpeed;
        move = new Vector3(0, 0, horizontalMove);

        if(horizontalMove != 0)
        {
            rb.MovePosition(move);
        }

        Debug.Log(horizontalMove);
    }
}
