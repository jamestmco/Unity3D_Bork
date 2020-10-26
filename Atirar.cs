using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atirar : MonoBehaviour
{
    List<GameObject> catNipLista = new List<GameObject>();

    public Transform pontoOrigem;
    public GameObject catnip;
    public float alcance = 30f;
    
    public int catNipMax = 5;

    public float tempoEspera = 0;
    public float tempoAtira = 1;

    public void Start()
    {

    }

    public void FixedUpdate()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Arremessar();
        } 
    }

    public void Arremessar()
    {
        if(catNipLista.Count < 5) {
            StartCoroutine(Espera());
            GameObject instanciaCatNip = Instantiate(catnip, pontoOrigem.position, pontoOrigem.rotation);
            instanciaCatNip.GetComponent<Rigidbody>().AddForce(pontoOrigem.forward * alcance, ForceMode.Impulse);
            catNipLista.Add(catnip);
            Debug.Log("Instanciado");
        }
        else
        {
            Debug.Log("Já não tens catnip, mano!");
        }
    }

    IEnumerator Espera()
    {
        yield return new WaitForSeconds(0.5f);
    }
}
