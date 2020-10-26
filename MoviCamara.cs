using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoviCamara : MonoBehaviour
{
    public Transform Jogador;
    float rodaX = 0f;
    public float sensibilidade = 150f;
    //    public GameObject visao;
    //    public GameObject camara;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        float movimentoX = Input.GetAxis("Mouse X") * sensibilidade * Time.deltaTime;
        //float movimentoY = Input.GetAxis("Mouse Y") * sensibilidade * Time.deltaTime;
        Jogador.Rotate(Vector3.up * movimentoX);

        //rodaX -= movimentoY;
        transform.localRotation = Quaternion.Euler(rodaX, 0f, 0f);
        rodaX = Mathf.Clamp(rodaX, 0f, 20f);
        //        transform.LookAt(visao);
    }
}
