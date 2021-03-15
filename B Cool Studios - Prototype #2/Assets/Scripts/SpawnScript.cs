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
        controller = GetComponent<CharacterController>();

        StartCoroutine(Randomize());
    }

    // Update is called once per frame
    void Update()
    {
        move = new Vector3(0, 0, forwardMotion);

        controller.Move(move * Time.deltaTime);
    }

    private IEnumerator Randomize()
    {
        while (spawning)
        {
            yield return new WaitForSeconds(cooldownChance);

            randomNumber = Random.Range(0.0f, 1.0f);

            if (randomNumber > randomChancePercentage)
            {
                Instantiate(AICar, transform.position, transform.rotation);
            }
        }
    }
}
