using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private float horizontalMove = 0f;
    private CharacterController controller;
    private Vector3 move;
    private Vector3 rotation;
    
    public float veeringSpeed;
    public float forwardMotion;
    public Joystick joystick;
    public GameObject steeringWheel;
    public GameObject blackScreen;
    public bool gameRunning;
    public GameObject PSA;


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();

        gameRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        horizontalMove = joystick.Horizontal * veeringSpeed;
        if(gameRunning)
        {
            move = new Vector3(horizontalMove * veeringSpeed, 0, forwardMotion);
        }
        else
        {
            move = new Vector3(0, 0, 0);
        }

        rotation = new Vector3(0, horizontalMove, 0);

        controller.Move(move * Time.deltaTime);

        steeringWheel.transform.eulerAngles = new Vector3((horizontalMove * 70), 90, -90);

        //if ((steeringWheel.transform.rotation.x > 0) && (steeringWheel.transform.rotation.x < 180))
        //{
            //steeringWheel.transform.Rotate(rotation);
        //}


    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Hazard"))
        {
            blackScreen.SetActive(true);

            gameRunning = false;

            StartCoroutine(SoundLink());

            Debug.Log("Game Over");
        }
    }

    private IEnumerator SoundLink()
    {
        FindObjectOfType<AudioManager>().Play("Scream");

        yield return new WaitForSeconds(2);

        FindObjectOfType<AudioManager>().Play("Crash");

        yield return new WaitForSeconds(1);

        PSA.SetActive(true);
    }
}
