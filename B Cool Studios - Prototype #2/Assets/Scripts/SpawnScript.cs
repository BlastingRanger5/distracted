using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    [Range(0.0f, 1.0f)]
    public float randomChancePercentage;
    public float cooldownChance;
    public GameObject AICar;
    public float forwardMotion;

    private float randomNumber;
    private CharacterController controller;
    private Vector3 move;
    private bool spawning = true;



    // Start is called before the first frame update
    void Start()
    {
        //Get the CharacterController and store it in a variable
        controller = GetComponent<CharacterController>();

        //Start randomizing spawn chances
        StartCoroutine(Randomize());
    }

    // Update is called once per frame
    void Update()
    {
        //Movement direction
        move = new Vector3(0, 0, forwardMotion);

        //Movement speed
        controller.Move(move * Time.deltaTime);
    }

    private IEnumerator Randomize()
    {
        //While it is allowed to spawn
        while (spawning)
        {
            //Wait for a number of seconds
            yield return new WaitForSeconds(cooldownChance);

            //Set a random number from 0 to 1
            randomNumber = Random.Range(0.0f, 1.0f);

            //If the number is higher than the spawn chance...
            if (randomNumber > randomChancePercentage)
            {
                //Create an AI car
                Instantiate(AICar, transform.position, transform.rotation);
            }
        }
    }
}
