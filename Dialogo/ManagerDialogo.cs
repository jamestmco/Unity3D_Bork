using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerDialogo : MonoBehaviour
{
    //public Text textoNome;
    public Text textoDialogo;
    public Animator animacao;
    public AudioClip escrita;
    public GameObject[] objetosDialogo;
    public GameObject imagemHolograma;

    private Queue<string> frases;

    void Awake()
    {
        frases = new Queue<string>();    
    }

    public void iniciaDialogo(Dialogo dialogo)
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        animacao.SetBool("CaixaAberta", true);

        //textoNome.text = dialogo.nome;

        frases.Clear();
        foreach (string frase in dialogo.frases)
        {
            frases.Enqueue(frase);
        }
        mostraProxima();
    }

    public void mostraProxima()
    {
        if(frases.Count == 0)
        {
            fimDialogo();
            return;
        }

        string frase = frases.Dequeue();
        //textoDialogo.text = frase;
        StopAllCoroutines();
        StartCoroutine(FraseAnimacao(frase));
    }

    IEnumerator FraseAnimacao(string frase)
    {
        AudioSource som = GetComponent<AudioSource>();
        som.PlayOneShot(escrita);
        textoDialogo.text = "";
        foreach (char letra in frase.ToCharArray())
        {
            textoDialogo.text += letra;
            yield return new WaitForSeconds(0.03f);
        }
        som.Stop();
    }

    void fimDialogo()
    {
        animacao.SetBool("CaixaAberta", false);
        objetosDialogo = GameObject.FindGameObjectsWithTag("Dialogo");
        foreach( GameObject objetoDialogo in objetosDialogo)
        {
            objetoDialogo.SetActive(false);
            imagemHolograma.SetActive(false);
        }
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
 