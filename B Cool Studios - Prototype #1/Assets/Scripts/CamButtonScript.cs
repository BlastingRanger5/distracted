using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamButtonScript : MonoBehaviour
{

    public Button answer1;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void ButtonPressed()
    {
        Debug.Log("You've pressed the button");
        StartCoroutine(postButton());
    }

    public void ButtonReleased()
    {
        Debug.Log("You've released the button");
        StopCoroutine(postButton());
    }


    IEnumerator postButton()
    {
        yield return new WaitForSeconds(30f);
        Debug.Log("Y E S");
    }


}
