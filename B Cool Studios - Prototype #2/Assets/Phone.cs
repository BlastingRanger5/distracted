using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Phone : MonoBehaviour
{

    public Button reply;
    public Text convoText;
    public Text replyText;
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void ButtonPressed()
    {
        Debug.Log("Reply Sent");
        replyText.text = "I hate you";
        StartCoroutine(postButton());
    }

    IEnumerator postButton()
    {
        yield return new WaitForSeconds(5f);
        Debug.Log("a new one");
        replyText.text = "";
        convoText.text = "Loser";
    }
}
