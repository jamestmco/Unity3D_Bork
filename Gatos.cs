using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gatos : MonoBehaviour
{
    public int vidaMaxima = 100;
    int vidaAtual;
    public bool estaZonzo = false;
    public GameObject modeloMola;
    public GameObject objetoJogadorMola;
    public Animator animagatos;
    public AudioClip slap;

    void Start()
    {
        vidaAtual = vidaMaxima;
        modeloMola.SetActive(false);
        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = slap;
    }

    void Update()
    {
        //gato.Vector3 = new Vector3(0f, -1f, 0f);
        if (estaZonzo == true)
        {
            GetComponent<GatoPercurso>().enabled = false;
        }
    }

    public void DanosSofridos(int danos)
    {
        if(vidaAtual > 10) 
        {
            vidaAtual -= danos;
            animagatos.SetTrigger("Knockback");
            GetComponent<AudioSource>().Play();
        }

        else if (vidaAtual <= 10)
        {
            estaZonzo = true;
            Debug.Log("Usa a mola agora!");
            animagatos.SetTrigger("Atordoado");
        }
    }

    public void Zonzo()
    {
        if (objetoJogadorMola.activeSelf)
        {
            modeloMola.SetActive(true);
        }
    }
}
