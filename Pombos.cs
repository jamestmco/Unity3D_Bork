using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pombos : MonoBehaviour
{
    public float distancia;
    public float alcance = 50f;

    public bool avistei;
    public AudioClip coocacho;
    private AudioSource som;

    //public Alt ajuda;

    void Start()
    {
        avistei = false;
        som = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //vai desenhar a linha em direção ao inimigo
        Physics.Raycast(transform.position, transform.forward, out RaycastHit hitInfo, alcance);

        if (avistei == false)
        {
            NaoVejoNada();
        }

        else if (avistei == true)
        {
            AvisteiteEdite();
        }

        if (hitInfo.collider.CompareTag("Player"))
        {
            avistei = true;
        }
    }

    void NaoVejoNada()
    {
        //faz rotação de 45º para cada lado 
        transform.rotation = Quaternion.Euler(45, Mathf.Sin(Time.realtimeSinceStartup * 0.3f) * 45, 0);
        Physics.Raycast(transform.position, transform.forward, out RaycastHit hitInfo, alcance);
        //desenha a linha verde para detetar o inimigo 
        Debug.DrawLine(transform.position, hitInfo.point, Color.green);
    }

    void AvisteiteEdite()
    {
        transform.rotation = Quaternion.Euler(45, 0, 0);
        Physics.Raycast(transform.position, transform.forward, out RaycastHit hitInfo, alcance);
        Debug.DrawLine(transform.position, hitInfo.point, Color.red);
        if (!som.isPlaying)
        {
            som.clip = coocacho;
            som.Play();
        }

        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            GameObject[] gatos = GameObject.FindGameObjectsWithTag("Gato");
            foreach (GameObject gato in gatos)
            {
                gato.GetComponent<GatoAtaque>().socorro = true;
            }
        }

        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            GameObject[] gatos = GameObject.FindGameObjectsWithTag("Gato");
            foreach (GameObject gato in gatos)
            {
                gato.GetComponent<Alt>().socorro = true;
            }
        }
    }
}  

