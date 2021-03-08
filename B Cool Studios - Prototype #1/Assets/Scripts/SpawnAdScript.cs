using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAdScript : MonoBehaviour
{
    private float randomResult;
    private float randomAd;
    private bool gameLost;

    public float spawnCooldown;
    public float spawnPercentage;
    public float spawnPercentageDecrease;
    public List<GameObject> ads;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ChanceToSpawn());
        StartCoroutine(IncreaseSpawnPercentage());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ChanceToSpawn()
    {
        while (!gameLost)
        {
            yield return new WaitForSeconds(spawnCooldown);

            randomResult = Random.Range(0.0f, 1.0f);

            if (randomResult > spawnPercentage)
            {
                Debug.Log("Spawned");

                randomAd = Random.Range(0.0f, 6.0f);

                if(randomAd <= 1.0f)
                {
                    ads[0].gameObject.SetActive(true);
                }
                else if (randomAd <= 2.0f)
                {
                    ads[1].gameObject.SetActive(true);
                }
                else if (randomAd <= 3.0f)
                {
                    ads[2].gameObject.SetActive(true);
                }
                else if (randomAd <= 4.0f)
                {
                    ads[3].gameObject.SetActive(true);
                }
                else if (randomAd <= 5.0f)
                {
                    ads[4].gameObject.SetActive(true);
                }
                else if (randomAd <= 6.0f)
                {
                    ads[5].gameObject.SetActive(true);
                }
            }
        }
        
    }

    IEnumerator IncreaseSpawnPercentage()
    {
        while (!gameLost)
        {
            yield return new WaitForSeconds(0.2f);
            spawnPercentage -= spawnPercentageDecrease;
            Debug.Log("Decrease!");
        }
        
    }
}
