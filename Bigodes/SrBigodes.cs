using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SrBigodes : MonoBehaviour
{
    public int vidaTotal = 200;
    public int vidaAtual;
    public Vida vida;

    /*static bool holograma1;
    static bool holograma2;
    static bool videosecreto;

    public GameObject videoA;
    public GameObject videoB;*/

    public AudioClip slap;

    // Start is called before the first frame update
    void Start()
    {
        vidaAtual = vidaTotal;
        vida.DefinirHPMaxima(vidaTotal);

        /*holograma1 = false;
        holograma2 = false;
        videosecreto = false;*/

        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = slap;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (vidaAtual <= 0)
        {
            Debug.Log("Bigodes has morrido");
            videoB.SetActive(true);
            Debug.Log("Quédobidio?");
        }*/
    
    }

    public void SofreDanos(int danos)
    {
        if (vidaAtual > 0)
        {
            vidaAtual -= danos;

            vida.DefinirHP(vidaAtual);

            GetComponent<AudioSource>().Play();
        }
        /*if (vidaAtual <= 60)
        {
            GetComponentInParent<Animator>().SetBool("Irritado", true);
        }*/
        if (vidaAtual <= 0)
        {
            Debug.Log("Bigodes has morrido");
            FindObjectOfType<VideoManager>().Final();
        }
    }
}

