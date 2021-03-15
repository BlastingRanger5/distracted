using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICarController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 move;

    public float forwardMotion;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        move = new Vector3(0, 0, forwardMotion);

        controller.Move(move * Time.deltaTime);
    }
}
