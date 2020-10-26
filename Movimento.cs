using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento : MonoBehaviour
{
    public CharacterController controlador;
    public float velocidade = 5f;
    public Animator animador;
    //public AudioClip caminhar;
    //private AudioSource som;

    void Start()
    {
        //som = GetComponent<AudioSource>();
    }

    void Update()
    {
        controlador.Move(new Vector3(0, -1, 0) * 0.3f); //gravidade, multipliquei por 0.1 porque caia demasiado rápido

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
/*
        if (Input.GetAxis("Horizontal") != 0)
        {
            animador.SetFloat("Movimento", Mathf.Abs(horizontal));
        }
        else if(Input.GetAxis("Vertical") != 0)
        {
            animador.SetFloat("Movimento", Mathf.Abs(vertical));
        }
*/

        if(Input.GetAxis("Horizontal") ==0 || Input.GetAxis("Vertical") != 0 /*&& !som.isPlaying*/)
        {
            animador.SetFloat("Movimento", Mathf.Abs(vertical));
            
            /*som.clip = caminhar;
            som.Play();*/
            Debug.Log("Frente ou trás");
        }
        if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") == 0 /*&& !som.isPlaying*/)
        {
            animador.SetFloat("Movimento", Mathf.Abs(horizontal));
            
            /*som.clip = caminhar; 
            som.Play();*/
            Debug.Log("Um dos lados");
        }
        else if(Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0 /*&& som.isPlaying*/)
        {
            
            //som.Stop();
            Debug.Log("Parado");
        }


        Vector3 movimento = transform.right * horizontal + transform.forward * vertical;
        controlador.Move(movimento * velocidade * Time.deltaTime);
    }

    public void GetAtaqueForte()
    {
        GetComponent<Ataque>().AtaqueForte();
    }
}
