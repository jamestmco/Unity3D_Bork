using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private Transform jogador;
    public int danosLigeiro = 5;
    public int danosForte = 10;
    public LayerMask jogadorLayer; 
    public Transform alcanceLigeiro;
    public Transform alcanceForte;
    public float alcance = 3f;
    //public float alcanceF = 6f;
    public int danosSonico = 10;

    public void AtaqueLigeiro()
    {
        Collider[] bigodesAtacaLeve = Physics.OverlapSphere(alcanceLigeiro.position, alcance, jogadorLayer);
        Debug.Log("Dammit");
        foreach (Collider jogador in bigodesAtacaLeve)
        {
            if (jogador != null)
            {
                jogador.GetComponent<EditeVida>().SofreDanos(danosLigeiro);
            }
        }
    }

    public void AtaqueForte()
    {
        Collider[] bigodesAtacaForte = Physics.OverlapSphere(alcanceForte.position, alcance, jogadorLayer);
        Debug.Log("Dammit2");
        foreach (Collider jogador in bigodesAtacaForte)
        {
            if (jogador != null)
            {
                jogador.GetComponent<EditeVida>().SofreDanos(danosForte);
            }
        }
    }

    public void AtaqueSonico()
    {
        Collider[] bigodesIrritado = Physics.OverlapSphere(alcanceLigeiro.position, alcance, jogadorLayer);
        Debug.Log("Dammit3");
        foreach (Collider jogador in bigodesIrritado)
        {
            if (jogador != null)
            {
                jogador.GetComponent<EditeVida>().SofreDanos(danosSonico);
            }
        }
    }
}
