using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Holograma : MonoBehaviour
{
    public GameObject dialogoHolograma;
    public GameObject imagemHolograma;
    private Transform jogador;
    public Transform bork;
    private bool visto;
    public bool holo1;
    public bool holo2;


    // Start is called before the first frame update
    void Start()
    {
        jogador = GameObject.FindGameObjectWithTag("Player").transform;
        visto = false;
        holo1 = false;
        holo2 = false;

        if (dialogoHolograma.activeInHierarchy)
        {
            dialogoHolograma.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider colisao)
    {
        /*if (visto == false)
        {
            visto = true;
        }*/

        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            //holo1 = true;
            FindObjectOfType<VideoManager>().holograma1 = true;
        }
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            //holo2 = true;
            FindObjectOfType<VideoManager>().holograma2 = true;
        }

        if (dialogoHolograma.activeInHierarchy==false && imagemHolograma != null)
        dialogoHolograma.SetActive(true);
        imagemHolograma.SetActive(true);
    }

    void OnTriggerExit(Collider colisao)
    {
        if (visto == true)
        {
            if(SceneManager.GetActiveScene().buildIndex == 2)
            {
                holo1 = true;
            }
            if(SceneManager.GetActiveScene().buildIndex == 3)
            {
                holo2 = true;
            }
            Destroy(dialogoHolograma);
            Destroy(imagemHolograma);
        }
    }

    // Update is called once per frame
    void Update()
    {
        bork.transform.LookAt(jogador);
    }
}
