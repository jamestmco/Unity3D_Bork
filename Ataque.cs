using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataque : MonoBehaviour
{
    public Animator animador;
    public Transform objetoAlcance;
    public float alcance = 0.5f;
    public LayerMask inimigosLayer;
    public LayerMask bossLayer;

    public int danosLigeiroGatos = 15;
    public int danosForteGatos = 25;
    //public Animator animagatos;

    public int danosLigeiroBigodes = 5;
    public int danosFortesBigodes = 15;

    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            AtaqueLigeiro();
        }
        else if (Input.GetButtonDown("Fire2"))
        {
            AtaqueForte();
        }
    }

    void AtaqueLigeiro()
    {
        animador.SetTrigger("AtaqueLigeiro");

        Collider[] atingirInimigo = Physics.OverlapSphere(objetoAlcance.position, alcance, inimigosLayer);
        Collider[] atingirBoss = Physics.OverlapSphere(objetoAlcance.position, alcance, bossLayer);

        foreach(Collider inimigo in atingirInimigo)
        {
            inimigo.GetComponent<Gatos>().DanosSofridos(danosLigeiroGatos);
            //animagatos.SetTrigger("Knockback");
        }

        foreach(Collider boss in atingirBoss)
        {
            boss.GetComponent<SrBigodes>().SofreDanos(danosLigeiroBigodes);
        }
    }

    public void AtaqueForte()
    {
        animador.SetTrigger("AtaqueForte");

        Collider[] atingirInimigo = Physics.OverlapSphere(objetoAlcance.position, alcance, inimigosLayer);
        Collider[] atingirBoss = Physics.OverlapSphere(objetoAlcance.position, alcance, bossLayer);

        foreach (Collider inimigo in atingirInimigo)
        {
            inimigo.GetComponent<Gatos>().DanosSofridos(danosForteGatos);
            //animagatos.SetTrigger("Knockback");
        }

        foreach (Collider boss in atingirBoss)
        {
            boss.GetComponent<SrBigodes>().SofreDanos(danosFortesBigodes);
        }
    }
/*
    void OnDrawGizmosSelected()
    {
        if (objetoAlcance == null)
            return;
        Gizmos.DrawWireSphere(objetoAlcance.position, alcance);
    }
*/
}
