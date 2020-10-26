using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Video : MonoBehaviour
{
    public double tempo;
    public double tempoAtual;
    public GameObject canvasVideo;
    public double falta;

    void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
        tempo = gameObject.GetComponent<VideoPlayer>().clip.length;
    }

    void Update()
    {
        falta = tempo - tempoAtual;

        /*if (Input.GetButtonDown("Fire1"))
        {
            falta = 1f;
        }*/

        tempoAtual = gameObject.GetComponent<VideoPlayer>().time;
        if(/*tempo-tempoAtual*/ falta <= 2f)
        {
            //canvasVideo.SetActive(false);
            FindObjectOfType<Niveis>().CenaSeguinte();
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
