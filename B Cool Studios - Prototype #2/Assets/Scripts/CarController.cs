using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public Slider slider;
    public float targetPosition;


    // Start is called before the first frame update
    void Start()
    {
        //Get variables from the CharacterController and store it in the variable controller
        controller = GetComponent<CharacterController>();

        slider = slider.gameObject.GetComponent<Slider>();

        //Set the gameRunning variable to true.
        gameRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Set up the horizontalMove variable with the joystick and the speed to steer.
        horizontalMove = joystick.Horizontal * veeringSpeed;

        //If the game is running...
        if(gameRunning)
        {
            //Set the movement speed
            move = new Vector3(horizontalMove * veeringSpeed, 0, forwardMotion);
        }
        else
        {
            //Stop the car
            move = new Vector3(0, 0, 0);
        }

        //Set up the rotation for the steering wheel
        rotation = new Vector3(0, horizontalMove, 0);

        //Move the car
        controller.Move(move * Time.deltaTime);

        //Rotate the steering wheel by using euler angles
        steeringWheel.transform.eulerAngles = new Vector3((horizontalMove * 70), 90, -90);

        //if ((steeringWheel.transform.rotation.x > 0) && (steeringWheel.transform.rotation.x < 180))
        //{
        //steeringWheel.transform.Rotate(rotation);
        //}

        slider.value = gameObject.transform.position.z / targetPosition;

        if(gameObject.transform.position.z >= targetPosition)
        {
            gameRunning = false;
            Debug.Log("You Win");
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        //If a gameobject with the tag Hazard (like the AI cars)...
        if (other.gameObject.CompareTag("Hazard"))
        {
            //Set the black screen image in front of the camera to true
            blackScreen.SetActive(true);

            //Set the gameRunning to false
            gameRunning = false;

            //Start playing soundbytes
            StartCoroutine(SoundLink());

            //Send a debug.log for the developer's use
            Debug.Log("Game Over");
        }
    }

    private IEnumerator SoundLink()
    {
        //Finds the sound scream in the audiomanager and plays it
        FindObjectOfType<AudioManager>().Play("Scream");

        //Waits for 2 seconds
        yield return new WaitForSeconds(2);

        //Finds the sound Crash in the audiomanager and plays it
        FindObjectOfType<AudioManager>().Play("Crash");

        //Wait for 1 second
        yield return new WaitForSeconds(1);

        //Shows the PSA text
        PSA.SetActive(true);
    }
}
