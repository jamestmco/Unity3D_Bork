using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatoAtaque : MonoBehaviour
{
    private Transform jogador;
    private float distancia;
    public float proximidade;
    public Animator animagatos;
    public Gatos referencia;

    public int danosPorGatos = 5;
    public LayerMask jogadorLayer;
    public Transform objetoAlcance;
    public float alcance = 2f;

    private bool touTaBer = false;

    float tempoAtaque = 0;
    float ataqueSeguinte = 1;

    private Transform catNip;
    private bool oohCatnip;
    private float distanciaCatNip;

    public bool socorro = false;

    // Start is called before the first frame update
    void Start()
    {
        jogador = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //catNip = GameObject.FindGameObjectWithTag("CatNip").transform;

        distancia = Vector3.Distance(jogador.position, transform.position);
        //distanciaCatNip = Vector3.Distance(catNip.position, transform.position);

        Vector3 direcaoAlvo = jogador.position - transform.position;
        float anguloGatoJogador = (Vector3.Angle(direcaoAlvo, transform.forward));

        if (anguloGatoJogador >= -80 && anguloGatoJogador <= 80)
        {   
            Debug.Log("Cadela à vista!");
            touTaBer = true;
        }

        /*Vector3 direcaoCatnip = catNip.position - transform.position;
        float anguloGatoCatNip = (Vector3.Angle(direcaoCatnip, transform.forward));

        if (anguloGatoCatNip >= -80 && anguloGatoCatNip <= 80)
        {
            Debug.Log("Ooh, aquilo é catnip?");
            oohCatnip = true;
        }*/

        if (distancia < 20f && distancia > 1.5f && touTaBer && !oohCatnip)
        {
            GangUp();
        }
        /*else*/ if(distancia <= 2f && touTaBer && !oohCatnip)
        {
            animagatos.ResetTrigger("Catwalk");
            Atacar();
            //StartCoroutine(Atacar());
        }
        if (socorro == true) 
        {
            GatoChamadoARececao();
        }
    }

    public void GangUp()
    {
        if (referencia.estaZonzo == false)
        {
            Seguir();
            if (distancia <= 2f)
            {
                animagatos.ResetTrigger("Catwalk"); 
            }
        }
    }

    public void Seguir()
    {
        transform.LookAt(jogador);
        animagatos.SetTrigger("Catwalk");
        transform.Translate(0f, 0f, 5f * Time.deltaTime);
    }

    public void Atacar()
    {
        if (tempoAtaque <= 0 && GetComponent<Gatos>().estaZonzo == false)
        {
            Debug.Log("Damage");

            tempoAtaque = ataqueSeguinte;
            transform.LookAt(jogador);
            animagatos.SetTrigger("CatPunch");

            Collider[] gatoAtingeEdite = Physics.OverlapSphere(objetoAlcance.position, alcance, jogadorLayer);

            foreach (Collider jogador in gatoAtingeEdite)
            {
                Debug.Log("Hit! Hit! Hit!");
                jogador.GetComponent<EditeVida>().SofreDanos(danosPorGatos);
            }
        }
        else
        {
            tempoAtaque -= Time.deltaTime;
        }
    }

    public void GatoChamadoARececao()
    {
        if (distancia > 1.5f && referencia.estaZonzo == false)
        {
            transform.LookAt(jogador);
            animagatos.SetTrigger("Catwalk");
            transform.Translate(0f, 0f, 5f * Time.deltaTime);
            if (distancia <= 1.5f)
            {
                animagatos.ResetTrigger("Catwalk");
                if (tempoAtaque <= 0 && referencia.estaZonzo == false)
                {
                    Debug.Log("Damage");

                    tempoAtaque = ataqueSeguinte;
                    transform.LookAt(jogador);
                    animagatos.SetTrigger("CatPunch");

                    Collider[] gatoAtingeEdite = Physics.OverlapSphere(objetoAlcance.position, alcance, jogadorLayer);

                    foreach (Collider jogador in gatoAtingeEdite)
                    {
                        Debug.Log("Hit! Hit! Hit!");
                        jogador.GetComponent<EditeVida>().SofreDanos(danosPorGatos);
                    }
                }
                else
                {
                    tempoAtaque -= Time.deltaTime;
                }
            }
        }
    }
}
