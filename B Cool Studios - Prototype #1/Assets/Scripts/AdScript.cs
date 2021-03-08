using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdScript : MonoBehaviour
{
    public void CloseAd()
    {
        this.gameObject.SetActive(false);
    }
}
