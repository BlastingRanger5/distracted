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
        //Getting the CharacterController script and putting it in the controller variable
        controller = GetComponent<CharacterController>();

        //Start a coroutine to disable gameobject
        StartCoroutine(SelfDestruct());
    }

    // Update is called once per frame
    void Update()
    {
        //Movement direction
        move = new Vector3(0, 0, forwardMotion);

        //The car actually moving
        controller.Move(move * Time.deltaTime);
    }

    private IEnumerator SelfDestruct()
    {
        //Waiting for 10 seconds until it disables
        yield return new WaitForSeconds(10);

        this.gameObject.SetActive(false);
    }
}
