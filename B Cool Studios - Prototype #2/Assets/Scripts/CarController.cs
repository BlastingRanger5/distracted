using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private float horizontalMove = 0f;
    private CharacterController controller;
    private Vector3 move;
    
    public float veeringSpeed;
    public Joystick joystick;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = joystick.Horizontal * veeringSpeed;
        move = new Vector3(horizontalMove, 0, 0);

        if(horizontalMove != 0)
        {
            controller.Move(move * veeringSpeed * Time.deltaTime);
        }

        Debug.Log(horizontalMove);
    }
}
