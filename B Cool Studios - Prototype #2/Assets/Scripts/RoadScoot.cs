using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadScoot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //If a gameobject with the tag player hits the collider...
        if (other.CompareTag("Player"))
        {
            //Move the road forward by 248.2 units
            this.gameObject.transform.position = new Vector3(0, 0, this.gameObject.transform.position.z + 248.2f);
        }
    }
}
