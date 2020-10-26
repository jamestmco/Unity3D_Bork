using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mola : MonoBehaviour
{
    //public Gatos refereGato;
    public AudioClip spring;

    public Transform objetoAlcance;
    public float alcance = 1f;
    public LayerMask inimigosLayer;

    void Start()
    {
        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = spring;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            /*
                refereGato.Zonzo();
                GetComponent<AudioSource>().Play();
            }*/
            Amolar();
        }
    }

    void Amolar()
    {
        Collider[] amolarInimigo = Physics.OverlapSphere(objetoAlcance.position, alcance, inimigosLayer);

        foreach (Collider inimigo in amolarInimigo)
        {
            if (inimigo.GetComponent<Gatos>().estaZonzo == true)
            {
                Debug.Log("Está zonzo!");
                inimigo.GetComponent<Gatos>().Zonzo();
                Debug.Log("Mola usada");
                GetComponent<AudioSource>().Play();
            }
        }
    }
}
