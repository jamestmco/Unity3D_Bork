using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selecionado : MonoBehaviour
{
    public GameObject A;
    public GameObject B;
    public GameObject C;


    void Start()
    {
        A.SetActive(true);
        B.SetActive(false);
        C.SetActive(false);
    }

    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (A.activeInHierarchy == true)
            {
                A.SetActive(false);
                B.SetActive(true);
            }
            else if(B.activeInHierarchy == true)
            {
                B.SetActive(false);
                C.SetActive(true);
            }
            else if (C.activeInHierarchy == true)
            {
                C.SetActive(false);
                A.SetActive(true);
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (C.activeInHierarchy == true)
            {
                C.SetActive(false);
                B.SetActive(true);
            }
            else if (B.activeInHierarchy == true)
            {
                B.SetActive(false);
                A.SetActive(true);
            }
            else if (A.activeInHierarchy == true)
            {
                A.SetActive(false);
                C.SetActive(true);
            }
        }
    }
}
