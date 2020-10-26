using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogoNovo : MonoBehaviour
{
    public GameObject uiObject;
    void Start()
    {
        //uiObject.SetActive(false);
    }

    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "NPC")
        {
            uiObject.SetActive(true);
            StartCoroutine("WaitForSec");
        }
    }
    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(10);
        Destroy(uiObject);
        Destroy(gameObject);
    }
}
