using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatNip : MonoBehaviour
{  
    private Transform catnip;
    private float distancia;
    public Animator animagatos;
    public Gatos referencia;

    public bool oohCatnip;

    void Start()
    {

    }

    void FixedUpdate()
    {
        catnip = GameObject.FindGameObjectWithTag("CatNip").transform;

        Vector3 direcaoAlvo = catnip.position - transform.position;
        float anguloGatoCatnip = (Vector3.Angle(direcaoAlvo, transform.forward));

        if (anguloGatoCatnip >= -80 && anguloGatoCatnip <= 80 && catnip.position.y < transform.position.y)
        {
            Debug.Log("Catnip! Catnip! Catnip!");
            oohCatnip = true;
        }

        distancia = Vector3.Distance(catnip.position, transform.position);

        if (distancia < 20 && distancia > 2 && oohCatnip)
        {
            SeguirCatnip();
        }
        if(distancia <= 2 && oohCatnip)
        {
            Brincar();
        }
    }

    void SeguirCatnip()
    {
        if (referencia.estaZonzo == false)
        {
            AtrasDoCatNip();
            if (distancia <= 2f)
            {
                animagatos.ResetTrigger("Catwalk");
            }
        }
    }

    void AtrasDoCatNip()
    {
        if (referencia.estaZonzo == false)
        {
        transform.LookAt(catnip);
        animagatos.SetTrigger("Catwalk");
        transform.Translate(0f, 0f, 5f * Time.deltaTime);
        }

    }

    void Brincar()
    {
        if (referencia.estaZonzo == false)
        {
            transform.LookAt(catnip);
            animagatos.SetTrigger("CatNip");
        }
        else
        {
            animagatos.ResetTrigger("CatNip");
        }
    }
}
